
namespace Restaurant_Contactless_Dining_System
{
  partial class RatingPrompt
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RatingPrompt));
      this.SubmitRating = new System.Windows.Forms.Button();
      this.description = new System.Windows.Forms.Label();
      this.title = new System.Windows.Forms.Label();
      this.filledStarRef = new System.Windows.Forms.PictureBox();
      this.starTwo = new System.Windows.Forms.PictureBox();
      this.starOne = new System.Windows.Forms.PictureBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.starThree = new System.Windows.Forms.PictureBox();
      this.starFour = new System.Windows.Forms.PictureBox();
      this.starFive = new System.Windows.Forms.PictureBox();
      this.emptyStarRef = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.filledStarRef)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.starTwo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.starOne)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.starThree)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.starFour)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.starFive)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.emptyStarRef)).BeginInit();
      this.SuspendLayout();
      // 
      // SubmitRating
      // 
      this.SubmitRating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(232)))));
      this.SubmitRating.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SubmitRating.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
      this.SubmitRating.ForeColor = System.Drawing.Color.White;
      this.SubmitRating.Location = new System.Drawing.Point(42, 327);
      this.SubmitRating.Name = "SubmitRating";
      this.SubmitRating.Size = new System.Drawing.Size(278, 44);
      this.SubmitRating.TabIndex = 2;
      this.SubmitRating.Text = "Submit";
      this.SubmitRating.UseVisualStyleBackColor = false;
      this.SubmitRating.Click += new System.EventHandler(this.SubmitPassword_Click);
      // 
      // description
      // 
      this.description.AutoSize = true;
      this.description.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.description.ForeColor = System.Drawing.SystemColors.ActiveBorder;
      this.description.Location = new System.Drawing.Point(20, 115);
      this.description.MaximumSize = new System.Drawing.Size(312, 0);
      this.description.Name = "description";
      this.description.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.description.Size = new System.Drawing.Size(305, 100);
      this.description.TabIndex = 10;
      this.description.Text = "تم استلام الطلب ، يرجى تقييم تجربة الكشك الخاصة بك لتلقي الإيصال. \r\n\r\nبمجرد الانت" +
    "هاء من التقييم ، يرجى أخذ الإيصال المطبوع إلى العداد لدفع الطلب.";
      // 
      // title
      // 
      this.title.AutoSize = true;
      this.title.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.title.Location = new System.Drawing.Point(19, 74);
      this.title.MinimumSize = new System.Drawing.Size(312, 0);
      this.title.Name = "title";
      this.title.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.title.Size = new System.Drawing.Size(312, 30);
      this.title.TabIndex = 9;
      this.title.Text = "Rate Your Experience";
      // 
      // filledStarRef
      // 
      this.filledStarRef.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.star__5_;
      this.filledStarRef.Location = new System.Drawing.Point(238, 20);
      this.filledStarRef.Name = "filledStarRef";
      this.filledStarRef.Size = new System.Drawing.Size(39, 50);
      this.filledStarRef.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.filledStarRef.TabIndex = 19;
      this.filledStarRef.TabStop = false;
      this.filledStarRef.Visible = false;
      // 
      // starTwo
      // 
      this.starTwo.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.star__4_;
      this.starTwo.Location = new System.Drawing.Point(115, 247);
      this.starTwo.Name = "starTwo";
      this.starTwo.Size = new System.Drawing.Size(39, 50);
      this.starTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.starTwo.TabIndex = 18;
      this.starTwo.TabStop = false;
      this.starTwo.Click += new System.EventHandler(this.pictureBox2_Click);
      // 
      // starOne
      // 
      this.starOne.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.star__4_;
      this.starOne.Location = new System.Drawing.Point(70, 247);
      this.starOne.Name = "starOne";
      this.starOne.Size = new System.Drawing.Size(39, 50);
      this.starOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.starOne.TabIndex = 17;
      this.starOne.TabStop = false;
      this.starOne.Click += new System.EventHandler(this.starOne_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.Logo_blue_copy;
      this.pictureBox1.Location = new System.Drawing.Point(24, 20);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(54, 50);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 16;
      this.pictureBox1.TabStop = false;
      // 
      // starThree
      // 
      this.starThree.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.star__4_;
      this.starThree.Location = new System.Drawing.Point(160, 247);
      this.starThree.Name = "starThree";
      this.starThree.Size = new System.Drawing.Size(39, 50);
      this.starThree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.starThree.TabIndex = 20;
      this.starThree.TabStop = false;
      this.starThree.Click += new System.EventHandler(this.starThree_Click);
      // 
      // starFour
      // 
      this.starFour.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.star__4_;
      this.starFour.Location = new System.Drawing.Point(205, 247);
      this.starFour.Name = "starFour";
      this.starFour.Size = new System.Drawing.Size(39, 50);
      this.starFour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.starFour.TabIndex = 21;
      this.starFour.TabStop = false;
      this.starFour.Click += new System.EventHandler(this.starFour_Click);
      // 
      // starFive
      // 
      this.starFive.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.star__4_;
      this.starFive.Location = new System.Drawing.Point(250, 247);
      this.starFive.Name = "starFive";
      this.starFive.Size = new System.Drawing.Size(39, 50);
      this.starFive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.starFive.TabIndex = 22;
      this.starFive.TabStop = false;
      this.starFive.Click += new System.EventHandler(this.starFive_Click);
      // 
      // emptyStarRef
      // 
      this.emptyStarRef.Image = global::Restaurant_Contactless_Dining_System.Properties.Resources.star__4_;
      this.emptyStarRef.Location = new System.Drawing.Point(283, 20);
      this.emptyStarRef.Name = "emptyStarRef";
      this.emptyStarRef.Size = new System.Drawing.Size(39, 50);
      this.emptyStarRef.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.emptyStarRef.TabIndex = 23;
      this.emptyStarRef.TabStop = false;
      this.emptyStarRef.Visible = false;
      // 
      // RatingPrompt
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(359, 407);
      this.ControlBox = false;
      this.Controls.Add(this.emptyStarRef);
      this.Controls.Add(this.starFive);
      this.Controls.Add(this.starFour);
      this.Controls.Add(this.starThree);
      this.Controls.Add(this.filledStarRef);
      this.Controls.Add(this.starTwo);
      this.Controls.Add(this.starOne);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.description);
      this.Controls.Add(this.title);
      this.Controls.Add(this.SubmitRating);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "RatingPrompt";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Rate Your Experience";
      this.Load += new System.EventHandler(this.PasswordChecker_Load);
      ((System.ComponentModel.ISupportInitialize)(this.filledStarRef)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.starTwo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.starOne)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.starThree)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.starFour)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.starFive)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.emptyStarRef)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button SubmitRating;
    private System.Windows.Forms.Label description;
    private System.Windows.Forms.Label title;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.PictureBox starOne;
    private System.Windows.Forms.PictureBox starTwo;
    private System.Windows.Forms.PictureBox filledStarRef;
    private System.Windows.Forms.PictureBox starThree;
    private System.Windows.Forms.PictureBox starFour;
    private System.Windows.Forms.PictureBox starFive;
    private System.Windows.Forms.PictureBox emptyStarRef;
  }
}