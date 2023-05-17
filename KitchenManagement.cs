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
  public partial class KitchenManagement : Form
  {
    bool isAdmin = true;
    bool isLock = false;

    private string branch_id;
    private string restaurant_id;

    public KitchenManagement()
    {
      InitializeComponent();
    }

    private void KitchenManagement_Load(object sender, EventArgs e)
    {
      CompleteOrder.Enabled = false;
      ConfirmOrder.Enabled = false;
      CancelOrder.Enabled = false;

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

    private void PendingOrdersTabs_SelectedIndexChanged(object sender, EventArgs e)
    {
      foreach (TabPage tab in PendingOrdersTabs.TabPages)
      {
        tab.Enabled = false;
      }
        (PendingOrdersTabs.TabPages[PendingOrdersTabs.SelectedIndex] as TabPage).Enabled = true;
    }

    private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      isAdmin = false;
    }

    private void RetrieveOrdersList_Click(object sender, EventArgs e)
    {
      //OrdersList.Items.Clear();

      //con.Open();
      //cmd.Connection = con;
      //cmd.CommandText = "SELECT id FROM orders where status='pending' OR status='preparing'";
      //dr = cmd.ExecuteReader();

      //if (dr.HasRows)
      //{
      //  while (dr.Read())
      //  {
      //    OrdersList.Items.Add(dr["id"]);
      //  }
      //}

      //dr.Close();
      //con.Close();
    }

    private void OrdersList_SelectedIndexChanged(object sender, EventArgs e)
    {
      //ReviewGroupBox.Enabled = true;
      //OrderedItemsList.Items.Clear();

      //string lines = "";

      //con.Open();
      //cmd.Connection = con;
      //cmd.CommandText = "SELECT * FROM orders where id=" + OrdersList.SelectedItem;
      //try
      //{
      //  dr = cmd.ExecuteReader();
      //}
      //catch (SQLiteException)
      //{
      //  MessageBox.Show("Connection with database was cut, reconnecting...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      //}

      //try
      //{
      //  var check = dr.HasRows;
      //}
      //catch (InvalidOperationException)
      //{
      //  dr.Close();
      //  con.Close();
      //  return;
      //}

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
      //          OrderedItemsList.Items.Add($"{line.Substring(found + 1, i)}x {line.Substring(0, found)}");

      //          total += (float.Parse(line.Substring(found2 + 1)) * int.Parse(line.Substring(found + 1, i)));
      //        }
      //      }
      //      catch (ArgumentOutOfRangeException)
      //      {
      //        MessageBox.Show("Error: no items found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //      }
      //      finally { }
      //    }

      //    PriceNumber.Text = $"{total:0.00} JD";

      //    if (dr["status"].Equals("preparing"))
      //    {
      //      StatusLabel.Text = "Status: Preparing";
      //      ConfirmOrder.Enabled = false;
      //      CancelOrder.Enabled = true;
      //      CompleteOrder.Enabled = true;
      //    }
      //    else
      //    {
      //      StatusLabel.Text = "Status: Pending";
      //      CompleteOrder.Enabled = false;
      //      ConfirmOrder.Enabled = true;
      //      CancelOrder.Enabled = true;
      //    }
      //  }
      //}

      //dr.Close();
      //con.Close();
    }

    private void ConfirmOrder_Click(object sender, EventArgs e)
    {
      //var res = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      //if (res == DialogResult.No)
      //{
      //  return;
      //}

      //con.Open();
      //cmd.Connection = con;
      //cmd.CommandText = "UPDATE orders SET status='preparing' where id=" + OrdersList.SelectedItem;

      //int rowsAffected = cmd.ExecuteNonQuery();
      //if (rowsAffected == 0)
      //  MessageBox.Show("Error... Record not modified.");
      //else
      //{
      //  MessageBox.Show("Order confirmed successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //}

      //con.Close();

      //RetrieveOrdersList_Click(this, new EventArgs());
      //ReviewGroupBox.Enabled = false;
    }

    private void CancelOrder_Click(object sender, EventArgs e)
    {
      //var res = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      //if (res == DialogResult.No)
      //{
      //  return;
      //}

      //con.Open();
      //cmd.Connection = con;
      //cmd.CommandText = "UPDATE orders SET status='cancelled' where id=" + OrdersList.SelectedItem;

      //int rowsAffected = cmd.ExecuteNonQuery();
      //if (rowsAffected == 0)
      //  MessageBox.Show("Error... Record not modified.");
      //else
      //{
      //  MessageBox.Show("Order confirmed successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //}

      //con.Close();

      //RetrieveOrdersList_Click(this, new EventArgs());
      //ReviewGroupBox.Enabled = false;
    }

    private void CompleteOrder_Click(object sender, EventArgs e)
    {
      //var res = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      //if (res == DialogResult.No)
      //{
      //  return;
      //}

      //con.Open();
      //cmd.Connection = con;
      //cmd.CommandText = "UPDATE orders SET status='complete' where id=" + OrdersList.SelectedItem;

      //int rowsAffected = cmd.ExecuteNonQuery();
      //if (rowsAffected == 0)
      //  MessageBox.Show("Error... Record not modified.");
      //else
      //{
      //  MessageBox.Show("Order confirmed successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //}

      //con.Close();

      //RetrieveOrdersList_Click(this, new EventArgs());
      //ReviewGroupBox.Enabled = false;
    }

    private void KitRetrieveOrders_Click(object sender, EventArgs e)
    {
      //KitOrdersList.Items.Clear();

      //con.Open();
      //cmd.Connection = con;
      //cmd.CommandText = "SELECT id FROM orders where status='pending' OR status='preparing'";
      //dr = cmd.ExecuteReader();

      //if (dr.HasRows)
      //{
      //  while (dr.Read())
      //  {
      //    KitOrdersList.Items.Add(dr["id"]);
      //  }
      //}

      //dr.Close();
      //con.Close();
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

      // create database handler
      DatabaseHandler db = new DatabaseHandler();

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
      // create database handler
      DatabaseHandler db = new DatabaseHandler();

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

      // create database handler
      DatabaseHandler db = new DatabaseHandler();

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

      // create database handler
      DatabaseHandler db = new DatabaseHandler();

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

      // create database handler
      DatabaseHandler db = new DatabaseHandler();

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

      // create database handler
      DatabaseHandler db = new DatabaseHandler();

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

      // create database handler
      DatabaseHandler db = new DatabaseHandler();

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

      // create database handler
      DatabaseHandler db = new DatabaseHandler();

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
        // create database handler
        DatabaseHandler db = new DatabaseHandler();

        // get cmd from database
        SqlCommand cmd = db.Command;

        // clear cmd
        cmd.Parameters.Clear();

        // read branch_id from DoneSetup.txt
        branch_id = File.ReadAllText("DoneSetup.txt");

        // add parameters
        cmd.Parameters.AddWithValue("@name_english", ItemNameInput.Text);
        cmd.Parameters.AddWithValue("@name_arabic", ItemArabicNameInput.Text);
        cmd.Parameters.AddWithValue("@description_english", ItemEnglishDescriptionInput.Text);
        cmd.Parameters.AddWithValue("@description_arabic", ItemArabicDescriptionInput.Text);
        cmd.Parameters.AddWithValue("@price", ItemPriceInput.Value);
        cmd.Parameters.AddWithValue("@category", ItemCategoryInput.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@image", File.ReadAllBytes(open2.FileName));
        cmd.Parameters.AddWithValue("@branch_id", branch_id);

        // set command text
        cmd.CommandText = "INSERT INTO menu_items (name_english, name_arabic, description_english, description_arabic, price, category, image, branch_id) VALUES (@name_english, @name_arabic, @description_english, @description_arabic, @price, @category, @image, @branch_id)";

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
        // create database handler
        DatabaseHandler db = new DatabaseHandler();

        // get cmd from database
        SqlCommand cmd = db.Command;

        // clear cmd
        cmd.Parameters.Clear();

        // read branch_id from DoneSetup.txt
        branch_id = File.ReadAllText("DoneSetup.txt");

        // add parameters
        cmd.Parameters.AddWithValue("@name_english", ItemNameInput.Text);
        cmd.Parameters.AddWithValue("@name_arabic", ItemArabicNameInput.Text);
        cmd.Parameters.AddWithValue("@description_english", ItemEnglishDescriptionInput.Text);
        cmd.Parameters.AddWithValue("@description_arabic", ItemArabicDescriptionInput.Text);
        cmd.Parameters.AddWithValue("@price", ItemPriceInput.Value);
        cmd.Parameters.AddWithValue("@category", ItemCategoryInput.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@image", File.ReadAllBytes(open2.FileName));
        cmd.Parameters.AddWithValue("@branch_id", branch_id);
        cmd.Parameters.AddWithValue("@id", (MenuItemsList.SelectedItem.ToString()).Substring(0, MenuItemsList.SelectedItem.ToString().IndexOf('.')));

        // set command text
        cmd.CommandText = "UPDATE menu_items SET name_english = @name_english, name_arabic = @name_arabic, description_english = @description_english, description_arabic = @description_arabic, price = @price, category = @category, image = @image WHERE item_id = @id";

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
      SpecialDealsRadio_CheckedChanged(this, new EventArgs());
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
    }

    private void DeleteItem_Click(object sender, EventArgs e)
    {
      DialogResult res = MessageBox.Show("Are you sure you want to delete item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (res == DialogResult.No)
        return;

      // create database handler
      DatabaseHandler db = new DatabaseHandler();

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
      // create database handler
      DatabaseHandler db = new DatabaseHandler();

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

      // create database handler
      DatabaseHandler db = new DatabaseHandler();

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
      catch (Exception)
      {
        MessageBox.Show("Error: Invalid color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void accentColorField_TextChanged(object sender, EventArgs e)
    {
      try
      {
        // take color from accentColorField and set it to accentColorBox
        accentColorBox.BackColor = ColorTranslator.FromHtml(accentColorField.Text);
      }
      catch (Exception)
      {
        MessageBox.Show("Error: Invalid color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void textColorField_TextChanged(object sender, EventArgs e)
    {
      try
      {
        // take color from textColorField and set it to textColorBox
        textColorBox.BackColor = ColorTranslator.FromHtml(textColorField.Text);
      }
      catch (Exception)
      {
        MessageBox.Show("Error: Invalid color", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}
