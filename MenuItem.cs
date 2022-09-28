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
        private string price_;
        private Image image_;

        public string NameItem
        {
            get { return name_; }
            set { name_ = value; ItemTitle.Text = value; }
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

        private void AddItem_Click(object sender, EventArgs e)
        {
            currentOrderModify.InsertItem(ItemTitle.Text, float.Parse(ItemPrice.Text));
            currentOrderModify.theMenu.currentOrder_Tick();
        }
    }
}
