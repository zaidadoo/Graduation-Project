using System.Drawing;

namespace Restaurant_Contactless_Dining_System
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.Title = new System.Windows.Forms.Label();
            this.SubTitle = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.SubmitPassword = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ShowPassword = new System.Windows.Forms.Button();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.RestaurantNameLabel = new System.Windows.Forms.Label();
            this.RestauranName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LogoUpload = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoUpload)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Title.Font = new System.Drawing.Font("Calibri", 48F);
            this.Title.ForeColor = System.Drawing.Color.Black;
            this.Title.Location = new System.Drawing.Point(114, 35);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(417, 71);
            this.Title.TabIndex = 0;
            this.Title.Text = "INITIAL SETUP";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SubTitle
            // 
            this.SubTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SubTitle.BackColor = System.Drawing.Color.Transparent;
            this.SubTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubTitle.Font = new System.Drawing.Font("Calibri Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubTitle.ForeColor = System.Drawing.Color.Black;
            this.SubTitle.Location = new System.Drawing.Point(53, 106);
            this.SubTitle.Name = "SubTitle";
            this.SubTitle.Size = new System.Drawing.Size(539, 116);
            this.SubTitle.TabIndex = 2;
            this.SubTitle.Text = "Welcome to the initial setup. Before adding items to the menu and customizing it," +
    " we\'d like you to input an admin password, the name of the restaurant, and the r" +
    "estaurant logo.";
            this.SubTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Password
            // 
            this.Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Password.BackColor = System.Drawing.Color.Gainsboro;
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(35, 315);
            this.Password.MaxLength = 40;
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(278, 24);
            this.Password.TabIndex = 3;
            this.Password.UseSystemPasswordChar = true;
            // 
            // SubmitPassword
            // 
            this.SubmitPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SubmitPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SubmitPassword.FlatAppearance.BorderSize = 0;
            this.SubmitPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitPassword.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitPassword.ForeColor = System.Drawing.Color.White;
            this.SubmitPassword.Location = new System.Drawing.Point(33, 430);
            this.SubmitPassword.Name = "SubmitPassword";
            this.SubmitPassword.Size = new System.Drawing.Size(280, 45);
            this.SubmitPassword.TabIndex = 4;
            this.SubmitPassword.Text = "Submit";
            this.SubmitPassword.UseVisualStyleBackColor = false;
            this.SubmitPassword.Click += new System.EventHandler(this.SubmitPassword_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.ExitButton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 51);
            this.panel1.TabIndex = 5;
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
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.LOGO_WHITE;
            this.pictureBox1.Location = new System.Drawing.Point(642, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // ShowPassword
            // 
            this.ShowPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ShowPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ShowPassword.FlatAppearance.BorderSize = 0;
            this.ShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowPassword.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPassword.ForeColor = System.Drawing.Color.White;
            this.ShowPassword.Location = new System.Drawing.Point(255, 345);
            this.ShowPassword.Name = "ShowPassword";
            this.ShowPassword.Size = new System.Drawing.Size(58, 24);
            this.ShowPassword.TabIndex = 4;
            this.ShowPassword.Text = "Show";
            this.ShowPassword.UseVisualStyleBackColor = false;
            this.ShowPassword.Click += new System.EventHandler(this.ShowPassword_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.Black;
            this.PasswordLabel.Location = new System.Drawing.Point(31, 293);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(71, 19);
            this.PasswordLabel.TabIndex = 6;
            this.PasswordLabel.Text = "Password";
            // 
            // RestaurantNameLabel
            // 
            this.RestaurantNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RestaurantNameLabel.AutoSize = true;
            this.RestaurantNameLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestaurantNameLabel.ForeColor = System.Drawing.Color.Black;
            this.RestaurantNameLabel.Location = new System.Drawing.Point(31, 237);
            this.RestaurantNameLabel.Name = "RestaurantNameLabel";
            this.RestaurantNameLabel.Size = new System.Drawing.Size(122, 19);
            this.RestaurantNameLabel.TabIndex = 8;
            this.RestaurantNameLabel.Text = "Restaurant Name";
            // 
            // RestauranName
            // 
            this.RestauranName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RestauranName.BackColor = System.Drawing.Color.Gainsboro;
            this.RestauranName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RestauranName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestauranName.Location = new System.Drawing.Point(35, 259);
            this.RestauranName.MaxLength = 40;
            this.RestauranName.Name = "RestauranName";
            this.RestauranName.Size = new System.Drawing.Size(278, 24);
            this.RestauranName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(389, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Click Box To Upload Logo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LogoUpload
            // 
            this.LogoUpload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogoUpload.BackColor = System.Drawing.Color.Gainsboro;
            this.LogoUpload.Location = new System.Drawing.Point(336, 259);
            this.LogoUpload.Name = "LogoUpload";
            this.LogoUpload.Size = new System.Drawing.Size(278, 216);
            this.LogoUpload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoUpload.TabIndex = 10;
            this.LogoUpload.TabStop = false;
            this.LogoUpload.Click += new System.EventHandler(this.LogoUpload_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.LogoUpload);
            this.panel2.Controls.Add(this.SubTitle);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.Title);
            this.panel2.Controls.Add(this.RestaurantNameLabel);
            this.panel2.Controls.Add(this.Password);
            this.panel2.Controls.Add(this.RestauranName);
            this.panel2.Controls.Add(this.SubmitPassword);
            this.panel2.Controls.Add(this.PasswordLabel);
            this.panel2.Controls.Add(this.ShowPassword);
            this.panel2.Location = new System.Drawing.Point(29, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 510);
            this.panel2.TabIndex = 11;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(703, 558);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupForm";
            this.Text = "Restaurant Initial Setup";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoUpload)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label SubTitle;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button SubmitPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ShowPassword;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label RestaurantNameLabel;
        private System.Windows.Forms.TextBox RestauranName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox LogoUpload;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel panel2;
    }
}

