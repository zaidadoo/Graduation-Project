
namespace Restaurant_Contactless_Dining_System
{
    partial class OrderedItem
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
      this.ItemTitle = new System.Windows.Forms.Label();
      this.QuantityLabel = new System.Windows.Forms.Label();
      this.quantityAdd = new System.Windows.Forms.Button();
      this.quantityMinus = new System.Windows.Forms.Button();
      this.priceLabel = new System.Windows.Forms.Label();
      this.itemsNotes = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // ItemTitle
      // 
      this.ItemTitle.AutoSize = true;
      this.ItemTitle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ItemTitle.ForeColor = System.Drawing.Color.White;
      this.ItemTitle.Location = new System.Drawing.Point(22, 39);
      this.ItemTitle.Name = "ItemTitle";
      this.ItemTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.ItemTitle.Size = new System.Drawing.Size(53, 26);
      this.ItemTitle.TabIndex = 2;
      this.ItemTitle.Text = "Item";
      this.ItemTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // QuantityLabel
      // 
      this.QuantityLabel.AutoSize = true;
      this.QuantityLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.QuantityLabel.ForeColor = System.Drawing.Color.White;
      this.QuantityLabel.Location = new System.Drawing.Point(257, 39);
      this.QuantityLabel.Name = "QuantityLabel";
      this.QuantityLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.QuantityLabel.Size = new System.Drawing.Size(23, 26);
      this.QuantityLabel.TabIndex = 2;
      this.QuantityLabel.Text = "1";
      this.QuantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // quantityAdd
      // 
      this.quantityAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.quantityAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
      this.quantityAdd.FlatAppearance.BorderSize = 0;
      this.quantityAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.quantityAdd.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
      this.quantityAdd.ForeColor = System.Drawing.Color.White;
      this.quantityAdd.Location = new System.Drawing.Point(293, 36);
      this.quantityAdd.Name = "quantityAdd";
      this.quantityAdd.Size = new System.Drawing.Size(32, 32);
      this.quantityAdd.TabIndex = 3;
      this.quantityAdd.Text = "+";
      this.quantityAdd.UseVisualStyleBackColor = false;
      this.quantityAdd.Click += new System.EventHandler(this.quantityAdd_Click);
      // 
      // quantityMinus
      // 
      this.quantityMinus.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.quantityMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
      this.quantityMinus.FlatAppearance.BorderSize = 0;
      this.quantityMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.quantityMinus.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
      this.quantityMinus.ForeColor = System.Drawing.Color.White;
      this.quantityMinus.Location = new System.Drawing.Point(213, 36);
      this.quantityMinus.Name = "quantityMinus";
      this.quantityMinus.Size = new System.Drawing.Size(32, 32);
      this.quantityMinus.TabIndex = 3;
      this.quantityMinus.Text = "-";
      this.quantityMinus.UseVisualStyleBackColor = false;
      this.quantityMinus.Click += new System.EventHandler(this.quantityMinus_Click);
      // 
      // priceLabel
      // 
      this.priceLabel.AutoSize = true;
      this.priceLabel.Font = new System.Drawing.Font("Calibri", 16F);
      this.priceLabel.ForeColor = System.Drawing.Color.White;
      this.priceLabel.Location = new System.Drawing.Point(347, 39);
      this.priceLabel.Name = "priceLabel";
      this.priceLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.priceLabel.Size = new System.Drawing.Size(51, 27);
      this.priceLabel.TabIndex = 2;
      this.priceLabel.Text = "0.00";
      this.priceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // itemsNotes
      // 
      this.itemsNotes.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.itemsNotes.BackColor = System.Drawing.Color.Black;
      this.itemsNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.itemsNotes.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.itemsNotes.ForeColor = System.Drawing.Color.White;
      this.itemsNotes.Location = new System.Drawing.Point(22, 91);
      this.itemsNotes.Multiline = true;
      this.itemsNotes.Name = "itemsNotes";
      this.itemsNotes.Size = new System.Drawing.Size(371, 96);
      this.itemsNotes.TabIndex = 4;
      this.itemsNotes.TextChanged += new System.EventHandler(this.itemsNotes_TextChanged);
      // 
      // OrderedItem
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
      this.Controls.Add(this.itemsNotes);
      this.Controls.Add(this.quantityAdd);
      this.Controls.Add(this.QuantityLabel);
      this.Controls.Add(this.priceLabel);
      this.Controls.Add(this.ItemTitle);
      this.Controls.Add(this.quantityMinus);
      this.Name = "OrderedItem";
      this.Size = new System.Drawing.Size(420, 209);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ItemTitle;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.Button quantityAdd;
        private System.Windows.Forms.Button quantityMinus;
        private System.Windows.Forms.Label priceLabel;
    private System.Windows.Forms.TextBox itemsNotes;
  }
}
