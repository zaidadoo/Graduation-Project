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

namespace Restaurant_Contactless_Dining_System
{
    public partial class PasswordChecker : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=menusystem.db;Version=3");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;

        public PasswordChecker()
        {
            InitializeComponent();
        }

        private void SubmitPassword_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT password FROM restaurant_info";
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["password"].Equals(Password.Text))
                    {
                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password, please try again.", "Password Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.No;
                        this.Close();
                    }
                }
            }

            dr.Close();
            con.Close();
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SubmitPassword_Click(this, new EventArgs());
            }
        }
    }
}
