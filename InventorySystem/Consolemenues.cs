using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem
{
    class Consolemenues
    {
        //Read an integer from the keyboard
        private int readSelection()
        {
            string readOption;
            int Option;
            do
                readOption = Console.ReadLine();
            while (!(int.TryParse(readOption, out Option)));
            return Option;
        }
        //Display to screen the text of any menu
        private void showMenu(string[] optionmenu, string title)
        {
            Console.Clear();
            Console.WriteLine(title);
            for (int i = 0; i < optionmenu.Length; i++)
            {
                System.Console.WriteLine(i + 1 + "  " + optionmenu[i]);
            }
            System.Console.WriteLine("Select your option; ");

        }

       public void menuMain(string[] optionmenu, string title)
        {
            int Option;
            do
            {
              showMenu(optionmenu, title);
              Option = readSelection();
               switch (Option)
               {
                    case 1: menuTools();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;

               }
            } while ( Option!= optionmenu.Length);

        }
        // Menu to modify any table
        private void menuTools()
        {
            string[] optionMenu = { "Products Information", "Product's Type Information",
                                    "Display Products Info", "Setup", "Quit" };
            string Title = "Inventory Control System: /Tools:";
            int Option;
            do
            {
                showMenu(optionMenu, Title);
                Option = readSelection();
                switch (Option)
                {
                    case 1:
                        menuProduct();
                        break;
                    case 2:
                        menuProducttype();
                        break;
                    case 3:
                       // displayProducts();
                        break;
                    case 4:
                        Setup();
                        break;
                }
            } while (Option != optionMenu.Length);

        }
        private void Setup()
        {

        }
        //Menu to midify the table Products
        private void menuProduct()
        {
            string[] optionMenu = { "Add New Product", "Update Product Information",
                                    "Delete Product", "Display narrow Products Info",
                                    "Display General Products Info","Quit" };
            string Title = "Inventory Control System: /Tools/Porducts Info:";
            int Option;
            Products products = new Products();
            do
            {
                showMenu(optionMenu, Title);
                Option = readSelection();
                switch (Option)
                {
                    case 1:
                        products.insertProduct();
                        break;
                    case 2:
                       products.updateProduct();
                        break;
                    case 3:
                       products.deleteProduct();
                        break;
                    case 4:
                        products.shortDisplayProducts();
                        break;
                    case 5:
                        products.DisplayProducts();
                        break;
                }
            } while (Option != optionMenu.Length);
        }
        //Menu to modify the table productstype
        private void menuProducttype()
        {
            string[] optionMenu = { "Add New Branch", "Update Branch Information",
                                    "Delete Branch", "Display all Branches", "Quit" };
            string Title = "Inventory Control System: /Tools/Poructstype Info:";
            int Option;
            Producttype productstype = new Producttype();
            do
            {
                showMenu(optionMenu, Title);
                Option = readSelection();
                switch (Option)
                {
                    case 1:
                        productstype.insertProducttype();
                        break;
                    case 2:
                        productstype.updateProducttype();
                        break;
                    case 3:
                        productstype.deleteProducttype();
                        break;
                    case 4:
                        productstype.displayProductstype();
                        break;
                }
            } while (Option != optionMenu.Length);

        }
       
    }
}
