using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Restaurant_Contactless_Dining_System
{
    public partial class RestaurantMenu : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=menusystem.db;Version=3");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;

        public RestaurantMenu()
        {
            InitializeComponent();
        }

        byte[] logoBytes = null;

        private void RestaurantMenu_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM restaurant_info";
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Title.Text = "WELCOME TO " + (dr["name"].ToString()).ToUpper();
                    if (dr["logo"] != null && !Convert.IsDBNull(dr["logo"]))
                    {
                        logoBytes = (byte[])dr["logo"];
                    }
                }
            }

            dr.Close();
            con.Close();

            MemoryStream ms = new MemoryStream(logoBytes);
            Image finalImage = Image.FromStream(ms);

            LogoFrame.Image = finalImage;


            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void StartOrder_Click(object sender, EventArgs e)
        {
            menuDisplay.Show();
        }
    }
}
