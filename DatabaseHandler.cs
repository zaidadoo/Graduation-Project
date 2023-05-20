using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Restaurant_Contactless_Dining_System
{
  public class DatabaseHandler
  {
    private static DatabaseHandler instance = null;
    private SqlConnection connection;
    private SqlCommand command;

    // constructor
    public DatabaseHandler()
    {
      string connectionString = Environment.GetEnvironmentVariable("MY_CONNECTION_STRING");
      connection = new SqlConnection(connectionString);
      command = new SqlCommand();
    }

    public static DatabaseHandler Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new DatabaseHandler();
        }

        return instance;
      }
    }

    // getter for command
    public SqlCommand Command
    {
      get 
      {
        return command; 
      }
    }

    // open connection
    public void OpenConnection()
    {
      if (connection.State == System.Data.ConnectionState.Closed)
      {
        connection.Open();
      }
    }

    // close connection
    public void CloseConnection()
    {
      if (connection.State == System.Data.ConnectionState.Open)
      {
        connection.Close();
      }
    }

    public SqlDataReader ExecuteQuery(String sql)
    {
      SqlDataReader reader;

      try
      {
        // open connection
        OpenConnection();

        command.CommandText = sql;
        command.Connection = connection;

        reader = command.ExecuteReader();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        reader = null;
      }

      return reader;
    }

    // execute non query
    public int ExecuteNonQuery()
    {
      int reader;

      try
      {
        // open connection
        OpenConnection();

        command.Connection = connection;

        reader = command.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);

        reader = -1;
      }

      return reader;
    }


    // bulk copy
    public bool BulkCopy(DataTable dataTable, string tableName)
    {
      // open connection
      OpenConnection();

      using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
      {
        bulkCopy.DestinationTableName = tableName;

        try
        {
          bulkCopy.WriteToServer(dataTable);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);

          return false;
        }
      }

      return true;
    }
  }
}
