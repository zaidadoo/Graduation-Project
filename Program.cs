using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Restaurant_Contactless_Dining_System
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      bool doneSetup = true;

      // check if DoneSetup.txt exists
      // create it if it doesn't
      if (!System.IO.File.Exists("DoneSetup.txt"))
      {
        System.IO.File.Create("DoneSetup.txt");
        doneSetup = false;
      }
      else
      {
        // get the contents of DoneSetup.txt
        string contents = System.IO.File.ReadAllText("DoneSetup.txt");

        // if file is empty doneSetup is false
        if (contents.Equals(""))
          doneSetup = false;
      }

      if (!doneSetup)
      {
        Application.Run(new SetupChoice());
      }
      else
      {
        Application.Run(new MainMenu());
      }
    }
  }
}
