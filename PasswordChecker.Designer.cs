
namespace Restaurant_Contactless_Dining_System
{
    partial class PasswordChecker
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordChecker));
      this.Password = new System.Windows.Forms.TextBox();
      this.SubmitPassword = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.branchField = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // Password
      // 
      this.Password.BackColor = System.Drawing.Color.White;
      this.Password.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.Password.Location = new System.Drawing.Point(42, 242);
      this.Password.Name = "Password";
      this.Password.Size = new System.Drawing.Size(278, 32);
      this.Password.TabIndex = 0;
      this.Password.UseSystemPasswordChar = true;
      this.Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_KeyDown);
      // 
      // SubmitPassword
      // 
      this.SubmitPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(232)))));
      this.SubmitPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SubmitPassword.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
      this.SubmitPassword.ForeColor = System.Drawing.Color.White;
      this.SubmitPassword.Location = new System.Drawing.Point(42, 310);
      this.SubmitPassword.Name = "SubmitPassword";
      this.SubmitPassword.Size = new System.Drawing.Size(278, 44);
      this.SubmitPassword.TabIndex = 2;
      this.SubmitPassword.Text = "Submit";
      this.SubmitPassword.UseVisualStyleBackColor = false;
      this.SubmitPassword.Click += new System.EventHandler(this.SubmitPassword_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
      this.label4.Location = new System.Drawing.Point(39, 222);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(66, 17);
      this.label4.TabIndex = 14;
      this.label4.Text = "Password";
      // 
      // branchField
      // 
      this.branchField.BackColor = System.Drawing.Color.White;
      this.branchField.Enabled = false;
      this.branchField.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
      this.branchField.Location = new System.Drawing.Point(42, 175);
      this.branchField.MaxLength = 40;
      this.branchField.Name = "branchField";
      this.branchField.ReadOnly = true;
      this.branchField.Size = new System.Drawing.Size(278, 32);
      this.branchField.TabIndex = 13;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
      this.label3.Location = new System.Drawing.Point(39, 155);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(68, 17);
      this.label3.TabIndex = 12;
      this.label3.Text = "Branch ID\r\n";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.SystemColors.ActiveBorder;
      this.label2.Location = new System.Drawing.Point(20, 103);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(318, 20);
      this.label2.TabIndex = 10;
      this.label2.Text = "Please enter this branch\'s password to proceed.\r\n";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(112, 71);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(135, 30);
      this.label5.TabIndex = 9;
      this.label5.Text = "Quick Check";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.Logo_blue_copy;
      this.pictureBox1.Location = new System.Drawing.Point(152, 20);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(54, 50);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 16;
      this.pictureBox1.TabStop = false;
      // 
      // PasswordChecker
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(359, 407);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.branchField);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.SubmitPassword);
      this.Controls.Add(this.Password);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "PasswordChecker";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Admin Password Login";
      this.Load += new System.EventHandler(this.PasswordChecker_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button SubmitPassword;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox branchField;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}