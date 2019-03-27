InventorySystem System Version 1.0

**************************************************************************************
REQUIREMENTS TO RUN THE PROJECT

The was designed to use SQLite as DataBase System.

 1- You need access to the Console Command.
  
   	  
*****************************************************************************************
 
Description

This is a Console aplication, cross plataform. Its have been designed to be use for differents small business or individual person. With the System you can have 
the control of all the inventory and your execute all normal operation of one Warehouse (Setup, Reciebing, Shipping).

You can initiate the system  with the Costumer information (Company Name, Address, Phone, Manager, Locations). It is store in a database table file.

The purpose is to create a console aplication where smalls business can update and control their own inventory using different devices. 

PENDING: Reciebing and Shipping.

The users can modify, delete or add info store in the differents tables.

1. Custom Classes
   The class(es) I created are:

     class Consolemenues
     {
        private int readSelection()
        {                    
	}
        private void showMenu(string[] optionmenu, string title)
        {
        }
       public void menuMain(string[] optionmenu, string title)
        {
        }
        private void menuTools()
        {
        }
        private void Setup()
        {
        }
        private void menuProduct()
        {
        }
        private void menuProducttype()
        {
        }
    }
	class Producttype: DataClass
    {
        public Producttype(string tablename="")
        {
        }
        public void OpenDB()
        {
        }
        public void CloseDB() => dbConnection.Close();
        private void inputColumn(string title, ref string branch, ref string model, ref string caracteristic, ref int year)
        {
        }
        private void displayFeet(int rowsaffected, string title)
        {
        }
        public void insertProducttype()
        {
        }
        private bool showOneProduct(int id_producttype)
        {
        }
        private bool displayOneProducttype(ref int id_producttype)
        {
        }
        public void deleteProducttype()
        {
        }
        public void updateProducttype()
        {
        }
       public void displayProductstype()
        {
            
        }
    }
    class Products
    {
        public Products()
        {
        }
        public void OpenDB()
        {
        }
        public void CloseDB() => dbConnection.Close();
        private void inputColumn(string title, ref string barcode, ref string description, ref double cost, ref int id_producttype)
        {
        }
        public  void insertProduct()
        {
        }
        public void deleteProduct()
        {
        }
        private bool displayOneProduct(ref string barcode)
        {
        }
        private void displayFeet( int rowsaffected, string title)
        {
        }
        public void updateProduct()
        {
        }
        private bool showOneProduct(string barcode)
        {
        }
        public void shortDisplayProducts()
        {
        }
        public void DisplayProducts()
        {
        }
    }

  
2- DataBases Table.Example of files with specific contents.

           CONFIG
	**********************************
       id_company: "111"
	   company: "Jarv Distribution"
       address: "111 Software dr Luisville Kentucky"
       locations: 2
       manager:"Yo soy mismo"
	   phone: "123-456-7890"
	 
	 
	      PRODUCTS
	 *********************************
	   id_product: 1
       description: "Acura SUB"
       barcode: "5000765325555"
       costo: 45999.00
       id_producttype: 2
     
	 
	      PRODUCTTYPE
	 *********************************
	   id_producttype: 2
       branch: "Acura"
       model: "MDX"
       year: 2019
	   caracteristic: Tourist Sport

  
