using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Restaurant_Contactless_Dining_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SqlConnection con = new SqlConnection("Server=tcp:kioskjo.database.windows.net;Database=kioskjodb;User ID=kioskjo;Password=sMJJeL8GJ5vNHYY;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM restaurant_info";
            dr = cmd.ExecuteReader();

            

            if (!dr.HasRows)
            {
                con.Close();
                Application.Run(new SetupForm());
            }
            else
            {
                con.Close();
                Application.Run(new MainMenu());
            }

        }
    }
}
