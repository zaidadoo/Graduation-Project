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
      this.topStripPanel = new System.Windows.Forms.Panel();
      this.ExitButton = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.ShowPassword = new System.Windows.Forms.Button();
      this.SubmitPassword = new System.Windows.Forms.Button();
      this.branchIdField = new System.Windows.Forms.TextBox();
      this.passwordField = new System.Windows.Forms.TextBox();
      this.RestaurantNameLabel = new System.Windows.Forms.Label();
      this.Title = new System.Windows.Forms.Label();
      this.SubTitle = new System.Windows.Forms.Label();
      this.setupPanel = new System.Windows.Forms.Panel();
      this.newRestaurantCheck = new System.Windows.Forms.CheckBox();
      this.textColorBox = new System.Windows.Forms.PictureBox();
      this.label8 = new System.Windows.Forms.Label();
      this.textColorField = new System.Windows.Forms.TextBox();
      this.accentColorBox = new System.Windows.Forms.PictureBox();
      this.label7 = new System.Windows.Forms.Label();
      this.accentColorField = new System.Windows.Forms.TextBox();
      this.mainColorBox = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.mainColorField = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.numOfTablesField = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.LogoUpload = new System.Windows.Forms.PictureBox();
      this.nameEnglishField = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.nameArabicField = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.topStripPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.setupPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.textColorBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.accentColorBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.mainColorBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numOfTablesField)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.LogoUpload)).BeginInit();
      this.SuspendLayout();
      // 
      // topStripPanel
      // 
      this.topStripPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(232)))));
      this.topStripPanel.Controls.Add(this.ExitButton);
      this.topStripPanel.Controls.Add(this.pictureBox1);
      this.topStripPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.topStripPanel.Location = new System.Drawing.Point(0, 0);
      this.topStripPanel.Name = "topStripPanel";
      this.topStripPanel.Size = new System.Drawing.Size(1173, 51);
      this.topStripPanel.TabIndex = 5;
      // 
      // ExitButton
      // 
      this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(232)))));
      this.ExitButton.FlatAppearance.BorderSize = 0;
      this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExitButton.ForeColor = System.Drawing.Color.White;
      this.ExitButton.Location = new System.Drawing.Point(1094, 0);
      this.ExitButton.Name = "ExitButton";
      this.ExitButton.Size = new System.Drawing.Size(79, 51);
      this.ExitButton.TabIndex = 1;
      this.ExitButton.Text = "Exit";
      this.ExitButton.UseVisualStyleBackColor = false;
      this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.Logo_copy;
      this.pictureBox1.Location = new System.Drawing.Point(3, 8);
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
      this.ShowPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(232)))));
      this.ShowPassword.FlatAppearance.BorderSize = 0;
      this.ShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ShowPassword.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ShowPassword.ForeColor = System.Drawing.Color.White;
      this.ShowPassword.Location = new System.Drawing.Point(288, 558);
      this.ShowPassword.Name = "ShowPassword";
      this.ShowPassword.Size = new System.Drawing.Size(58, 24);
      this.ShowPassword.TabIndex = 4;
      this.ShowPassword.Text = "Show";
      this.ShowPassword.UseVisualStyleBackColor = false;
      this.ShowPassword.Click += new System.EventHandler(this.ShowPassword_Click);
      // 
      // SubmitPassword
      // 
      this.SubmitPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.SubmitPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(232)))));
      this.SubmitPassword.FlatAppearance.BorderSize = 0;
      this.SubmitPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SubmitPassword.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.SubmitPassword.ForeColor = System.Drawing.Color.White;
      this.SubmitPassword.Location = new System.Drawing.Point(446, 620);
      this.SubmitPassword.Name = "SubmitPassword";
      this.SubmitPassword.Size = new System.Drawing.Size(280, 45);
      this.SubmitPassword.TabIndex = 4;
      this.SubmitPassword.Text = "Submit";
      this.SubmitPassword.UseVisualStyleBackColor = false;
      this.SubmitPassword.Click += new System.EventHandler(this.SubmitPassword_Click);
      // 
      // branchIdField
      // 
      this.branchIdField.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.branchIdField.BackColor = System.Drawing.Color.White;
      this.branchIdField.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.branchIdField.Location = new System.Drawing.Point(68, 376);
      this.branchIdField.MaxLength = 40;
      this.branchIdField.Name = "branchIdField";
      this.branchIdField.Size = new System.Drawing.Size(278, 32);
      this.branchIdField.TabIndex = 1;
      // 
      // passwordField
      // 
      this.passwordField.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.passwordField.BackColor = System.Drawing.Color.White;
      this.passwordField.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.passwordField.Location = new System.Drawing.Point(68, 520);
      this.passwordField.MaxLength = 40;
      this.passwordField.Name = "passwordField";
      this.passwordField.Size = new System.Drawing.Size(278, 32);
      this.passwordField.TabIndex = 3;
      this.passwordField.UseSystemPasswordChar = true;
      // 
      // RestaurantNameLabel
      // 
      this.RestaurantNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.RestaurantNameLabel.AutoSize = true;
      this.RestaurantNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.RestaurantNameLabel.ForeColor = System.Drawing.Color.Black;
      this.RestaurantNameLabel.Location = new System.Drawing.Point(65, 356);
      this.RestaurantNameLabel.Name = "RestaurantNameLabel";
      this.RestaurantNameLabel.Size = new System.Drawing.Size(186, 17);
      this.RestaurantNameLabel.TabIndex = 8;
      this.RestaurantNameLabel.Text = "Restaurant Unique Branch ID";
      // 
      // Title
      // 
      this.Title.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.Title.BackColor = System.Drawing.Color.Transparent;
      this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.Title.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Title.ForeColor = System.Drawing.Color.Black;
      this.Title.Location = new System.Drawing.Point(38, 27);
      this.Title.Name = "Title";
      this.Title.Size = new System.Drawing.Size(417, 71);
      this.Title.TabIndex = 0;
      this.Title.Text = "INITIAL SETUP";
      this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // SubTitle
      // 
      this.SubTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.SubTitle.BackColor = System.Drawing.Color.Transparent;
      this.SubTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SubTitle.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.SubTitle.ForeColor = System.Drawing.Color.DimGray;
      this.SubTitle.Location = new System.Drawing.Point(42, 84);
      this.SubTitle.Name = "SubTitle";
      this.SubTitle.Size = new System.Drawing.Size(1041, 67);
      this.SubTitle.TabIndex = 2;
      this.SubTitle.Text = resources.GetString("SubTitle.Text");
      // 
      // setupPanel
      // 
      this.setupPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.setupPanel.BackColor = System.Drawing.Color.White;
      this.setupPanel.Controls.Add(this.nameEnglishField);
      this.setupPanel.Controls.Add(this.label2);
      this.setupPanel.Controls.Add(this.newRestaurantCheck);
      this.setupPanel.Controls.Add(this.label3);
      this.setupPanel.Controls.Add(this.textColorBox);
      this.setupPanel.Controls.Add(this.nameArabicField);
      this.setupPanel.Controls.Add(this.label8);
      this.setupPanel.Controls.Add(this.textColorField);
      this.setupPanel.Controls.Add(this.accentColorBox);
      this.setupPanel.Controls.Add(this.label7);
      this.setupPanel.Controls.Add(this.accentColorField);
      this.setupPanel.Controls.Add(this.mainColorBox);
      this.setupPanel.Controls.Add(this.label1);
      this.setupPanel.Controls.Add(this.mainColorField);
      this.setupPanel.Controls.Add(this.label6);
      this.setupPanel.Controls.Add(this.numOfTablesField);
      this.setupPanel.Controls.Add(this.label5);
      this.setupPanel.Controls.Add(this.label4);
      this.setupPanel.Controls.Add(this.LogoUpload);
      this.setupPanel.Controls.Add(this.SubTitle);
      this.setupPanel.Controls.Add(this.Title);
      this.setupPanel.Controls.Add(this.RestaurantNameLabel);
      this.setupPanel.Controls.Add(this.passwordField);
      this.setupPanel.Controls.Add(this.branchIdField);
      this.setupPanel.Controls.Add(this.SubmitPassword);
      this.setupPanel.Controls.Add(this.ShowPassword);
      this.setupPanel.Location = new System.Drawing.Point(0, 51);
      this.setupPanel.Name = "setupPanel";
      this.setupPanel.Size = new System.Drawing.Size(1173, 699);
      this.setupPanel.TabIndex = 11;
      // 
      // newRestaurantCheck
      // 
      this.newRestaurantCheck.AutoSize = true;
      this.newRestaurantCheck.Checked = true;
      this.newRestaurantCheck.CheckState = System.Windows.Forms.CheckState.Checked;
      this.newRestaurantCheck.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
      this.newRestaurantCheck.Location = new System.Drawing.Point(68, 168);
      this.newRestaurantCheck.Name = "newRestaurantCheck";
      this.newRestaurantCheck.Size = new System.Drawing.Size(124, 21);
      this.newRestaurantCheck.TabIndex = 29;
      this.newRestaurantCheck.Text = "New Restaurant";
      this.newRestaurantCheck.UseVisualStyleBackColor = true;
      this.newRestaurantCheck.CheckedChanged += new System.EventHandler(this.newRestaurantCheck_CheckedChanged);
      // 
      // textColorBox
      // 
      this.textColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.textColorBox.Location = new System.Drawing.Point(589, 376);
      this.textColorBox.Name = "textColorBox";
      this.textColorBox.Size = new System.Drawing.Size(32, 32);
      this.textColorBox.TabIndex = 28;
      this.textColorBox.TabStop = false;
      // 
      // label8
      // 
      this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.ForeColor = System.Drawing.Color.Black;
      this.label8.Location = new System.Drawing.Point(465, 356);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(71, 17);
      this.label8.TabIndex = 27;
      this.label8.Text = "Text Color";
      // 
      // textColorField
      // 
      this.textColorField.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.textColorField.BackColor = System.Drawing.Color.White;
      this.textColorField.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.textColorField.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.textColorField.Location = new System.Drawing.Point(468, 376);
      this.textColorField.MaxLength = 40;
      this.textColorField.Name = "textColorField";
      this.textColorField.Size = new System.Drawing.Size(115, 32);
      this.textColorField.TabIndex = 26;
      this.textColorField.TextChanged += new System.EventHandler(this.textColorField_TextChanged);
      // 
      // accentColorBox
      // 
      this.accentColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.accentColorBox.Location = new System.Drawing.Point(589, 304);
      this.accentColorBox.Name = "accentColorBox";
      this.accentColorBox.Size = new System.Drawing.Size(32, 32);
      this.accentColorBox.TabIndex = 25;
      this.accentColorBox.TabStop = false;
      // 
      // label7
      // 
      this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.ForeColor = System.Drawing.Color.Black;
      this.label7.Location = new System.Drawing.Point(465, 284);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(86, 17);
      this.label7.TabIndex = 24;
      this.label7.Text = "Accent Color";
      // 
      // accentColorField
      // 
      this.accentColorField.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.accentColorField.BackColor = System.Drawing.Color.White;
      this.accentColorField.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.accentColorField.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.accentColorField.Location = new System.Drawing.Point(468, 304);
      this.accentColorField.MaxLength = 40;
      this.accentColorField.Name = "accentColorField";
      this.accentColorField.Size = new System.Drawing.Size(115, 32);
      this.accentColorField.TabIndex = 23;
      this.accentColorField.TextChanged += new System.EventHandler(this.accentColorField_TextChanged);
      // 
      // mainColorBox
      // 
      this.mainColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.mainColorBox.Location = new System.Drawing.Point(589, 232);
      this.mainColorBox.Name = "mainColorBox";
      this.mainColorBox.Size = new System.Drawing.Size(32, 32);
      this.mainColorBox.TabIndex = 22;
      this.mainColorBox.TabStop = false;
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.Black;
      this.label1.Location = new System.Drawing.Point(465, 212);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(76, 17);
      this.label1.TabIndex = 21;
      this.label1.Text = "Main Color";
      // 
      // mainColorField
      // 
      this.mainColorField.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.mainColorField.BackColor = System.Drawing.Color.White;
      this.mainColorField.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.mainColorField.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.mainColorField.Location = new System.Drawing.Point(468, 232);
      this.mainColorField.MaxLength = 40;
      this.mainColorField.Name = "mainColorField";
      this.mainColorField.Size = new System.Drawing.Size(115, 32);
      this.mainColorField.TabIndex = 20;
      this.mainColorField.TextChanged += new System.EventHandler(this.mainColorField_TextChanged);
      // 
      // label6
      // 
      this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.ForeColor = System.Drawing.Color.Black;
      this.label6.Location = new System.Drawing.Point(747, 168);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(160, 17);
      this.label6.TabIndex = 19;
      this.label6.Text = "Click box to upload logo";
      // 
      // numOfTablesField
      // 
      this.numOfTablesField.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.numOfTablesField.BackColor = System.Drawing.Color.White;
      this.numOfTablesField.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.numOfTablesField.Location = new System.Drawing.Point(68, 448);
      this.numOfTablesField.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
      this.numOfTablesField.Name = "numOfTablesField";
      this.numOfTablesField.Size = new System.Drawing.Size(278, 32);
      this.numOfTablesField.TabIndex = 18;
      // 
      // label5
      // 
      this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.ForeColor = System.Drawing.Color.Black;
      this.label5.Location = new System.Drawing.Point(65, 428);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(118, 17);
      this.label5.TabIndex = 16;
      this.label5.Text = "Number of Tables";
      // 
      // label4
      // 
      this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.Color.Black;
      this.label4.Location = new System.Drawing.Point(65, 501);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(112, 17);
      this.label4.TabIndex = 15;
      this.label4.Text = "Branch Password";
      // 
      // LogoUpload
      // 
      this.LogoUpload.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.LogoUpload.BackColor = System.Drawing.Color.Transparent;
      this.LogoUpload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.LogoUpload.Location = new System.Drawing.Point(750, 188);
      this.LogoUpload.Name = "LogoUpload";
      this.LogoUpload.Size = new System.Drawing.Size(350, 350);
      this.LogoUpload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.LogoUpload.TabIndex = 10;
      this.LogoUpload.TabStop = false;
      this.LogoUpload.Click += new System.EventHandler(this.LogoUpload_Click);
      // 
      // nameEnglishField
      // 
      this.nameEnglishField.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.nameEnglishField.BackColor = System.Drawing.Color.White;
      this.nameEnglishField.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.nameEnglishField.Location = new System.Drawing.Point(68, 232);
      this.nameEnglishField.MaxLength = 40;
      this.nameEnglishField.Name = "nameEnglishField";
      this.nameEnglishField.Size = new System.Drawing.Size(278, 32);
      this.nameEnglishField.TabIndex = 12;
      // 
      // label3
      // 
      this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.Color.Black;
      this.label3.Location = new System.Drawing.Point(65, 284);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(173, 17);
      this.label3.TabIndex = 13;
      this.label3.Text = "Restaurant Name In Arabic";
      // 
      // nameArabicField
      // 
      this.nameArabicField.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.nameArabicField.BackColor = System.Drawing.Color.White;
      this.nameArabicField.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.nameArabicField.Location = new System.Drawing.Point(68, 304);
      this.nameArabicField.MaxLength = 40;
      this.nameArabicField.Name = "nameArabicField";
      this.nameArabicField.Size = new System.Drawing.Size(278, 32);
      this.nameArabicField.TabIndex = 14;
      // 
      // label2
      // 
      this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.Black;
      this.label2.Location = new System.Drawing.Point(65, 212);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(179, 17);
      this.label2.TabIndex = 11;
      this.label2.Text = "Restaurant Name In English";
      // 
      // SetupForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
      this.ClientSize = new System.Drawing.Size(1173, 747);
      this.ControlBox = false;
      this.Controls.Add(this.topStripPanel);
      this.Controls.Add(this.setupPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "SetupForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Restaurant Initial Setup";
      this.Load += new System.EventHandler(this.SetupForm_Load);
      this.topStripPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.setupPanel.ResumeLayout(false);
      this.setupPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.textColorBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.accentColorBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.mainColorBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numOfTablesField)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.LogoUpload)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel topStripPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ExitButton;
    private System.Windows.Forms.Button ShowPassword;
    private System.Windows.Forms.Button SubmitPassword;
    private System.Windows.Forms.TextBox branchIdField;
    private System.Windows.Forms.TextBox passwordField;
    private System.Windows.Forms.Label RestaurantNameLabel;
    private System.Windows.Forms.Label Title;
    private System.Windows.Forms.Label SubTitle;
    private System.Windows.Forms.Panel setupPanel;
    private System.Windows.Forms.NumericUpDown numOfTablesField;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.PictureBox LogoUpload;
    private System.Windows.Forms.PictureBox textColorBox;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox textColorField;
    private System.Windows.Forms.PictureBox accentColorBox;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox accentColorField;
    private System.Windows.Forms.PictureBox mainColorBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox mainColorField;
    private System.Windows.Forms.CheckBox newRestaurantCheck;
    private System.Windows.Forms.TextBox nameEnglishField;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox nameArabicField;
  }
}

