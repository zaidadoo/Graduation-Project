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
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;
using System.Diagnostics;
using OfficeOpenXml.Table;

namespace Restaurant_Contactless_Dining_System
{
  public partial class KitchenManagement : Form
  {
    bool isAdmin = true;
    bool isLock = false;

    private string branch_id;
    private string restaurant_id;

    // map item_id to item_name
    private Dictionary<string, string> item_id_to_name = new Dictionary<string, string>();

    // map item_id to usual_time
    private Dictionary<string, string> item_id_to_usual_time = new Dictionary<string, string>();

    // create a tick event for kitchen orders
    Timer ordersTimer;

    // create a data table that will store all orders selected
    DataTable orders = new DataTable();

    // create a data table that will store all order items selected
    DataTable orderItems = new DataTable();

    public KitchenManagement()
    {
      InitializeComponent();

      ordersTimer = new Timer();
    }

    private void KitchenManagement_Load(object sender, EventArgs e)
    {
      CompleteOrder.Enabled = false;
      ConfirmOrder.Enabled = false;
      CancelOrder.Enabled = false;

      UpdateItemIdDictionary();

      // set default date time picker values

      // set start range to beginning of year
      dataStartRangeDateTime.Value = new DateTime(DateTime.Now.Year, 1, 1);

      // set date time picker to current date
      dataEndRangeDateTime.Value = DateTime.Now;

      // add to order data table columns: order_id, branch_id, order_time, rating, total_price, start_prepare_time, end_prepare_time
      orders.Columns.Add("Order ID", typeof(string));
      orders.Columns.Add("Branch ID", typeof(string));
      orders.Columns.Add("Order Time", typeof(DateTime));
      orders.Columns.Add("Experience Rating", typeof(int));
      orders.Columns.Add("Price of Order", typeof(double));
      orders.Columns.Add("Time of Preparing Start", typeof(DateTime));
      orders.Columns.Add("Time of Preparing End", typeof(DateTime));

      // add to order items data table columns: order_id, item name, quantity, description
      orderItems.Columns.Add("Order ID", typeof(string));
      orderItems.Columns.Add("Item Name", typeof(string));
      orderItems.Columns.Add("Quantity", typeof(int));
      orderItems.Columns.Add("Preparation Note", typeof(string));

      foreach (TabPage tab in Tabs.TabPages)
      {
        tab.Enabled = false;
      }
        (Tabs.TabPages[Tabs.SelectedIndex] as TabPage).Enabled = true;

      foreach (TabPage tab in PendingOrdersTabs.TabPages)
      {
        tab.Enabled = false;
      }
        (PendingOrdersTabs.TabPages[PendingOrdersTabs.SelectedIndex] as TabPage).Enabled = true;

      foreach (TabPage tab in ManageRestaurantTabs.TabPages)
      {
        tab.Enabled = false;
      }
        (ManageRestaurantTabs.TabPages[ManageRestaurantTabs.SelectedIndex] as TabPage).Enabled = true;
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!isLock)
        Application.Exit();
      else
      {
        MessageBox.Show("Please disable lock screen from manager settings.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void bACKToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!isLock)
        this.Close();
      else
      {
        MessageBox.Show("Please disable lock screen from manager settings.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
    {
      foreach (TabPage tab in Tabs.TabPages)
      {
        tab.Enabled = false;
      }
        (Tabs.TabPages[Tabs.SelectedIndex] as TabPage).Enabled = true;
    }

    private void adminToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!isAdmin)
      {
        lockScreenToolStripMenuItem.Enabled = false;

        PasswordChecker passCheck = new PasswordChecker();
        passCheck.ShowDialog();

        if (passCheck.DialogResult.Equals(DialogResult.Yes))
        {
          isAdmin = true;
          MessageBox.Show("Logged in successfully.", "User Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
      else
      {
        lockScreenToolStripMenuItem.Enabled = true;
      }

    }

    private void Tabs_Selecting(object sender, TabControlCancelEventArgs e)
    {
      if (!e.TabPage.Enabled && isLock)
      {
        MessageBox.Show("Please disable lock screen from manager settings.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
        e.Cancel = true;
      }
    }

    private void offToolStripMenuItem_Click(object sender, EventArgs e)
    {
      isLock = false;
    }

    private void onToolStripMenuItem_Click(object sender, EventArgs e)
    {
      isLock = true;
    }

    private void PendingOrdersTabs_Selecting(object sender, TabControlCancelEventArgs e)
    {
      if (!e.TabPage.Enabled && isLock)
      {
        MessageBox.Show("Please disable lock screen from manager settings.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
        e.Cancel = true;
      }
    }

    private void UpdateItemIdDictionary()
    {
      // clear dictionary
      item_id_to_name.Clear();
      item_id_to_usual_time.Clear();

      // get db handler
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd
      SqlCommand cmd = db.Command;

      // clear params
      cmd.Parameters.Clear();

      // read branch_id from DoneSetup.txt
      branch_id = File.ReadAllText("DoneSetup.txt");

      // add params
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      string sqlString = "SELECT * FROM menu_items WHERE branch_id=@branch_id";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          item_id_to_name.Add(dr["item_id"].ToString(), dr["name_english"].ToString());
          item_id_to_usual_time.Add(dr["item_id"].ToString(), dr["usual_time"].ToString());
        }
      }

      // close connection
      db.CloseConnection();
    }

    // kitchen orders tick event
    private void KitchenOrders_Tick(object sender, EventArgs e)
    {
      UpdateOrders();
    }

    private void PendingOrdersTabs_SelectedIndexChanged(object sender, EventArgs e)
    {
      foreach (TabPage tab in PendingOrdersTabs.TabPages)
      {
        tab.Enabled = false;
      }
        (PendingOrdersTabs.TabPages[PendingOrdersTabs.SelectedIndex] as TabPage).Enabled = true;

      // if pending orders tab name selected called "cashier side"
      if (PendingOrdersTabs.SelectedTab.Name.Equals("CashierSide"))
      {
        UpdateItemIdDictionary();
      }

      // if kitchen view tab name selected called "kitchen view"
      if(PendingOrdersTabs.SelectedTab.Name.Equals("KitchenView"))
      {
        UpdateItemIdDictionary();

        // check if tick event running
        if (!ordersTimer.Enabled)
        {
          ordersTimer.Interval = 1000;
          ordersTimer.Tick += new System.EventHandler(KitchenOrders_Tick);
          ordersTimer.Start();
        }
      }
      else
      {
        // if tick event running destroy it
        if (ordersTimer.Enabled)
          ordersTimer.Stop();
      }
    }

    private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      isAdmin = false;
    }

    private void RetrieveOrdersList_Click(object sender, EventArgs e)
    {
      OrdersList.Items.Clear();

      // get db handler
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd
      SqlCommand cmd = db.Command;

      // clear params
      cmd.Parameters.Clear();

      // read branch_id from DoneSetup.txt
      branch_id = File.ReadAllText("DoneSetup.txt");

      // add params
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      string sqlString = "SELECT order_id FROM orders WHERE status='pending' OR status='preparing' AND branch_id=@branch_id";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          OrdersList.Items.Add(dr["order_id"]);
        }
      }

      // close connection
      db.CloseConnection();
    }

    private void OrdersList_SelectedIndexChanged(object sender, EventArgs e)
    {
      // check if selecting anything
      if (OrdersList.SelectedIndex == -1)
        return;

      ReviewGroupBox.Enabled = true;
      OrderedItemsList.Items.Clear();

      string order_id = OrdersList.SelectedItem.ToString();

      // get db instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd
      SqlCommand cmd = db.Command;

      // clear params
      cmd.Parameters.Clear();

      // add params
      cmd.Parameters.AddWithValue("@order_id", order_id);

      string sqlString = "SELECT * FROM customer_order_items WHERE order_id=@order_id";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          // get item name from item_id_to_name dictionary
          string item_name = item_id_to_name[dr["item_id"].ToString()];

          // get item quantity int
          int item_quantity = Convert.ToInt32(dr["quantity"]);

          for (int i = 0; i < item_quantity; i++)
            OrderedItemsList.Items.Add(item_name);
        }
      }

      // close connection
      db.CloseConnection();

      // clear params
      cmd.Parameters.Clear();

      // add params
      cmd.Parameters.AddWithValue("@order_id", order_id);

      sqlString = "SELECT * FROM orders WHERE order_id=@order_id";

      dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          // if preparing
          if (dr["status"].ToString().Equals("preparing"))
          {
            StatusLabel.Text = "Status: Preparing";
            ConfirmOrder.Enabled = false;
            CancelOrder.Enabled = true;
            CompleteOrder.Enabled = true;
          }

          if (dr["status"].ToString().Equals("pending"))
          {
            StatusLabel.Text = "Status: Pending";
            CompleteOrder.Enabled = false;
            ConfirmOrder.Enabled = true;
            CancelOrder.Enabled = true;
          }

          // total price
          PriceNumber.Text = dr["total_price"].ToString() + " JD";
        }
      }

