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
  public partial class OrderedItem : UserControl
  {
    Order currentOrderModify = CompleteMenu.currentOrder;

    public OrderedItem()
    {
      InitializeComponent();

      id_ = -1;
    }

    private int id_;
    private string name_;
    private string notes_;
    private float price_;
    private int quantity_;

    private bool englishLang_;

    private string accentColor_;
    private string lighterColor_;
    private string textColor_;

    public int IDItem
    {
      get { return id_; }
      set { id_ = value; }
    }

    public string NameItem
    {
      get { return name_; }
      set { name_ = value; ItemTitle.Text = value; }
    }

    public string NotesItem
    {
      get { return notes_; }
      set { notes_ = value; itemsNotes.Text = value; }
    }

    public float PriceItem
    {
      get { return price_; }
      set { price_ = value; priceLabel.Text = $"{value:0.00}"; }
    }

    public int QuantityItem
    {
      get { return quantity_; }
      set { quantity_ = value; QuantityLabel.Text = quantity_.ToString(); }
    }

    public bool EnglishLang
    {
      get { return englishLang_; }
      set 
      { 
        englishLang_ = value; 

        if (value)
          itemsNotes.RightToLeft = RightToLeft.No;
        else
          itemsNotes.RightToLeft = RightToLeft.Yes;
      }
    }

    public string AccentColor
    {
      get { return accentColor_; }
      set 
      { 
        accentColor_ = value; 
        quantityAdd.BackColor = ColorTranslator.FromHtml(value);
        quantityMinus.BackColor = ColorTranslator.FromHtml(value);
        itemsNotes.BackColor = ColorTranslator.FromHtml(value);
      }
    }

    public string LighterColor
    {
      get { return lighterColor_; }
      set
      {
        this.BackColor = ColorTranslator.FromHtml(value);
      }
    }

    public string TextColor
    {
      get { return textColor_; }
      set
      {
        ItemTitle.ForeColor = ColorTranslator.FromHtml(value);
        priceLabel.ForeColor = ColorTranslator.FromHtml(value);
        QuantityLabel.ForeColor = ColorTranslator.FromHtml(value);
        itemsNotes.ForeColor = ColorTranslator.FromHtml(value);
      }
    }

    private void quantityAdd_Click(object sender, EventArgs e)
    {
      currentOrderModify.AddItem(id_);
      currentOrderModify.theMenu.currentOrder_Tick();
    }

    private void quantityMinus_Click(object sender, EventArgs e)
    {
      currentOrderModify.DecreaseItem(id_);
      currentOrderModify.theMenu.currentOrder_Tick();
    }

    private void itemsNotes_TextChanged(object sender, EventArgs e)
    {
      currentOrderModify.UpdateNotes(itemsNotes.Text, id_);
    }
  }
}
