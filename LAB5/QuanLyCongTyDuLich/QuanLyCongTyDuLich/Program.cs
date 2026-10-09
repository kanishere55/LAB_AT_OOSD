using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCongTyDuLich
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => MessageBox.Show("Không thực hiện được: " + e.Exception.Message,
                "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            try { using (var connection = Data.Db.OpenConnection()) { } }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL QuanLyCongTyDuLich.\nChạy Database/QuanLyCongTyDuLich.sql và kiểm tra Data Source trong App.config.\n\n" + ex.Message,
                    "Kết nối SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Run(new Forms.FrmMain());
        }
    }
}