      // close connection
      db.CloseConnection();
    }

    private void ConfirmOrder_Click(object sender, EventArgs e)
    {
      var res = MessageBox.Show("Are you sure you want to prepare order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (res == DialogResult.No)
      {
        return;
      }

      // get db instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd
      SqlCommand cmd = db.Command;

      // clear params
      cmd.Parameters.Clear();

      // add params
      cmd.Parameters.AddWithValue("@order_id", OrdersList.SelectedItem);

      // start_preparing_time
      cmd.Parameters.AddWithValue("@start_prepare_time", DateTime.Now);

      // end_prepare_time
      cmd.Parameters.AddWithValue("@end_prepare_time", CalculateExpectedPreparationTime());

      cmd.CommandText = "UPDATE orders SET status='preparing', start_prepare_time=@start_prepare_time, end_prepare_time=@end_prepare_time WHERE order_id=@order_id";

      int rowsAffected = db.ExecuteNonQuery();
      
      if (rowsAffected == 0)
        MessageBox.Show("Error... Record not modified.");
      else
        MessageBox.Show("Order confirmed successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

      // close connection
      db.CloseConnection();

      RetrieveOrdersList_Click(this, new EventArgs());
      ReviewGroupBox.Enabled = false;
    }

    private DateTime CalculateExpectedPreparationTime()
    {
      // create datetime object with 
      DateTime expectedTime = DateTime.Now;

      // for each item name in OrderedItemsList
      foreach (string item_name in OrderedItemsList.Items)
      {
        // find item_id (key) from item_id_to_name dictionary using item_name (value)
        string item_id = item_id_to_name.FirstOrDefault(x => x.Value == item_name).Key;

        // get usual_time from item_id_to_usual_time dictionary
        string usual_time = item_id_to_usual_time[item_id];

        // split usual_time into hours, minutes, seconds
        string[] timeParts = usual_time.Split(':');

        // add hours, minutes, seconds to time object
        expectedTime = expectedTime.AddHours(Convert.ToDouble(timeParts[0]));
        expectedTime = expectedTime.AddMinutes(Convert.ToDouble(timeParts[1]));
        expectedTime = expectedTime.AddSeconds(Convert.ToDouble(timeParts[2]));
      }

      return expectedTime;
    }

    private void CancelOrder_Click(object sender, EventArgs e)
    {
      var res = MessageBox.Show("Are you sure you want cancel order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (res == DialogResult.No)
      {
        return;
      }

      // get db instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd
      SqlCommand cmd = db.Command;

      // clear params
      cmd.Parameters.Clear();

      // add params
      cmd.Parameters.AddWithValue("@order_id", OrdersList.SelectedItem);

      cmd.CommandText = "UPDATE orders SET status='cancelled' WHERE order_id=@order_id";

      int rowsAffected = db.ExecuteNonQuery();

      if (rowsAffected == 0)
        MessageBox.Show("Error... Record not modified.");
      else
        MessageBox.Show("Order cancelled successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

      // close connection
      db.CloseConnection();

      RetrieveOrdersList_Click(this, new EventArgs());
      ReviewGroupBox.Enabled = false;
    }

    private void CompleteOrder_Click(object sender, EventArgs e)
    {
      var res = MessageBox.Show("Are you sure you want to complete order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (res == DialogResult.No)
      {
        return;
      }

      // get db instance
      DatabaseHandler db = DatabaseHandler.Instance;
      SqlCommand cmd = db.Command;

      // clear params
      cmd.Parameters.Clear();

      // get order_id
      string order_id = OrdersList.SelectedItem.ToString();

      // add params
      cmd.Parameters.AddWithValue("@order_id", OrdersList.SelectedItem);

      // end_prepare_time
      cmd.Parameters.AddWithValue("@end_prepare_time", DateTime.Now);

      cmd.CommandText = "UPDATE orders SET status='complete', end_prepare_time=@end_prepare_time WHERE order_id=@order_id";

      int rowsAffected = db.ExecuteNonQuery();

      if (rowsAffected == 0)
        MessageBox.Show("Error... Record not modified.");
      else
        MessageBox.Show("Order completed successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

      // close connection
      db.CloseConnection();

      RetrieveOrdersList_Click(this, new EventArgs());
      ReviewGroupBox.Enabled = false;

      // update items usual time
      UpdateItemsUsualTime(order_id);

      // update items 
      UpdateItemIdDictionary();
    }

    private void UpdateItemsUsualTime(string order_id)
    {
      // get number of items in OrderedItemsList
      int itemsCount = OrderedItemsList.Items.Count;

      // create an array of size itemsCount to store percentage of each item
      double[] percentage = new double[itemsCount];

      double totalSeconds = 0;

      // for each item name in OrderedItemsList using foreach
      foreach (string item_name in OrderedItemsList.Items)
      {
        double totalTime = GetItemUsualTimeInSeconds(item_name);

        // add total time to totalSeconds
        totalSeconds += totalTime;
      }

      // same as above but calculate percentage of each item using foreach
      foreach (string item_name in OrderedItemsList.Items)
      {
        double totalTime = GetItemUsualTimeInSeconds(item_name);

        percentage[OrderedItemsList.Items.IndexOf(item_name)] = totalTime / totalSeconds;
      }

      // get db instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd
      SqlCommand cmd = db.Command;

      // clear params
      cmd.Parameters.Clear();

      // add params
      cmd.Parameters.AddWithValue("@order_id", order_id);

      string sqlString = "SELECT * FROM orders WHERE order_id=@order_id";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      // get start_prepare_time and end_prepare_time
      DateTime start_prepare_time = new DateTime();
      DateTime end_prepare_time = new DateTime();

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          start_prepare_time = Convert.ToDateTime(dr["start_prepare_time"]);
          end_prepare_time = Convert.ToDateTime(dr["end_prepare_time"]);
        }
      }

      // close connection
      db.CloseConnection();

      // calculate total time taken to prepare order
      TimeSpan timeTaken = end_prepare_time.Subtract(start_prepare_time);

      // get total time taken in seconds
      double totalTimeTaken = timeTaken.TotalSeconds;

      // magic number that modifies usual time by that amount of percent
      double ModifyPercentage = 0.1;

      // for each item in OrderedItemsList
      foreach (string item_name in OrderedItemsList.Items)
      {
        // get item_id from item_id_to_name dictionary
        string item_id = item_id_to_name.FirstOrDefault(x => x.Value == item_name).Key;

        // get total time in seconds
        double totalTime = GetItemUsualTimeInSeconds(item_name);

        // get derived usual time
        double newUsualTime = totalTimeTaken * percentage[OrderedItemsList.Items.IndexOf(item_name)];

        // calculate difference between old usual time and derived usual time
        double difference = newUsualTime - totalTime;

        // update totalTime by adding difference with ModifyPercentage
        totalTime += difference * ModifyPercentage;

        // convert totalTime to time object
        TimeSpan time = TimeSpan.FromSeconds(totalTime);

        // get db instance
        db = DatabaseHandler.Instance;

        // get cmd
        cmd = db.Command;

        // clear params
        cmd.Parameters.Clear();

        // add params
        cmd.Parameters.AddWithValue("@item_id", item_id);

        // convert time object to string
        string usual_time = time.ToString(@"hh\:mm\:ss");

        // add params
        cmd.Parameters.AddWithValue("@usual_time", usual_time);

        cmd.CommandText = "UPDATE menu_items SET usual_time=@usual_time WHERE item_id=@item_id";

        db.ExecuteNonQuery();
      }

      // close connection
      db.CloseConnection();
    }

    private double GetItemUsualTimeInSeconds(string item_name)
    {
      // find item_id (key) from item_id_to_name dictionary using item_name (value)
      string item_id = item_id_to_name.FirstOrDefault(x => x.Value == item_name).Key;

      // get usual_time from item_id_to_usual_time dictionary
      string usual_time = item_id_to_usual_time[item_id];

      // split usual_time into hours, minutes, seconds
      string[] timeParts = usual_time.Split(':');

      // add hours, minutes, seconds to time object
      TimeSpan time = new TimeSpan(Convert.ToInt32(timeParts[0]), Convert.ToInt32(timeParts[1]), Convert.ToInt32(timeParts[2]));

      // get total time in seconds
      double totalTime = time.TotalSeconds;

      return totalTime;
    }

    private void UpdateOrders()
    {
      // a temporary list to hold order ids
      List<string> order_ids = new List<string>();

      // get db instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd
      SqlCommand cmd = db.Command;

      // clear params
      cmd.Parameters.Clear();

      // get branch_id from DoneSetup.txt
      string branch_id = File.ReadAllText("DoneSetup.txt");

      // add params
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      string sqlString = "SELECT * FROM orders WHERE branch_id=@branch_id AND status='preparing'";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          // get order_id
          string order_id = dr["order_id"].ToString();

          // add order_id to list
          order_ids.Add(order_id);

          bool orderExists = false;

          // check if order control already exists in flow layout panel
          foreach (KitchenOrder order in preparingOrdersPanel.Controls)
          {
            if (order.OrderId == order_id)
            {
              orderExists = true;
              break;
            }
          }

          // if order control already exists in flow layout panel
          if (orderExists)
            continue;

          // get start_prepare_time datetime
          DateTime start_prepare_time = Convert.ToDateTime(dr["start_prepare_time"]);

          // get end_prepare_time datetime
          DateTime end_prepare_time = Convert.ToDateTime(dr["end_prepare_time"]);

          // create new order control
          KitchenOrder kitchenOrder = new KitchenOrder(order_id, start_prepare_time, end_prepare_time, item_id_to_name);

          // add order control to flow layout panel
          preparingOrdersPanel.Controls.Add(kitchenOrder);
        }
      }

      // close connection
      db.CloseConnection();

      // for each order control in flow layout panel
      foreach (KitchenOrder order in preparingOrdersPanel.Controls)
      {
        // add event handler to each order control
        order.KitchenOrderLoad();

        // check if control order id is in order_ids list
        if (!order_ids.Contains(order.OrderId))
        {
          // remove order control from flow layout panel
          preparingOrdersPanel.Controls.Remove(order);
        }
      }
    }

    private void KitOrdersList_SelectedIndexChanged(object sender, EventArgs e)
    {
      //KitOrderedItemsList.Items.Clear();

      //string lines = "";

      //con.Open();
      //cmd.Connection = con;
      //cmd.CommandText = "SELECT * FROM orders where id=" + KitOrdersList.SelectedItem;
      //dr = cmd.ExecuteReader();

      //if (dr.HasRows)
      //{
      //  double total = 0;

      //  while (dr.Read())
      //  {
      //    lines += dr["items"];

      //    foreach (string line in lines.Split('\n'))
      //    {
      //      var found = line.IndexOf(":");
      //      var found2 = line.LastIndexOf(":");

      //      try
      //      {
      //        if (found > 0 && found2 - 1 > 0)
      //        {
      //          int i = 0;
      //          if (found2 - found > 2)
      //          {
      //            i = 2;
      //          }
      //          else
      //          {
      //            i = 1;
      //          }
      //          KitOrderedItemsList.Items.Add($"{line.Substring(found + 1, i)}x {line.Substring(0, found)}");

      //          total += (float.Parse(line.Substring(found2 + 1)) * int.Parse(line.Substring(found + 1, i)));
      //        }
      //      }
      //      catch (ArgumentOutOfRangeException)
      //      {
      //        MessageBox.Show("Error: no items found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //      }
      //      finally { }
      //    }
      //  }
      //}

      //dr.Close();
      //con.Close();
    }

    private void RetrieveAllOrders_Click(object sender, EventArgs e)
    {
      //con.Open();

      //string comm = "SELECT * FROM orders ORDER BY id";
      //cmd = new SQLiteCommand(comm, con);

      //var da = new SQLiteDataAdapter(comm, con);
      //var ds = new DataSet();

      //da.Fill(ds, "orders");

      //OrdersGridView.DataSource = ds.Tables["orders"].DefaultView;

      //con.Close();
    }

    private void ManageRestaurantTabs_Selecting(object sender, TabControlCancelEventArgs e)
    {
      if (!e.TabPage.Enabled && isLock)
      {
        MessageBox.Show("Please disable lock screen from manager settings.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
        e.Cancel = true;
      }
    }

    private void ManageRestaurantTabs_SelectedIndexChanged(object sender, EventArgs e)
    {
      foreach (TabPage tab in ManageRestaurantTabs.TabPages)
      {
        tab.Enabled = false;
      }

        (ManageRestaurantTabs.TabPages[ManageRestaurantTabs.SelectedIndex] as TabPage).Enabled = true;

      // get the selected tab name
      string selectedTab = ManageRestaurantTabs.SelectedTab.Name;

      if(selectedTab.Equals("BranchInfo"))
      {
        OnBranchInfoLoad();
      }

      if (selectedTab.Equals("RestaurantInfo"))
      {
        OnRestaurantInfoLoad();
      }
    }

    private void OnBranchInfoLoad()
    {
      // read branch_id from DoneSetup.txt
      branch_id = File.ReadAllText("DoneSetup.txt");

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from database
      SqlCommand cmd = db.Command;

      // clear cmd
      cmd.Parameters.Clear();

      // add branch_id to cmd
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      // get all data from branch table
      string sqlString = "SELECT * FROM branch WHERE branch_id = @branch_id";

      SqlDataReader reader = db.ExecuteQuery(sqlString);

      if(reader.HasRows)
      {
        while (reader.Read()) 
        { 
          // set branchField
          branchIdField.Text = reader["branch_id"].ToString();

          // set numberUpDown numOfTablesField
          numOfTablesField.Value = int.Parse(reader["number_of_tables"].ToString());
        }
      }

      // close connection
      db.CloseConnection();
    }

    private void OnRestaurantInfoLoad()
    {
      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from database
      SqlCommand cmd = db.Command;

      // clear cmd
      cmd.Parameters.Clear();

      // get branch_id from DoneSetup.txt
      string branch_id = File.ReadAllText("DoneSetup.txt");

      // add branch_id to cmd
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      // get restaurant_id from branch table
      string sqlString = "SELECT restaurant_id FROM branch WHERE branch_id = @branch_id";

      SqlDataReader reader = db.ExecuteQuery(sqlString);

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          // set restaurantField
          restaurant_id = reader["restaurant_id"].ToString();
        }
      }

      // close connection
      db.CloseConnection();

      // clear cmd
      cmd.Parameters.Clear();

      // add restaurant_id to cmd
        cmd.Parameters.AddWithValue("@restaurant_id", restaurant_id);

      // get restaurant info from restaurant_info table
      sqlString = "SELECT * FROM restaurant_info WHERE restaurant_id = @restaurant_id";

      reader = db.ExecuteQuery(sqlString);

      if (reader.HasRows)
      {
        while (reader.Read())
        {
          // set nameEnglishField
          nameEnglishField.Text = reader["name_english"].ToString();

          // set nameArabicField
          nameArabicField.Text = reader["name_arabic"].ToString();

          // set mainColorField
          mainColorField.Text = reader["main_color"].ToString();

          // set accentColorField
          accentColorField.Text = reader["accent_color"].ToString();

          // set textColorField
          textColorField.Text = reader["text_color"].ToString();

          // set logoBytes
          logoBytes = (byte[])reader["logo"];

          // set LogoUpload picture box
          LogoUpload.Image = Image.FromStream(new MemoryStream(logoBytes));

          // set logoUploadOkay
          logoUploadOkay = true;
        }
      }

      // close connection
      db.CloseConnection();
    }

    bool logoUploadOkay = false;
    byte[] logoBytes = null;

    private void RefreshData_Click(object sender, EventArgs e)
    {
      //if (!isAdmin)
      //{
      //  PasswordChecker passCheck = new PasswordChecker();
      //  passCheck.ShowDialog();

      //  if (passCheck.DialogResult.Equals(DialogResult.Yes))
      //  {
      //    isAdmin = true;
      //    MessageBox.Show("Logged in successfully.", "User Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //  }
      //  else
      //  {
      //    RestaurantInfoGroup.Enabled = false;
      //    return;
      //  }
      //}

      //RestaurantInfoGroup.Enabled = true;

      //con.Open();

      //cmd.Connection = con;
      //cmd.CommandText = "SELECT * FROM restaurant_info";

      //dr = cmd.ExecuteReader();

      //if (dr.HasRows)
      //{
      //  while (dr.Read())
      //  {
      //    RestauranName.Text = dr["name"].ToString();
      //    Password.Text = dr["password"].ToString();
      //    if (dr["logo"] != null && !Convert.IsDBNull(dr["logo"]))
      //    {
      //      logoBytes = (byte[])dr["logo"];
      //    }
      //  }
      //}

      //dr.Close();
      //con.Close();

      //MemoryStream ms = new MemoryStream(logoBytes);
      //Image finalImage = Image.FromStream(ms);

      //LogoUpload.Image = finalImage;
      //logoUploadOkay = true;
    }

    OpenFileDialog open = new OpenFileDialog();

    private void LogoUpload_Click(object sender, EventArgs e)
    {
      open.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif)|*.png; *.jpg; *.jpeg; *.gif";
      if (open.ShowDialog() == DialogResult.OK)
      {
        LogoUpload.Image = new Bitmap(open.FileName);

        logoUploadOkay = true;

        // convert image to byte array
        ImageConverter converter = new ImageConverter();
        logoBytes = (byte[])converter.ConvertTo(LogoUpload.Image, typeof(byte[]));

        List<string> top3Colors = ColorAnalyzer.GetTop3DistinctColors(logoBytes);

        int i = 0;
        foreach (string color in top3Colors)
        {
          switch(i)
          {
            case 0:
              mainColorField.Text = color;
              break;
            case 2:
              textColorField.Text = color;
              break;
          }

          i++;
        }

        // set accent color by getting main color and making it 30% lighter
        string mainColor = mainColorField.Text;
        Color lighterAccent = ColorTranslator.FromHtml(mainColor);
        lighterAccent = ControlPaint.Light(lighterAccent, 0.3f);
        accentColorField.Text = ColorTranslator.ToHtml(lighterAccent);
      }
      else
      {
        logoUploadOkay = false;
      }
    }

    private void SubmitPassword_Click(object sender, EventArgs e)
    {
      //if (!isAdmin)
      //{
      //  PasswordChecker passCheck = new PasswordChecker();
      //  passCheck.ShowDialog();

      //  if (passCheck.DialogResult.Equals(DialogResult.Yes))
      //  {
      //    isAdmin = true;
      //    MessageBox.Show("Logged in successfully.", "User Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //  }
      //  else
      //  {
      //    RestaurantInfoGroup.Enabled = false;
      //    return;
      //  }
      //}

      //DialogResult res = MessageBox.Show("Are you sure you want to submit details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      //if (res == DialogResult.No)
      //  return;

      //if (RestauranName.Text.Equals("") || Password.Text.Equals(""))
      //{
      //  MessageBox.Show("Error: Restaurant Name or Password field is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //  return;
      //}
      //if (!logoUploadOkay)
      //{
      //  MessageBox.Show("Error: Logo not uploaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //  return;
      //}

      //con.Open();
      //cmd.Connection = con;

      //if (open.FileName != "")
      //{
      //  cmd.CommandText = "UPDATE restaurant_info SET name=@iname, password=@ipassword, logo=@ilogo";

      //  byte[] image = File.ReadAllBytes(open.FileName);

      //  cmd.Parameters.AddWithValue("iname", RestauranName.Text);
      //  cmd.Parameters.Add("ilogo", DbType.Binary, 20).Value = image;
      //  cmd.Parameters.AddWithValue("ipassword", Password.Text);
      //}
      //else
      //{
      //  cmd.CommandText = "UPDATE restaurant_info SET name=@iname, password=@ipassword";

      //  cmd.Parameters.AddWithValue("iname", RestauranName.Text);
      //  cmd.Parameters.AddWithValue("ipassword", Password.Text);
      //}

      //int rowsAffected = cmd.ExecuteNonQuery();
      //if (rowsAffected == 0)
      //  MessageBox.Show("Error... Record not updated.");
      //else
      //{
      //  MessageBox.Show("Restaurant Information Updated Successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //}

      //con.Close();
    }

    bool newItem = false;

    private void ModifyItems_Click(object sender, EventArgs e)
    {
      newItem = false;
      ModifyItemsPanel.Enabled = true;
      ItemDetailsPanel.Enabled = false;
    }

    private void AddNewItems_Click(object sender, EventArgs e)
    {
      newItem = true;
      ModifyItemsPanel.Enabled = false;
      ItemDetailsPanel.Enabled = true;
    }

    private void SpecialDealsRadio_CheckedChanged(object sender, EventArgs e)
    {
      MenuItemsList.Enabled = true;
      DeleteItem.Enabled = false;
      ClearFormFields_Click(this, new EventArgs());
      ItemDetailsPanel.Enabled = false;
      MenuItemsList.Items.Clear();

      // check if special deal radio is checked
      if (!SpecialDealsRadio.Checked)
        return;

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;
      cmd.Parameters.Clear();

      // read branch_id from DoneSetup.txt
      if (branch_id == null)
        branch_id = File.ReadAllText("DoneSetup.txt");

      // cmd params
      cmd.Parameters.AddWithValue("@branch_id", branch_id);
      cmd.Parameters.AddWithValue("@category", "Promotions");

      string sqlString = "SELECT * FROM menu_items WHERE branch_id=@branch_id AND category=@category";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          MenuItemsList.Items.Add(dr["item_id"] + ". " + dr["name_english"].ToString());
        }
      }
      else
      {
        MessageBox.Show("No items found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      // close db connection
      db.CloseConnection();
    }

    private void StarterItemsRadio_CheckedChanged(object sender, EventArgs e)
    {
      MenuItemsList.Enabled = true;
      DeleteItem.Enabled = false;
      ClearFormFields_Click(this, new EventArgs());
      ItemDetailsPanel.Enabled = false;
      MenuItemsList.Items.Clear();

      // check if start items radio is checked
      if (!StarterItemsRadio.Checked)
        return;

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;

      // clear cmd
      cmd.Parameters.Clear();

      // read branch_id from DoneSetup.txt
      if (branch_id == null)
        branch_id = File.ReadAllText("DoneSetup.txt");

      // cmd params
      cmd.Parameters.AddWithValue("@branch_id", branch_id);
      cmd.Parameters.AddWithValue("@category", "Starter Items");

      string sqlString = "SELECT * FROM menu_items WHERE branch_id=@branch_id AND category=@category";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          MenuItemsList.Items.Add(dr["item_id"] + ". " + dr["name_english"].ToString());
        }
      }
      else
      {
        MessageBox.Show("No items found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      // close connection
      db.CloseConnection();
    }

    private void MainItemsRadio_CheckedChanged(object sender, EventArgs e)
    {
      MenuItemsList.Enabled = true;
      DeleteItem.Enabled = false;
      ClearFormFields_Click(this, new EventArgs());
      ItemDetailsPanel.Enabled = false;
      MenuItemsList.Items.Clear();

      // check if main items radio is checked
      if (!MainItemsRadio.Checked)
        return;

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;

      // clear cmd
      cmd.Parameters.Clear();

      // read branch_id from DoneSetup.txt
      if (branch_id == null)
        branch_id = File.ReadAllText("DoneSetup.txt");

      // cmd params
      cmd.Parameters.AddWithValue("@branch_id", branch_id);
      cmd.Parameters.AddWithValue("@category", "Main Items");

      // query
      string sqlString = "SELECT * FROM menu_items WHERE branch_id=@branch_id AND category=@category";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          MenuItemsList.Items.Add(dr["item_id"] + ". " + dr["name_english"].ToString());
        }
      }
      else
      {
        MessageBox.Show("No items found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      // close connection
      db.CloseConnection();
    }

    private void DessertsRadio_CheckedChanged(object sender, EventArgs e)
    {
      MenuItemsList.Enabled = true;
      DeleteItem.Enabled = false;
      ClearFormFields_Click(this, new EventArgs());
      ItemDetailsPanel.Enabled = false;
      MenuItemsList.Items.Clear();

      // check if desserts radio is checked
      if (!DessertsRadio.Checked)
        return;

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;

      // clear cmd
      cmd.Parameters.Clear();

      // read branch_id from DoneSetup.txt
      if(branch_id == null)
        branch_id = File.ReadAllText("DoneSetup.txt");

      // cmd params
      cmd.Parameters.AddWithValue("@branch_id", branch_id);
      cmd.Parameters.AddWithValue("@category", "Desserts");

      // query
      string sqlString = "SELECT * FROM menu_items WHERE branch_id=@branch_id AND category=@category";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          MenuItemsList.Items.Add(dr["item_id"] + ". " + dr["name_english"].ToString());
        }
      }
      else
      {
        MessageBox.Show("No items found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      db.CloseConnection();
    }

    private void ExtraItemsRadio_CheckedChanged(object sender, EventArgs e)
    {
      MenuItemsList.Enabled = true;
      DeleteItem.Enabled = false;
      ClearFormFields_Click(this, new EventArgs());
      ItemDetailsPanel.Enabled = false;
      MenuItemsList.Items.Clear();

      // check if extra items radio is checked
      if (!ExtraItemsRadio.Checked)
        return;

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;

      // clear cmd
      cmd.Parameters.Clear();

      // read branch_id from DoneSetup.txt
      if (branch_id == null)
        branch_id = File.ReadAllText("DoneSetup.txt");

      // cmd params
      cmd.Parameters.AddWithValue("@branch_id", branch_id);
      cmd.Parameters.AddWithValue("@category", "Extra Items");

      // query
      string sqlString = "SELECT * FROM menu_items WHERE branch_id=@branch_id AND category=@category";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          MenuItemsList.Items.Add(dr["item_id"] + ". " + dr["name_english"].ToString());
        }
      }
      else
      {
        MessageBox.Show("No items found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      db.CloseConnection();
    }

    bool picUploadOkay = false;

    private void MenuItemsList_SelectedIndexChanged(object sender, EventArgs e)
    {
      DeleteItem.Enabled = true;

      // check if selected item is null
      if (MenuItemsList.SelectedItem == null)
        return;

      string itemID = (MenuItemsList.SelectedItem.ToString()).Substring(0, MenuItemsList.SelectedItem.ToString().IndexOf('.'));

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      SqlCommand cmd = db.Command;

      cmd.Parameters.Clear();

      cmd.Parameters.AddWithValue("@item_id", itemID);

      string sqlString = "SELECT * FROM menu_items WHERE item_id=@item_id";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      byte[] imageBytes = null;

      if (dr.HasRows)
      {
        ItemDetailsPanel.Enabled = true;
        while (dr.Read())
        {
          // english name
          ItemNameInput.Text = dr["name_english"].ToString();

          // arabic name
          ItemArabicNameInput.Text = dr["name_arabic"].ToString();

          // english description
          ItemEnglishDescriptionInput.Text = dr["description_english"].ToString();

          // arabic description
          ItemArabicDescriptionInput.Text = dr["description_arabic"].ToString();

          // price
          ItemPriceInput.Value = decimal.Parse(dr["price"].ToString());

          // expected time
          try
          {
            // convert time data type (hh:mm:ss) to date time object
            string[] time = dr["usual_time"].ToString().Split(':');
            ItemExpectedTimeInput.Value = new DateTime(2018, 1, 1, int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
          }
          catch
          {
            // set date time to 0
            ItemExpectedTimeInput.Value = new DateTime(2018, 1, 1, 0, 0, 0);
          }

          // ItemCategoryInput selection
          if (dr["category"].ToString() == "Promotions")
            ItemCategoryInput.SelectedIndex = 0;
          else if (dr["category"].ToString() == "Starter Items")
            ItemCategoryInput.SelectedIndex = 1;
          else if (dr["category"].ToString() == "Main Items")
            ItemCategoryInput.SelectedIndex = 2;
          else if (dr["category"].ToString() == "Desserts")
            ItemCategoryInput.SelectedIndex = 3;
          else if (dr["category"].ToString() == "Extra Items")
            ItemCategoryInput.SelectedIndex = 4;

          if (dr["image"] != null && !Convert.IsDBNull(dr["image"]))
          {
            imageBytes = (byte[])dr["image"];
          }
        }
      }

      // close connection
      db.CloseConnection();

      MemoryStream ms = new MemoryStream(imageBytes);
      Image finalImage = Image.FromStream(ms);

      UploadItemPicture.Image = finalImage;
      picUploadOkay = true;
    }

    OpenFileDialog open2 = new OpenFileDialog();
    private void UploadItemPicture_Click(object sender, EventArgs e)
    {
      open2.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif)|*.png; *.jpg; *.jpeg; *.gif";
      if (open2.ShowDialog() == DialogResult.OK)
      {
        UploadItemPicture.Image = new Bitmap(open2.FileName);

        picUploadOkay = true;
      }
    }

    private void SubmitItemDetails_Click(object sender, EventArgs e)
    {
      DialogResult res = MessageBox.Show("Are you sure you want to submit details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (res == DialogResult.No)
        return;

      // name english empty
      if (ItemNameInput.Text.Equals(""))
      {
        MessageBox.Show("Error: Item english name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // arabic name empty
      if (ItemArabicNameInput.Text.Equals(""))
      {
        MessageBox.Show("Error: Item arabic name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // english description empty
      if (ItemEnglishDescriptionInput.Text.Equals(""))
      {
        MessageBox.Show("Error: Item english description cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // arabic description empty
      if (ItemArabicDescriptionInput.Text.Equals(""))
      {
        MessageBox.Show("Error: Item arabic description cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // price empty
      if (ItemPriceInput.Value == 0)
      {
        MessageBox.Show("Error: Item price cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // expected time (date time picker) empty
      if (ItemExpectedTimeInput.Value == new DateTime(2018, 1, 1, 0, 0, 0))
      {
        MessageBox.Show("Error: Item expected time cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // category empty
      if (ItemCategoryInput.SelectedIndex == -1)
      {
        MessageBox.Show("Error: Item category cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // logo upload empty
      if (!picUploadOkay)
      {
        MessageBox.Show("Error: Image not uploaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (newItem)
      {
        // get database handler instance
        DatabaseHandler db = DatabaseHandler.Instance;

        // get cmd from database
        SqlCommand cmd = db.Command;

        // clear cmd
        cmd.Parameters.Clear();

        // read branch_id from DoneSetup.txt
        branch_id = File.ReadAllText("DoneSetup.txt");

        // add parameters

        // convert expected datetime to time data type for database
        string time = ItemExpectedTimeInput.Value.ToString("00:mm:ss");

        // add time parameter
        cmd.Parameters.AddWithValue("@usual_time", time);

        cmd.Parameters.AddWithValue("@name_english", ItemNameInput.Text);
        cmd.Parameters.AddWithValue("@name_arabic", ItemArabicNameInput.Text);
        cmd.Parameters.AddWithValue("@description_english", ItemEnglishDescriptionInput.Text);
        cmd.Parameters.AddWithValue("@description_arabic", ItemArabicDescriptionInput.Text);
        cmd.Parameters.AddWithValue("@price", ItemPriceInput.Value);
        cmd.Parameters.AddWithValue("@category", ItemCategoryInput.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@branch_id", branch_id);

        MemoryStream ms = new MemoryStream();
        UploadItemPicture.Image.Save(ms, UploadItemPicture.Image.RawFormat);
        byte[] img = ms.ToArray();

        cmd.Parameters.AddWithValue("@image", img);

        // set command text
        cmd.CommandText = "INSERT INTO menu_items (name_english, name_arabic, description_english, description_arabic, price, usual_time, category, image, branch_id) VALUES (@name_english, @name_arabic, @description_english, @description_arabic, @price, @usual_time, @category, @image, @branch_id)";

        int rowsAffected = db.ExecuteNonQuery();

        if (rowsAffected == 0)
        {
          MessageBox.Show("Error: Item not added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

          // close connection
          db.CloseConnection();

          return;
        }

        MessageBox.Show("Item added successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // close connection
        db.CloseConnection();

        ItemDetailsPanel.Enabled = false;
        UploadItemPicture.Image = null;
        ClearFormFields_Click(this, new EventArgs());
      }
      else
      {
        // get database handler instance
        DatabaseHandler db = DatabaseHandler.Instance;

        // get cmd from database
        SqlCommand cmd = db.Command;

        // clear cmd
        cmd.Parameters.Clear();

        // read branch_id from DoneSetup.txt
        branch_id = File.ReadAllText("DoneSetup.txt");

        // add parameters

        // convert expected time to time data type for database
        string time = ItemExpectedTimeInput.Value.ToString("00:mm:ss");

        // add time parameter
        cmd.Parameters.AddWithValue("@usual_time", time);

        cmd.Parameters.AddWithValue("@name_english", ItemNameInput.Text);
        cmd.Parameters.AddWithValue("@name_arabic", ItemArabicNameInput.Text);
        cmd.Parameters.AddWithValue("@description_english", ItemEnglishDescriptionInput.Text);
        cmd.Parameters.AddWithValue("@description_arabic", ItemArabicDescriptionInput.Text);
        cmd.Parameters.AddWithValue("@price", ItemPriceInput.Value);
        cmd.Parameters.AddWithValue("@category", ItemCategoryInput.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@branch_id", branch_id);
        cmd.Parameters.AddWithValue("@id", (MenuItemsList.SelectedItem.ToString()).Substring(0, MenuItemsList.SelectedItem.ToString().IndexOf('.')));

        MemoryStream ms = new MemoryStream();
        UploadItemPicture.Image.Save(ms, UploadItemPicture.Image.RawFormat);
        byte[] img = ms.ToArray();

        cmd.Parameters.AddWithValue("@image", img);

        // set command text
        cmd.CommandText = "UPDATE menu_items SET name_english = @name_english, name_arabic = @name_arabic, description_english = @description_english, description_arabic = @description_arabic, price = @price, usual_time = @usual_time, category = @category, image = @image WHERE item_id = @id";

        int rowsAffected = db.ExecuteNonQuery();

        if (rowsAffected == 0)
          MessageBox.Show("Error... item not updated.");
        else
        {
          MessageBox.Show("Item updated successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // close connection
        db.CloseConnection();

        ItemDetailsPanel.Enabled = false;
        UploadItemPicture.Image = null;
        ClearFormFields_Click(this, new EventArgs());
      }

      MenuItemsList.Enabled = false;

      // check which radio button is checked
      if (SpecialDealsRadio.Checked)
        SpecialDealsRadio_CheckedChanged(this, new EventArgs());

      if (StarterItemsRadio.Checked)
        StarterItemsRadio_CheckedChanged(this, new EventArgs());

      if (MainItemsRadio.Checked)
        MainItemsRadio_CheckedChanged(this, new EventArgs());

      if (DessertsRadio.Checked)
        DessertsRadio_CheckedChanged(this, new EventArgs());

      if (ExtraItemsRadio.Checked)
        ExtraItemsRadio_CheckedChanged(this, new EventArgs());
    }

    private void ClearFormFields_Click(object sender, EventArgs e)
    {
      UploadItemPicture.Image = null;
      ItemNameInput.Clear();
      ItemPriceInput.Value = 0;
      ItemCategoryInput.Text = "";
      ItemArabicNameInput.Clear();
      ItemEnglishDescriptionInput.Clear();
      ItemArabicDescriptionInput.Clear();

      // make date time to 1/1/2018 00:00:00
      ItemExpectedTimeInput.Value = new DateTime(2018, 1, 1, 0, 0, 0);
    }

    private void DeleteItem_Click(object sender, EventArgs e)
    {
      DialogResult res = MessageBox.Show("Are you sure you want to delete item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (res == DialogResult.No)
        return;

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;

      try
      {
        string id = (MenuItemsList.SelectedItem.ToString()).Substring(0, MenuItemsList.SelectedItem.ToString().IndexOf('.'));

        // add parameters
        cmd.Parameters.AddWithValue("@id", id);

        cmd.CommandText = "DELETE FROM menu_items WHERE item_id=@id";
      }
      catch (NullReferenceException)
      {
        MessageBox.Show("Select an item first please.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        int rowsAffected = db.ExecuteNonQuery();
        if (rowsAffected == 0)
          MessageBox.Show("Error... item not deleted.");
        else
        {
          MessageBox.Show("Item deleted successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // close connection
        db.CloseConnection();

        // clear menu
        MenuItemsList.Items.Clear();

        // unselect radio buttons
        SpecialDealsRadio.Checked = false;
        StarterItemsRadio.Checked = false;
        MainItemsRadio.Checked = false;
        DessertsRadio.Checked = false;
        ExtraItemsRadio.Checked = false;

        // disable delete button
        DeleteItem.Enabled = false;
      }
    }

    private void TextInputButton_Click(object sender, EventArgs e)
    {
      var reader = new StreamReader("form.txt");

      ItemNameInput.Text = reader.ReadLine();
      ItemPriceInput.Value = decimal.Parse(reader.ReadLine());
      ItemCategoryInput.Text = reader.ReadLine();

      reader.Close();
    }

    private void subbmitBranchInfo_Click(object sender, EventArgs e)
    {
      // check if branch id is empty
      if (branchIdField.Text.Equals(""))
      {
        MessageBox.Show("Error: Branch ID is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // check if numericUpDown numoftablesfield is empty
      if (numOfTablesField.Value == 0)
      {
        MessageBox.Show("Error: Number of tables is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // check if currentPasswordField is empty
      if (currentPasswordField.Text.Equals(""))
      {
        MessageBox.Show("Error: Current password is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // check if newPasswordField is empty
      if (newPasswordField.Text.Equals(""))
      {
        MessageBox.Show("Error: New password is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // check if current and new password are the same
      if (currentPasswordField.Text.Equals(newPasswordField.Text))
      {
        MessageBox.Show("Error: Current and new password are the same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // check if current password is correct
      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from database
      SqlCommand cmd = db.Command;

      // hash password with sha 512
      SHA512 sha512 = SHA512.Create();
      byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(currentPasswordField.Text));
      string hashedPassword = BitConverter.ToString(bytes).Replace("-", "").ToLower();

      // clear paramter
      cmd.Parameters.Clear();

      // add password and branch id parameters
      cmd.Parameters.AddWithValue("@password", hashedPassword);
      cmd.Parameters.AddWithValue("@branchId", branchIdField.Text);

      string sqlString = "SELECT * FROM users WHERE password = @password AND branch_id = @branchId";

      SqlDataReader reader = db.ExecuteQuery(sqlString);

      if(!reader.HasRows)
      {
        MessageBox.Show("Error: Current password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // close connection
        db.CloseConnection();

        return;
      }

      // close connection
      db.CloseConnection();

      // clear paramter
      cmd.Parameters.Clear();

      // add branch id and num of tables parameters
      cmd.Parameters.AddWithValue("@branchId", branchIdField.Text);
      cmd.Parameters.AddWithValue("@numOfTables", numOfTablesField.Value);

      // update branch num of tables
      cmd.CommandText = "UPDATE branch SET number_of_tables = @numOfTables WHERE branch_id = @branchId";

      int RowsAffected = db.ExecuteNonQuery();

      if (RowsAffected == 0)
      {
        MessageBox.Show("Error: Branch not updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // close connection
        db.CloseConnection();

        return;
      }

      // close connection
      db.CloseConnection();

      // hash new password with sha 512
      bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(newPasswordField.Text));
      hashedPassword = BitConverter.ToString(bytes).Replace("-", "").ToLower();

      // clear paramter
      cmd.Parameters.Clear();

      // add password and branch id parameters
      cmd.Parameters.AddWithValue("@password", hashedPassword);
      cmd.Parameters.AddWithValue("@branchId", branchIdField.Text);

      cmd.CommandText = "UPDATE users SET password = @password WHERE branch_id = @branchId";

      RowsAffected = db.ExecuteNonQuery();

      if (RowsAffected == 0)
      {
        MessageBox.Show("Error: Password not updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // close connection
        db.CloseConnection();

        return;
      }

      // close connection
      db.CloseConnection();

      // popup success
      MessageBox.Show("Password and number of tables updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void submitRestaurantInfo_Click(object sender, EventArgs e)
    {
      // check if nameEnglishField empty
      if (nameEnglishField.Text.Equals(""))
      {
        MessageBox.Show("Error: English name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // check if nameArabicField empty
      if (nameArabicField.Text.Equals(""))
      {
        MessageBox.Show("Error: Arabic name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // check if mainColorField empty
      if (mainColorField.Text.Equals(""))
      {
        MessageBox.Show("Error: Main color is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // check if accentColorField empty
      if (accentColorField.Text.Equals(""))
      {
        MessageBox.Show("Error: Accent color is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // check if textColorField empty
      if (textColorField.Text.Equals(""))
      {
        MessageBox.Show("Error: Text color is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // check if LogoUpload image is empty
      if (LogoUpload.Image == null)
      {
        MessageBox.Show("Error: Logo is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from database
      SqlCommand cmd = db.Command;

      // clear paramter
      cmd.Parameters.Clear();

      // update restaurant_info table
      cmd.Parameters.AddWithValue("@nameEnglish", nameEnglishField.Text);
      cmd.Parameters.AddWithValue("@nameArabic", nameArabicField.Text);
      cmd.Parameters.AddWithValue("@mainColor", mainColorField.Text);
      cmd.Parameters.AddWithValue("@accentColor", accentColorField.Text);
      cmd.Parameters.AddWithValue("@textColor", textColorField.Text);
      cmd.Parameters.AddWithValue("@restaurantId", restaurant_id);

      // add UploadLogo image
      MemoryStream ms = new MemoryStream();
      LogoUpload.Image.Save(ms, LogoUpload.Image.RawFormat);
      byte[] img = ms.ToArray();
      cmd.Parameters.AddWithValue("@logo", img);

      string sqlString = "UPDATE restaurant_info SET name_english = @nameEnglish, name_arabic = @nameArabic, main_color = @mainColor, accent_color = @accentColor, text_color = @textColor, logo = @logo WHERE restaurant_id = @restaurantId";

      db.ExecuteQuery(sqlString);

      // close connection
      db.CloseConnection();

      // popup success
      MessageBox.Show("Restaurant info updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    } 

    private void mainColorField_TextChanged(object sender, EventArgs e)
    {
      try
      {
        // take color from mainColorField and set it to mainColorBox
        mainColorBox.BackColor = ColorTranslator.FromHtml(mainColorField.Text);
      }
      catch
      {
      }
    }

    private void accentColorField_TextChanged(object sender, EventArgs e)
    {
      try
      {
        // take color from accentColorField and set it to accentColorBox
        accentColorBox.BackColor = ColorTranslator.FromHtml(accentColorField.Text);
      }
      catch
      {
      }
    }

    private void textColorField_TextChanged(object sender, EventArgs e)
    {
      try
      {
        // take color from textColorField and set it to textColorBox
        textColorBox.BackColor = ColorTranslator.FromHtml(textColorField.Text);
      }
      catch
      {
      }
    }

    private void submitDataAnalyzerButton_Click(object sender, EventArgs e)
    {
      UpdateItemIdDictionary();

      // clear data in columnChart Rating
      columnChart.Series["Rating"].Points.Clear();

      // clear data in pieChart SalesBreakdown
      pieChart.Series["SalesBreakdown"].Points.Clear();

      // clear series in lineChart
      lineChart.Series.Clear();

      // clear order data table
      orders.Rows.Clear();

      // clear item data table
      orderItems.Rows.Clear();

      // disable dataExporterButton
      dataExporterButton.Enabled = false;

      // create a dynamic list that will hold menu items to filter
      List<string> menuItems = new List<string>();

      // check if items to analyze is empty
      if(itemsToAnalyzeInput.Text == "")
      {
        // add all item id from dictionary (item_id_to_name) to menuItems
        foreach (KeyValuePair<string, string> entry in item_id_to_name)
        {
          menuItems.Add(entry.Key);
        }
      }
      else
      {
        string itemsToAnalyzeInputString = itemsToAnalyzeInput.Text;
        string itemsNotFound = "";

        // for each item in itemsToAnalyzeInput separated by comma
        foreach (string item in itemsToAnalyzeInputString.Split(','))
        {
          // trim value
          string trimmedItem = item.Trim();

          // check if item_name (value) exists in item_id_to_name dictionary
          if (item_id_to_name.ContainsValue(trimmedItem))
          {
            // add item_id (key) to menuItems
            menuItems.Add(item_id_to_name.FirstOrDefault(x => x.Value.Equals(trimmedItem, StringComparison.OrdinalIgnoreCase)).Key);
          }
          else
          {
            // check if a similar item_name exists in item_id_to_name dictionary
            bool similarItemFound = item_id_to_name.Any(x => x.Value.Equals(trimmedItem, StringComparison.OrdinalIgnoreCase));

            if (similarItemFound)
            {
              // add item_id (key) to menuItems
              menuItems.Add(item_id_to_name.FirstOrDefault(x => x.Value.Equals(trimmedItem, StringComparison.OrdinalIgnoreCase)).Key);
            }
            else
            {
              // add item to itemsNotFound
              itemsNotFound += trimmedItem + ", ";
            }
          }
        }

        // check if itemsNotFound is not empty
        if (!itemsNotFound.Equals(""))
        {
          // remove last comma
          itemsNotFound = itemsNotFound.Remove(itemsNotFound.Length - 2);

          // popup error
          MessageBox.Show("Error: Items not found: " + itemsNotFound, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

          return;
        }
      }

      // check if menuItems is empty
      if (menuItems.Count == 0)
      {
        // popup error
        MessageBox.Show("Error: No items to analyze", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        return;
      }

      // get start date
      DateTime startDate = dataStartRangeDateTime.Value;

      // get end date
      DateTime endDate = dataEndRangeDateTime.Value;

      // create new dictionary list that holds date and rating count
      Dictionary<DateTime, int> dateRatingCount = new Dictionary<DateTime, int>();

      // create new dictionary list that holds date and rating sum
      Dictionary<DateTime, int> dateRatingSum = new Dictionary<DateTime, int>();

      // create new dictionary list that holds date and a dictionary list that holds item id and sales count
      Dictionary<DateTime, Dictionary<string, int>> dateItemSalesCount = new Dictionary<DateTime, Dictionary<string, int>>();

      // add x axis as each month from start date to end date
      for (DateTime date = startDate; date <= endDate; date = date.AddMonths(1))
      {
        // add date and 0 to dateRatingCount
        dateRatingCount.Add(date, 0);

        // add date and 0 to dateRatingSum
        dateRatingSum.Add(date, 0);

        // create new dictionary list that holds item id and sales count
        Dictionary<string, int> itemSalesCount = new Dictionary<string, int>();

        // add each menu item to itemSalesCount
        foreach (string item in menuItems)
        {
          // get item name from item_id_to_name dictionary
          string itemName = item_id_to_name[item];

          // add item name and 0 to itemSalesCount
          itemSalesCount.Add(itemName, 0);
        }

        // add date and itemSalesCount to dateItemSalesCount
        dateItemSalesCount.Add(date, itemSalesCount);
      }

      // set y axis range
      columnChart.ChartAreas[0].AxisY.Minimum = 1;
      columnChart.ChartAreas[0].AxisY.Maximum = 5;

      columnChart.ChartAreas[0].AxisX2.Enabled = AxisEnabled.False;
      columnChart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.False;

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from database
      SqlCommand cmd = db.Command;

      // clear paramter
      cmd.Parameters.Clear();

      // create new dynamic list that hold order ids in data range
      List<string> orderIds = new List<string>();

      // get start date in string format
      string startDateString = startDate.ToString("yyyy-MM-dd");

      // get end date in string format
      string endDateString = endDate.ToString("yyyy-MM-dd");

      // get branch_id from DoneSetup.txt
      branch_id = File.ReadAllText("DoneSetup.txt");

      // get all order ids in data range where status is complete, and filter orders without selected menu items
      string sqlString = "SELECT * FROM orders WHERE branch_id = @branchId AND order_time BETWEEN @startDate AND @endDate AND status = 'complete' AND EXISTS (SELECT 1 FROM customer_order_items WHERE customer_order_items.order_id = orders.order_id AND item_id IN (" + string.Join(",", menuItems) + "))";

      // add branch_id
      cmd.Parameters.AddWithValue("@branchId", branch_id);
      // add startDate
      cmd.Parameters.AddWithValue("@startDate", startDateString);
      // add endDate
      cmd.Parameters.AddWithValue("@endDate", endDateString);

      // execute query
      SqlDataReader reader = db.ExecuteQuery(sqlString);

      // check if there are rows in the database
      if (reader.HasRows)
      {
        // read all rows
        while (reader.Read())
        {
          // add order_id to orderIds
          orderIds.Add(reader["order_id"].ToString());

          // get date of order
          DateTime orderDate = DateTime.Parse(reader["order_time"].ToString());

          // reset date to first day of month
          orderDate = new DateTime(orderDate.Year, orderDate.Month, 1);

          // get rating of order
          int orderRating = int.Parse(reader["rating"].ToString());

          // check if dateRatingCount contains orderDate
          if (dateRatingCount.ContainsKey(orderDate))
          {
            // increment dateRatingCount
            dateRatingCount[orderDate]++;

            // add orderRating to dateRatingSum
            dateRatingSum[orderDate] += orderRating;
          }

          // get date again
          orderDate = DateTime.Parse(reader["order_time"].ToString());
          
          // store total price in double
          double totalPrice = double.Parse(reader["total_price"].ToString());

          // check if start prepare time is not null
          if (reader["start_prepare_time"] != DBNull.Value)
          {
            // store start prepare time in DateTime
            DateTime startPrepareTime = DateTime.Parse(reader["start_prepare_time"].ToString());

            // check if end prepare time is not null
            if (reader["end_prepare_time"] != DBNull.Value)
            {
              // store end prepare time in DateTime
              DateTime endPrepareTime = DateTime.Parse(reader["end_prepare_time"].ToString());

              // add order to orders data table
              orders.Rows.Add(reader["order_id"].ToString(), reader["branch_id"].ToString(), orderDate, orderRating, totalPrice, startPrepareTime, endPrepareTime);
            }
            else
            {
              // add order to orders data table
              orders.Rows.Add(reader["order_id"].ToString(), reader["branch_id"].ToString(), orderDate, orderRating, totalPrice, startPrepareTime, DBNull.Value);
            }
          }
          else
          {
            // add order to orders data table
            orders.Rows.Add(reader["order_id"].ToString(), reader["branch_id"].ToString(), orderDate, orderRating, totalPrice, DBNull.Value, DBNull.Value);
          }
        }
      }
      else
      {
        // popup error
        MessageBox.Show("Error: No data found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // close connection
        db.CloseConnection();

        return;
      }

      // close connection
      db.CloseConnection();

      // add data to columnChart Rating
      foreach (KeyValuePair<DateTime, int> entry in dateRatingSum)
      {
        // get date
        DateTime date = entry.Key;

        // get rating sum
        int ratingSum = entry.Value;

        // get rating count
        int ratingCount = dateRatingCount[date];

        // calculate average rating
        double averageRating = Math.Round((double)ratingSum / ratingCount, 2);

        // add data to columnChart Rating
        columnChart.Series["Rating"].Points.AddXY(date.ToString("MMM yyyy"), averageRating);
      }

      // clear cmd params
      cmd.Parameters.Clear();

      // get all order items in order list
      sqlString = "SELECT customer_order_items.*, orders.order_time FROM customer_order_items INNER JOIN orders ON customer_order_items.order_id = orders.order_id WHERE customer_order_items.order_id IN (" + string.Join(",", orderIds) + ")";

      // execute query
      reader = db.ExecuteQuery(sqlString);

      // check if there are rows in the database
      if (reader.HasRows)
      {
        // read all rows
        while (reader.Read())
        {
          // get item id
          string itemId = reader["item_id"].ToString();

          // get item name
          string itemName = item_id_to_name[itemId];

          // get item quantity
          int itemQuantity = int.Parse(reader["quantity"].ToString());

          // check if itemQuantity is more than 0
          if (itemQuantity > 0)
          {
            // add data to pieChart
            bool itemExists = false;

            // check if pieChart already has item name in series SalesBreakdown
            foreach(DataPoint dataPoint in pieChart.Series["SalesBreakdown"].Points)
            {
              // check if dataPoint has same item name
              if (dataPoint.AxisLabel.Equals(itemName))
              {
                // add itemQuantity to dataPoint
                dataPoint.YValues[0] += itemQuantity;

                // set itemExists to true
                itemExists = true;

                // exit loop
                break;
              }
            }

            // check if itemExists is false
            if (!itemExists)
            {
              // add item name and itemQuantity to pieChart
              pieChart.Series["SalesBreakdown"].Points.AddXY(itemName, itemQuantity);
            }
          }

          // get date of order
          DateTime orderDate = DateTime.Parse(reader["order_time"].ToString());

          // reset date to first day of month
          orderDate = new DateTime(orderDate.Year, orderDate.Month, 1);

          // check if dateItemSalesCount contains orderDate
          if (dateItemSalesCount.ContainsKey(orderDate))
          {
            // check if dateItemSalesCount[orderDate] contains itemName
            if (dateItemSalesCount[orderDate].ContainsKey(itemName))
            {
              // increment dateItemSalesCount
              dateItemSalesCount[orderDate][itemName] += itemQuantity;
            }
            else
            {
              // add itemName to dateItemSalesCount
              dateItemSalesCount[orderDate].Add(itemName, itemQuantity);
            }
          }

          // add order item to orderItems data table
          orderItems.Rows.Add(reader["order_id"].ToString(), itemName, itemQuantity, reader["description"].ToString());
        }
      }

      // close connection
      db.CloseConnection();

      // shows quantity for each item in pieChart
      pieChart.Series["SalesBreakdown"].IsValueShownAsLabel = true;

      // get total sales (number of items sold)
      int totalSales = 0;

      // get total sales (number of items sold)
      foreach (DataPoint dataPoint in pieChart.Series["SalesBreakdown"].Points)
      {
        // add dataPoint to totalSales
        totalSales += (int)dataPoint.YValues[0];
      }

      // add percentages to pieChart
      foreach (DataPoint dataPoint in pieChart.Series["SalesBreakdown"].Points)
      {
        // get item quantity
        int itemQuantity = (int)dataPoint.YValues[0];

        // calculate percentage
        double percentage = Math.Round((double)itemQuantity / totalSales * 100, 2);

        // set dataPoint label to item name, quantity, and percentage
        dataPoint.Label = dataPoint.AxisLabel + " (" + itemQuantity + ", " + percentage + "%)";
      }

      // add data to lineChart, create a series for each item, x is date, y is quantity
      foreach (KeyValuePair<DateTime, Dictionary<string, int>> entry in dateItemSalesCount)
      {
        // get date
        DateTime date = entry.Key;

        // get item sales count
        Dictionary<string, int> itemSalesCount = entry.Value;

        // add data to lineChart
        foreach (KeyValuePair<string, int> itemEntry in itemSalesCount)
        {
          // get item name
          string itemName = itemEntry.Key;

          // get item quantity
          int itemQuantity = itemEntry.Value;

          // check if lineChart already has series with item name
          bool seriesExists = false;

          // check if lineChart already has series with item name
          foreach (Series series in lineChart.Series)
          {
            // check if series has same name as itemName
            if (series.Name.Equals(itemName))
            {
              // add dataPoint to series
              series.Points.AddXY(date.ToString("MMM yyyy"), itemQuantity);

              // set seriesExists to true
              seriesExists = true;

              // exit loop
              break;
            }
          }

          // check if seriesExists is false
          if (!seriesExists)
          {
            // create new series
            Series series = new Series();

            // set series name to itemName
            series.Name = itemName;

            // set series chart type to line
            series.ChartType = SeriesChartType.Line;

            // add dataPoint to series
            series.Points.AddXY(date.ToString("MMM yyyy"), itemQuantity);

            // add series to lineChart
            lineChart.Series.Add(series);
          }
        }
      }

      // enable dataExporterButton
      dataExporterButton.Enabled = true;
    }

    private void dataExporterButton_Click(object sender, EventArgs e)
    {
      // Create a new Excel package
      using (ExcelPackage package = new ExcelPackage())
      {
        // Create a worksheet for the "Orders" table
        ExcelWorksheet ordersWorksheet = package.Workbook.Worksheets.Add("Orders");

        // Load the data from the "orders" DataTable to the "Orders" worksheet
        ordersWorksheet.Cells["A1"].LoadFromDataTable(orders, true);

        // Create a worksheet for the "Order Items" table
        ExcelWorksheet orderItemsWorksheet = package.Workbook.Worksheets.Add("Ordered Items");

        // Load the data from the "orderItems" DataTable to the "Order Items" worksheet
        orderItemsWorksheet.Cells["A1"].LoadFromDataTable(orderItems, true);

        // Convert the date values in the "Orders" worksheet to the desired format
        for (int row = 2; row <= ordersWorksheet.Dimension.End.Row; row++)
        {
          DateTime orderDateTime = (DateTime)ordersWorksheet.Cells[row, 3].Value;
          ordersWorksheet.Cells[row, 3].Value = orderDateTime.ToString("yyyy-MM-dd HH:mm:ss");

          if (ordersWorksheet.Cells[row, 6].Value != null)
          {
            DateTime preparingStartDateTime = (DateTime)ordersWorksheet.Cells[row, 6].Value;
            ordersWorksheet.Cells[row, 6].Value = orderDateTime.ToString("yyyy-MM-dd HH:mm:ss");
          }

          if (ordersWorksheet.Cells[row, 7].Value != null)
          {
            DateTime preparingStartDateTime = (DateTime)ordersWorksheet.Cells[row, 7].Value;
            ordersWorksheet.Cells[row, 7].Value = orderDateTime.ToString("yyyy-MM-dd HH:mm:ss");
          }
        }

        // Set the table style for both worksheets
        ExcelRange ordersTableRange = ordersWorksheet.Cells[ordersWorksheet.Dimension.Address];
        ExcelTable ordersTable = ordersWorksheet.Tables.Add(ordersTableRange, "OrdersTable");
        ordersTable.TableStyle = OfficeOpenXml.Table.TableStyles.Light1;

        ExcelRange orderItemsTableRange = orderItemsWorksheet.Cells[orderItemsWorksheet.Dimension.Address];
        ExcelTable orderItemsTable = orderItemsWorksheet.Tables.Add(orderItemsTableRange, "OrderItemsTable");
        orderItemsTable.TableStyle = OfficeOpenXml.Table.TableStyles.Light1;

        // Set column autofit for "Orders" worksheet
        ordersWorksheet.Cells[ordersWorksheet.Dimension.Address].AutoFitColumns();

        // Set column autofit for "Order Items" worksheet
        orderItemsWorksheet.Cells[orderItemsWorksheet.Dimension.Address].AutoFitColumns();

        // Save the Excel file locally to a new folder called "Exports"
        // Check if the directory exists
        if (!Directory.Exists("Exports"))
        {
          // Create the directory if it doesn't exist
          Directory.CreateDirectory("Exports");
        }

        // Generate a unique file name based on the current timestamp
        string fileName = "Exports/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xlsx";

        // Save the Excel file
        FileInfo fileInfo = new FileInfo(fileName);
        package.SaveAs(fileInfo);

        // remove Exports/ from filename
        string fileNameWithoutExports = fileName.Substring(8);

        // Open the directory containing the saved file
        Process.Start(fileInfo.Directory.FullName + "\\" + fileNameWithoutExports);
      }
    }
  }
}
