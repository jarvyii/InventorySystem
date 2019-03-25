using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace InventorySystem
{
    class Products: DataClass
    {
        public SQLiteConnection dbConnection;
        public Products()
        {

        }
        public void OpenDB()
        {
            dbConnection = new SQLiteConnection("Data Source=./db/inventorydb.db;Version=3;");
            //System.Console.WriteLine(dbConnection);

            dbConnection.Open();
           
            /*
            string sql = "insert into products (description, barcode) values ('Pencil 1', '4000')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            closeDB(); */
        }

        public void CloseDB() => dbConnection.Close();

        /**************************************************
            Read for the Keyboard or any input device the info fot 
            any column in the Table Product.
         *************************************************************/
         private void inputColumn(string title, ref string barcode, ref string description, ref double cost, ref int id_producttype)
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine();
            Console.Write("Barcode of the product:");
            barcode = Console.ReadLine();
            Console.Write("Description of the product:");
            description = Console.ReadLine();
            Console.Write("Cost of the product:");
            cost = 0.0;
            do
            {
            }
            while (!double.TryParse(Console.ReadLine(), out cost));
                                          
            //float cost = Console.Read();
            Console.Write("Type or Branch of the product:");
            id_producttype = Console.Read();
        }

        /*******************************************************
         * Insert new Record or Row in the Table Products
         * ******************************************************/
        public  void insertProduct()
        {
            string barcode="", description="", title = "Adding new Product Info to the Inventory Control System";
            double cost=0.0;
            int id_producttype=1;
            //Call the Methodo imputColumn from the Class Product to read the column info
            inputColumn(title, ref barcode, ref description, ref cost, ref id_producttype);
            OpenDB();

            string commandSQL= "insert into products (description, barcode, cost, id_producttype) values " +
                                                    "(@description, @barcode, @cost, @id_producttype)";
           
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@barcode", barcode);
            command.Parameters.AddWithValue("@cost", cost);
            command.Parameters.AddWithValue("@id_producttype", id_producttype);
            displayFeet(command.ExecuteNonQuery(), "Product added succesfully");// Execute the Querry and display the Page Feet.
            
            CloseDB();
        }
        public void deleteProduct()
        {
            string barcode = "";
            if (!displayOneProduct(ref barcode))
            {
                return;
            }
            Console.WriteLine("Are you sure you want to permanently delete this Product? Y/N");
            string answer = "";
            answer = Console.ReadLine();
            if (answer.ToUpper() == "N")
            {
                return;
            }
            OpenDB();
            string commandSQL = "delete from products where barcode = @barcode";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            command.Parameters.AddWithValue("@barcode", barcode);
            displayFeet(command.ExecuteNonQuery(), "Product deleted succesfully." );    // Execute the Querry and display the Page Feet.
            CloseDB();
        }
        private bool displayOneProduct(ref string barcode)
        {
            barcode = "";
            Console.Clear();
            Console.Write("Please type the Barcode of the Product:");
            barcode = Console.ReadLine();
            return (showOneProduct(barcode)); //Return True if exist the Product barcode othewise false
        }
        private void displayFeet( int rowsaffected, string title)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" {0} "+ title, rowsaffected);
            Console.WriteLine("Press any key to continue.");
            System.Console.ReadKey();
        }
        public void updateProduct()
        {
            string oldbarcode = "";
            if(!displayOneProduct(ref oldbarcode))
            {
                return;
            }
            string barcode = "", description = "", Title = "Updating the Info of one Product.";
            double cost = 0.0;
            int id_producttype = 1;

            //Call the Methodo imputColumn from the Class Product to read the column info
            inputColumn(Title, ref barcode, ref description, ref cost, ref id_producttype);
            OpenDB();
            string commandSQL = "update products  set description = @description, cost = @cost, " +
                                "id_producttype = @id_producttype, barcode =@barcode where barcode = @oldbarcode";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);

            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@barcode", barcode);
            command.Parameters.AddWithValue("@oldbarcode", oldbarcode);
            command.Parameters.AddWithValue("@cost", cost);
            command.Parameters.AddWithValue("@id_producttype", id_producttype);
            Int32 rowsAffected = command.ExecuteNonQuery();
            displayFeet(rowsAffected, "Product updated succesfully.");// Execute the Querry and display the Page Feet.

            CloseDB();
        }
        /****************************************************************
         * Display to Screen the Info about one specific Product.
         * Return true if exist, false in othercase.
         * ***************************************************************/
        private bool showOneProduct(string barcode)
        {
            OpenDB();
            string commandSQL = "select * from products where barcode=@barcode";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            command.Parameters.AddWithValue("@barcode", barcode);
            var reader = command.ExecuteReader();
            
            bool hasrow = reader.HasRows;
            if (hasrow)
            {
                int Lines = 0;
                Console.WriteLine("\t{0}\t{1}\t{2}", reader.GetName(1), reader.GetName(2), reader.GetName(3));
                Console.WriteLine("*************************************************************");
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}", reader.GetString(1), reader.GetString(2), reader.GetFloat(3));
                    if (Lines >= 20)
                    {
                        Console.Clear();
                        Lines = 0;
                        Console.WriteLine("*************************************************************");
                        Console.WriteLine("Press any key to continue.");
                        System.Console.ReadKey();
                    }
                    Lines ++;
                }
            }
            else
            {
                Console.WriteLine("Sorry!!. There are not Product in your Inventory Control System..");
            }
            Console.WriteLine("*************************************************************");
            Console.WriteLine("Press any key to continue.");
            System.Console.ReadKey();
            reader.Close();
            CloseDB();
            return hasrow;
        }

        public void shortDisplayProducts()
        {
            Console.Clear();
            OpenDB();
             string commandSQL = "select * from shortviewproducts";
             SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
             var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                Console.WriteLine("*************************************************************");
                int noLines = 1;
                while (reader.Read())
                {
                    Console.WriteLine(noLines + ")\t{0}\t{1}\t{2}", reader.GetString(0), reader.GetString(1), reader.GetFloat(2));
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
        /********************************************************************************
         *  Display all Info About the products Table and Producttype Table
         *  *****************************************************************************/
        public void DisplayProducts()
        {
            Console.Clear();
            OpenDB();
            string commandSQL = "select * from viewproducts";
            SQLiteCommand command = new SQLiteCommand(commandSQL, dbConnection);
            var reader = command.ExecuteReader();
            
            if (reader.HasRows)
            {    // Display Columns's Names.
                Console.WriteLine("  \t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4), reader.GetName(5), reader.GetName(6));
                Console.WriteLine("********************************************************************************");
                int noLines = 1; 
                while (reader.Read())
                {
                    Console.WriteLine(noLines + ")\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", reader.GetString(0), reader.GetString(1), reader.GetFloat(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6));
                    if((noLines % 20 )== 0) // More than one 20 Products in a Page
                    {
                        Console.WriteLine("********************************************************************************");
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
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("Press any key to continue.");
            System.Console.ReadKey();
        }

    }
}
