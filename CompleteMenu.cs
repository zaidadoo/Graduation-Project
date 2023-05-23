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
using System.IO;
using System.Text.RegularExpressions;

namespace Restaurant_Contactless_Dining_System
{
  public partial class CompleteMenu : UserControl
  {
    public static Order currentOrder;
    private static bool englishLanguage = true;

    private string restaurant_id = "";
    private string restaurant_name = "";
    private string branch_id = "";
    private int table_count = 0;

    string mainColor = "";
    string accentColor = "";
    string lighterColor = "";
    string textColor = "";

    public CompleteMenu()
    {
      InitializeComponent();
    }

    public void setLanguage(bool isEnglish)
    {
      englishLanguage = isEnglish;
      loaderHelper();
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
      DialogResult confirmation;

      if(englishLanguage)
        confirmation = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
      else
        confirmation = MessageBox.Show("هل أنت متأكد؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

      if (confirmation == DialogResult.Yes)
      {
        DisplayItems.Controls.Clear();
        currentOrder.ClearAll();
        this.Hide();
      }
    }

    public void currentOrder_Tick()
    {
      int i = 0;
      OrderedItems.Controls.Clear();

      while (i < currentOrder.size)
      {
        OrderedItem current = new OrderedItem();

        current.IDItem = i;

        current.NameItem = currentOrder.items[i];
        current.NotesItem = currentOrder.notes[i];

        current.PriceItem = currentOrder.price[i] * currentOrder.quantity[i];
        current.QuantityItem = currentOrder.quantity[i];

        current.EnglishLang = englishLanguage;

        current.AccentColor = accentColor;
        current.LighterColor = lighterColor;
        current.TextColor = textColor;

        OrderedItems.Controls.Add(current);
        i++;
      }

      if(englishLanguage)
        TotalPriceLabel.Text = $"Total: {currentOrder.GetTotal():0.00}";
      else
        TotalPriceLabel.Text = $"المجموع: {currentOrder.GetTotal():0.00}";
    }

    byte[] logoBytes = null;

    private void CompleteMenu_Load(object sender, EventArgs e)
    {
    }

    private void loaderHelper()
    {
      // create a new order object
      currentOrder = new Order();
      currentOrder.setParent = this;

      // call starter item button
      StarterItemsButton_Click(this, new EventArgs());

      OrderedItems.HorizontalScroll.Visible = false;

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;
      cmd.Parameters.Clear();

      // get branch_id from DoneSetup.txt
      branch_id = File.ReadAllText("DoneSetup.txt");

      // add parameters
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      string sqlString = "SELECT * FROM branch WHERE branch_id = @branch_id";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      int numOfTables = 0;

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          // get restaurant_id
          restaurant_id = dr["restaurant_id"].ToString();

          numOfTables = Convert.ToInt32(dr["number_of_tables"]);
        }
      }

      // close connection
      db.CloseConnection();

      table_count = numOfTables;

      UpdateNumOfTables(numOfTables);
      updateColors();
      updateLanguage();
    }

