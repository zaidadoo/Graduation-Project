
namespace Restaurant_Contactless_Dining_System
{
    partial class RestaurantMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestaurantMenu));
            this.StartOrder = new System.Windows.Forms.Button();
            this.LogoFrame = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.menuDisplay = new Restaurant_Contactless_Dining_System.CompleteMenu();
            ((System.ComponentModel.ISupportInitialize)(this.LogoFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // StartOrder
            // 
            this.StartOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StartOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.StartOrder.FlatAppearance.BorderSize = 0;
            this.StartOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartOrder.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartOrder.ForeColor = System.Drawing.Color.White;
            this.StartOrder.Location = new System.Drawing.Point(496, 434);
            this.StartOrder.Name = "StartOrder";
            this.StartOrder.Size = new System.Drawing.Size(292, 63);
            this.StartOrder.TabIndex = 13;
            this.StartOrder.Text = "Start Order";
            this.StartOrder.UseVisualStyleBackColor = false;
            this.StartOrder.Click += new System.EventHandler(this.StartOrder_Click);
            // 
            // LogoFrame
            // 
            this.LogoFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoFrame.Location = new System.Drawing.Point(553, 132);
            this.LogoFrame.Name = "LogoFrame";
            this.LogoFrame.Size = new System.Drawing.Size(179, 148);
            this.LogoFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoFrame.TabIndex = 12;
            this.LogoFrame.TabStop = false;
            // 
            // Title
            // 
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Title.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(218, 294);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(848, 83);
            this.Title.TabIndex = 11;
            this.Title.Text = "WELCOME TO RESTAURANT";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // menuDisplay
            // 
            this.menuDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.menuDisplay.Location = new System.Drawing.Point(-1, -1);
            this.menuDisplay.Name = "menuDisplay";
            this.menuDisplay.Size = new System.Drawing.Size(1287, 633);
            this.menuDisplay.TabIndex = 14;
            this.menuDisplay.Visible = false;
            // 
            // RestaurantMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1284, 628);
            this.Controls.Add(this.menuDisplay);
            this.Controls.Add(this.StartOrder);
            this.Controls.Add(this.LogoFrame);
            this.Controls.Add(this.Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RestaurantMenu";
            this.Text = "Restaurant Menu";
            this.Load += new System.EventHandler(this.RestaurantMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoFrame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartOrder;
        private System.Windows.Forms.PictureBox LogoFrame;
        private System.Windows.Forms.Label Title;
        public CompleteMenu menuDisplay;
    }
}