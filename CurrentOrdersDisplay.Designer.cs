
namespace Restaurant_Contactless_Dining_System
{
    partial class CustomerOrdersDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerOrdersDisplay));
            this.Menu2 = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.LogoPanel = new System.Windows.Forms.Panel();
            this.LogoFrame = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.OrderNumbers = new System.Windows.Forms.TextBox();
            this.LogoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu2
            // 
            this.Menu2.BackColor = System.Drawing.Color.DimGray;
            this.Menu2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Menu2.Location = new System.Drawing.Point(0, 1010);
            this.Menu2.Name = "Menu2";
            this.Menu2.Size = new System.Drawing.Size(1904, 31);
            this.Menu2.TabIndex = 0;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.BackColor = System.Drawing.Color.DarkGray;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(1825, 1010);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(79, 31);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LogoPanel
            // 
            this.LogoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LogoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.LogoPanel.Controls.Add(this.LogoFrame);
            this.LogoPanel.Location = new System.Drawing.Point(-10, -3);
            this.LogoPanel.Name = "LogoPanel";
            this.LogoPanel.Size = new System.Drawing.Size(241, 1044);
            this.LogoPanel.TabIndex = 3;
            // 
            // LogoFrame
            // 
            this.LogoFrame.BackColor = System.Drawing.Color.Transparent;
            this.LogoFrame.Location = new System.Drawing.Point(36, 25);
            this.LogoFrame.Name = "LogoFrame";
            this.LogoFrame.Size = new System.Drawing.Size(174, 163);
            this.LogoFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoFrame.TabIndex = 0;
            this.LogoFrame.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Title.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(237, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(1514, 117);
            this.Title.TabIndex = 4;
            this.Title.Text = "CURRENT ORDERS BEING PREPARED:";
            // 
            // OrderNumbers
            // 
            this.OrderNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.OrderNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OrderNumbers.Enabled = false;
            this.OrderNumbers.Font = new System.Drawing.Font("Calibri Light", 72F);
            this.OrderNumbers.ForeColor = System.Drawing.Color.DarkGray;
            this.OrderNumbers.Location = new System.Drawing.Point(233, 112);
            this.OrderNumbers.Multiline = true;
            this.OrderNumbers.Name = "OrderNumbers";
            this.OrderNumbers.ReadOnly = true;
            this.OrderNumbers.Size = new System.Drawing.Size(1498, 810);
            this.OrderNumbers.TabIndex = 5;
            this.OrderNumbers.TabStop = false;
            this.OrderNumbers.Text = "None at the moment...";
            // 
            // CustomerOrdersDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.OrderNumbers);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.Menu2);
            this.Controls.Add(this.LogoPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "CustomerOrdersDisplay";
            this.Text = "Customer Orders Display";
            this.Load += new System.EventHandler(this.CustomerOrdersDisplay_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CustomersOrdersDisplay_KeyDown);
            this.LogoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Menu2;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel LogoPanel;
        private System.Windows.Forms.PictureBox LogoFrame;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox OrderNumbers;
    }
}