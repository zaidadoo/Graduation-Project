
namespace Restaurant_Contactless_Dining_System
{
    partial class CompleteMenu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.Tab = new System.Windows.Forms.Panel();
      this.ExitButton = new System.Windows.Forms.Button();
      this.CategoryMenu = new System.Windows.Forms.Panel();
      this.ExtraItemsButton = new System.Windows.Forms.Button();
      this.DessertsButton = new System.Windows.Forms.Button();
      this.MainItemsButton = new System.Windows.Forms.Button();
      this.StarterItemsButton = new System.Windows.Forms.Button();
      this.SpecialDealsButton = new System.Windows.Forms.Button();
      this.LogoFrame = new System.Windows.Forms.PictureBox();
      this.SelectedItem = new System.Windows.Forms.Panel();
      this.OrderPanel = new System.Windows.Forms.Panel();
      this.TotalPriceLabel = new System.Windows.Forms.Label();
      this.ClearAllButton = new System.Windows.Forms.Button();
      this.OrderedItems = new System.Windows.Forms.FlowLayoutPanel();
      this.CheckoutButton = new System.Windows.Forms.Button();
      this.Title = new System.Windows.Forms.Label();
      this.DisplayItems = new System.Windows.Forms.FlowLayoutPanel();
      this.CategoryTitle = new System.Windows.Forms.Label();
      this.Tab.SuspendLayout();
      this.CategoryMenu.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.LogoFrame)).BeginInit();
      this.OrderPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // Tab
      // 
      this.Tab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.Tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
      this.Tab.Controls.Add(this.ExitButton);
      this.Tab.Location = new System.Drawing.Point(0, 0);
      this.Tab.Name = "Tab";
      this.Tab.Size = new System.Drawing.Size(1920, 48);
      this.Tab.TabIndex = 0;
      // 
      // ExitButton
      // 
      this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
      this.ExitButton.FlatAppearance.BorderSize = 0;
      this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExitButton.ForeColor = System.Drawing.Color.White;
      this.ExitButton.Location = new System.Drawing.Point(1841, 0);
      this.ExitButton.Name = "ExitButton";
      this.ExitButton.Size = new System.Drawing.Size(79, 48);
      this.ExitButton.TabIndex = 2;
      this.ExitButton.Text = "Back";
      this.ExitButton.UseVisualStyleBackColor = false;
      this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
      // 
      // CategoryMenu
      // 
      this.CategoryMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.CategoryMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
      this.CategoryMenu.Controls.Add(this.ExtraItemsButton);
      this.CategoryMenu.Controls.Add(this.DessertsButton);
      this.CategoryMenu.Controls.Add(this.MainItemsButton);
      this.CategoryMenu.Controls.Add(this.StarterItemsButton);
      this.CategoryMenu.Controls.Add(this.SpecialDealsButton);
      this.CategoryMenu.Controls.Add(this.LogoFrame);
      this.CategoryMenu.Location = new System.Drawing.Point(0, 0);
      this.CategoryMenu.Name = "CategoryMenu";
      this.CategoryMenu.Size = new System.Drawing.Size(365, 1080);
      this.CategoryMenu.TabIndex = 1;
      // 
      // ExtraItemsButton
      // 
      this.ExtraItemsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
      this.ExtraItemsButton.FlatAppearance.BorderSize = 0;
      this.ExtraItemsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExtraItemsButton.Font = new System.Drawing.Font("Calibri", 14.25F);
      this.ExtraItemsButton.ForeColor = System.Drawing.Color.White;
      this.ExtraItemsButton.Location = new System.Drawing.Point(0, 646);
      this.ExtraItemsButton.Name = "ExtraItemsButton";
      this.ExtraItemsButton.Size = new System.Drawing.Size(365, 97);
      this.ExtraItemsButton.TabIndex = 12;
      this.ExtraItemsButton.Text = "Extra Items";
      this.ExtraItemsButton.UseVisualStyleBackColor = false;
      this.ExtraItemsButton.Click += new System.EventHandler(this.ExtraItemsButton_Click);
      // 
      // DessertsButton
      // 
      this.DessertsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
      this.DessertsButton.FlatAppearance.BorderSize = 0;
      this.DessertsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.DessertsButton.Font = new System.Drawing.Font("Calibri", 14.25F);
      this.DessertsButton.ForeColor = System.Drawing.Color.White;
      this.DessertsButton.Location = new System.Drawing.Point(0, 543);
      this.DessertsButton.Name = "DessertsButton";
      this.DessertsButton.Size = new System.Drawing.Size(365, 97);
      this.DessertsButton.TabIndex = 12;
      this.DessertsButton.Text = "Desserts";
      this.DessertsButton.UseVisualStyleBackColor = false;
      this.DessertsButton.Click += new System.EventHandler(this.DessertsButton_Click);
      // 
      // MainItemsButton
      // 
      this.MainItemsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
      this.MainItemsButton.FlatAppearance.BorderSize = 0;
      this.MainItemsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.MainItemsButton.Font = new System.Drawing.Font("Calibri", 14.25F);
      this.MainItemsButton.ForeColor = System.Drawing.Color.White;
      this.MainItemsButton.Location = new System.Drawing.Point(0, 440);
      this.MainItemsButton.Name = "MainItemsButton";
      this.MainItemsButton.Size = new System.Drawing.Size(365, 97);
      this.MainItemsButton.TabIndex = 12;
      this.MainItemsButton.Text = "Main Items";
      this.MainItemsButton.UseVisualStyleBackColor = false;
      this.MainItemsButton.Click += new System.EventHandler(this.MainItemsButton_Click);
      // 
      // StarterItemsButton
      // 
      this.StarterItemsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
      this.StarterItemsButton.FlatAppearance.BorderSize = 0;
      this.StarterItemsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.StarterItemsButton.Font = new System.Drawing.Font("Calibri", 14.25F);
      this.StarterItemsButton.ForeColor = System.Drawing.Color.White;
      this.StarterItemsButton.Location = new System.Drawing.Point(-3, 337);
      this.StarterItemsButton.Name = "StarterItemsButton";
      this.StarterItemsButton.Size = new System.Drawing.Size(365, 97);
      this.StarterItemsButton.TabIndex = 12;
      this.StarterItemsButton.Text = "Starter Items";
      this.StarterItemsButton.UseVisualStyleBackColor = false;
      this.StarterItemsButton.Click += new System.EventHandler(this.StarterItemsButton_Click);
      // 
      // SpecialDealsButton
      // 
      this.SpecialDealsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
      this.SpecialDealsButton.FlatAppearance.BorderSize = 0;
      this.SpecialDealsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SpecialDealsButton.Font = new System.Drawing.Font("Calibri", 14.25F);
      this.SpecialDealsButton.ForeColor = System.Drawing.Color.White;
      this.SpecialDealsButton.Location = new System.Drawing.Point(0, 234);
      this.SpecialDealsButton.Name = "SpecialDealsButton";
      this.SpecialDealsButton.Size = new System.Drawing.Size(365, 97);
      this.SpecialDealsButton.TabIndex = 12;
      this.SpecialDealsButton.Text = "Special Deals";
      this.SpecialDealsButton.UseVisualStyleBackColor = false;
      this.SpecialDealsButton.Click += new System.EventHandler(this.SpecialDealsButton_Click);
      // 
      // LogoFrame
      // 
      this.LogoFrame.BackColor = System.Drawing.Color.Transparent;
      this.LogoFrame.Location = new System.Drawing.Point(70, 21);
      this.LogoFrame.Name = "LogoFrame";
      this.LogoFrame.Size = new System.Drawing.Size(227, 189);
      this.LogoFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.LogoFrame.TabIndex = 11;
      this.LogoFrame.TabStop = false;
      // 
      // SelectedItem
      // 
      this.SelectedItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
      this.SelectedItem.Location = new System.Drawing.Point(356, 234);
      this.SelectedItem.Name = "SelectedItem";
      this.SelectedItem.Size = new System.Drawing.Size(10, 97);
      this.SelectedItem.TabIndex = 2;
      // 
      // OrderPanel
      // 
      this.OrderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.OrderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
      this.OrderPanel.Controls.Add(this.TotalPriceLabel);
      this.OrderPanel.Controls.Add(this.ClearAllButton);
      this.OrderPanel.Controls.Add(this.OrderedItems);
      this.OrderPanel.Controls.Add(this.CheckoutButton);
      this.OrderPanel.Location = new System.Drawing.Point(1448, 166);
      this.OrderPanel.Name = "OrderPanel";
      this.OrderPanel.Size = new System.Drawing.Size(472, 913);
      this.OrderPanel.TabIndex = 4;
      // 
      // TotalPriceLabel
      // 
      this.TotalPriceLabel.AutoSize = true;
      this.TotalPriceLabel.BackColor = System.Drawing.Color.Transparent;
      this.TotalPriceLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.TotalPriceLabel.Font = new System.Drawing.Font("Calibri", 24F);
      this.TotalPriceLabel.ForeColor = System.Drawing.Color.White;
      this.TotalPriceLabel.Location = new System.Drawing.Point(15, 747);
      this.TotalPriceLabel.Name = "TotalPriceLabel";
      this.TotalPriceLabel.Size = new System.Drawing.Size(89, 39);
      this.TotalPriceLabel.TabIndex = 5;
      this.TotalPriceLabel.Text = "Total:";
      // 
      // ClearAllButton
      // 
      this.ClearAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
      this.ClearAllButton.FlatAppearance.BorderSize = 0;
      this.ClearAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ClearAllButton.Font = new System.Drawing.Font("Calibri", 14.25F);
      this.ClearAllButton.ForeColor = System.Drawing.Color.White;
      this.ClearAllButton.Location = new System.Drawing.Point(242, 817);
      this.ClearAllButton.Name = "ClearAllButton";
      this.ClearAllButton.Size = new System.Drawing.Size(214, 77);
      this.ClearAllButton.TabIndex = 15;
      this.ClearAllButton.Text = "Clear All";
      this.ClearAllButton.UseVisualStyleBackColor = false;
      this.ClearAllButton.Click += new System.EventHandler(this.ClearAllButton_Click);
      // 
      // OrderedItems
      // 
      this.OrderedItems.AutoScroll = true;
      this.OrderedItems.Location = new System.Drawing.Point(21, 19);
      this.OrderedItems.Name = "OrderedItems";
      this.OrderedItems.Size = new System.Drawing.Size(446, 725);
      this.OrderedItems.TabIndex = 14;
      // 
      // CheckoutButton
      // 
      this.CheckoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
      this.CheckoutButton.FlatAppearance.BorderSize = 0;
      this.CheckoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.CheckoutButton.Font = new System.Drawing.Font("Calibri", 14.25F);
      this.CheckoutButton.ForeColor = System.Drawing.Color.White;
      this.CheckoutButton.Location = new System.Drawing.Point(22, 817);
      this.CheckoutButton.Name = "CheckoutButton";
      this.CheckoutButton.Size = new System.Drawing.Size(214, 77);
      this.CheckoutButton.TabIndex = 13;
      this.CheckoutButton.Text = "Checkout";
      this.CheckoutButton.UseVisualStyleBackColor = false;
      this.CheckoutButton.Click += new System.EventHandler(this.CheckoutButton_Click);
      // 
      // Title
      // 
      this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.Title.AutoSize = true;
      this.Title.BackColor = System.Drawing.Color.Transparent;
      this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.Title.Font = new System.Drawing.Font("Calibri", 32F);
      this.Title.ForeColor = System.Drawing.Color.White;
      this.Title.Location = new System.Drawing.Point(1439, 110);
      this.Title.Name = "Title";
      this.Title.Size = new System.Drawing.Size(253, 53);
      this.Title.TabIndex = 5;
      this.Title.Text = "YOUR ORDER";
      // 
      // DisplayItems
      // 
      this.DisplayItems.AutoScroll = true;
      this.DisplayItems.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
      this.DisplayItems.Location = new System.Drawing.Point(391, 166);
      this.DisplayItems.Name = "DisplayItems";
      this.DisplayItems.Size = new System.Drawing.Size(1051, 911);
      this.DisplayItems.TabIndex = 6;
      // 
      // CategoryTitle
      // 
      this.CategoryTitle.AutoSize = true;
      this.CategoryTitle.BackColor = System.Drawing.Color.Transparent;
      this.CategoryTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.CategoryTitle.Font = new System.Drawing.Font("Calibri", 48F);
      this.CategoryTitle.ForeColor = System.Drawing.Color.White;
      this.CategoryTitle.Location = new System.Drawing.Point(378, 85);
      this.CategoryTitle.Name = "CategoryTitle";
      this.CategoryTitle.Size = new System.Drawing.Size(1005, 78);
      this.CategoryTitle.TabIndex = 5;
      this.CategoryTitle.Text = "Please select a category from the left.";
      // 
      // CompleteMenu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
      this.Controls.Add(this.DisplayItems);
      this.Controls.Add(this.CategoryTitle);
      this.Controls.Add(this.Title);
      this.Controls.Add(this.OrderPanel);
      this.Controls.Add(this.SelectedItem);
      this.Controls.Add(this.CategoryMenu);
      this.Controls.Add(this.Tab);
      this.Name = "CompleteMenu";
      this.Size = new System.Drawing.Size(1920, 1080);
      this.Load += new System.EventHandler(this.CompleteMenu_Load);
      this.Tab.ResumeLayout(false);
      this.CategoryMenu.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.LogoFrame)).EndInit();
      this.OrderPanel.ResumeLayout(false);
      this.OrderPanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Tab;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel CategoryMenu;
        private System.Windows.Forms.PictureBox LogoFrame;
        private System.Windows.Forms.Panel SelectedItem;
        private System.Windows.Forms.Button StarterItemsButton;
        private System.Windows.Forms.Button SpecialDealsButton;
        private System.Windows.Forms.Button MainItemsButton;
        private System.Windows.Forms.Button ExtraItemsButton;
        private System.Windows.Forms.Button DessertsButton;
        private System.Windows.Forms.Panel OrderPanel;
        private System.Windows.Forms.Button CheckoutButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.FlowLayoutPanel DisplayItems;
        private System.Windows.Forms.FlowLayoutPanel OrderedItems;
        private System.Windows.Forms.Button ClearAllButton;
        private System.Windows.Forms.Label CategoryTitle;
        private System.Windows.Forms.Label TotalPriceLabel;
    }
}
