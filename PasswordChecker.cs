using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Restaurant_Contactless_Dining_System
{
  public partial class PasswordChecker : Form
  {
    private string branch_id;

    public PasswordChecker()
    {
      InitializeComponent();
    }

    private void SubmitPassword_Click(object sender, EventArgs e)
    {
      // check if password is empty
      if (Password.Text.Equals(""))
      {
        MessageBox.Show("Please enter a password.", "Password Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // create databse handler
      DatabaseHandler db = DatabaseHandler.Instance;

      // hash password with sha 512
      SHA512 sha512 = SHA512.Create();
      byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(Password.Text));
      string hashedPassword = BitConverter.ToString(bytes).Replace("-", "").ToLower();

      // get cmd from DatabaseHandler
      SqlCommand cmd = db.Command;

      // select branch_id and password from users
      cmd.Parameters.Clear();
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      SqlDataReader dr = db.ExecuteQuery("SELECT branch_id, password FROM users WHERE branch_id = @branch_id");

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          if (dr["password"].Equals(hashedPassword))
          {
            this.DialogResult = DialogResult.Yes;
            this.Close();
          }
          else
          {
            MessageBox.Show("Wrong password, please try again.", "Password Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }

      dr.Close();
      
      // close database connection
      db.CloseConnection();
    }

    private void Password_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        SubmitPassword_Click(this, new EventArgs());
      }
    }

    private void PasswordChecker_Load(object sender, EventArgs e)
    {
      // read from DoneSetup.txt branch_id
      branch_id = System.IO.File.ReadAllText("DoneSetup.txt");

      // set branchField to branch_id
      branchField.Text = branch_id;
    }
  }
}
