using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using QuanLyHoSoBenhAn.Data;
using QuanLyHoSoBenhAn.Services;

internal static class BusinessChecks
{
    static readonly HoSoService S = new HoSoService();
    static readonly string RunId = Guid.NewGuid().ToString("N").Substring(0, 8);
    static readonly List<string> Lines = new List<string>
    {
        "Ma,NoiDung,KetQua"
    };
    static int passed, failed;
    static string Id(string s)
    {
        return s + "_" + RunId;
    }

    static void Assert(bool condition, string message)
    {
        if (!condition)
            throw new Exception(message);
    }

    static int Count(string table, string field, string value)
    {
        // table/field are constants in this harness.
        return Convert.ToInt32(Db.Query("SELECT COUNT(*) FROM " + table + " WHERE " + field + "=@m", Db.P("m", value)).Rows[0][0]);
    }

    static void Check(string id, string title, Action work)
    {
        try
        {
            work();
            passed++;
            Lines.Add(id + ",\"" + title + "\",PASS");
            Console.WriteLine("PASS " + id + " " + title);
        }
        catch (Exception e)
        {
            failed++;
            Lines.Add(id + ",\"" + title + "\",FAIL");
            Console.WriteLine("FAIL " + id + " " + e.Message);
        }
    }

    static void Reject(Action work, int expected = 0)
    {
        try
        {
            work();
        }
        catch (SqlException e)
        {
            if (expected != 0 && e.Number != expected)
                throw new Exception("Sai lỗi SQL: " + e.Number + ", mong đợi " + expected);
            return;
        }
        catch (ArgumentException)
        {
            if (expected == 0)
                return;
            throw;
        }

        throw new Exception("Thao tác sai đã được chấp nhận.");
    }

    static BenhNhanInput Patient(string tag)
    {
        return new BenhNhanInput
        {
            Ma = Id(tag),
            HoTen = "Bệnh nhân kiểm thử",
            DiaChi = "Địa chỉ mẫu",
            DienThoai = "0900000099",
            NgaySinh = new DateTime(1990, 1, 1),
            Ngay = new DateTime(2026, 1, 1),
            SoTien = 100000,
            Anh = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+aLTkAAAAASUVORK5CYII="),
            MaDangKy = Id(tag + "D"),
            MaHoSo = Id(tag + "H"),
            MaThu = Id(tag + "L")
        };
    }

    static void Visit(string tag, string hs, DateTime date, string type = "Điều trị", string hen = null, decimal fee = 0)
    {
        S.LapPhieu(Id(tag), hs, "BS01", "K01", date, type, hen, fee);
    }

    static void Exam(string tag)
    {
        S.GhiKham(Id(tag), "Mẫu triệu chứng", 36.5m, "Mẫu", "Kết luận mẫu", "Theo dõi", "Chưa ghi nhận", "Mẫu thực hành");
    }

    static DataTable Drugs(string drug = "T01", int amount = 2)
    {
        var t = HoSoService.DongToa();
        t.Rows.Add(1, drug, amount, "Liều mẫu", "Cách dùng mẫu");
        return t;
    }

    static void Race(Action a, Action b)
    {
        int ok = 0, rejected = 0;
        Action<Action> run = work =>
        {
            try
            {
                work();
                System.Threading.Interlocked.Increment(ref ok);
            }
            catch (SqlException)
            {
                System.Threading.Interlocked.Increment(ref rejected);
            }
        };
        Task.WaitAll(Task.Run(() => run(a)), Task.Run(() => run(b)));
        Assert(ok == 1 && rejected == 1, "Hai thao tác đồng thời phải có đúng một thành công.");
    }

