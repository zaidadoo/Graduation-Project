using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Contactless_Dining_System
{
  public partial class MainMenu : Form
  {
    public MainMenu()
    {
      InitializeComponent();
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void Choice1Access_Click(object sender, EventArgs e)
    {
      Form changeForm = new CustomerOrdersDisplay();
      this.Hide();
      changeForm.ShowDialog();
      this.Show();
    }

    private void Choice2Access_Click(object sender, EventArgs e)
    {
      Form changeForm = new RestaurantMenu();
      this.Hide();
      changeForm.ShowDialog();
      this.Show();
    }

    private void Choice3Access_Click(object sender, EventArgs e)
    {
      PasswordChecker passCheck = new PasswordChecker();
      passCheck.ShowDialog();

      if (passCheck.DialogResult.Equals(DialogResult.Yes))
      {
        Form changeForm = new KitchenManagement();
        this.Hide();
        changeForm.ShowDialog();

        try
        {
          this.Show();
        }
        catch (ObjectDisposedException)
        {
          Application.Exit();
        }
      }
      else
      {
        return;
      }
    }

    private void ExitButton_Click_1(object sender, EventArgs e)
    {
      Application.Exit();
    }
  }
}
