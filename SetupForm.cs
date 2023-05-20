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
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Restaurant_Contactless_Dining_System
{
  public partial class SetupForm : Form
  {
    public SetupForm()
    {
      InitializeComponent();
    }

    private void SetupForm_Load(object sender, EventArgs e)
    {
    }

    // function that sets colors to page
    private void SetColors()
    {
      // get colors from text box
      string mainColor = mainColorField.Text;
      string accentColor = accentColorField.Text;
      string textColor = textColorField.Text;

      // set main color to all panels on this page recursively
      try
      {
        // set mainColorBox BG
        mainColorBox.BackColor = ColorTranslator.FromHtml(mainColor);

        foreach (Control c in this.Controls)
        {
          if (c is Panel)
          {
            c.BackColor = ColorTranslator.FromHtml(mainColor);
          }
        }
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }

      // get 10 percent lighter color from accent
      Color lighterAccent = ColorTranslator.FromHtml(accentColor);
      lighterAccent = ControlPaint.Light(lighterAccent, 0.1f);

      // set accent color to all buttons on this page recursively
      try
      {
        // set accentColorBox BG
        accentColorBox.BackColor = lighterAccent;

        // set topStripPanel bg too
        topStripPanel.BackColor = ColorTranslator.FromHtml(accentColor);

        foreach (Control c in topStripPanel.Controls)
        {
          if (c is Button)
          {
            c.BackColor = lighterAccent;
            c.ForeColor = ColorTranslator.FromHtml(textColor);
          }
        }

        foreach (Control c in setupPanel.Controls)
        {
          if (c is Button)
          {
            c.BackColor = lighterAccent;
            c.ForeColor = ColorTranslator.FromHtml(textColor);
          }
        }
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }

      // set text color to all labels on this page recursively
      try
      { 
        // set textColorBox BG
        textColorBox.BackColor = ColorTranslator.FromHtml(textColor);

        foreach (Control c in setupPanel.Controls)
        {
          if (c is Label)
          {
            c.ForeColor = ColorTranslator.FromHtml(textColor);
          }
        }
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }

    bool showPWD = false;
    private void ShowPassword_Click(object sender, EventArgs e)
    {
      if (showPWD)
      {
        passwordField.UseSystemPasswordChar = true;
        ShowPassword.Text = "Show";
        showPWD = false;
      }
      else
      {
        passwordField.UseSystemPasswordChar = false;
        ShowPassword.Text = "Hide";
        showPWD = true;
      }
    }

    bool logoUploadOkay = false;
    OpenFileDialog open = new OpenFileDialog();

    private void LogoUpload_Click(object sender, EventArgs e)
    {
      // newRestaurantCheck checked
      if (!newRestaurantCheck.Checked)
      {
        MessageBox.Show("Error: Please check the box to confirm that you are a new restaurant.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

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

      // branch id empty
      if (branchIdField.Text.Equals(""))
      {
        MessageBox.Show("Error: Restaurant Name is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // if restaurant eng name empty
      if (nameEnglishField.Text.Equals(""))
      {
        MessageBox.Show("Error: Restaurant English Name is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // if restaurant arabic name empty
      if (newRestaurantCheck.Checked && nameArabicField.Text.Equals(""))
      {
        MessageBox.Show("Error: Restaurant Arabic Name is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // if table count empty
      if (numOfTablesField.Text.Equals(""))
      {
        MessageBox.Show("Error: Table Count is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // password empty
      if (passwordField.Text.Equals(""))
      {
        MessageBox.Show("Error: Password is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // if logo not uploaded
      if (newRestaurantCheck.Checked && !logoUploadOkay)
      {
        MessageBox.Show("Error: Logo not uploaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // if main color empty
      if (newRestaurantCheck.Checked && mainColorField.Text.Equals(""))
      {
        MessageBox.Show("Error: Main Color is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // if accent color empty
      if (newRestaurantCheck.Checked && accentColorField.Text.Equals(""))
      {
        MessageBox.Show("Error: Accent Color is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // if text color empty
      if (newRestaurantCheck.Checked && textColorField.Text.Equals(""))
      {
        MessageBox.Show("Error: Text Color is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // create DatabaseHandler
      DatabaseHandler db = DatabaseHandler.Instance;
      SqlDataReader reader;

      if(newRestaurantCheck.Checked)
      {
        // get cmd from database
        SqlCommand cmd = db.Command;

        // clear cmd params
        cmd.Parameters.Clear();

        // add params
        cmd.Parameters.AddWithValue("@name_english", nameEnglishField.Text);

        // check if restaurant_name exists
        reader = db.ExecuteQuery("SELECT * FROM restaurant_info WHERE name_english = @name_english");

        if (reader.HasRows)
        {
          MessageBox.Show("Error: Restaurant Name already exists, please uncheck new restaurant.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

          // close connection
          db.CloseConnection();

          return;
        }

        // close connection
        db.CloseConnection();
      }

      // get cmd from database
      SqlCommand cmd2 = db.Command;

      cmd2.Parameters.Clear();

      // add params
      cmd2.Parameters.AddWithValue("@branch_id", branchIdField.Text);

      // check if branch id already exists
      reader = db.ExecuteQuery("SELECT * FROM branch WHERE branch_id = @branch_id");

      if (reader.HasRows)
      {
        MessageBox.Show("Error: Branch ID taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // close connection
        db.CloseConnection();

        return;
      }

      // close connection
      db.CloseConnection();

      if (newRestaurantCheck.Checked)
      {
        // gather info from fields
        string nameEnglish = nameEnglishField.Text;
        string nameArabic = nameArabicField.Text;
        string mainColor = mainColorField.Text;
        string accentColor = accentColorField.Text;
        string textColor = textColorField.Text;
        byte[] image = File.ReadAllBytes(open.FileName);

        // get command from DatabaseHandler
        SqlCommand cmd = db.Command;

        // example: cmd.CommandText = "INSERT INTO menu (name, price, category, image)" + " values (@iname, @iprice, @icategory, @iimage)";
        cmd.CommandText = "INSERT INTO restaurant_info (logo, name_arabic, name_english, main_color, accent_color, text_color)" + " values (@ilogo, @iname_arabic, @iname_english, @imain_color, @iaccent_color, @itext_color)";

        // insert into restaurant_info
        cmd.Parameters.Clear();
        cmd.Parameters.Add("ilogo", SqlDbType.VarBinary).Value = image;
        cmd.Parameters.AddWithValue("iname_arabic", nameArabic);
        cmd.Parameters.AddWithValue("iname_english", nameEnglish);
        cmd.Parameters.AddWithValue("imain_color", mainColor);
        cmd.Parameters.AddWithValue("iaccent_color", accentColor);
        cmd.Parameters.AddWithValue("itext_color", textColor);

        int rowsAffected = db.ExecuteNonQuery();

        if (rowsAffected == 0) 
        { 
          MessageBox.Show("Error... Could not add restaurant information.");

          // close connection
          db.CloseConnection();

          return;
        }

        // close connection
        db.CloseConnection();
      }

      // gather info from fields
      string branchId = branchIdField.Text;
      int numOfTables = Int32.Parse(numOfTablesField.Text);

      // clear cmd params
      cmd2.Parameters.Clear();

      // add params
      cmd2.Parameters.AddWithValue("@name_english", nameEnglishField.Text);

      // get restaurant_id using name_english
      reader = db.ExecuteQuery("SELECT restaurant_id FROM restaurant_info WHERE name_english = @name_english");

      if (!reader.HasRows)
      {
        MessageBox.Show("Error: Restaurant Name does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // close connection
        db.CloseConnection();

        return;
      }

      reader.Read();
      int restaurantId = reader.GetInt32(0);

      // close connection
      db.CloseConnection();

      // clear cmd params
      cmd2.Parameters.Clear();

      cmd2.CommandText = "INSERT INTO branch (branch_id, restaurant_id, number_of_tables)" + " values (@ibranch_id, @irestaurant_id, @inum_of_tables)";

      cmd2.Parameters.Clear();
      cmd2.Parameters.AddWithValue("ibranch_id", branchId);
      cmd2.Parameters.AddWithValue("irestaurant_id", restaurantId);
      cmd2.Parameters.AddWithValue("inum_of_tables", numOfTables);

      int rowsAffected2 = db.ExecuteNonQuery();

      if (rowsAffected2 == 0)
      {
        MessageBox.Show("Error... Could not add new branch.");

        // close connection
        db.CloseConnection();

        return;
      }

      // gather info from fields
      string password = passwordField.Text;

      // hash password with sha 512
      SHA512 sha512 = SHA512.Create();
      byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(passwordField.Text));
      string hashedPassword = BitConverter.ToString(bytes).Replace("-", "").ToLower();

      // get command from DatabaseHandler
      SqlCommand cmd3 = db.Command;

      cmd3.CommandText = "INSERT INTO users (branch_id, password)" + " values (@ibranch_id, @ipassword)";

      cmd3.Parameters.Clear();
      cmd3.Parameters.AddWithValue("ibranch_id", branchId);
      cmd3.Parameters.AddWithValue("ipassword", hashedPassword);

      int rowsAffected3 = db.ExecuteNonQuery();

      if (rowsAffected3 == 0)
      {
        MessageBox.Show("Error... Could not add new user.");

        // close connection
        db.CloseConnection();

        return;
      }
      else
      {
        Form changeForm = new SetupChoice();
        this.Hide();
        changeForm.ShowDialog();
        Application.Exit();
      }
    }

    private void mainColorField_TextChanged(object sender, EventArgs e)
    {
      SetColors();
    }

    private void accentColorField_TextChanged(object sender, EventArgs e)
    {
      SetColors();
    }

    private void textColorField_TextChanged(object sender, EventArgs e)
    {
      SetColors();
    }

    private void newRestaurantCheck_CheckedChanged(object sender, EventArgs e)
    {
      // if unchecked then disable name in arabic and english fields
      if (!newRestaurantCheck.Checked)
      {
        nameArabicField.Enabled = false;
        mainColorField.Enabled = false;
        accentColorField.Enabled = false;
        textColorField.Enabled = false;
      }
      else
      {
        nameArabicField.Enabled = true;
        mainColorField.Enabled = true;
        accentColorField.Enabled = true;
        textColorField.Enabled = true;
      }
    }
  }
}
