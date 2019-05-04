using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            IManagementDAO management = new ManagementDAO();
            int userInput = 0;
            do
            {
                userInput = Menu.DisplayMainMenu();
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Insert user Name:");
                        string clientUserName = Console.ReadLine();
                        Console.WriteLine("Inser password:");
                        int clientPassword = Convert.ToInt32(Console.ReadLine());
                        if (management.ClientUserNamePasswordValidation(clientUserName, clientPassword) == 1)
                        {
                            Console.Clear();
                            ClientMenu(clientUserName, clientPassword);
                        }
                        break;
                    case 2:
                        management.InsertNewClient();
                        break;
                    case 3:
                        Console.WriteLine("Insert user Name:");
                        string providerUserName = Console.ReadLine();
                        Console.WriteLine("Inser password:");
                        int providerPassword = Convert.ToInt32(Console.ReadLine());
                        if (management.ProviderUserNamePasswordValidation(providerUserName, providerPassword) == 1)
                        {
                            Console.Clear();
                            ProviderMenu(providerUserName, providerPassword);
                        }
                        break;
                    case 4:
                        management.InsertNewProvider();
                        break;
                }
                Console.Clear();
            } while (userInput != 5);
        }
       
        static public void ProviderMenu(string userName, int password)
        {
            IManagementDAO management = new ManagementDAO();
            int userInput = 0;
            userInput = Menu.DisplayProviderMenu();
                switch (userInput)
                {
                    case 1:
                    Console.WriteLine("Insert product name");
                    string productName = Console.ReadLine();
                    if (management.IfProductExist(productName) == 1 && management.IfSameProvaider(userName, password, productName) == true)
                    {
                        Console.WriteLine($"Insert quantity of product {productName}");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        management.AddProductQuantity(productName, quantity);
                    }
                    if (management.IfProductExist(productName) == 1 && management.IfSameProvaider(userName, password, productName) == false)
                    {
                        Console.WriteLine($"Product {productName} already exist");
                        Console.ReadLine();
                    }
                    if (management.IfProductExist(productName) == 0)
                    {
                        management.InsertNewProductToStock();
                    }
                    break;
                    case 2:
                    management.ShowAllMyProducts(management.ReturnProviderNumberByUserNameAndPassword(userName, password));
                    Console.ReadLine();
                        break;
                    case 3:
                        break;

                }
            
        }
        static public void ClientMenu(string userName, int password)
        {
            IManagementDAO management = new ManagementDAO();
            int userInput = 0;
            userInput = Menu.DisplayClientMenu();
            switch (userInput)
            {
                case 1:
                    management.ShowAllMyOrders(management.ReturnClientNumberByUserNameAndPassword(userName, password));
                    Console.ReadLine();
                    break;
                case 2:
                    management.ViewAllProducts();
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Insert product name");
                    string productName = Console.ReadLine();
                    if (management.IfProductExist(productName) == 1)
                    {
                        Console.WriteLine("Insert the amount of product you want to order");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        if(quantity >  management.ReturnProductQuantity(productName)|| management.ReturnProductQuantity(productName) == 0)
                        {
                            Console.WriteLine("Out of stock");
                            Console.ReadLine(); 
                        }
                        else
                        {
                            management.OrderProduct(productName, quantity, userName, password);
                            management.UpdateTotalOrderCost(quantity, productName);
                            management.UpdateQuantityInStock(quantity, productName);
                        }
                    }
                        break;
            }
        }
   
    }
}
