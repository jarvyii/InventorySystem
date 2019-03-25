using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace InventorySystem
{
    class Config
    { 
        public SQLiteConnection dbConnection;
       // string tableName;
        public void OpenDB()
        {
            dbConnection = new SQLiteConnection("Data Source=C:/JARV/WEBPAGE/Code Louisville/C#/project/InventorySystem/InventorySystem/DB/inventorydb.db;Version=3;");
            dbConnection.Open();
        }

        public void CloseDB() => dbConnection.Close();

        private bool displayOneProducttype()
        {
            return true; 
            //Return True if exist the Product barcode othewise false
        } 
        /***********************************************************************
         * Update the Company Inforation
         * *********************************************************************/
        void updateConfig()
         { 
           // string id_company = "";
            if (!displayOneProducttype())
            {
                return;
            }
            Console.WriteLine("Are you sure you want to permanently change the Company Information? Y/N");
            string answer = "";
            answer = Console.ReadLine();
            if (answer.ToUpper() == "N")
            {
                return;
            }
            string company = "", model = "", caracteristic = "", Title = "Updating all Info of one Product Type.";
            int year = 2019;

            //Call the Methodo imputColumn from the Class Product to read the column info
           // inputColumn(Title, ref branch, ref model, ref caracteristic, ref year);

            OpenDB();
            string commandSQL = "update producttype  set branch = @branch, model = @model, " +
                "year = @year, caracteristic =@caracteristic where id_producttype = @id_producttype";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            /*command.Parameters.AddWithValue("@id_producttype", id_producttype);
            command.Parameters.AddWithValue("@branch", branch);
            command.Parameters.AddWithValue("@model", model);
            command.Parameters.AddWithValue("@year", year);
            command.Parameters.AddWithValue("@caracteristic", caracteristic);
            displayFeet(command.ExecuteNonQuery(), "Product Type succesfully and permantly updated.");
            */
            CloseDB(); 
        }
    }
    
    
}
