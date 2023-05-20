
namespace Restaurant_Contactless_Dining_System
{
    partial class MenuItem
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
      this.ItemPicture = new System.Windows.Forms.PictureBox();
      this.ItemTitle = new System.Windows.Forms.Label();
      this.ItemPrice = new System.Windows.Forms.Label();
      this.AddItem = new System.Windows.Forms.Button();
      this.currencyLabel = new System.Windows.Forms.Label();
      this.itemDescription = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.ItemPicture)).BeginInit();
      this.SuspendLayout();
      // 
      // ItemPicture
      // 
      this.ItemPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.ItemPicture.Location = new System.Drawing.Point(0, 1);
      this.ItemPicture.Name = "ItemPicture";
      this.ItemPicture.Size = new System.Drawing.Size(171, 171);
      this.ItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.ItemPicture.TabIndex = 0;
      this.ItemPicture.TabStop = false;
      // 
      // ItemTitle
      // 
      this.ItemTitle.AutoSize = true;
      this.ItemTitle.BackColor = System.Drawing.Color.Transparent;
      this.ItemTitle.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ItemTitle.ForeColor = System.Drawing.Color.White;
      this.ItemTitle.Location = new System.Drawing.Point(177, 1);
      this.ItemTitle.MinimumSize = new System.Drawing.Size(710, 0);
      this.ItemTitle.Name = "ItemTitle";
      this.ItemTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.ItemTitle.Size = new System.Drawing.Size(710, 36);
      this.ItemTitle.TabIndex = 1;
      this.ItemTitle.Text = "Item";
      // 
      // ItemPrice
      // 
      this.ItemPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ItemPrice.AutoSize = true;
      this.ItemPrice.BackColor = System.Drawing.Color.Transparent;
      this.ItemPrice.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
      this.ItemPrice.ForeColor = System.Drawing.Color.White;
      this.ItemPrice.Location = new System.Drawing.Point(796, 139);
      this.ItemPrice.Name = "ItemPrice";
      this.ItemPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.ItemPrice.Size = new System.Drawing.Size(64, 33);
      this.ItemPrice.TabIndex = 1;
      this.ItemPrice.Text = "0.00";
      this.ItemPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // AddItem
      // 
      this.AddItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.AddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
      this.AddItem.FlatAppearance.BorderSize = 0;
      this.AddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.AddItem.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.AddItem.ForeColor = System.Drawing.Color.White;
      this.AddItem.Location = new System.Drawing.Point(899, 0);
      this.AddItem.Name = "AddItem";
      this.AddItem.Size = new System.Drawing.Size(118, 173);
      this.AddItem.TabIndex = 2;
      this.AddItem.Text = "+";
      this.AddItem.UseVisualStyleBackColor = false;
      this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
      // 
      // currencyLabel
      // 
      this.currencyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.currencyLabel.AutoSize = true;
      this.currencyLabel.BackColor = System.Drawing.Color.Transparent;
      this.currencyLabel.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
      this.currencyLabel.ForeColor = System.Drawing.Color.White;
      this.currencyLabel.Location = new System.Drawing.Point(852, 139);
      this.currencyLabel.Name = "currencyLabel";
      this.currencyLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.currencyLabel.Size = new System.Drawing.Size(41, 33);
      this.currencyLabel.TabIndex = 1;
      this.currencyLabel.Text = "JD";
      this.currencyLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // itemDescription
      // 
      this.itemDescription.AutoSize = true;
      this.itemDescription.BackColor = System.Drawing.Color.Transparent;
      this.itemDescription.Font = new System.Drawing.Font("Calibri Light", 14.75F);
      this.itemDescription.ForeColor = System.Drawing.Color.White;
      this.itemDescription.Location = new System.Drawing.Point(179, 38);
      this.itemDescription.MaximumSize = new System.Drawing.Size(500, 0);
      this.itemDescription.MinimumSize = new System.Drawing.Size(710, 125);
      this.itemDescription.Name = "itemDescription";
      this.itemDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.itemDescription.Size = new System.Drawing.Size(710, 125);
      this.itemDescription.TabIndex = 3;
      this.itemDescription.Text = "Item";
      // 
      // MenuItem
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
      this.Controls.Add(this.currencyLabel);
      this.Controls.Add(this.ItemPrice);
      this.Controls.Add(this.itemDescription);
      this.Controls.Add(this.AddItem);
      this.Controls.Add(this.ItemTitle);
      this.Controls.Add(this.ItemPicture);
      this.Name = "MenuItem";
      this.Size = new System.Drawing.Size(1017, 173);
      this.Load += new System.EventHandler(this.MenuItem_Load);
      ((System.ComponentModel.ISupportInitialize)(this.ItemPicture)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ItemPicture;
        private System.Windows.Forms.Label ItemTitle;
        private System.Windows.Forms.Label ItemPrice;
        private System.Windows.Forms.Button AddItem;
        private System.Windows.Forms.Label currencyLabel;
    private System.Windows.Forms.Label itemDescription;
  }
}
