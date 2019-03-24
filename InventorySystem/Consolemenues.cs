using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem
{
    class Consolemenues
    {
        private int readSelection()
        {
            string readOption;
            int Option;
            do
                readOption = Console.ReadLine();
            while (!(int.TryParse(readOption, out Option)));
            return Option;
        }
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
        private void menuTools()
        {
            string[] optionMenu = { "Products Information", "Product's Type Information",
                                    "Display Products Info", "Quit" };
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
                }
            } while (Option != optionMenu.Length);

        }
        private void menuProduct()
        {
            string[] optionMenu = { "Add New Product", "Update Product Information",
                                    "Delete Product", "Display Products", "Quit" };
            string Title = "Inventory Control System: /Tools/Poructs Info:";
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
                }
            } while (Option != optionMenu.Length);
        }
        private void menuProducttype()
        {
            string[] optionMenu = { "Add New Branch", "Update Branch Information",
                                    "Delete Branch", "Display all Branches", "Quit" };
            string Title = "Inventory Control System: /Tools/Poructstype Info:";
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
                }
            } while (Option != optionMenu.Length);

        }
       
    }
}
