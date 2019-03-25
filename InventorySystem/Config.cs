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
            dbConnection = new SQLiteConnection("Data Source=./db/inventorydb.db;Version=3;");
            dbConnection.Open();
        }

        public void CloseDB() => dbConnection.Close();

        /****************************************************************
        * Display to Screen the Info about one specific Product Type.
        * Return true if exist, false in othercase.
        * ***************************************************************/
        private bool showOneProduct(string id_company)
        {
            OpenDB();
            string commandSQL = "select * from config where id_company=@id_company";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            command.Parameters.AddWithValue("@id_company", id_company);
            var reader = command.ExecuteReader();

            bool hasrow = reader.HasRows;
            if (hasrow)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}", reader.GetName(1), reader.GetName(2), reader.GetName(3));
                Console.WriteLine("*************************************************************");
                Console.WriteLine();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}", reader.GetString(1), reader.GetString(2), reader.GetInt32(3));

                }
            }
            else
            {
                Console.WriteLine("Sorry!!. There are not this Branch in your Inventory Control System..");
            }
            Console.WriteLine();
            Console.WriteLine("*************************************************************");
            // Console.WriteLine("Press any key to continue.");
            //System.Console.ReadKey();
            reader.Close();
            CloseDB();
            return hasrow;
        }

        /**************************************************
           Read for the Keyboard or any input device the info for 
           any column in the Table Producttype.
        *************************************************************/
        private void inputColumn(string title, ref string company, ref string address, ref int locations, ref string phone, ref string manager)
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine();
            Console.Write("Branch:");
           // branch = Console.ReadLine();
            Console.Write("Model:");
           // model = Console.ReadLine();
            Console.Write("Year:");
            /*
            do
            { //read until type an integer number
            }
            while (!int.TryParse(Console.ReadLine(), out year));
            */
            Console.Write("Caracteristic:");
           // caracteristic = Console.ReadLine();
        }
        /***********************************************************************
         * Update the Company Inforation
         * *********************************************************************/
        void updateConfig()
         { 
            string id_company = "";
            if (!showOneProduct(id_company))
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
            string company = "", address = "",  phone = "", manager = "",Title = "Updating all Info of one Product Type.";
            int locations = 1;

            //Call the Methodo imputColumn from the Class Product to read the column info
            inputColumn(Title, ref company, ref address, ref locations, ref phone, ref manager);

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
