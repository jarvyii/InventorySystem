using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace InventorySystem
{
    class Producttype: DataClass
    {
        public SQLiteConnection dbConnection;
        public Products()
        {
        }
        public void OpenDB()
        {
            dbConnection = new SQLiteConnection("Data Source=C:/JARV/WEBPAGE/Code Louisville/C#/project/InventorySystem/InventorySystem/DB/inventorydb.db;Version=3;");
            dbConnection.Open();
        }

        public void CloseDB() => dbConnection.Close();
        /*
        public void Insertdd(string @Name, string @code)
        {
            SQLiteConnection dbConnection = OpenDB();
            string sql = "insert into products (description, barcode) values (@Name, @code)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            closeDB(dbConnection);
        }*/
        public void Insert(string name, string barcode)
        {
            OpenDB();
            string commandSQL = "insert into products (description, barcode) values (@name, @barcode)";
            /*
            string commandSQL = "UPDATE Sales.Store SET Demographics = @demographics "
                + "WHERE CustomerID = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {*/
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            /* SqlCommand command = new SqlCommand(commandText, connection);
             command.Parameters.Add("@ID", SqlDbType.Int); 
             command.Parameters["@name"].Value = name;*/

            // Use AddWithValue to assign Demographics.
            // SQL Server will implicitly convert strings into XML.
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@barcode", barcode);

            //   try
            //  {
            //   connection.Open();
            Int32 rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("RowsAffected: {0}", rowsAffected);
            /*   }
               catch (Exception ex)
               {
                   Console.WriteLine(ex.Message);
               } */
            // }
            CloseDB();
        }
        public void Delete(string barcode)
        {
            OpenDB();
            string commandSQL = "delete from products where barcode = @barcode";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            command.Parameters.AddWithValue("@barcode", barcode);
            Int32 rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("RowsAffected: {0}", rowsAffected);
            CloseDB();
        }
        public void Update(string name, string barcode)
        {
            OpenDB();
            string commandSQL = "update products  set description = @name where barcode = @barcode";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@barcode", barcode);
            Int32 rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("RowsAffected: {0}", rowsAffected);
            CloseDB();
        }

        public void DisplayRecords()
        {
            OpenDB();
            string commandSQL = "select * from products";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Description: " + reader["Description"] + "Bar Code: " + reader["barcode"]);
            }
            CloseDB();
        }
    }
}
