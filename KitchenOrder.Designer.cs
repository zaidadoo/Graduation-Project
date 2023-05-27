namespace Restaurant_Contactless_Dining_System
{
  partial class KitchenOrder
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
      this.timerLabel = new System.Windows.Forms.Label();
      this.orderInformationLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // timerLabel
      // 
      this.timerLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.timerLabel.AutoSize = true;
      this.timerLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.timerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.timerLabel.Location = new System.Drawing.Point(51, 5);
      this.timerLabel.Name = "timerLabel";
      this.timerLabel.Size = new System.Drawing.Size(201, 30);
      this.timerLabel.TabIndex = 4;
      this.timerLabel.Text = "Time Left: 00:00:00";
      // 
      // orderInformationLabel
      // 
      this.orderInformationLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.orderInformationLabel.AutoSize = true;
      this.orderInformationLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.orderInformationLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.orderInformationLabel.Location = new System.Drawing.Point(26, 44);
      this.orderInformationLabel.Name = "orderInformationLabel";
      this.orderInformationLabel.Size = new System.Drawing.Size(234, 160);
      this.orderInformationLabel.TabIndex = 5;
      this.orderInformationLabel.Text = "\t\tOrder ID: 20\r\n\r\n\r\n#ORD 20 - 27/05/2023 5:44:05 PM\r\n#\tTotal\t\tProduct\r\n01\t03.75\t\t" +
    "Classic Burger\r\n01\t03.75\t\tTacolicious\r\n01\t04.50\t\tChocolate Lava Cake";
      // 
      // KitchenOrder
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.AutoSize = true;
      this.BackColor = System.Drawing.Color.WhiteSmoke;
      this.Controls.Add(this.orderInformationLabel);
      this.Controls.Add(this.timerLabel);
      this.MinimumSize = new System.Drawing.Size(303, 263);
      this.Name = "KitchenOrder";
      this.Size = new System.Drawing.Size(303, 263);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label timerLabel;
    private System.Windows.Forms.Label orderInformationLabel;
  }
}
