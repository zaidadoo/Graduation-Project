using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Restaurant_Contactless_Dining_System
{
  public partial class SetupChoice : Form
  {
    public SetupChoice()
    {
      InitializeComponent();
    }

    private void loginButton_Click(object sender, EventArgs e)
    {
      // check if branch_id and password fields are empty
      if (branchField.Text.Equals("") || passwordField.Text.Equals(""))
      {
        MessageBox.Show("Please fill in all fields!");
        return;
      }

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from DatabaseHandler
      SqlCommand cmd = db.Command;

      // check if branch_id exists
      SqlDataReader reader;

      // add parameters
      cmd.Parameters.Clear();
      cmd.Parameters.AddWithValue("@branch_id", branchField.Text);

      reader = db.ExecuteQuery("SELECT * FROM branch WHERE branch_id = @branch_id");

      if (!reader.HasRows)
      {
        MessageBox.Show("Branch ID does not exist!");

        // close database connection
        db.CloseConnection();

        return;
      }

      // close database connection
      db.CloseConnection();

      // check if branch_id password is correct
      // hash password with sha 512
      SHA512 sha512 = SHA512.Create();
      byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(passwordField.Text));
      string hashedPassword = BitConverter.ToString(bytes).Replace("-", "").ToLower();

      // get cmd from DatabaseHandler
      cmd = db.Command;

      // add parameters
      cmd.Parameters.Clear();
      cmd.Parameters.AddWithValue("@branch_id", branchField.Text);
      cmd.Parameters.AddWithValue("@password", hashedPassword);

      reader = db.ExecuteQuery("SELECT * FROM users WHERE branch_id = @branch_id AND password = @password");

      if (reader.HasRows)
      {
        // write branch_id to DoneSetup.txt
        System.IO.File.WriteAllText("DoneSetup.txt", branchField.Text);

        // close database connection
        db.CloseConnection();

        // show MainMenu form
        Form changeForm = new MainMenu();
        this.Hide();

        changeForm.ShowDialog();
      }
      else
      {
        // show error message
        MessageBox.Show("Incorrect password!");

        // close connection
        db.CloseConnection();

        return;
      }
    }

    private void setupButton_Click(object sender, EventArgs e)
    {
      // show SetupForm
      Form changeForm = new SetupForm();
      this.Hide();

      changeForm.ShowDialog();
    }
  }
}
