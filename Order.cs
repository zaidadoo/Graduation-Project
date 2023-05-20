using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Contactless_Dining_System
{
  public class Order
  {
    public int[] databaseIDs = new int[100];
    public string[] items = new string[100];
    public int[] quantity = new int[100];
    public float[] price = new float[100];
    public string[] notes = new string[100];
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

      for (int i = 0; i < size; i++)
      {
        total += quantity[i] * price[i];
      }

      return total;
    }

    public void UpdateNotes(string val, int index)
    {
      notes[index] = val;
    }

    public void AddItem(int index)
    {
      if (quantity[index] < 10)
        quantity[index]++;
    }

    public void InsertItem(string val, float price_, int databaseID)
    {
      if(size > 99)
        return;

      if (size < 1)
      {
        databaseIDs[0] = databaseID;
        items[0] = val;
        quantity[0] = 1;
        price[0] = price_;
        size++;
        return;
      }

      // find index of item
      int index = Array.LastIndexOf(items, val);

      // if item is found
      if (index > -1 && notes[index] == null)
      {
        // if quantity is more than 10, don't add
        if (quantity[index] >= 10)
          return;

        quantity[index]++;
        return;
      }

      databaseIDs[size] = databaseID;
      items[size] = val;
      quantity[size] = 1;
      price[size] = price_;
      size++;
    }

    public void DecreaseItem(int index)
    {
      if (size < 1)
      {
        return;
      }

      if(index > -1)
        quantity[index]--;

      if (quantity[index] < 1)
      {
        int j = index;
        while (j < size - 1)
        {
          items[j] = items[j + 1];
          quantity[j] = quantity[j + 1];
          price[j] = price[j + 1];

          j++;
        }

        items[j] = "";
        notes[j] = null;
        size--;
      }

      return;
    }

    public void ClearAll()
    {
      for (int i = 0; i < size; i++)
      {
        items[i] = "";
        quantity[i] = 0;
        price[i] = 0;
        notes[i] = null;
      }

      size = 0;
      theMenu.currentOrder_Tick();

      return;
    }

  }
}
