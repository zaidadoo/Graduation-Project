
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
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.SubmitPassword = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(127, 105);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(236, 31);
            this.Password.TabIndex = 0;
            this.Password.UseSystemPasswordChar = true;
            this.Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_KeyDown);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(159, 36);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(173, 33);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "PLEASE ENTER";
            // 
            // SubmitPassword
            // 
            this.SubmitPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.SubmitPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitPassword.ForeColor = System.Drawing.Color.White;
            this.SubmitPassword.Location = new System.Drawing.Point(151, 142);
            this.SubmitPassword.Name = "SubmitPassword";
            this.SubmitPassword.Size = new System.Drawing.Size(188, 31);
            this.SubmitPassword.TabIndex = 2;
            this.SubmitPassword.Text = "Submit";
            this.SubmitPassword.UseVisualStyleBackColor = false;
            this.SubmitPassword.Click += new System.EventHandler(this.SubmitPassword_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F);
            this.label1.Location = new System.Drawing.Point(132, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "ADMIN PASSWORD";
            // 
            // PasswordChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 208);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SubmitPassword);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.Password);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PasswordChecker";
            this.Text = "Admin Password Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button SubmitPassword;
        private System.Windows.Forms.Label label1;
    }
}