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
  public partial class CustomerOrdersDisplay : Form
  {
    public CustomerOrdersDisplay()
    {
      InitializeComponent();
    }

    private void ordersTimer_Tick(object sender, EventArgs e)
    {
      //con.Open();

      //cmd.Connection = con;

      //cmd.CommandText = "SELECT * FROM orders WHERE status='preparing'";

      //dr = cmd.ExecuteReader();

      //if (!dr.HasRows)
      //    OrderNumbers.Text = "None at the moment...";
      //else
      //{
      //    OrderNumbers.Text = "";
      //    while (dr.Read())
      //    {
      //        OrderNumbers.Text += "#" + dr["id"].ToString() + " ";
      //    }
      //}

      //dr.Close();
      //con.Close();
    }

    byte[] logoBytes = null;

    private void CustomerOrdersDisplay_Load(object sender, EventArgs e)
    {
      FormBorderStyle = FormBorderStyle.None;
      WindowState = FormWindowState.Maximized;

      // create a databasehandler
      DatabaseHandler db = new DatabaseHandler();

      // get branch_id from DoneSetup.txt
      string branch_id = File.ReadAllText("DoneSetup.txt");
      string restaurant_id = "";

      // get cmd from DatabaseHandler
      SqlCommand cmd = db.Command;

      // clear cmd
      cmd.Parameters.Clear();

      // add paramters
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      // get restaurant_id using branch_id
      SqlDataReader reader = db.ExecuteQuery("SELECT * FROM branch WHERE branch_id = @branch_id");

      if(reader.HasRows)
      {
        while(reader.Read())
        {
          restaurant_id = reader["restaurant_id"].ToString();
        }
      }
      else
      {
        // popup error and return
        MessageBox.Show("Error: No restaurant_id found for branch_id " + branch_id);

        // close connection
        db.CloseConnection();

        return;
      }

      // close connection
      db.CloseConnection();

      // clear cmd parameters
      cmd.Parameters.Clear();

      // add parameters
      cmd.Parameters.AddWithValue("@restaurant_id", restaurant_id);

      // get logo and colors from restaurant_info
      SqlDataReader dr = db.ExecuteQuery("SELECT logo, main_color, accent_color, text_color FROM restaurant_info WHERE restaurant_id=@restaurant_id");

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          if (dr["logo"] != null && !Convert.IsDBNull(dr["logo"]))
          {
            logoBytes = (byte[])dr["logo"];
          }

          UpdatePanelColor(dr["main_color"].ToString(), dr["accent_color"].ToString(), dr["text_color"].ToString());
        }
      }
      else
      {
        // popup error and return
        MessageBox.Show("Error: No logo found for restaurant_id " + restaurant_id);

        // close connection
        db.CloseConnection();

        return;
      }

      // close connection
      db.CloseConnection();

      MemoryStream ms = new MemoryStream(logoBytes);
      Image finalImage = Image.FromStream(ms);

      LogoFrame.Image = finalImage;

      Timer ordersTimer = new Timer();
      ordersTimer.Interval = 5000;
      ordersTimer.Tick += new System.EventHandler(ordersTimer_Tick);
      ordersTimer.Start();
    }

    // update window color
    private void UpdatePanelColor(string mainColor, string accentColor, string textColor)
    {
      // update logo panel with accent color
      LogoPanel.BackColor = ColorTranslator.FromHtml(accentColor);

      // update bottom panel with accent color
      BottomPanel.BackColor = ColorTranslator.FromHtml(accentColor);

      // update customer orders panel with main color
      this.BackColor = ColorTranslator.FromHtml(mainColor);

      // update OrderNumbers with main color
      OrderNumbers.BackColor = ColorTranslator.FromHtml(mainColor);

      // update OrderNumbers with text color
      OrderNumbers.ForeColor = ColorTranslator.FromHtml(textColor);

      // update all controls with text color
      foreach (Control c in this.Controls)
      {
        c.ForeColor = ColorTranslator.FromHtml(textColor);
      }
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
