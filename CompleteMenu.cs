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
using System.Data.SqlTypes;

namespace Restaurant_Contactless_Dining_System
{
  public partial class CompleteMenu : UserControl
  {
    public static Order currentOrder;
    private static bool englishLanguage = true;

    private string restaurant_id = "";
    private string branch_id = "";

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
        TotalPriceLabel.Text = $"{currentOrder.GetTotal():0.00} :المجموع";
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

      if (dr.HasRows)
      {
        while (dr.Read())
        {
          // get restaurant_id
          restaurant_id = dr["restaurant_id"].ToString();
        }
      }

      // close connection
      db.CloseConnection();

      updateColors();
      updateLanguage();
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
        CheckoutButton.Text = "Checkout";
        ClearAllButton.Text = "Clear All";
        ExitButton.Text = "Back";
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
        CheckoutButton.Text = "الدفع";
        ClearAllButton.Text = "مسح";
        ExitButton.Text = "رجوع";
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
      CheckoutButton.ForeColor = ColorTranslator.FromHtml(textColor);
      ClearAllButton.ForeColor = ColorTranslator.FromHtml(textColor);
      SpecialDealsButton.ForeColor = ColorTranslator.FromHtml(textColor);
      StarterItemsButton.ForeColor = ColorTranslator.FromHtml(textColor);
      MainItemsButton.ForeColor = ColorTranslator.FromHtml(textColor);
      DessertsButton.ForeColor = ColorTranslator.FromHtml(textColor);
      ExtraItemsButton.ForeColor = ColorTranslator.FromHtml(textColor);

      // create a lighter color by 10%
      Color lighterAccent = ColorTranslator.FromHtml(accentColor);
      lighterAccent = ControlPaint.Light(lighterAccent, 0.1f);
      lighterColor = ColorTranslator.ToHtml(lighterAccent);

      // set lighter accent colors
      CheckoutButton.BackColor = lighterAccent;
      ClearAllButton.BackColor = lighterAccent;
      SpecialDealsButton.BackColor = lighterAccent;
      StarterItemsButton.BackColor = lighterAccent;
      MainItemsButton.BackColor = lighterAccent;
      DessertsButton.BackColor = lighterAccent;
      ExtraItemsButton.BackColor = lighterAccent;
      ExitButton.BackColor = lighterAccent;

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

    private void CheckoutButton_Click(object sender, EventArgs e)
    {
      if (currentOrder.size < 1)
      {
        MessageBox.Show("Please select at least one item before checking out.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      DialogResult confirmation = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

      return;

      //if (confirmation == DialogResult.Yes)
      //{

      //  string queryString = "";
      //  for (int i = 0; i < currentOrder.size; i++)
      //  {
      //    queryString += currentOrder.items[i] + ":" + currentOrder.quantity[i] + ":" + currentOrder.price[i] + "\n";
      //  }

      //  con.Open();

      //  cmd.Connection = con;
      //  cmd.CommandText = "INSERT INTO orders (items)" + " values (@items_)";

      //  cmd.Parameters.AddWithValue("items_", queryString);

      //  int rowsAffected = cmd.ExecuteNonQuery();


      //  if (rowsAffected == 0)
      //    MessageBox.Show("Error... please contact technical maintenance service.");

      //  con.Close();

      //  int CurrentOrderId = 0;
      //  string RestaurantName = "";

      //  con.Open();
      //  cmd.Connection = con;
      //  cmd.CommandText = "SELECT id FROM orders ORDER BY id DESC LIMIT 1";
      //  dr = cmd.ExecuteReader();

      //  if (dr.HasRows)
      //  {
      //    while (dr.Read())
      //    {
      //      CurrentOrderId = int.Parse(dr["id"].ToString());
      //    }
      //  }

      //  dr.Close();

      //  cmd.CommandText = "SELECT * FROM restaurant_info";
      //  dr = cmd.ExecuteReader();

      //  if (dr.HasRows)
      //  {
      //    while (dr.Read())
      //    {
      //      RestaurantName += dr["name"].ToString();
      //    }
      //  }

      //  dr.Close();
      //  con.Close();

      //  var writer = new StreamWriter("receipt.txt");
      //  writer.WriteLine("▀█▀ █░█ ▄▀█ █▄░█ █▄▀   █▄█ █▀█ █░█");
      //  writer.WriteLine("░█░ █▀█ █▀█ █░▀█ █░█   ░█░ █▄█ █▄█");
      //  writer.WriteLine("");
      //  writer.WriteLine("");
      //  writer.WriteLine("");
      //  writer.WriteLine("\t\t\t" + RestaurantName);
      //  writer.WriteLine("");
      //  writer.WriteLine("\tPlease go to the counter");
      //  writer.WriteLine("\tto pay for your order.");
      //  writer.WriteLine("");
      //  writer.WriteLine("\t\tOrder ID: " + CurrentOrderId.ToString());
      //  writer.WriteLine("");
      //  writer.WriteLine("");
      //  writer.WriteLine("#ORD " + CurrentOrderId.ToString() + " - " + DateTime.UtcNow);
      //  writer.WriteLine("#\tTotal\t\tProduct");
      //  for (int i = 0; i < currentOrder.size; i++)
      //  {
      //    writer.WriteLine($"{currentOrder.quantity[i]:00}\t{(currentOrder.price[i] * currentOrder.quantity[i]):00.00}\t\t{currentOrder.items[i]}");
      //  }
      //  writer.WriteLine("");
      //  writer.WriteLine("Total\t\t\t" + currentOrder.GetTotal());
      //  writer.WriteLine("");
      //  writer.WriteLine("Have a good day!");

      //  writer.Close();

      //  currentOrder.ClearAll();
      //  MessageBox.Show("Order received, and pending receipt printed. Please take printed receipt to counter to pay for order.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

      //  this.Hide();
      //}
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
