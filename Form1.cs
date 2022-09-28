using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace Restaurant_Contactless_Dining_System
{
    public partial class SetupForm : Form
    {
        SQLiteConnection con = new SQLiteConnection("Data Source=menusystem.db;Version=3");
        SQLiteCommand cmd = new SQLiteCommand();

        public SetupForm()
        {
            InitializeComponent();
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
        }

        bool showPWD = false;
        private void ShowPassword_Click(object sender, EventArgs e)
        {
            if(showPWD)
            {
                Password.UseSystemPasswordChar = true;
                ShowPassword.Text = "Show";
                showPWD = false;
            }
            else
            {
                Password.UseSystemPasswordChar = false;
                ShowPassword.Text = "Hide";
                showPWD = true;
            }
        }

        bool logoUploadOkay = false;
        OpenFileDialog open = new OpenFileDialog();

        private void LogoUpload_Click(object sender, EventArgs e)
        {
            open.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif)|*.png; *.jpg; *.jpeg; *.gif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                LogoUpload.Image = new Bitmap(open.FileName);

                logoUploadOkay = true;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SubmitPassword_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to submit details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;

            if(RestauranName.Text.Equals("") || Password.Text.Equals(""))
            {
                MessageBox.Show("Error: Restaurant Name or Password field is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!logoUploadOkay)
            {
                MessageBox.Show("Error: Logo not uploaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO restaurant_info (name, logo, password)" + " values (@iname, @ilogo, @ipassword)";

            byte[] image = File.ReadAllBytes(open.FileName);

            cmd.Parameters.AddWithValue("iname", RestauranName.Text);
            cmd.Parameters.Add("ilogo", DbType.Binary, 20).Value = image;
            cmd.Parameters.AddWithValue("ipassword", Password.Text);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 0)
                MessageBox.Show("Error... Record not added.");
            else
            {
                Form changeForm = new MainMenu();
                this.Hide();
                changeForm.ShowDialog();
                Application.Exit();
            }

            con.Close();
        }
    }
}
