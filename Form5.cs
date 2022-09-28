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
    public partial class KitchenManagement : Form
    {
        bool isAdmin = true;
        bool isLock = false;

        SQLiteConnection con = new SQLiteConnection("Data Source=menusystem.db;Version=3");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataReader dr;

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
            if(!isLock)
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
            OrdersList.Items.Clear();

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT id FROM orders where status='pending' OR status='preparing'";
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    OrdersList.Items.Add(dr["id"]);
                }
            }

            dr.Close();
            con.Close();
        }

        private void OrdersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReviewGroupBox.Enabled = true;
            OrderedItemsList.Items.Clear();

            string lines = "";

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM orders where id=" + OrdersList.SelectedItem;
            try
            {
                dr = cmd.ExecuteReader();
            }
            catch(SQLiteException)
            {
                MessageBox.Show("Connection with database was cut, reconnecting...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                var check = dr.HasRows;
            }
            catch(InvalidOperationException)
            {
                dr.Close();
                con.Close();
                return;
            }

            if (dr.HasRows)
            {
                double total = 0;

                while (dr.Read())
                {
                    lines += dr["items"];

                    foreach (string line in lines.Split('\n'))
                    {
                        var found = line.IndexOf(":");
                        var found2 = line.LastIndexOf(":");

                        try
                        {
                            if(found > 0 && found2 - 1 > 0)
                            {
                                int i = 0;
                                if(found2 - found > 2)
                                {
                                    i = 2;
                                }
                                else
                                {
                                    i = 1;
                                }
                                OrderedItemsList.Items.Add($"{line.Substring(found + 1, i)}x {line.Substring(0, found)}");

                                total += (float.Parse(line.Substring(found2 + 1)) * int.Parse(line.Substring(found + 1, i)));
                            }
                        }
                        catch(ArgumentOutOfRangeException)
                        {
                            MessageBox.Show("Error: no items found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally { }
                    }

                    PriceNumber.Text = $"{total:0.00} JD";

                    if(dr["status"].Equals("preparing"))
                    {
                        StatusLabel.Text = "Status: Preparing";
                        ConfirmOrder.Enabled = false;
                        CancelOrder.Enabled = true;
                        CompleteOrder.Enabled = true;
                    }
                    else
                    {
                        StatusLabel.Text = "Status: Pending";
                        CompleteOrder.Enabled = false;
                        ConfirmOrder.Enabled = true;
                        CancelOrder.Enabled = true;
                    }
                }
            }

            dr.Close();
            con.Close();
        }

        private void ConfirmOrder_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.No)
            {
                return;
            }

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE orders SET status='preparing' where id=" + OrdersList.SelectedItem;

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 0)
                MessageBox.Show("Error... Record not modified.");
            else
            {
                MessageBox.Show("Order confirmed successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();

            RetrieveOrdersList_Click(this, new EventArgs());
            ReviewGroupBox.Enabled = false;
        }

        private void CancelOrder_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE orders SET status='cancelled' where id=" + OrdersList.SelectedItem;

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 0)
                MessageBox.Show("Error... Record not modified.");
            else
            {
                MessageBox.Show("Order confirmed successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();

            RetrieveOrdersList_Click(this, new EventArgs());
            ReviewGroupBox.Enabled = false;
        }

        private void CompleteOrder_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE orders SET status='complete' where id=" + OrdersList.SelectedItem;

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 0)
                MessageBox.Show("Error... Record not modified.");
            else
            {
                MessageBox.Show("Order confirmed successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();

            RetrieveOrdersList_Click(this, new EventArgs());
            ReviewGroupBox.Enabled = false;
        }

        private void KitRetrieveOrders_Click(object sender, EventArgs e)
        {
            KitOrdersList.Items.Clear();

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT id FROM orders where status='pending' OR status='preparing'";
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    KitOrdersList.Items.Add(dr["id"]);
                }
            }

            dr.Close();
            con.Close();
        }

        private void KitOrdersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            KitOrderedItemsList.Items.Clear();

            string lines = "";

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM orders where id=" + KitOrdersList.SelectedItem;
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                double total = 0;

                while (dr.Read())
                {
                    lines += dr["items"];

                    foreach (string line in lines.Split('\n'))
                    {
                        var found = line.IndexOf(":");
                        var found2 = line.LastIndexOf(":");

                        try
                        {
                            if (found > 0 && found2 - 1 > 0)
                            {
                                int i = 0;
                                if (found2 - found > 2)
                                {
                                    i = 2;
                                }
                                else
                                {
                                    i = 1;
                                }
                                KitOrderedItemsList.Items.Add($"{line.Substring(found + 1, i)}x {line.Substring(0, found)}");

                                total += (float.Parse(line.Substring(found2 + 1)) * int.Parse(line.Substring(found + 1, i)));
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            MessageBox.Show("Error: no items found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally { }
                    }
                }
            }

            dr.Close();
            con.Close();
        }

        private void RetrieveAllOrders_Click(object sender, EventArgs e)
        {
            con.Open();

            string comm = "SELECT * FROM orders ORDER BY id";
            cmd = new SQLiteCommand(comm, con);

            var da = new SQLiteDataAdapter(comm, con);
            var ds = new DataSet();

            da.Fill(ds, "orders");

            OrdersGridView.DataSource = ds.Tables["orders"].DefaultView;

            con.Close();
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
        }

        bool logoUploadOkay = false;
        byte[] logoBytes = null;

        private void RefreshData_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                PasswordChecker passCheck = new PasswordChecker();
                passCheck.ShowDialog();

                if (passCheck.DialogResult.Equals(DialogResult.Yes))
                {
                    isAdmin = true;
                    MessageBox.Show("Logged in successfully.", "User Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RestaurantInfoGroup.Enabled = false;
                    return;
                }
            }

            RestaurantInfoGroup.Enabled = true;

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM restaurant_info";

            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    RestauranName.Text = dr["name"].ToString();
                    Password.Text = dr["password"].ToString();
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

            LogoUpload.Image = finalImage;
            logoUploadOkay = true;
        }

        bool showPWD = false;
        private void ShowPassword_Click(object sender, EventArgs e)
        {
            if (showPWD)
            {
                Password.UseSystemPasswordChar = true;
                ShowPassword.Text = "Show";
                showPWD = false;
            }
            else
            {
                Password.UseSystemPasswordChar = false;
                ShowPassword.Text = "Hide";
                showPWD = true;
            }
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
            if (!isAdmin)
            {
                PasswordChecker passCheck = new PasswordChecker();
                passCheck.ShowDialog();

                if (passCheck.DialogResult.Equals(DialogResult.Yes))
                {
                    isAdmin = true;
                    MessageBox.Show("Logged in successfully.", "User Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    RestaurantInfoGroup.Enabled = false;
                    return;
                }
            }

            DialogResult res = MessageBox.Show("Are you sure you want to submit details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;

            if (RestauranName.Text.Equals("") || Password.Text.Equals(""))
            {
                MessageBox.Show("Error: Restaurant Name or Password field is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!logoUploadOkay)
            {
                MessageBox.Show("Error: Logo not uploaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            con.Open();
            cmd.Connection = con;

            if(open.FileName != "")
            {
                cmd.CommandText = "UPDATE restaurant_info SET name=@iname, password=@ipassword, logo=@ilogo";

                byte[] image = File.ReadAllBytes(open.FileName);

                cmd.Parameters.AddWithValue("iname", RestauranName.Text);
                cmd.Parameters.Add("ilogo", DbType.Binary, 20).Value = image;
                cmd.Parameters.AddWithValue("ipassword", Password.Text);
            }
            else
            {
                cmd.CommandText = "UPDATE restaurant_info SET name=@iname, password=@ipassword";

                cmd.Parameters.AddWithValue("iname", RestauranName.Text);
                cmd.Parameters.AddWithValue("ipassword", Password.Text);
            }

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 0)
                MessageBox.Show("Error... Record not updated.");
            else
            {
                MessageBox.Show("Restaurant Information Updated Successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();
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

            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM menu WHERE category='special'";
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MenuItemsList.Items.Add(dr["id"] + ". " + dr["name"].ToString());
                }
            }

            dr.Close();
            con.Close();
        }

        private void StarterItemsRadio_CheckedChanged(object sender, EventArgs e)
        {
            MenuItemsList.Enabled = true;
            DeleteItem.Enabled = false;
            ClearFormFields_Click(this, new EventArgs());
            ItemDetailsPanel.Enabled = false;
            MenuItemsList.Items.Clear();

            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM menu WHERE category='starter'";
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MenuItemsList.Items.Add(dr["id"] + ". " + dr["name"].ToString());
                }
            }

            dr.Close();
            con.Close();
        }

        private void MainItemsRadio_CheckedChanged(object sender, EventArgs e)
        {
            MenuItemsList.Enabled = true;
            DeleteItem.Enabled = false;
            ClearFormFields_Click(this, new EventArgs());
            ItemDetailsPanel.Enabled = false;
            MenuItemsList.Items.Clear();

            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM menu WHERE category='main'";
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MenuItemsList.Items.Add(dr["id"] + ". " + dr["name"].ToString());
                }
            }

            dr.Close();
            con.Close();
        }

        private void DessertsRadio_CheckedChanged(object sender, EventArgs e)
        {
            MenuItemsList.Enabled = true;
            DeleteItem.Enabled = false;
            ClearFormFields_Click(this, new EventArgs());
            ItemDetailsPanel.Enabled = false;
            MenuItemsList.Items.Clear();

            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM menu WHERE category='dessert'";
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MenuItemsList.Items.Add(dr["id"] + ". " + dr["name"].ToString());
                }
            }

            dr.Close();
            con.Close();
        }

        private void ExtraItemsRadio_CheckedChanged(object sender, EventArgs e)
        {
            MenuItemsList.Enabled = true;
            DeleteItem.Enabled = false;
            ClearFormFields_Click(this, new EventArgs());
            ItemDetailsPanel.Enabled = false;
            MenuItemsList.Items.Clear();

            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM menu WHERE category='extra'";
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MenuItemsList.Items.Add(dr["id"] + ". " + dr["name"].ToString());
                }
            }

            dr.Close();
            con.Close();
        }

        bool picUploadOkay = false;

        private void MenuItemsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteItem.Enabled = true;

            con.Open();
            cmd.Connection = con;

            string itemID = (MenuItemsList.SelectedItem.ToString()).Substring(0, MenuItemsList.SelectedItem.ToString().IndexOf('.'));

            cmd.CommandText = "SELECT * FROM menu WHERE id=" + int.Parse(itemID);
            dr = cmd.ExecuteReader();

            byte[] imageBytes = null;

            if (dr.HasRows)
            {
                ItemDetailsPanel.Enabled = true;
                while (dr.Read())
                {
                    ItemNameInput.Text = dr["name"].ToString();
                    ItemPriceInput.Value = decimal.Parse(dr["price"].ToString());
                    if(dr["category"].Equals("special"))
                    {
                        ItemCategoryInput.SelectedIndex = 0;
                    }
                    else if (dr["category"].Equals("starter"))
                    {
                        ItemCategoryInput.SelectedIndex = 1;
                    }
                    else if (dr["category"].Equals("main"))
                    {
                        ItemCategoryInput.SelectedIndex = 2;
                    }
                    else if (dr["category"].Equals("dessert"))
                    {
                        ItemCategoryInput.SelectedIndex = 3;
                    }
                    else
                    {
                        ItemCategoryInput.SelectedIndex = 4;
                    }

                    if (dr["image"] != null && !Convert.IsDBNull(dr["image"]))
                    {
                        imageBytes = (byte[])dr["image"];
                    }
                }
            }

            dr.Close();
            con.Close();

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
            if(newItem)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to submit details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                    return;

                if (ItemNameInput.Text.Equals("") || ItemCategoryInput.SelectedItem == null)
                {
                    MessageBox.Show("Error: Some details might be missing, please check before submiting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!picUploadOkay)
                {
                    MessageBox.Show("Error: Image not uploaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                con.Open();

                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO menu (name, price, category, image)" + " values (@iname, @iprice, @icategory, @iimage)";
                
                byte[] image = File.ReadAllBytes(open2.FileName);
                cmd.Parameters.AddWithValue("iname", ItemNameInput.Text);
                cmd.Parameters.AddWithValue("iprice", ItemPriceInput.Value);
                if(ItemCategoryInput.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("icategory", "special");
                }
                else if (ItemCategoryInput.SelectedIndex == 1)
                {
                    cmd.Parameters.AddWithValue("icategory", "starter");
                }
                else if (ItemCategoryInput.SelectedIndex == 2)
                {
                    cmd.Parameters.AddWithValue("icategory", "main");
                }
                else if (ItemCategoryInput.SelectedIndex == 3)
                {
                    cmd.Parameters.AddWithValue("icategory", "dessert");
                }
                else
                {
                    cmd.Parameters.AddWithValue("icategory", "extra");
                }
                cmd.Parameters.Add("iimage", DbType.Binary, 20).Value = image;

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                    MessageBox.Show("Error... item not added.");
                else
                {
                    MessageBox.Show("Item added successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();

                ItemDetailsPanel.Enabled = false;
                UploadItemPicture.Image = null;
                ClearFormFields_Click(this, new EventArgs());
            }
            else
            {
                DialogResult res = MessageBox.Show("Are you sure you want to submit details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                    return;

                if (ItemNameInput.Text.Equals("") || ItemCategoryInput.SelectedItem == null)
                {
                    MessageBox.Show("Error: Some details might be missing, please check before submiting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!picUploadOkay)
                {
                    MessageBox.Show("Error: Image not uploaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                con.Open();

                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO menu (name, price, category, image)" + " values (@iname, @iprice, @icategory, @iimage)";

                if (open2.FileName != "")
                {
                    cmd.CommandText = "UPDATE menu SET name=@iname, price=@iprice, category=@icategory, image=@iimage WHERE id=@iid";

                    byte[] image = File.ReadAllBytes(open2.FileName);
                    cmd.Parameters.AddWithValue("iname", ItemNameInput.Text);
                    cmd.Parameters.AddWithValue("iprice", ItemPriceInput.Value);
                    cmd.Parameters.AddWithValue("iid", (MenuItemsList.SelectedItem.ToString()).Substring(0, MenuItemsList.SelectedItem.ToString().IndexOf('.')));
                    if (ItemCategoryInput.SelectedIndex == 0)
                    {
                        cmd.Parameters.AddWithValue("icategory", "special");
                    }
                    else if (ItemCategoryInput.SelectedIndex == 1)
                    {
                        cmd.Parameters.AddWithValue("icategory", "starter");
                    }
                    else if (ItemCategoryInput.SelectedIndex == 2)
                    {
                        cmd.Parameters.AddWithValue("icategory", "main");
                    }
                    else if (ItemCategoryInput.SelectedIndex == 3)
                    {
                        cmd.Parameters.AddWithValue("icategory", "dessert");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("icategory", "extra");
                    }
                    cmd.Parameters.Add("iimage", DbType.Binary, 20).Value = image;
                }
                else
                {
                    cmd.CommandText = "UPDATE menu SET name=@iname, price=@iprice, category=@icategory WHERE id=@iid";

                    cmd.Parameters.AddWithValue("iname", ItemNameInput.Text);
                    cmd.Parameters.AddWithValue("iprice", ItemPriceInput.Value);
                    cmd.Parameters.AddWithValue("iid", (MenuItemsList.SelectedItem.ToString()).Substring(0, MenuItemsList.SelectedItem.ToString().IndexOf('.')));
                    if (ItemCategoryInput.SelectedIndex == 0)
                    {
                        cmd.Parameters.AddWithValue("icategory", "special");
                    }
                    else if (ItemCategoryInput.SelectedIndex == 1)
                    {
                        cmd.Parameters.AddWithValue("icategory", "starter");
                    }
                    else if (ItemCategoryInput.SelectedIndex == 2)
                    {
                        cmd.Parameters.AddWithValue("icategory", "main");
                    }
                    else if (ItemCategoryInput.SelectedIndex == 3)
                    {
                        cmd.Parameters.AddWithValue("icategory", "dessert");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("icategory", "extra");
                    }
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                    MessageBox.Show("Error... item not updated.");
                else
                {
                    MessageBox.Show("Item updated successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();

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
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to delete item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;

            con.Open();
            cmd.Connection = con;

            try
            {
                cmd.CommandText = "DELETE FROM menu WHERE id=" + (MenuItemsList.SelectedItem.ToString()).Substring(0, MenuItemsList.SelectedItem.ToString().IndexOf('.'));
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Select an item first please.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                    MessageBox.Show("Error... item not deleted.");
                else
                {
                    MessageBox.Show("Item deleted successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();

                SpecialDealsRadio_CheckedChanged(this, new EventArgs());
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
    }
}
