using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] optionMenu = { "Tools", "Recieving", "Shipping", "Quit" };
            string Title = "Hello. This your Inventory Control System";
            Consolemenues consolemenues = new Consolemenues();
            
            consolemenues.menuMain(optionMenu, Title);
            // testingProducttype();
            //testingProducts();
        }

        private static void testingProducttype()
        {
            Producttype producttype = new Producttype("Producttype");
            
           // producttype.Insert("IPhone", "30 Fierce", 2018, "5' Screen 32 GB");
            //producttype.Delete(4);
           // producttype.Update(5, "Alaca-tel", "Fierce 303",2019, "Digital sensor");
           // producttype.DisplayRecords();
            System.Console.ReadKey();
        }


        private static void testingProducts()
        {
            Products products = new Products();
            // System.Console.WriteLine(products.dbConnection);
            //NewMethod(products);
            //products.DisplayRecords();
            System.Console.ReadKey();
        }

        private static void NewMethod(Products products)
        {
            //products.Insert("PC I6", "50007");
            // products.Delete("@code");
            //products.Update("Laptop I7", "strbarcode");
        }
    }
}
