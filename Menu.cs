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

namespace Restaurant_Contactless_Dining_System
{
  public partial class RestaurantMenu : Form
  {
    private static bool englishLanguage = true;

    public RestaurantMenu()
    {
      InitializeComponent();
    }

    private void UpdatePanelColors(string mainColor, string accentColor, string textColor)
    {
      // make this bg to main color
      this.BackColor = ColorTranslator.FromHtml(mainColor);

      // make title to text color
      Title.ForeColor = ColorTranslator.FromHtml(textColor);

      // make StartOrder to accent color
      engStartOrder.BackColor = ColorTranslator.FromHtml(accentColor);
      arabicStartOrder.BackColor = ColorTranslator.FromHtml(accentColor);
    }

    byte[] logoBytes = null;

    private void RestaurantMenu_Load(object sender, EventArgs e)
    {
      // get branch_id from DoneSetup.txt 
      string branch_id = File.ReadAllText("DoneSetup.txt");

      // create database handler
      DatabaseHandler db = new DatabaseHandler();

      // get cmd from DatabaseHandler
      SqlCommand cmd = db.Command;

      cmd.Parameters.Clear();
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      // get restaurant_id from branch_id in branch table
      SqlDataReader reader = db.ExecuteQuery("SELECT * FROM branch WHERE branch_id = @branch_id");

      string restaurant_id = "";

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          // get restaurant_id
          restaurant_id = reader["restaurant_id"].ToString();
        }
      }
      else
      {
        // close connection
        db.CloseConnection();

        // show error message
        MessageBox.Show("Error: Cannot find restaurant_id from branch_id in branch table");

        // close application
        Application.Exit();
      }

      // close connection
      db.CloseConnection();

      cmd.Parameters.Clear();
      cmd.Parameters.AddWithValue("@restaurant_id", restaurant_id);

      // get restaurant name and logo from restaurant_info table
      SqlDataReader dr = db.ExecuteQuery("SELECT * FROM restaurant_info WHERE restaurant_id = @restaurant_id");

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          Title.Text = "WELCOME TO " + (dr["name_english"].ToString()).ToUpper() + "\nنرحب بكم في " + dr["name_arabic"].ToString();

          if (dr["logo"] != null && !Convert.IsDBNull(dr["logo"]))
          {
            logoBytes = (byte[])dr["logo"];
          }

          UpdatePanelColors(dr["main_color"].ToString(), dr["accent_color"].ToString(), dr["text_color"].ToString());
        }
      }
      else
      {
        // close connection
        db.CloseConnection();

        // show error message
        MessageBox.Show("Error: Cannot find restaurant name and logo from restaurant_info table");

        // close application
        Application.Exit();
      }

      // close connection
      db.CloseConnection();

      MemoryStream ms = new MemoryStream(logoBytes);
      Image finalImage = Image.FromStream(ms);

      LogoFrame.Image = finalImage;

      FormBorderStyle = FormBorderStyle.None;
      WindowState = FormWindowState.Maximized;
    }

    private void StartOrder_Click(object sender, EventArgs e)
    {
      menuDisplay.setLanguage(true);
      menuDisplay.Show();
    }

    private void arabicStartOrder_Click(object sender, EventArgs e)
    {
      menuDisplay.setLanguage(false);
      menuDisplay.Show();
    }
  }
}
