using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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

            SQLiteConnection con = new SQLiteConnection("Data Source=menusystem.db;Version=3");
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader dr;

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