    static int Main(string[] args)
    {
        var connection = new SqlConnectionStringBuilder(Db.ConnectionString) { InitialCatalog = "QuanLyHoSoBenhAn_Test" };
        if (args.Length > 1) connection.DataSource = args[1];
        Db.ConnectionString = connection.ConnectionString;
        Db.Query("SELECT 1");
        var p = Patient("BN");
        var q = Patient("BQ");
        Check("T01", "Đăng ký tạo BN - phiếu đăng ký - lệ phí - hồ sơ", () =>
        {
            S.DangKy(p);
            Assert(Count("BenhNhan", "MaBenhNhan", p.Ma) == 1 && Count("PhieuDangKy", "MaBenhNhan", p.Ma) == 1 && Count("PhieuThuLePhi", "MaBenhNhan", p.Ma) == 1 && Count("HoSoBenhAn", "MaBenhNhan", p.Ma) == 1, "Thiếu bảng liên quan.");
            S.DangKy(q);
        });
        Check("T02", "Thiếu ảnh bị từ chối và không tạo bệnh nhân", () =>
        {
            var x = Patient("NoAnh");
            x.Anh = null;
            Reject(() => S.DangKy(x), 51000);
            Assert(Count("BenhNhan", "MaBenhNhan", x.Ma) == 0, "Còn bản ghi lỗi.");
        });
        Check("T03", "Lệ phí 0 không cấp hồ sơ", () =>
        {
            var x = Patient("NoPhi");
            x.SoTien = 0;
            Reject(() => S.DangKy(x), 51000);
            Assert(Count("HoSoBenhAn", "MaBenhNhan", x.Ma) == 0, "Đã cấp hồ sơ.");
        });
        Check("T04", "Ngày sinh sau ngày đăng ký bị từ chối", () =>
        {
            var x = Patient("Birth");
            x.NgaySinh = x.Ngay.AddDays(1);
            Reject(() => S.DangKy(x), 51000);
        });
        Check("T05", "Trùng mã hồ sơ hoàn tác ba bảng đã ghi trước", () =>
        {
            var x = Patient("DupHS");
            x.MaHoSo = p.MaHoSo;
            Reject(() => S.DangKy(x), 2627);
            Assert(Count("BenhNhan", "MaBenhNhan", x.Ma) + Count("PhieuDangKy", "MaBenhNhan", x.Ma) + Count("PhieuThuLePhi", "MaBenhNhan", x.Ma) == 0, "Rollback thiếu.");
        });
        Check("T06", "Trùng phiếu đăng ký hoàn tác bệnh nhân mới", () =>
        {
            var x = Patient("DupDK");
            x.MaDangKy = p.MaDangKy;
            Reject(() => S.DangKy(x), 2627);
            Assert(Count("BenhNhan", "MaBenhNhan", x.Ma) == 0, "Còn bệnh nhân mồ côi.");
        });
        Check("T07", "Thu lệ phí chồng thời hạn bị từ chối", () => Reject(() => S.ThuPhi(Id("LPdup"), p.Ma, new DateTime(2026, 12, 31), 100000), 51002));
        Check("T08", "Gia hạn đúng một năm kế tiếp", () => S.ThuPhi(Id("LPnext"), p.Ma, new DateTime(2027, 1, 1), 100000));
        Check("T09", "Tra cứu bằng mã hồ sơ và điện thoại", () => Assert(S.BenhNhan(p.MaHoSo).Rows.Count == 1 && S.BenhNhan("0900000099").Rows.Count >= 2, "Không tìm được bệnh nhân."));
        Check("T10", "Phiếu khám điều trị liên kết hồ sơ - bác sĩ - khoa", () => Visit("PK", p.MaHoSo, new DateTime(2026, 10, 1), fee: 150000));
        Check("T11", "FK chặn phiếu khám không có hồ sơ", () => Reject(() => Visit("BadFK", "KHONGTONTAI", new DateTime(2026, 10, 1)), 547));
        Check("T12", "Khám định kỳ phải miễn phí", () => Reject(() => Visit("Free", p.MaHoSo, new DateTime(2026, 10, 2), "Định kỳ", fee: 1), 547));
        Check("T13", "Khám định kỳ lần đầu trong quý phí 0", () => Visit("DQ4", p.MaHoSo, new DateTime(2026, 10, 2), "Định kỳ"));
        Check("T14", "UNIQUE chặn khám định kỳ lặp trong quý", () => Reject(() => Visit("DQdup", p.MaHoSo, new DateTime(2026, 12, 15), "Định kỳ"), 2601));
        Check("T15", "Quý tiếp theo được khám sau gia hạn", () => Visit("DQnew", p.MaHoSo, new DateTime(2027, 1, 2), "Định kỳ"));
        Check("T16", "Lệ phí hết hiệu lực không khám định kỳ", () => Reject(() => Visit("Expired", q.MaHoSo, new DateTime(2027, 1, 2), "Định kỳ"), 51007));
        Check("T17", "Đặt hẹn quý chưa sử dụng", () => S.DatHen(Id("LH"), q.MaHoSo, new DateTime(2026, 10, 20, 8, 0, 0), "Khám định kỳ"));
        Check("T18", "UNIQUE chặn hai lịch hẹn cùng quý", () => Reject(() => S.DatHen(Id("LHdup"), q.MaHoSo, new DateTime(2026, 11, 1), "Khám"), 2601));
        Check("T19", "Hủy lịch rồi đặt lại trong quý", () =>
        {
            S.SuaHen(Id("LH"), new DateTime(2026, 10, 20, 8, 0, 0), "Khám", "Đã hủy");
            S.DatHen(Id("LHnew"), q.MaHoSo, new DateTime(2026, 10, 21, 8, 0, 0), "Khám");
        });
        Check("T20", "Không dùng lịch hẹn của hồ sơ khác", () => Reject(() => Visit("WrongHS", p.MaHoSo, new DateTime(2026, 10, 21, 8, 0, 0), "Định kỳ", Id("LHnew")), 51008));
        Check("T21", "Không dùng lịch đã hủy", () => Reject(() => Visit("Cancelled", q.MaHoSo, new DateTime(2026, 10, 20, 8, 0, 0), "Định kỳ", Id("LH")), 51008));
        Check("T22", "Đã có lịch hẹn thì cần liên kết đúng mã", () => Reject(() => Visit("NoHen", q.MaHoSo, new DateTime(2026, 10, 21), "Định kỳ"), 51019));
        Check("T23", "Lập phiếu theo lịch cập nhật trạng thái cùng transaction", () =>
        {
            Visit("HenPK", q.MaHoSo, new DateTime(2026, 10, 21, 8, 0, 0), "Định kỳ", Id("LHnew"));
            Assert(Convert.ToString(Db.Query("SELECT TrangThai FROM LichHen WHERE MaHen=@m", Db.P("m", Id("LHnew"))).Rows[0][0]) == "Đã thực hiện", "Lịch chưa cập nhật.");
        });
        Check("T24", "Không tái sử dụng lịch đã thực hiện", () => Reject(() => Visit("Reuse", q.MaHoSo, new DateTime(2026, 10, 21), "Định kỳ", Id("LHnew")), 51008));
        Check("T25", "Đổi hẹn sang thời hạn hết quyền lợi bị chặn", () =>
        {
            S.DatHen(Id("LHq2"), q.MaHoSo, new DateTime(2026, 5, 1), "Khám");
            Reject(() => S.SuaHen(Id("LHq2"), new DateTime(2028, 5, 1), "Khám", "Đã hẹn"), 51006);
        });
        Check("T26", "Chưa có kết luận không được lập toa", () => Reject(() => S.LapToa(Id("NoKL"), Id("PK"), "BS01", "Mẫu", Drugs()), 51013));
        Check("T27", "Ghi triệu chứng kết luận và theo dõi", () => Exam("PK"));
        Check("T28", "Toa không có dòng thuốc bị từ chối", () => Reject(() => S.LapToa(Id("Empty"), Id("PK"), "BS01", "", HoSoService.DongToa()), 51015));
        Check("T29", "Bác sĩ kê phải đúng bác sĩ phiếu khám", () => Reject(() => S.LapToa(Id("WrongBS"), Id("PK"), "BS02", "", Drugs()), 51013));
        Check("T30", "Chỉ định gắn đúng phiếu khám", () => S.ChiDinh(Id("CD"), Id("PK"), "XN01", new DateTime(2026, 10, 1, 8, 0, 0)));
        Check("T31", "Còn xét nghiệm chờ thì chưa lập toa", () => Reject(() => S.LapToa(Id("WaitXN"), Id("PK"), "BS01", "", Drugs()), 51014));
        Check("T32", "Ngày trả kết quả không trước chỉ định", () => Reject(() => S.KetQua(Id("CD"), new DateTime(2026, 9, 1), "Kết quả mẫu"), 547));
        Check("T33", "Ghi kết quả hợp lệ", () => S.KetQua(Id("CD"), new DateTime(2026, 10, 1, 9, 0, 0), "Kết quả mẫu"));
        Check("T34", "Thuốc không tồn tại hoàn tác toa cha", () =>
        {
            Reject(() => S.LapToa(Id("BadDrug"), Id("PK"), "BS01", "", Drugs("KHONGTONTAI")), 547);
            Assert(Count("ToaThuoc", "MaToa", Id("BadDrug")) == 0, "Còn toa rỗng.");
        });
        Check("T35", "Số lượng 0 hoàn tác toa và chi tiết", () =>
        {
            Reject(() => S.LapToa(Id("BadQty"), Id("PK"), "BS01", "", Drugs(amount: 0)), 547);
            Assert(Count("ToaThuoc", "MaToa", Id("BadQty")) == 0, "Còn toa lỗi.");
        });
        Check("T36", "Lưu thành công toa có hai chi tiết", () =>
        {
            var t = Drugs();
            t.Rows.Add(2, "T02", 3, "Liều mẫu 2", "Cách dùng mẫu 2");
            S.LapToa(Id("TOA"), Id("PK"), "BS01", "Lời dặn mẫu", t);
            Assert(Count("ChiTietToaThuoc", "MaToa", Id("TOA")) == 2, "Thiếu chi tiết.");
        });
        Check("T37", "Mỗi phiếu có tối đa một toa", () => Reject(() => S.LapToa(Id("DupToa"), Id("PK"), "BS01", "", Drugs()), 2627));
        Check("T38", "Xuất toa có tên thuốc và đủ chi tiết", () => Assert(S.XuatToa(Id("TOA")).Contains("Thuốc mẫu A") && S.ChiTietToa(Id("TOA")).Rows.Count == 2, "Xuất toa thiếu dữ liệu."));
        Check("T39", "Chưa xuất viện chưa thanh toán không hoàn tất", () => Reject(() => S.HoanTat(Id("PK")), 51017));
        Check("T40", "Chỉ xuất viện chưa thanh toán không hoàn tất", () =>
        {
            S.ThuTuc(Id("PK"), true, false);
            Reject(() => S.HoanTat(Id("PK")), 51017);
        });
        Check("T41", "Đủ thủ tục mới hoàn tất và ghi lịch sử", () =>
        {
            S.ThuTuc(Id("PK"), true, true);
            S.HoanTat(Id("PK"));
            Assert(Convert.ToBoolean(S.ChiTietKham(Id("PK")).Rows[0]["DaHoanTat"]), "Chưa hoàn tất.");
        });
        Check("T42", "Không sửa lâm sàng sau hoàn tất", () => Reject(() => Exam("PK"), 51010));
        Check("T43", "Không thêm xét nghiệm sau hoàn tất", () => Reject(() => S.ChiDinh(Id("PostXN"), Id("PK"), "XN01", DateTime.Now), 51011));
        Check("T44", "Tra cứu lịch sử phân biệt đợt hoàn tất", () => Assert(S.LichSu(p.MaHoSo).Select("[Trạng thái]='Đã ghi nhận lịch sử'").Length == 1, "Sai trạng thái lịch sử."));
        Check("T45", "Khám định kỳ không phát hiện bệnh có thể không có toa", () =>
        {
            Exam("DQ4");
            S.ThuTuc(Id("DQ4"), true, true);
            S.HoanTat(Id("DQ4"));
            Assert(Count("ToaThuoc", "MaPhieuKham", Id("DQ4")) == 0, "Tạo toa không cần thiết.");
        });
        Check("T46", "Hai lần gia hạn đồng thời không chồng thời hạn", () => Race(() => S.ThuPhi(Id("RaceL1"), q.Ma, new DateTime(2027, 1, 1), 100000), () => S.ThuPhi(Id("RaceL2"), q.Ma, new DateTime(2027, 1, 1), 100000)));
        Check("T47", "Hai lịch hẹn đồng thời cùng quý chỉ nhận một", () => Race(() => S.DatHen(Id("RaceH1"), q.MaHoSo, new DateTime(2027, 4, 1), "Khám"), () => S.DatHen(Id("RaceH2"), q.MaHoSo, new DateTime(2027, 4, 2), "Khám")));
        Check("T48", "CHECK chặn kết quả đã hoàn thành nhưng NULL", () => Reject(() => Db.Execute("UPDATE ChiDinhXetNghiem SET KetQua=NULL WHERE MaChiDinh=@m", Db.P("m", Id("CD"))), 547));
        Check("T49", "Không hoàn tất nếu còn xét nghiệm chờ", () =>
        {
            Visit("WaitEnd", p.MaHoSo, new DateTime(2026, 10, 3));
            Exam("WaitEnd");
            S.ChiDinh(Id("WaitCd"), Id("WaitEnd"), "XN01", new DateTime(2026, 10, 3));
            S.ThuTuc(Id("WaitEnd"), true, true);
            Reject(() => S.HoanTat(Id("WaitEnd")), 51018);
        });
        Check("T50", "Lập phiếu lỗi FK không đổi trạng thái lịch hẹn", () =>
        {
            S.DatHen(Id("AtomicH"), p.MaHoSo, new DateTime(2027, 7, 5), "Khám");
            Reject(() => S.LapPhieu(Id("AtomicP"), p.MaHoSo, "BS-SAI", "K01", new DateTime(2027, 7, 5), "Định kỳ", Id("AtomicH"), 0), 547);
            Assert(Convert.ToString(Db.Query("SELECT TrangThai FROM LichHen WHERE MaHen=@m", Db.P("m", Id("AtomicH"))).Rows[0][0]) == "Đã hẹn", "Lịch bị đổi khi lập phiếu lỗi.");
        });
        string output = args.Length > 0 ? args[0] : "BusinessResults.csv";
        File.WriteAllLines(output, Lines, System.Text.Encoding.UTF8);
        Console.WriteLine("TOTAL " + passed + " PASS, " + failed + " FAIL");
        return failed == 0 ? 0 : 1;
    }
}
