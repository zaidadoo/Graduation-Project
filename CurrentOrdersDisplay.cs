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
    public partial class CustomerOrdersDisplay : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=menusystem.db;Version=3");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;

        public CustomerOrdersDisplay()
        {
            InitializeComponent();
        }

        private void ordersTimer_Tick(object sender, EventArgs e)
        {
            con.Open();

            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM orders WHERE status='preparing'";

            dr = cmd.ExecuteReader();

            if (!dr.HasRows)
                OrderNumbers.Text = "None at the moment...";
            else
            {
                OrderNumbers.Text = "";
                while (dr.Read())
                {
                    OrderNumbers.Text += "#" + dr["id"].ToString() + " ";
                }
            }

            dr.Close();
            con.Close();
        }

        byte[] logoBytes = null;

        private void CustomerOrdersDisplay_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT logo FROM restaurant_info";
            dr = cmd.ExecuteReader();

            if(dr.HasRows)
            {
                while(dr.Read())
                {
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

            Timer ordersTimer = new Timer();
            ordersTimer.Interval = 5000;
            ordersTimer.Tick += new System.EventHandler(ordersTimer_Tick);
            ordersTimer.Start();

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomersOrdersDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();

                e.SuppressKeyPress = true;
            }
        }
    }
}