    private void UpdateNumOfTables(int num)
    {
      if(num == 0)
      {
        // disable dine in button
        dineInButton.Enabled = false;

        return;
      }

      // clear tableComboBox
      tableComboBox.Items.Clear();

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;

      // clear parameters
      cmd.Parameters.Clear();

      // add parameters
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      // get all orders from database that are pending or preparing
      string sqlString = "SELECT * FROM orders WHERE branch_id = @branch_id AND (status = 'pending' OR status = 'preparing')";

      // create a resizable list of order ids
      int[] orderIDs = new int[num];
      int size = 0;

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          orderIDs[size] = Convert.ToInt32(dr["order_id"]);
          size++;
        }
      }

      // close connection
      db.CloseConnection();

      // resizable occuppied tables list
      int[] occuppiedTables = new int[size];
      int sizeTables = 0;

      // iterate through order ids
      for (int i = 0; i < size; i++)
      {
        // clear parameters
        cmd.Parameters.Clear();

        // add parameters
        cmd.Parameters.AddWithValue("@order_id", orderIDs[i]);

        // get all orders from database that are pending or preparing
        sqlString = "SELECT * FROM dine_in_orders WHERE order_id = @order_id";

        dr = db.ExecuteQuery(sqlString);

        if (dr.HasRows)
        {
          while (dr.Read())
          {
            occuppiedTables[sizeTables] = Convert.ToInt32(dr["table_number"]);
            sizeTables++;
          }
        }

        // close connection
        db.CloseConnection();
      }

      // populate tableComboBox with num
      for (int i = 1; i <= num; i++)
      {
        if (!occuppiedTables.Contains(i))
        {
          if(englishLanguage)
            tableComboBox.Items.Add($"Table {i}");
          else
            tableComboBox.Items.Add($"طاولة {i}");
        }
      }
    }

    private void updateLanguage()
    {
      if(englishLanguage)
      {
        SpecialDealsButton.Text = "Promotions";
        StarterItemsButton.Text = "Starter Items";
        MainItemsButton.Text = "Main Items";
        DessertsButton.Text = "Desserts";
        ExtraItemsButton.Text = "Extra Items";
        Title.Text = "Your Order";
        TotalPriceLabel.Text = "Total:";
        ClearAllButton.Text = "Clear All";
        ExitButton.Text = "Back";
        dineInButton.Text = "Dine In";
        takeOutButton.Text = "Take Out";
        dineInNote.Text = "Please select table number if dining in.";

        Title.RightToLeft = RightToLeft.No;
        CategoryTitle.RightToLeft = RightToLeft.No;
        TotalPriceLabel.RightToLeft = RightToLeft.No;
        dineInNote.RightToLeft = RightToLeft.No;
      }
      else
      {
        // set arabic
        SpecialDealsButton.Text = "العروض";
        StarterItemsButton.Text = "المقبلات";
        MainItemsButton.Text = "الأطباق الرئيسية";
        DessertsButton.Text = "الحلويات";
        ExtraItemsButton.Text = "الإضافات";
        Title.Text = "طلبك";
        TotalPriceLabel.Text = "المجموع:";
        ClearAllButton.Text = "مسح";
        ExitButton.Text = "رجوع";
        dineInButton.Text = "في المطعم";
        takeOutButton.Text = "خارج المطعم";
        dineInNote.Text = "الرجاء اختيار رقم الطاولة.";

        Title.RightToLeft = RightToLeft.Yes;
        CategoryTitle.RightToLeft = RightToLeft.Yes;
        TotalPriceLabel.RightToLeft = RightToLeft.Yes;
        dineInNote.RightToLeft = RightToLeft.Yes;
      }
    }

    private void updateColors()
    {
      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;
      cmd.Parameters.Clear();

      // add parameters
      cmd.Parameters.AddWithValue("@restaurant_id", restaurant_id);

      string sqlString = "SELECT * FROM restaurant_info WHERE restaurant_id = @restaurant_id";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          // get restaurant name
          restaurant_name = dr["name_english"].ToString();

          // get main color
          mainColor = dr["main_color"].ToString();

          // get accent color
          accentColor = dr["accent_color"].ToString();

          // get text color
          textColor = dr["text_color"].ToString();

          if (dr["logo"] != null && !Convert.IsDBNull(dr["logo"]))
          {
            logoBytes = (byte[])dr["logo"];
          }
        }
      }

      MemoryStream ms = new MemoryStream(logoBytes);
      Image finalImage = Image.FromStream(ms);

      LogoFrame.Image = finalImage;

      // close connection
      db.CloseConnection();

      // set main colors
      this.BackColor = ColorTranslator.FromHtml(mainColor);

      // set accent colors
      CategoryMenu.BackColor = ColorTranslator.FromHtml(accentColor);
      Tab.BackColor = ColorTranslator.FromHtml(accentColor);
      OrderPanel.BackColor = ColorTranslator.FromHtml(accentColor);
      SelectedItem.BackColor = ColorTranslator.FromHtml(accentColor);
      ExitButton.BackColor = ColorTranslator.FromHtml(accentColor);

      // set text colors
      CategoryTitle.ForeColor = ColorTranslator.FromHtml(textColor);
      Title.ForeColor = ColorTranslator.FromHtml(textColor);
      TotalPriceLabel.ForeColor = ColorTranslator.FromHtml(textColor);
      ExitButton.ForeColor = ColorTranslator.FromHtml(textColor);
      dineInButton.ForeColor = ColorTranslator.FromHtml(textColor);
      ClearAllButton.ForeColor = ColorTranslator.FromHtml(textColor);
      SpecialDealsButton.ForeColor = ColorTranslator.FromHtml(textColor);
      StarterItemsButton.ForeColor = ColorTranslator.FromHtml(textColor);
      MainItemsButton.ForeColor = ColorTranslator.FromHtml(textColor);
      DessertsButton.ForeColor = ColorTranslator.FromHtml(textColor);
      ExtraItemsButton.ForeColor = ColorTranslator.FromHtml(textColor);
      takeOutButton.ForeColor = ColorTranslator.FromHtml(textColor);
      tableComboBox.ForeColor = ColorTranslator.FromHtml(textColor);
      dineInNote.ForeColor = ColorTranslator.FromHtml(textColor);

      // create a lighter color by 10%
      Color lighterAccent = ColorTranslator.FromHtml(accentColor);
      lighterAccent = ControlPaint.Light(lighterAccent, 0.1f);
      lighterColor = ColorTranslator.ToHtml(lighterAccent);

      // set lighter accent colors
      dineInButton.BackColor = lighterAccent;
      takeOutButton.BackColor = lighterAccent;
      ClearAllButton.BackColor = lighterAccent;
      SpecialDealsButton.BackColor = lighterAccent;
      StarterItemsButton.BackColor = lighterAccent;
      MainItemsButton.BackColor = lighterAccent;
      DessertsButton.BackColor = lighterAccent;
      ExtraItemsButton.BackColor = lighterAccent;
      ExitButton.BackColor = lighterAccent;
      tableComboBox.BackColor = lighterAccent;
    }

    public void retrieveItems(string catName)
    {
      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;

      // clear cmd parameters
      cmd.Parameters.Clear();

      // add parameters
      cmd.Parameters.AddWithValue("@category", catName);
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      string sqlString = "SELECT * FROM menu_items WHERE category = @category AND branch_id = @branch_id";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      DisplayItems.Controls.Clear();

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          MenuItem current = new MenuItem();

          if(englishLanguage)
            current.NameItem = dr["name_english"].ToString();
          else
            current.NameItem = dr["name_arabic"].ToString();

          if(englishLanguage)
            current.DescriptionItem = dr["description_english"].ToString();
          else
            current.DescriptionItem = dr["description_arabic"].ToString();

          current.AccentColor = accentColor;
          current.LighterColor = lighterColor;
          current.TextColor = textColor;

          current.PriceItem = $"{dr["price"]:0.00}";

          current.DatabaseID = Convert.ToInt32(dr["item_id"]);

          current.EnglishLang = englishLanguage;

          DisplayItems.Controls.Add(current);

          if (dr["image"] != null && !Convert.IsDBNull(dr["image"]))
          {
            logoBytes = (byte[])dr["image"];
          }

          MemoryStream ms = new MemoryStream(logoBytes);
          Image finalImage = Image.FromStream(ms);
          current.ImageItem = finalImage;
        }
      }

      // close connection
      db.CloseConnection();
    }

    private void StarterItemsButton_Click(object sender, EventArgs e)
    {
      SelectedItem.Show();
      SelectedItem.Top = StarterItemsButton.Top;

      if(englishLanguage)
        CategoryTitle.Text = "Starter Items";
      else
        CategoryTitle.Text = "المقبلات";

      retrieveItems("Starter Items");
    }
    private void SpecialDealsButton_Click(object sender, EventArgs e)
    {
      SelectedItem.Show();
      SelectedItem.Top = SpecialDealsButton.Top;

      if (englishLanguage)
        CategoryTitle.Text = "Promotions";
      else
        CategoryTitle.Text = "عروض";

      retrieveItems("Promotions");
    }

    private void MainItemsButton_Click(object sender, EventArgs e)
    {
      SelectedItem.Show();
      SelectedItem.Top = MainItemsButton.Top;

      if (englishLanguage)
        CategoryTitle.Text = "Main Items";
      else
        CategoryTitle.Text = "الأطباق الرئيسية";

      retrieveItems("Main Items");
    }

    private void DessertsButton_Click(object sender, EventArgs e)
    {
      SelectedItem.Show();
      SelectedItem.Top = DessertsButton.Top;

      if (englishLanguage)
        CategoryTitle.Text = "Desserts";
      else
        CategoryTitle.Text = "الحلويات";

      retrieveItems("Desserts");
    }

    private void ExtraItemsButton_Click(object sender, EventArgs e)
    {
      SelectedItem.Show();
      SelectedItem.Top = ExtraItemsButton.Top;

      if(englishLanguage)
        CategoryTitle.Text = "Extra Items";
      else
        CategoryTitle.Text = "إضافات";

      retrieveItems("Extra Items");
    }

    private void Checkout(bool isDineIn)
    {
      if (currentOrder.size < 1)
      {
        if (englishLanguage)
          MessageBox.Show("Please select at least one item before checking out.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        else
          MessageBox.Show("الرجاء اختيار غرض واحد على الأقل قبل الدفع.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        return;
      }

      DialogResult confirmation;

      if (englishLanguage)
        confirmation = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
      else
        confirmation = MessageBox.Show("هل أنت متأكد؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

      if (confirmation == DialogResult.No)
        return;

        // get database handler instance
        DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;

      // clear cmd parameters
      cmd.Parameters.Clear();

      // add parameters
      // branch id
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      // order time
      cmd.Parameters.AddWithValue("@order_time", DateTime.Now);

      // get total price from TotalPriceLabel
      string totalPrice = TotalPriceLabel.Text;

      // remove any alphabets from string
      totalPrice = Regex.Replace(totalPrice, "[^0-9.]", "");

      // total price
      cmd.Parameters.AddWithValue("@total_price", totalPrice);

      cmd.CommandText = "INSERT INTO orders (branch_id, order_time, total_price) VALUES (@branch_id, @order_time, @total_price)";

      //cmd.CommandText = "INSERT INTO orders (branch_id, order_time) VALUES (@branch_id, @order_time)";

      int rowsAffected = db.ExecuteNonQuery();

      if (rowsAffected == 0)
      { 
        MessageBox.Show("Error... Could not add order. Please contact technical maintenance service.");
        db.CloseConnection();

        return;
      }

      // close connection
      db.CloseConnection();

      // clear cmd parameters
      cmd.Parameters.Clear();

      // add parameters
      // branch id
      cmd.Parameters.AddWithValue("@branch_id", branch_id);

      // get order id
      string sqlString = "SELECT TOP 1 order_id FROM orders WHERE branch_id = @branch_id ORDER BY order_id DESC";

      SqlDataReader dr = db.ExecuteQuery(sqlString);

      int order_id = 0;

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          order_id = Convert.ToInt32(dr["order_id"]);
        }
      }
      else
      {
        // error
        MessageBox.Show("Error... Could not get order ID. Please contact technical maintenance service.");
        db.CloseConnection();

        return;
      }

      // close connection
      db.CloseConnection();

      // clear cmd parameters
      cmd.Parameters.Clear();

      // create data table to store cart info
      DataTable cart = new DataTable();
      cart.Columns.Add("order_id", typeof(int));
      cart.Columns.Add("item_id", typeof(int));
      cart.Columns.Add("quantity", typeof(int));
      cart.Columns.Add("description", typeof(string));

      for (int i = 0; i < currentOrder.size; i++)
      {
        // add row to cart
        cart.Rows.Add(order_id, currentOrder.databaseIDs[i], currentOrder.quantity[i], currentOrder.notes[i] == null ? "" : currentOrder.notes[i]);
      }

      if(!db.BulkCopy(cart, "customer_order_items"))
      {
        // error
        MessageBox.Show("Error... Could not add order items. Please contact technical maintenance service.");
        db.CloseConnection();

        return;
      }

      // close connection
      db.CloseConnection();

      if(isDineIn)
      {
        // get tableComboBox selected item
        string table = tableComboBox.SelectedItem.ToString();

        // remove everything that isn't a number
        table = Regex.Replace(table, "[^0-9]", "");

        // clear cmd parameters
        cmd.Parameters.Clear();

        // add parameters
        // order id
        cmd.Parameters.AddWithValue("@order_id", order_id);

        // table number
        cmd.Parameters.AddWithValue("@table_number", table);

        // add table number to dine_in_orders
        cmd.CommandText = "INSERT INTO dine_in_orders (order_id, table_number) VALUES (@order_id, @table_number)";

        rowsAffected = db.ExecuteNonQuery();

        if (rowsAffected == 0)
        {
          MessageBox.Show("Error... Could not add table number. Please contact technical maintenance service.");
          db.CloseConnection();

          return;
        }

        // close connection
        db.CloseConnection();
      }

      RatingPrompt rating = new RatingPrompt(order_id, englishLanguage);
      rating.ShowDialog();

      var writer = new StreamWriter("receipt.txt");
      writer.WriteLine("▀█▀ █░█ ▄▀█ █▄░█ █▄▀   █▄█ █▀█ █░█");
      writer.WriteLine("░█░ █▀█ █▀█ █░▀█ █░█   ░█░ █▄█ █▄█");
      writer.WriteLine("");
      writer.WriteLine("");
      writer.WriteLine("");
      writer.WriteLine("\t\t\t" + restaurant_name);
      writer.WriteLine("");
      writer.WriteLine("\tPlease go to the counter");
      writer.WriteLine("\tto pay for your order.");
      writer.WriteLine("");
      writer.WriteLine("\t\tOrder ID: " + order_id.ToString());
      writer.WriteLine("");
      writer.WriteLine("");
      writer.WriteLine("#ORD " + order_id.ToString() + " - " + DateTime.Now);
      writer.WriteLine("#\tTotal\t\tProduct");

      for (int i = 0; i < currentOrder.size; i++)
      {
        writer.WriteLine($"{currentOrder.quantity[i]:00}\t{(currentOrder.price[i] * currentOrder.quantity[i]):00.00}\t\t{currentOrder.items[i]}");

        // add the notes[i] as a new line if it's not empty
        if (currentOrder.notes[i] != null && currentOrder.notes[i] != "")
        {
          // split each 10 characters into a new line
          for (int j = 0; j < currentOrder.notes[i].Length; j += 10)
          {
            writer.WriteLine("\t\t\t" + currentOrder.notes[i].Substring(j, Math.Min(10, currentOrder.notes[i].Length - j)));
          }
        }
      }

      writer.WriteLine("");
      writer.WriteLine("Total\t\t\t" + currentOrder.GetTotal());
      writer.WriteLine("");
      writer.WriteLine("Have a good day!");

      writer.Close();

      currentOrder.ClearAll();

      this.Hide();
    }

    private void CheckoutButton_Click(object sender, EventArgs e)
    {
      // check if tableComboBox is selected
      if (tableComboBox.SelectedIndex == -1)
      {
        if (englishLanguage)
          MessageBox.Show("Please select a table before checking out.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        else
          MessageBox.Show("الرجاء اختيار طاولة قبل الدفع.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        return;
      }

      // get selected table
      string selectedTable = tableComboBox.SelectedItem.ToString();

      // update table combox box
      UpdateNumOfTables(table_count);

      // check if table still available in comboBox
      if (!tableComboBox.Items.Contains(selectedTable))
      {
        // table is not available
        if (englishLanguage)
          MessageBox.Show("Sorry, this table is no longer available.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        else
          MessageBox.Show("عذرا، هذه الطاولة غير متوفرة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        return;
      }

      // select table
      tableComboBox.SelectedItem = selectedTable;

      Checkout(true);
    }

    private void ClearAllButton_Click(object sender, EventArgs e)
    {
      DialogResult confirmation;

      if (englishLanguage)
        confirmation = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
      else
        confirmation = MessageBox.Show("هل أنت متأكد؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

      if (confirmation == DialogResult.Yes)
      {
        currentOrder.ClearAll();
      }
    }

    private void takeOutButton_Click(object sender, EventArgs e)
    {
      Checkout(false);
    }
  }
}
