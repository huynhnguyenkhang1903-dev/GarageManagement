using Project_GarageManagement.Enities.Login;
using Project_GarageManagement.FormCongViec;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using WinFormsApp = System.Windows.Forms.Application;


namespace Project_GarageManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WinFormsApp.EnableVisualStyles();
            WinFormsApp.SetCompatibleTextRenderingDefault(false);
            WinFormsApp.Run(new frmlogin());
        }

        private static bool Connection()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["GarageManagementEntities"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open(); 
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối SQL Server!\n" + ex.Message,
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
