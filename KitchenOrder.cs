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

namespace Restaurant_Contactless_Dining_System
{
  public partial class KitchenOrder : UserControl
  {
    private bool hasLoaded = false;

    private string orderId;
    private DateTime orderStartPrepareTime;
    private DateTime orderEndPrepareTime;

    // map item_id to item_name
    private Dictionary<string, string> item_id_to_name;

    public KitchenOrder(string orderId, DateTime orderStartPrepareTime, DateTime orderEndPrepareTime, Dictionary<string, string> item_id_to_name)
    {
      InitializeComponent();

      this.orderId = orderId;
      this.orderStartPrepareTime = orderStartPrepareTime;
      this.orderEndPrepareTime = orderEndPrepareTime;
      this.item_id_to_name = item_id_to_name;
    }

    // get orderId
    public string OrderId
    {
      get
      {
        return orderId;
      }
    }

    private void DelayOrder()
    {
      // get db instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd instance
      SqlCommand cmd = db.Command;

      // clear params
      cmd.Parameters.Clear();

      // add params
      cmd.Parameters.AddWithValue("@order_id", orderId);

      // add 5 minutes to the end prepare time
      orderEndPrepareTime = orderEndPrepareTime.AddMinutes(5);

      // add params
      cmd.Parameters.AddWithValue("@end_prepare_time", orderEndPrepareTime);

      cmd.CommandText = "UPDATE orders SET end_prepare_time=@end_prepare_time WHERE order_id=@order_id";

      db.ExecuteNonQuery();

      // close connection
      db.CloseConnection();
    }

    private void UpdateTimer()
    {
      // get difference between now and end time
      TimeSpan timeDifference = orderEndPrepareTime.Subtract(DateTime.Now);

      if (timeDifference > TimeSpan.Zero) 
      {
        // update timer Time Left: 00:00:00
        timerLabel.Text = "Time Left: " + timeDifference.ToString(@"hh\:mm\:ss");
      }
      else
      {
        // update timer Time Left: 00:00:00
        timerLabel.Text = "Time Left: 00:00:00";

        DelayOrder();
      }
    }

    public void KitchenOrderLoad()
    {
      UpdateTimer();

      if (hasLoaded)
        return;

      hasLoaded = true;

      // clear orderInformationLabel
      orderInformationLabel.Text = "";

      // initialize orderInformationLabel
      orderInformationLabel.Text += "#ORD " + orderId.ToString() + " - " + orderStartPrepareTime.ToString() + "\n\n";
      orderInformationLabel.Text += "Quantity    Product\n";

      // get db instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd instance
      SqlCommand cmd = db.Command;

      // clear params
      cmd.Parameters.Clear();

      // add params
      cmd.Parameters.AddWithValue("@order_id", orderId);

      string sqlString = "SELECT * FROM customer_order_items WHERE order_id=@order_id";

      SqlDataReader reader = db.ExecuteQuery(sqlString);

      if(reader.HasRows)
      {
        while(reader.Read())
        {
          // get item name using item_id from dictionary
          string itemName = item_id_to_name[reader["item_id"].ToString()];

          orderInformationLabel.Text += $"{reader["quantity"]:00}              {itemName}\n";

          // get description
          string description = reader["description"].ToString();

          // add the description as a new line if it's not empty
          if (description != null && description != "")
          {
            // split each 20 characters into a new line
            for (int j = 0; j < description.Length; j += 20)
            {
              orderInformationLabel.Text += "-                    " + description.Substring(j, Math.Min(20, description.Length - j)) + "\n";
            }
          }
        }
      }

      // close connection
      db.CloseConnection();
    }
  }
}
