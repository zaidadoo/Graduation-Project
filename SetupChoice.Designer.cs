namespace Restaurant_Contactless_Dining_System
{
  partial class SetupChoice
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupChoice));
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.loginButton = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.branchField = new System.Windows.Forms.TextBox();
      this.passwordField = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.setupButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(232)))));
      this.pictureBox1.Location = new System.Drawing.Point(-22, -9);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(428, 519);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // pictureBox2
      // 
      this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(232)))));
      this.pictureBox2.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.Logo_copy;
      this.pictureBox2.Location = new System.Drawing.Point(36, 12);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(293, 313);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox2.TabIndex = 1;
      this.pictureBox2.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(462, 70);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(118, 30);
      this.label1.TabIndex = 2;
      this.label1.Text = "Hey, hello!";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
      this.label2.Location = new System.Drawing.Point(463, 100);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(230, 40);
      this.label2.TabIndex = 3;
      this.label2.Text = "Please enter the branch details,\r\nor create a new branch to the left!\r\n";
      // 
      // loginButton
      // 
      this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(232)))));
      this.loginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.loginButton.FlatAppearance.BorderSize = 0;
      this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.loginButton.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.loginButton.ForeColor = System.Drawing.Color.White;
      this.loginButton.Location = new System.Drawing.Point(467, 334);
      this.loginButton.Name = "loginButton";
      this.loginButton.Size = new System.Drawing.Size(278, 41);
      this.loginButton.TabIndex = 4;
      this.loginButton.Text = "Login";
      this.loginButton.UseVisualStyleBackColor = false;
      this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
      this.label3.Location = new System.Drawing.Point(464, 161);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(68, 17);
      this.label3.TabIndex = 5;
      this.label3.Text = "Branch ID\r\n";
      // 
      // branchField
      // 
      this.branchField.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.branchField.BackColor = System.Drawing.Color.White;
      this.branchField.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.branchField.Location = new System.Drawing.Point(467, 181);
      this.branchField.MaxLength = 40;
      this.branchField.Name = "branchField";
      this.branchField.Size = new System.Drawing.Size(278, 32);
      this.branchField.TabIndex = 6;
      // 
      // passwordField
      // 
      this.passwordField.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.passwordField.BackColor = System.Drawing.Color.White;
      this.passwordField.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.passwordField.Location = new System.Drawing.Point(467, 258);
      this.passwordField.MaxLength = 40;
      this.passwordField.Name = "passwordField";
      this.passwordField.Size = new System.Drawing.Size(278, 32);
      this.passwordField.TabIndex = 8;
      this.passwordField.UseSystemPasswordChar = true;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
      this.label4.Location = new System.Drawing.Point(464, 238);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(66, 17);
      this.label4.TabIndex = 7;
      this.label4.Text = "Password";
      // 
      // setupButton
      // 
      this.setupButton.BackColor = System.Drawing.Color.White;
      this.setupButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.setupButton.FlatAppearance.BorderSize = 0;
      this.setupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.setupButton.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.setupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(232)))));
      this.setupButton.Location = new System.Drawing.Point(47, 334);
      this.setupButton.Name = "setupButton";
      this.setupButton.Size = new System.Drawing.Size(278, 41);
      this.setupButton.TabIndex = 9;
      this.setupButton.Text = "Setup";
      this.setupButton.UseVisualStyleBackColor = false;
      this.setupButton.Click += new System.EventHandler(this.setupButton_Click);
      // 
      // SetupChoice
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.setupButton);
      this.Controls.Add(this.passwordField);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.branchField);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.loginButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pictureBox2);
      this.Controls.Add(this.pictureBox1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "SetupChoice";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Setup Choice";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button loginButton;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox branchField;
    private System.Windows.Forms.TextBox passwordField;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button setupButton;
  }
}