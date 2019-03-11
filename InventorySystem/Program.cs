using System;

namespace InventorySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Products products = new Products();
            // System.Console.WriteLine(products.dbConnection);
            NewMethod(products);
            products.DisplayRecords();
            System.Console.ReadKey();
        }

        private static void NewMethod(Products products)
        {
            products.Insert("PC I6", "50002");
        }
    }
}
