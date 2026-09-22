using System;
using System.Windows.Forms;
using QuanLyThuVien.Forms;
namespace QuanLyThuVien
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
