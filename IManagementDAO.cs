using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    public interface IManagementDAO
    {
        void InsertNewClient();
        void InsertNewProvider();
        void InsertNewProductToStock();
        int ProviderUserNamePasswordValidation(string userName, int password);
        int IfProductExist(string productName);
        int ReturnProviderNumberByUserNameAndPassword(string userName, int password);
        bool IfSameProvaider(string userName, int password, string productName);
        void AddProductQuantity(string productName, int quantity);
        void ShowAllMyProducts(int providerNumber);
        int ClientUserNamePasswordValidation(string userName, int password);
        int ReturnClientNumberByUserNameAndPassword(string userName, int password);
        void ShowAllMyOrders(int providerNumber);
        void ViewAllProducts();
        int ReturnProductQuantity(string productName);
        void OrderProduct(string productName, int quantity, string userName, int password);
        int ReturnProductNumberByProductName(string productName);
        void UpdateTotalOrderCost(int quantity, string productName);
        void UpdateQuantityInStock(int quantity, string productName);
        int TotalCostSum(int clientNumber);


        }
      
}
