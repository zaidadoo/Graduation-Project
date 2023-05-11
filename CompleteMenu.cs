using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Restaurant_Contactless_Dining_System
{
  public partial class CompleteMenu : UserControl
  {
    SQLiteConnection con = new SQLiteConnection("Data Source=menusystem.db;Version=3");
    SQLiteCommand cmd = new SQLiteCommand();
    SQLiteDataReader dr;

    public static Order currentOrder = new Order();

    public CompleteMenu()
    {
      InitializeComponent();
      currentOrder.setParent = this;
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
      DialogResult confirmation = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

      if (confirmation == DialogResult.Yes)
      {
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
        current.NameItem = currentOrder.items[i];
        current.PriceItem = currentOrder.price[i] * currentOrder.quantity[i];
        current.QuantityItem = currentOrder.quantity[i];
        OrderedItems.Controls.Add(current);
        i++;
      }

      TotalPriceLabel.Text = $"Total: {currentOrder.GetTotal():0.00}";
    }

    byte[] logoBytes = null;

    private void CompleteMenu_Load(object sender, EventArgs e)
    {
      return;

      SelectedItem.Hide();

      OrderedItems.HorizontalScroll.Visible = false;

      con.Open();
      cmd.Connection = con;
      cmd.CommandText = "SELECT * FROM restaurant_info";
      dr = cmd.ExecuteReader();

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          if (dr["logo"] != null && !Convert.IsDBNull(dr["logo"]))
          {
            logoBytes = (byte[])dr["logo"];
          }
        }
      }

      dr.Close();
      con.Close();

      MemoryStream ms = new MemoryStream(logoBytes);
      Image finalImage = Image.FromStream(ms);

      LogoFrame.Image = finalImage;
    }

    public void retrieveItems(string catName)
    {
      con.Open();
      cmd.Connection = con;
      cmd.CommandText = "SELECT * FROM menu WHERE category='" + catName + "'";
      dr = cmd.ExecuteReader();
      DisplayItems.Controls.Clear();

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          MenuItem current = new MenuItem();
          current.NameItem = dr["name"].ToString();
          current.PriceItem = $"{dr["price"]:0.00}";
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

      dr.Close();
      con.Close();
    }

    private void StarterItemsButton_Click(object sender, EventArgs e)
    {
      SelectedItem.Show();
      SelectedItem.Top = StarterItemsButton.Top;
      CategoryTitle.Text = "Starter Items";
      retrieveItems("starter");
    }
    private void SpecialDealsButton_Click(object sender, EventArgs e)
    {
      SelectedItem.Show();
      SelectedItem.Top = SpecialDealsButton.Top;
      CategoryTitle.Text = "Special Deals";
      retrieveItems("special");
    }

    private void MainItemsButton_Click(object sender, EventArgs e)
    {
      SelectedItem.Show();
      SelectedItem.Top = MainItemsButton.Top;
      CategoryTitle.Text = "Main Items";
      retrieveItems("main");
    }

    private void DessertsButton_Click(object sender, EventArgs e)
    {
      SelectedItem.Show();
      SelectedItem.Top = DessertsButton.Top;
      CategoryTitle.Text = "Desserts";
      retrieveItems("dessert");
    }

    private void ExtraItemsButton_Click(object sender, EventArgs e)
    {
      SelectedItem.Show();
      SelectedItem.Top = ExtraItemsButton.Top;
      CategoryTitle.Text = "Extra Items";
      retrieveItems("extra");
    }

    private void CheckoutButton_Click(object sender, EventArgs e)
    {
      if (currentOrder.size < 1)
      {
        MessageBox.Show("Please select at least one item before checking out.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      DialogResult confirmation = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

      if (confirmation == DialogResult.Yes)
      {

        string queryString = "";
        for (int i = 0; i < currentOrder.size; i++)
        {
          queryString += currentOrder.items[i] + ":" + currentOrder.quantity[i] + ":" + currentOrder.price[i] + "\n";
        }

        con.Open();

        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO orders (items)" + " values (@items_)";

        cmd.Parameters.AddWithValue("items_", queryString);

        int rowsAffected = cmd.ExecuteNonQuery();


        if (rowsAffected == 0)
          MessageBox.Show("Error... please contact technical maintenance service.");

        con.Close();

        int CurrentOrderId = 0;
        string RestaurantName = "";

        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "SELECT id FROM orders ORDER BY id DESC LIMIT 1";
        dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
          while (dr.Read())
          {
            CurrentOrderId = int.Parse(dr["id"].ToString());
          }
        }

        dr.Close();

        cmd.CommandText = "SELECT * FROM restaurant_info";
        dr = cmd.ExecuteReader();

        if (dr.HasRows)
        {
          while (dr.Read())
          {
            RestaurantName += dr["name"].ToString();
          }
        }

        dr.Close();
        con.Close();

        var writer = new StreamWriter("receipt.txt");
        writer.WriteLine("▀█▀ █░█ ▄▀█ █▄░█ █▄▀   █▄█ █▀█ █░█");
        writer.WriteLine("░█░ █▀█ █▀█ █░▀█ █░█   ░█░ █▄█ █▄█");
        writer.WriteLine("");
        writer.WriteLine("");
        writer.WriteLine("");
        writer.WriteLine("\t\t\t" + RestaurantName);
        writer.WriteLine("");
        writer.WriteLine("\tPlease go to the counter");
        writer.WriteLine("\tto pay for your order.");
        writer.WriteLine("");
        writer.WriteLine("\t\tOrder ID: " + CurrentOrderId.ToString());
        writer.WriteLine("");
        writer.WriteLine("");
        writer.WriteLine("#ORD " + CurrentOrderId.ToString() + " - " + DateTime.UtcNow);
        writer.WriteLine("#\tTotal\t\tProduct");
        for (int i = 0; i < currentOrder.size; i++)
        {
          writer.WriteLine($"{currentOrder.quantity[i]:00}\t{(currentOrder.price[i] * currentOrder.quantity[i]):00.00}\t\t{currentOrder.items[i]}");
        }
        writer.WriteLine("");
        writer.WriteLine("Total\t\t\t" + currentOrder.GetTotal());
        writer.WriteLine("");
        writer.WriteLine("Have a good day!");

        writer.Close();

        currentOrder.ClearAll();
        MessageBox.Show("Order received, and pending receipt printed. Please take printed receipt to counter to pay for order.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

        this.Hide();
      }
    }

    private void ClearAllButton_Click(object sender, EventArgs e)
    {
      DialogResult confirmation = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

      if (confirmation == DialogResult.Yes)
      {
        currentOrder.ClearAll();
      }
    }
  }
}
