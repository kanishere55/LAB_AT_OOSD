using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyHoSoBenhAn.Data
{
    public static class Db
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
        public static SqlParameter P(string key, object value)
        {
            return new SqlParameter("@" + key, value ?? DBNull.Value);
        }

        public static DataTable Query(string sql, params SqlParameter[] args)
        {
            using (var c = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, c))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(args);
                var t = new DataTable();
                da.Fill(t);
                return t;
            }
        }

        public static int Execute(string sql, params SqlParameter[] args)
        {
            using (var c = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, c))
            {
                cmd.Parameters.AddRange(args);
                c.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static void Procedure(string name, params SqlParameter[] args)
        {
            using (var c = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(name, c))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(args);
                c.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static string Friendly(Exception e)
        {
            var x = e as SqlException;
            if (x != null)
            {
                if (x.Number == 2601 || x.Number == 2627)
                    return "Mã đã tồn tại hoặc quyền khám/lịch hẹn trong quý đã được sử dụng.";
                if (x.Number == 547)
                    return "Dữ liệu vi phạm liên kết hoặc điều kiện: kiểm tra mã tham chiếu, số lượng, liều dùng, ngày và lệ phí.";
            }

            return e.Message;
        }
    }
}
