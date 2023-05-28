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
    private string branch_id;

    public CustomerOrdersDisplay()
    {
      InitializeComponent();
    }

    private void ordersTimer_Tick(object sender, EventArgs e)
    {
      string preparingOrders = "";
      string readyOrders = "";

      // get db instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;

      // clear cmd
      cmd.Parameters.Clear();

      // add parameters
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      string sqlString = "SELECT * FROM orders WHERE status='preparing' AND branch_id=@branch_id";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          // get end_prepare_time
          DateTime end_prepare_time = Convert.ToDateTime(dr["end_prepare_time"]);

          // calculate time left
          TimeSpan timeLeft = end_prepare_time.Subtract(DateTime.Now);

          // get in minutes
          int minutesLeft = (int)timeLeft.TotalMinutes;

          // check if minutes greatear than 0
          if (minutesLeft > 0)
          {
            // add to preparingOrders
            preparingOrders += "#" + dr["order_id"].ToString() + " (" + minutesLeft + " minutes) ";
          }
          else
          {
            // add to readyOrders
            readyOrders += "#" + dr["order_id"].ToString() + " ";
          }
        }
      }
      else
      {
        preparingOrders = "";
      }

      // close connection
      db.CloseConnection();

      PreparingOrderNumbers.Text = preparingOrders;
      ReadyOrderNumbers.Text = readyOrders;
    }

    byte[] logoBytes = null;

    private void CustomerOrdersDisplay_Load(object sender, EventArgs e)
    {
      FormBorderStyle = FormBorderStyle.None;
      WindowState = FormWindowState.Maximized;

      // create a databasehandler
      DatabaseHandler db = DatabaseHandler.Instance;

      // get branch_id from DoneSetup.txt
      branch_id = File.ReadAllText("DoneSetup.txt");
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

      ordersTimer_Tick(null, null);

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

      // update customer orders panel with main color
      this.BackColor = ColorTranslator.FromHtml(mainColor);

      // update OrderNumbers with main color
      PreparingOrderNumbers.BackColor = ColorTranslator.FromHtml(mainColor);
      ReadyOrderNumbers.BackColor = ColorTranslator.FromHtml(mainColor);

      // update OrderNumbers with text color
      PreparingOrderNumbers.ForeColor = ColorTranslator.FromHtml(textColor);
      ReadyOrderNumbers.ForeColor = ColorTranslator.FromHtml(textColor);

      // update all controls with text color
      foreach (Control c in this.Controls)
      {
        c.ForeColor = ColorTranslator.FromHtml(textColor);
      }

      // get accent color 10% darker
      Color lighterAccentColor = ColorTranslator.FromHtml(accentColor);
      lighterAccentColor = ControlPaint.Light(lighterAccentColor, 0.1f);

      // update bottom panel
      BottomPanel.BackColor = lighterAccentColor;
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
