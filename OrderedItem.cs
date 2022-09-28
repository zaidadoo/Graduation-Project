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
        }

        private string name_;
        private float price_;
        private int quantity_;

        public string NameItem
        {
            get { return name_; }
            set { name_ = value; ItemTitle.Text = value; }
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

        private void quantityAdd_Click(object sender, EventArgs e)
        {
            currentOrderModify.InsertItem(ItemTitle.Text, 0);
            currentOrderModify.theMenu.currentOrder_Tick();
        }

        private void quantityMinus_Click(object sender, EventArgs e)
        {
            currentOrderModify.DecreaseItem(ItemTitle.Text);
            currentOrderModify.theMenu.currentOrder_Tick();
        }
    }
}
