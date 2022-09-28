
namespace Restaurant_Contactless_Dining_System
{
    partial class MainMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.Title = new System.Windows.Forms.Label();
            this.SubTitle = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.DragPanel = new System.Windows.Forms.Panel();
            this.SystemLogo = new System.Windows.Forms.PictureBox();
            this.Choice1Title = new System.Windows.Forms.Label();
            this.Choice3Title = new System.Windows.Forms.Label();
            this.Choice2Title = new System.Windows.Forms.Label();
            this.Choice1Access = new System.Windows.Forms.Button();
            this.Choice2Access = new System.Windows.Forms.Button();
            this.Choice3Access = new System.Windows.Forms.Button();
            this.Choice1Desc = new System.Windows.Forms.Label();
            this.Choice2Desc = new System.Windows.Forms.Label();
            this.Choice3Desc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Choice3Pic = new System.Windows.Forms.PictureBox();
            this.Choice2Pic = new System.Windows.Forms.PictureBox();
            this.Choice1Pic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DragPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SystemLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Choice3Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Choice2Pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Choice1Pic)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Title.Font = new System.Drawing.Font("Calibri", 48F);
            this.Title.ForeColor = System.Drawing.Color.Black;
            this.Title.Location = new System.Drawing.Point(214, 14);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(676, 83);
            this.Title.TabIndex = 2;
            this.Title.Text = "CHOOSE DISPLAY MODE";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SubTitle
            // 
            this.SubTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SubTitle.BackColor = System.Drawing.Color.Transparent;
            this.SubTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubTitle.Font = new System.Drawing.Font("Calibri Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubTitle.ForeColor = System.Drawing.Color.Gray;
            this.SubTitle.Location = new System.Drawing.Point(283, 93);
            this.SubTitle.Name = "SubTitle";
            this.SubTitle.Size = new System.Drawing.Size(539, 116);
            this.SubTitle.TabIndex = 3;
            this.SubTitle.Text = "Choose which display mode you want the software to show. ";
            this.SubTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(0, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(79, 51);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // DragPanel
            // 
            this.DragPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.DragPanel.Controls.Add(this.ExitButton);
            this.DragPanel.Controls.Add(this.SystemLogo);
            this.DragPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DragPanel.Location = new System.Drawing.Point(0, 0);
            this.DragPanel.Name = "DragPanel";
            this.DragPanel.Size = new System.Drawing.Size(1180, 51);
            this.DragPanel.TabIndex = 6;
            // 
            // SystemLogo
            // 
            this.SystemLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SystemLogo.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.LOGO_WHITE;
            this.SystemLogo.Location = new System.Drawing.Point(1119, 7);
            this.SystemLogo.Name = "SystemLogo";
            this.SystemLogo.Size = new System.Drawing.Size(49, 37);
            this.SystemLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SystemLogo.TabIndex = 0;
            this.SystemLogo.TabStop = false;
            this.SystemLogo.WaitOnLoad = true;
            // 
            // Choice1Title
            // 
            this.Choice1Title.BackColor = System.Drawing.Color.Transparent;
            this.Choice1Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choice1Title.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Choice1Title.ForeColor = System.Drawing.Color.White;
            this.Choice1Title.Location = new System.Drawing.Point(60, 3);
            this.Choice1Title.Name = "Choice1Title";
            this.Choice1Title.Size = new System.Drawing.Size(173, 34);
            this.Choice1Title.TabIndex = 8;
            this.Choice1Title.Text = "Customer Display";
            this.Choice1Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Choice3Title
            // 
            this.Choice3Title.BackColor = System.Drawing.Color.Transparent;
            this.Choice3Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choice3Title.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Choice3Title.ForeColor = System.Drawing.Color.White;
            this.Choice3Title.Location = new System.Drawing.Point(41, 3);
            this.Choice3Title.Name = "Choice3Title";
            this.Choice3Title.Size = new System.Drawing.Size(210, 34);
            this.Choice3Title.TabIndex = 8;
            this.Choice3Title.Text = "Kitchen Management";
            this.Choice3Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Choice2Title
            // 
            this.Choice2Title.BackColor = System.Drawing.Color.Transparent;
            this.Choice2Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choice2Title.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Choice2Title.ForeColor = System.Drawing.Color.White;
            this.Choice2Title.Location = new System.Drawing.Point(60, 3);
            this.Choice2Title.Name = "Choice2Title";
            this.Choice2Title.Size = new System.Drawing.Size(173, 34);
            this.Choice2Title.TabIndex = 8;
            this.Choice2Title.Text = "Customer Menu";
            this.Choice2Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Choice1Access
            // 
            this.Choice1Access.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Choice1Access.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Choice1Access.FlatAppearance.BorderSize = 0;
            this.Choice1Access.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choice1Access.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Choice1Access.ForeColor = System.Drawing.Color.White;
            this.Choice1Access.Location = new System.Drawing.Point(21, 489);
            this.Choice1Access.Name = "Choice1Access";
            this.Choice1Access.Size = new System.Drawing.Size(292, 33);
            this.Choice1Access.TabIndex = 9;
            this.Choice1Access.Text = "Access";
            this.Choice1Access.UseVisualStyleBackColor = false;
            this.Choice1Access.Click += new System.EventHandler(this.Choice1Access_Click);
            // 
            // Choice2Access
            // 
            this.Choice2Access.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Choice2Access.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Choice2Access.FlatAppearance.BorderSize = 0;
            this.Choice2Access.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choice2Access.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Choice2Access.ForeColor = System.Drawing.Color.White;
            this.Choice2Access.Location = new System.Drawing.Point(406, 489);
            this.Choice2Access.Name = "Choice2Access";
            this.Choice2Access.Size = new System.Drawing.Size(292, 33);
            this.Choice2Access.TabIndex = 9;
            this.Choice2Access.Text = "Access";
            this.Choice2Access.UseVisualStyleBackColor = false;
            this.Choice2Access.Click += new System.EventHandler(this.Choice2Access_Click);
            // 
            // Choice3Access
            // 
            this.Choice3Access.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Choice3Access.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Choice3Access.FlatAppearance.BorderSize = 0;
            this.Choice3Access.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choice3Access.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Choice3Access.ForeColor = System.Drawing.Color.White;
            this.Choice3Access.Location = new System.Drawing.Point(791, 489);
            this.Choice3Access.Name = "Choice3Access";
            this.Choice3Access.Size = new System.Drawing.Size(292, 33);
            this.Choice3Access.TabIndex = 9;
            this.Choice3Access.Text = "Access";
            this.Choice3Access.UseVisualStyleBackColor = false;
            this.Choice3Access.Click += new System.EventHandler(this.Choice3Access_Click);
            // 
            // Choice1Desc
            // 
            this.Choice1Desc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Choice1Desc.BackColor = System.Drawing.Color.Transparent;
            this.Choice1Desc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choice1Desc.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Choice1Desc.ForeColor = System.Drawing.Color.Gray;
            this.Choice1Desc.Location = new System.Drawing.Point(45, 534);
            this.Choice1Desc.Name = "Choice1Desc";
            this.Choice1Desc.Size = new System.Drawing.Size(245, 116);
            this.Choice1Desc.TabIndex = 10;
            this.Choice1Desc.Text = "This will display the order number for current orders being prepared in the kitch" +
    "en. The order number is written on the printed receipt.";
            this.Choice1Desc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Choice2Desc
            // 
            this.Choice2Desc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Choice2Desc.BackColor = System.Drawing.Color.Transparent;
            this.Choice2Desc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choice2Desc.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Choice2Desc.ForeColor = System.Drawing.Color.Gray;
            this.Choice2Desc.Location = new System.Drawing.Point(430, 534);
            this.Choice2Desc.Name = "Choice2Desc";
            this.Choice2Desc.Size = new System.Drawing.Size(245, 116);
            this.Choice2Desc.TabIndex = 10;
            this.Choice2Desc.Text = "This will allow the customer to order from the menu set by the kitchen. The menu " +
    "can send orders to the kitchen, and print receipts for the customers.";
            this.Choice2Desc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Choice3Desc
            // 
            this.Choice3Desc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Choice3Desc.BackColor = System.Drawing.Color.Transparent;
            this.Choice3Desc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Choice3Desc.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Choice3Desc.ForeColor = System.Drawing.Color.Gray;
            this.Choice3Desc.Location = new System.Drawing.Point(815, 534);
            this.Choice3Desc.Name = "Choice3Desc";
            this.Choice3Desc.Size = new System.Drawing.Size(245, 116);
            this.Choice3Desc.TabIndex = 10;
            this.Choice3Desc.Text = "This is where you can manage the system. Add items to the menu, check and manage " +
    "orders, and more.";
            this.Choice3Desc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.Choice1Title);
            this.panel1.Location = new System.Drawing.Point(21, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 137);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel2.Controls.Add(this.Choice2Title);
            this.panel2.Location = new System.Drawing.Point(406, 216);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 137);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel3.Controls.Add(this.Choice3Title);
            this.panel3.Location = new System.Drawing.Point(791, 216);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(292, 137);
            this.panel3.TabIndex = 11;
            // 
            // Choice3Pic
            // 
            this.Choice3Pic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Choice3Pic.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.KITCHEN_MANAGE;
            this.Choice3Pic.Location = new System.Drawing.Point(791, 253);
            this.Choice3Pic.Name = "Choice3Pic";
            this.Choice3Pic.Size = new System.Drawing.Size(292, 236);
            this.Choice3Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Choice3Pic.TabIndex = 0;
            this.Choice3Pic.TabStop = false;
            // 
            // Choice2Pic
            // 
            this.Choice2Pic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Choice2Pic.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.ORDER_HERE;
            this.Choice2Pic.Location = new System.Drawing.Point(406, 253);
            this.Choice2Pic.Name = "Choice2Pic";
            this.Choice2Pic.Size = new System.Drawing.Size(292, 236);
            this.Choice2Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Choice2Pic.TabIndex = 0;
            this.Choice2Pic.TabStop = false;
            // 
            // Choice1Pic
            // 
            this.Choice1Pic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Choice1Pic.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.TV_Screen;
            this.Choice1Pic.Location = new System.Drawing.Point(21, 253);
            this.Choice1Pic.Name = "Choice1Pic";
            this.Choice1Pic.Size = new System.Drawing.Size(292, 236);
            this.Choice1Pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Choice1Pic.TabIndex = 0;
            this.Choice1Pic.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(426, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Note: ALT + F4 to close menu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.Choice1Pic);
            this.panel4.Controls.Add(this.Choice3Pic);
            this.panel4.Controls.Add(this.Choice2Pic);
            this.panel4.Controls.Add(this.Choice3Desc);
            this.panel4.Controls.Add(this.Title);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.Choice2Desc);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.Choice1Desc);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.Choice3Access);
            this.panel4.Controls.Add(this.Choice2Access);
            this.panel4.Controls.Add(this.Choice1Access);
            this.panel4.Controls.Add(this.SubTitle);
            this.panel4.Location = new System.Drawing.Point(41, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1104, 665);
            this.panel4.TabIndex = 12;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1180, 713);
            this.Controls.Add(this.DragPanel);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.DragPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SystemLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Choice3Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Choice2Pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Choice1Pic)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Choice1Pic;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label SubTitle;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.PictureBox SystemLogo;
        private System.Windows.Forms.Panel DragPanel;
        private System.Windows.Forms.PictureBox Choice2Pic;
        private System.Windows.Forms.PictureBox Choice3Pic;
        private System.Windows.Forms.Label Choice1Title;
        private System.Windows.Forms.Label Choice3Title;
        private System.Windows.Forms.Label Choice2Title;
        private System.Windows.Forms.Button Choice1Access;
        private System.Windows.Forms.Button Choice2Access;
        private System.Windows.Forms.Button Choice3Access;
        private System.Windows.Forms.Label Choice1Desc;
        private System.Windows.Forms.Label Choice2Desc;
        private System.Windows.Forms.Label Choice3Desc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
    }
}