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
  public partial class MenuItem : UserControl
  {
    Order currentOrderModify = CompleteMenu.currentOrder;

    public MenuItem()
    {
      InitializeComponent();
    }

    private string name_;
    private string description_;
    private string price_;
    private Image image_;

    private bool englishLang_;

    private string accentColor_;
    private string lighterColor_;
    private string textColor_;

    public string NameItem
    {
      get { return name_; }
      set { name_ = value; ItemTitle.Text = value; }
    }

    public string DescriptionItem
    {
      get { return description_; }
      set { description_ = value; itemDescription.Text = value; }
    }

    public string PriceItem
    {
      get { return price_; }
      set { price_ = value; ItemPrice.Text = value; }
    }

    public Image ImageItem
    {
      get { return image_; }
      set { image_ = value; ItemPicture.Image = value; }
    }

    public bool EnglishLang
    {
      get { return englishLang_; }
      set { englishLang_ = value; }
    }

    public string LighterColor
    {
      get { return lighterColor_; }
      set { lighterColor_ = value; }
    }

    public string AccentColor
    {
      get { return accentColor_; }
      set { accentColor_ = value; }
    }

    public string TextColor
    {
      get { return textColor_; }
      set { textColor_ = value; }
    }

    private void AddItem_Click(object sender, EventArgs e)
    {
      currentOrderModify.InsertItem(ItemTitle.Text, float.Parse(ItemPrice.Text));
      currentOrderModify.theMenu.currentOrder_Tick();
    }

    private void MenuItem_Load(object sender, EventArgs e)
    {
      if(englishLang_)
        currencyLabel.Text = "JD";
      else
        currencyLabel.Text = "د.ا.";

      if(englishLang_)
        itemDescription.RightToLeft = RightToLeft.No;
      else
        itemDescription.RightToLeft = RightToLeft.Yes;

      if(englishLang_)
        ItemTitle.RightToLeft = RightToLeft.No;
      else
        ItemTitle.RightToLeft = RightToLeft.Yes;

      this.BackColor = ColorTranslator.FromHtml(accentColor_);
      AddItem.BackColor = ColorTranslator.FromHtml(lighterColor_);

      ItemTitle.ForeColor = ColorTranslator.FromHtml(textColor_);
      itemDescription.ForeColor = ColorTranslator.FromHtml(textColor_);
      ItemPrice.ForeColor = ColorTranslator.FromHtml(textColor_);
      currencyLabel.ForeColor = ColorTranslator.FromHtml(textColor_);
    }
  }
}
