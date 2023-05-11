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
    public RestaurantMenu()
    {
      InitializeComponent();
    }

    byte[] logoBytes = null;

    private void RestaurantMenu_Load(object sender, EventArgs e)
    {
      // get branch_id from DoneSetup.txt 
      string branch_id = File.ReadAllText("DoneSetup.txt");

      // create database handler
      DatabaseHandler db = new DatabaseHandler();

      // get restaurant_id from branch_id in branch table
      SqlDataReader reader = db.ExecuteQuery("SELECT restaurant_id FROM branch WHERE branch_id = \'" + branch_id + "\'");

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

      // get restaurant name and logo from restaurant_info table
      SqlDataReader dr = db.ExecuteQuery("SELECT * FROM restaurant_info WHERE restaurant_id = \'" + restaurant_id + "\'");

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          Title.Text = "WELCOME TO " + (dr["name_english"].ToString()).ToUpper();
          if (dr["logo"] != null && !Convert.IsDBNull(dr["logo"]))
          {
            logoBytes = (byte[])dr["logo"];
          }
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
      menuDisplay.Show();
    }
  }
}
