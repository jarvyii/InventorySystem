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
        public Producttype(string tablename="")
        {
            tableName = tablename;
        }
        public void OpenDB()
        {
            dbConnection = new SQLiteConnection("Data Source=./db/inventorydb.db;Version=3;");
            dbConnection.Open();
        }

        public void CloseDB() => dbConnection.Close();
        /**************************************************
            Read for the Keyboard or any input device the info for 
            any column in the Table Producttype.
         *************************************************************/
        private void inputColumn(string title, ref string branch, ref string model, ref string caracteristic, ref int year)
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine();
            Console.Write("Branch:");
            branch = Console.ReadLine();
            Console.Write("Model:");
            model = Console.ReadLine();
            Console.Write("Year:");
            do
            { //read until type an integer number
            }
            while (!int.TryParse(Console.ReadLine(), out year));

            Console.Write("Caracteristic:");
            caracteristic = Console.ReadLine();
        }
        private void displayFeet(int rowsaffected, string title)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" {0} " + title, rowsaffected);
            Console.WriteLine("Press any key to continue.");
            System.Console.ReadKey();
        }
        public void insertProducttype()
        {
            string branch = "", model = "", caracteristic="", title = "Adding new Product Type Info to the Inventory Control System";
            int year = 2019;
            //Call the Method imputColumn from the Class Producttype to read the column info
            inputColumn(title, ref branch, ref model, ref caracteristic, ref year);
            OpenDB();
            string commandSQL = "insert into Producttype (branch, model, year, caracteristic) values (@branch, @model, @year, @caracteristic)";
            
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            
            command.Parameters.AddWithValue("@branch", branch);
            command.Parameters.AddWithValue("@model", model);
            command.Parameters.AddWithValue("@year", year);
            command.Parameters.AddWithValue("@caracteristic", caracteristic);
            
            // Execute the Querry and display the Page Feet.
            displayFeet(command.ExecuteNonQuery(), "Product added succesfully.");    
                       
            CloseDB();
        }
        /****************************************************************
        * Display to Screen the Info about one specific Product Type.
        * Return true if exist, false in othercase.
        * ***************************************************************/
        private bool showOneProduct(int id_producttype)
        {
            OpenDB();
            string commandSQL = "select * from producttype where id_producttype=@id_producttype";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            command.Parameters.AddWithValue("@id_producttype", id_producttype);
            var reader = command.ExecuteReader();

            bool hasrow = reader.HasRows;
            if (hasrow)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}", reader.GetName(1), reader.GetName(2), reader.GetName(3));
                Console.WriteLine("*************************************************************");
                Console.WriteLine();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}", reader.GetString(1), reader.GetString(2), reader.GetFloat(3));
                    
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
        private bool displayOneProducttype(ref int id_producttype)
        {
            Console.Clear();
            Console.Write("Please type the Id of the Products Type:");
            string inputStr = string.Empty;
            do
            {
                inputStr = Console.ReadLine();
            } while (!int.TryParse(inputStr, out id_producttype));
           return (showOneProduct(id_producttype)); //Return True if exist the Product barcode othewise false
        }
        public void deleteProducttype()
        {
            int id_Producttype =0;
            if (!displayOneProducttype(ref id_Producttype))
            {
                return;
            }
            Console.WriteLine("Are you sure you want to permanently delete this branch? Y/N");
            string answer = "";
            answer = Console.ReadLine();
            if (answer.ToUpper() == "N")
            {
                return;
            }
            OpenDB();
            string commandSQL = "delete from producttype where id_producttype = @id_Producttype";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            command.Parameters.AddWithValue("@id_Producttype", id_Producttype);
            // Execute the Querry and display the Page Feet.
            displayFeet(command.ExecuteNonQuery(), "Product Type succesfully and permantly deleted.");

            CloseDB();
        }
        public void updateProducttype()
        {
            int id_producttype = 0;
            if (!displayOneProducttype(ref id_producttype))
            {
                return;
            }
            Console.WriteLine("Are you sure you want to permanently chnage this branch? Y/N");
            string answer = "";
            answer = Console.ReadLine();
            if (answer.ToUpper() == "N")
            {
                return;
            }
            string branch = "", model="", caracteristic="",Title = "Updating all Info of one Product Type.";
            int year = 2019;
            
            //Call the Methodo imputColumn from the Class Product to read the column info
            inputColumn(Title, ref branch, ref model, ref caracteristic, ref year);

            OpenDB();
            string commandSQL = "update producttype  set branch = @branch, model = @model, " +
                "year = @year, caracteristic =@caracteristic where id_producttype = @id_producttype";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            command.Parameters.AddWithValue("@id_producttype", id_producttype);
            command.Parameters.AddWithValue("@branch", branch);
            command.Parameters.AddWithValue("@model", model);
            command.Parameters.AddWithValue("@year", year);
            command.Parameters.AddWithValue("@caracteristic", caracteristic);
            displayFeet(command.ExecuteNonQuery(), "Product Type succesfully and permantly updated.");
                        
            CloseDB();
        }
       
    public void displayProductstype()
        {
            Console.Clear();
            OpenDB();
            string commandSQL = "select * from viewproductstype";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), 
                                                               reader.GetName(3), reader.GetName(4));
                Console.WriteLine("*************************************************************");
                int noLines = 1;
                while (reader.Read())
                {
                    Console.WriteLine(noLines + ")\t{0}\t{1}\t{2}\t{3}\t{4}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), 
                                                                              reader.GetInt32(3), reader.GetString(4));
                    if ((noLines % 20) == 0) // More than one 20 Products in a Page
                    {
                        Console.WriteLine("*************************************************************");
                        Console.WriteLine("Press any key to continue.");
                        System.Console.ReadKey();
                        Console.Clear();
                    }
                    noLines++;
                }
            }
            else
            {
                Console.WriteLine("Sorry!!. There are not Product in your Inventory Control System..");
            }
            reader.Close();
            CloseDB();
            Console.WriteLine("*************************************************************");
            Console.WriteLine("Press any key to continue.");
            System.Console.ReadKey();

        }
    }
}
