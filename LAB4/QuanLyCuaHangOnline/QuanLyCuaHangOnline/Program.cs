using System;
using System.Windows.Forms;

namespace QuanLyCuaHangOnline
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                var app = new AppContext();
                using (var connection = Db.OpenConnection()) { }
                app.Products.Groups();
                Application.Run(new FrmMain(app));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở hệ thống. " + ex.Message, "e-SHOPPING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
