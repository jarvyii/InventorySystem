using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace InventorySystem
{
    class Producttype: DataClass
    {
        public SQLiteConnection dbConnection;
        string tableName;
        public Producttype(string tablename)
        {
            tableName = tablename;
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
        public void Insert(string branch, string model, int year, string caracteristic)
        {
            OpenDB();
            string commandSQL = "insert into Producttype (branch, model, year, caracteristic) values (@branch, @model, @year, @caracteristic)";
            
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            
            // Use AddWithValue to assign Demographics.
            // SQL Server will implicitly convert strings into XML.
            command.Parameters.AddWithValue("@tablename", tableName);
            command.Parameters.AddWithValue("@branch", branch);
            command.Parameters.AddWithValue("@model", model);
            command.Parameters.AddWithValue("@year", year);
            command.Parameters.AddWithValue("@caracteristic", caracteristic);
            
            Int32 rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("RowsAffected: {0}", rowsAffected);
            
            CloseDB();
        }
        public void Delete(int id)
        {
            OpenDB();
            string commandSQL = "delete from producttype where id_producttype = @id";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            command.Parameters.AddWithValue("@id", id);
            Int32 rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("RowsAffected: {0}", rowsAffected);
            CloseDB();
        }
        public void Update(int id, string branch, string model, int year, string caracteristic)
        {
            OpenDB();
            string commandSQL = "update producttype  set branch = @branch, model = @model, " +
                "year = @year, caracteristic =@caracteristic where id_producttype = @id";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@branch", branch);
            command.Parameters.AddWithValue("@model", model);
            command.Parameters.AddWithValue("@year", year);
            command.Parameters.AddWithValue("@caracteristic", caracteristic);
            Int32 rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("RowsAffected: {0}", rowsAffected);
            CloseDB();
        }
        /*
        Console.WriteLine("Bar Code", "Description", "Cost", "Branch", "Model", "Year", "Caracteristic");
            while (reader.Read())
            {
                Console.WriteLine(reader["Barcode"] + reader["Description"] + reader["Cost"] + reader["Branch"] + reader["Model"] + reader["Year"] + reader["Caracteristic"] );
            }
    CloseDB();*/
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
