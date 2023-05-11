
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
      this.engStartOrder = new System.Windows.Forms.Button();
      this.LogoFrame = new System.Windows.Forms.PictureBox();
      this.Title = new System.Windows.Forms.Label();
      this.arabicStartOrder = new System.Windows.Forms.Button();
      this.menuDisplay = new Restaurant_Contactless_Dining_System.CompleteMenu();
      ((System.ComponentModel.ISupportInitialize)(this.LogoFrame)).BeginInit();
      this.SuspendLayout();
      // 
      // engStartOrder
      // 
      this.engStartOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.engStartOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
      this.engStartOrder.FlatAppearance.BorderSize = 0;
      this.engStartOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.engStartOrder.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.engStartOrder.ForeColor = System.Drawing.Color.White;
      this.engStartOrder.Location = new System.Drawing.Point(553, 633);
      this.engStartOrder.Name = "engStartOrder";
      this.engStartOrder.Size = new System.Drawing.Size(382, 102);
      this.engStartOrder.TabIndex = 13;
      this.engStartOrder.Text = "English - Start Order";
      this.engStartOrder.UseVisualStyleBackColor = false;
      this.engStartOrder.Click += new System.EventHandler(this.StartOrder_Click);
      // 
      // LogoFrame
      // 
      this.LogoFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.LogoFrame.BackColor = System.Drawing.Color.Transparent;
      this.LogoFrame.Location = new System.Drawing.Point(553, 305);
      this.LogoFrame.Name = "LogoFrame";
      this.LogoFrame.Size = new System.Drawing.Size(799, 148);
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
      this.Title.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Title.ForeColor = System.Drawing.Color.White;
      this.Title.Location = new System.Drawing.Point(218, 467);
      this.Title.Name = "Title";
      this.Title.Size = new System.Drawing.Size(1468, 153);
      this.Title.TabIndex = 11;
      this.Title.Text = "WELCOME TO RESTAURANT\r\nنرحب بكم في كنتاكي";
      this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // arabicStartOrder
      // 
      this.arabicStartOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.arabicStartOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
      this.arabicStartOrder.FlatAppearance.BorderSize = 0;
      this.arabicStartOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.arabicStartOrder.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.arabicStartOrder.ForeColor = System.Drawing.Color.White;
      this.arabicStartOrder.Location = new System.Drawing.Point(970, 633);
      this.arabicStartOrder.Name = "arabicStartOrder";
      this.arabicStartOrder.Size = new System.Drawing.Size(382, 102);
      this.arabicStartOrder.TabIndex = 15;
      this.arabicStartOrder.Text = "اللغة العربية - ابدأ طلبك";
      this.arabicStartOrder.UseVisualStyleBackColor = false;
      this.arabicStartOrder.Click += new System.EventHandler(this.arabicStartOrder_Click);
      // 
      // menuDisplay
      // 
      this.menuDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.menuDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
      this.menuDisplay.Location = new System.Drawing.Point(-6, -1);
      this.menuDisplay.Name = "menuDisplay";
      this.menuDisplay.Size = new System.Drawing.Size(1907, 1046);
      this.menuDisplay.TabIndex = 14;
      this.menuDisplay.Visible = false;
      // 
      // RestaurantMenu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
      this.ClientSize = new System.Drawing.Size(1904, 1041);
      this.Controls.Add(this.menuDisplay);
      this.Controls.Add(this.arabicStartOrder);
      this.Controls.Add(this.engStartOrder);
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

        private System.Windows.Forms.Button engStartOrder;
        private System.Windows.Forms.PictureBox LogoFrame;
        private System.Windows.Forms.Label Title;
        public CompleteMenu menuDisplay;
    private System.Windows.Forms.Button arabicStartOrder;
  }
}