using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Contactless_Dining_System
{
    public class Order
    {
        public string[] items = new string[100];
        public int[] quantity = new int[100];
        public float[] price = new float[100];
        public int size = 0;

        public CompleteMenu theMenu;

        public CompleteMenu setParent
        {
            set
            {
                theMenu = value;
            }
        }

        public float GetTotal()
        {
            float total = 0;

            for(int i = 0; i < size; i++)
            {
                total += quantity[i] * price[i];
            }

            return total;
        }

        public void InsertItem(string val, float price_)
        {
            if (size < 1)
            {
                items[0] = val;
                quantity[0] = 1;
                price[0] = price_;
                size++;
                return;
            }

            int i = 0;
            while(i < size)
            {
                if (items[i].Equals(val))
                {
                    quantity[i]++;
                    return;
                }
                i++;
            }

            items[size] = val;
            quantity[size] = 1;
            price[size] = price_;
            size++;
        }

        public void DecreaseItem(string val)
        {
            if (size < 1)
            {
                return;
            }

            int i = 0;
            while (i < size)
            {
                if (items[i].Equals(val))
                {
                    quantity[i]--;
                    break;
                }
                i++;
            }

            if(quantity[i] < 1)
            {
                int j = i;
                while(j < size-1)
                {
                    items[j] = items[j + 1];
                    quantity[j] = quantity[j + 1];
                    price[j] = price[j + 1];

                    j++;
                }

                items[j] = "";
                size--;
            }

            return;
        }

        public void ClearAll()
        {
            for(int i = 0; i < size; i++)
            {
                items[i] = "";
                quantity[i] = 0;
                price[i] = 0;
            }

            size = 0;
            theMenu.currentOrder_Tick();

            return;
        }

    }
}
