using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    class Menu
    {
        static public int DisplayMainMenu()
        {
            Console.WriteLine("Who are you? Enter an option between (1-4) or (5) to EXIT");
            Console.WriteLine();
            Console.WriteLine("1.Existing client");
            Console.WriteLine("2.New client");
            Console.WriteLine("3.Existing provider");
            Console.WriteLine("4.New provider");
            Console.WriteLine("5.Exit");

            int userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;
        }
        static public int DisplayProviderMenu()
        {
            Console.WriteLine("Enter an option (1-2) or (3) to EXIT");
            Console.WriteLine();
            Console.WriteLine("1.Insert product to stock");
            Console.WriteLine("2.Show all my products in the stock");
            Console.WriteLine("3.Exit");
            int userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;
        }
        static public int DisplayClientMenu()
        {
            Console.WriteLine("Enter an option (1-2) or (3) to EXIT");
            Console.WriteLine();
            Console.WriteLine("1.Show all my shopping list");
            Console.WriteLine("2.View all products");
            Console.WriteLine("3.Order products");
            Console.WriteLine("4.Exit");
            int userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;
        }


    }
}



