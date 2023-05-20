using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Restaurant_Contactless_Dining_System
{
  public partial class RatingPrompt : Form
  {
    private int order_id;
    private bool englishLang;
    private int rating;

    public RatingPrompt()
    {
      InitializeComponent();
    }

    public RatingPrompt(int order_id, bool englishLang)
    {
      InitializeComponent();

      this.order_id = order_id;
      this.englishLang = englishLang;
      this.rating = 0;
    }

    private void SubmitPassword_Click(object sender, EventArgs e)
    {
      if(rating == 0)
      {
        if(englishLang)
          MessageBox.Show("Please select a rating.");
        else
          MessageBox.Show("يرجى تحديد تقييم.");

        return;
      }

      // get database handler instance
      DatabaseHandler db = DatabaseHandler.Instance;

      // get cmd from db
      SqlCommand cmd = db.Command;

      // clear cmd
      cmd.Parameters.Clear();

      // set cmd text
      cmd.CommandText = "UPDATE orders SET rating = @rating WHERE order_id = @order_id";

      // set cmd params
      cmd.Parameters.AddWithValue("@rating", rating);
      cmd.Parameters.AddWithValue("@order_id", order_id);

      int rowsAffected = db.ExecuteNonQuery();

      if(rowsAffected == 0)
      {
        if (englishLang)
          MessageBox.Show("An error occurred, please try again.");
        else
          MessageBox.Show("حدث خطأ ، يرجى المحاولة مرة أخرى.");
      }

      // close connection
      db.CloseConnection();

      // close form
      this.Close();
    }

    private void PasswordChecker_Load(object sender, EventArgs e)
    {
      if(englishLang)
      {
        title.RightToLeft = RightToLeft.No;
        description.RightToLeft = RightToLeft.No;
        SubmitRating.RightToLeft = RightToLeft.No;

        title.Text = "Rate Your Experience";
        description.Text = "Order received, please rate your \r\nkiosk experience to receive the receipt. \r\n\r\nOnce you're done rating, please take the \r\nprinted receipt to the counter to pay for order.\r\n";
        SubmitRating.Text = "Submit Rating";
      }
      else
      {
        // arabic
        title.RightToLeft = RightToLeft.Yes;
        description.RightToLeft = RightToLeft.Yes;
        SubmitRating.RightToLeft = RightToLeft.Yes;

        title.Text = "قيم تجربتك";
        description.Text = "تم استلام الطلب ، يرجى تقييم تجربة الكشك الخاصة بك لتلقي الإيصال. \r\n\r\nبمجرد الانتهاء من التقييم ، يرجى أخذ الإيصال المطبوع إلى العداد لدفع الطلب.\r\n";
        SubmitRating.Text = "إرسال التقييم";
      }
    }

    private void starOne_Click(object sender, EventArgs e)
    {
      starOne.Image = filledStarRef.Image;

      rating = 1;

      starTwo.Image = emptyStarRef.Image;
      starThree.Image = emptyStarRef.Image;
      starFour.Image = emptyStarRef.Image;
      starFive.Image = emptyStarRef.Image;
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
      starOne.Image = filledStarRef.Image;
      starTwo.Image = filledStarRef.Image;

      rating = 2;

      starThree.Image = emptyStarRef.Image;
      starFour.Image = emptyStarRef.Image;
      starFive.Image = emptyStarRef.Image;
    }

    private void starThree_Click(object sender, EventArgs e)
    {
      starOne.Image = filledStarRef.Image;
      starTwo.Image = filledStarRef.Image;
      starThree.Image = filledStarRef.Image;

      rating = 3;

      starFour.Image = emptyStarRef.Image;
      starFive.Image = emptyStarRef.Image;
    }

    private void starFour_Click(object sender, EventArgs e)
    {
      starOne.Image = filledStarRef.Image;
      starTwo.Image = filledStarRef.Image;
      starThree.Image = filledStarRef.Image;
      starFour.Image = filledStarRef.Image;

      rating = 4;

      starFive.Image = emptyStarRef.Image;
    }

    private void starFive_Click(object sender, EventArgs e)
    {
      starOne.Image = filledStarRef.Image;
      starTwo.Image = filledStarRef.Image;
      starThree.Image = filledStarRef.Image;
      starFour.Image = filledStarRef.Image;
      starFive.Image = filledStarRef.Image;

      rating = 5;
    }
  }
}
