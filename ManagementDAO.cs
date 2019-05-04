using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    class ManagementDAO : IManagementDAO
    {
        public void InsertNewClient()
        {
            Console.WriteLine("Insert User Name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Inser Password:");
            int password = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Insert Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Insert Credit Card Number:");
            decimal creditCardNumber = Convert.ToDecimal(Console.ReadLine());
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("INSERT_NEW_CLIENT", conn);


                cmd.Parameters.Add(new SqlParameter("@USERNAME", userName));
                cmd.Parameters.Add(new SqlParameter("@PASS", password));
                cmd.Parameters.Add(new SqlParameter("@FIRST_NAME", firstName));
                cmd.Parameters.Add(new SqlParameter("@LAST_NAME", lastName));
                cmd.Parameters.Add(new SqlParameter("@CREDIT_CARD_NUMBER", creditCardNumber));
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void InsertNewProvider()
        {

            Console.WriteLine("Insert User Name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Inser Password:");
            int password = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert Company Name:");
            string companyName = Console.ReadLine();
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("INSERT_NEW_PROVIDER", conn);


                cmd.Parameters.Add(new SqlParameter("@USERNAME", userName));
                cmd.Parameters.Add(new SqlParameter("@PASS", password));
                cmd.Parameters.Add(new SqlParameter("@COMPANY_NAME", companyName));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public int ProviderUserNamePasswordValidation(string userName, int password)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("CHECK_PASSWORD_USERNAME_PROVIDER", conn);

                cmd.Parameters.Add(new SqlParameter("@USERNAME", userName));
                cmd.Parameters.Add(new SqlParameter("@PASS", password));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                result = (int)cmd.ExecuteScalar();
            }
            return result;
        }
        public void InsertNewProductToStock()
        {
            Console.WriteLine("Insert Product Name:");
            string productName = Console.ReadLine();
            Console.WriteLine("Insert Provider Number:");
            int providerNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert Cost:");
            int cost = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert Quantity:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {

                SqlCommand cmd = new SqlCommand("INSERT_NEW_PRODUCT", conn);

                cmd.Parameters.Add(new SqlParameter("@PRODUCT_NAME", productName));
                cmd.Parameters.Add(new SqlParameter("@PROVIDER_NUMBER", providerNumber));
                cmd.Parameters.Add(new SqlParameter("@COST", cost));
                cmd.Parameters.Add(new SqlParameter("@QUANTITY", quantity));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }


        }
        public int IfProductExist(string productName)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("CHECK_IF_PRODUCT_EXIST", conn);

                cmd.Parameters.Add(new SqlParameter("@PRODUCT_NAME", productName));

                cmd.Connection.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                result = (int)cmd.ExecuteScalar();
            }
            return result;
        }
        public int ReturnProviderNumberByUserNameAndPassword(string userName, int password)
        {
            int providerNumberByDataInsert = 0;
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("RETURN_PROVIDER_NUMBER_BY_USER_NAME_AND_PASSWORD", conn);

                cmd.Parameters.Add(new SqlParameter("@USERNAME", userName));
                cmd.Parameters.Add(new SqlParameter("@PASS", password));
                cmd.Connection.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() == true)
                    {
                        Provider provider = new Provider()
                        {
                            ProvidertNumber = (int)reader["PROVIDER_NUMBER"]
                        };
                        providerNumberByDataInsert = provider.ProvidertNumber;
                    }

                }
            }
            return providerNumberByDataInsert;
        }
        public int ReturnProviderNumberByProductName(string productName)
        {
            int providerNumberByProductName = 0;
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("RETURN_PROVIDER_NUMBER_BY_PRODUCT_NAME", conn);

                cmd.Parameters.Add(new SqlParameter("@PRODUCT_NAME", productName));

                cmd.Connection.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() == true)
                    {
                        Provider provider = new Provider()
                        {
                            ProvidertNumber = (int)reader["PROVIDER_NUMBER"]
                        };
                        providerNumberByProductName = provider.ProvidertNumber;
                    }

                }
            }
            return providerNumberByProductName;
        }
        public bool IfSameProvaider(string userName, int password, string productName)
        {
            bool result = false;

            if (ReturnProviderNumberByProductName(productName) == ReturnProviderNumberByUserNameAndPassword(userName, password))
            {
                result = true;
            }
            return result;
        }
        public void AddProductQuantity(string productName, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("ADD_PRODUCT_QUANTITY", conn);

                cmd.Parameters.Add(new SqlParameter("@PRODUCT_NAME", productName));
                cmd.Parameters.Add(new SqlParameter("@QUANTITY_IN_STOCK", quantity));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void ShowAllMyProducts(int providerNumber)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("SHOW_ALL_MY_PRODUCTS", conn);

                cmd.Parameters.Add(new SqlParameter("@PROVIDER_NUMBER", providerNumber));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                //cmd.ExecuteNonQuery();
                while (reader.Read() == true)
                {
                    Console.WriteLine($"PRODUCT NUMBER:{reader["PRODUCT_NUMBER"],2}   PRODUCT NAME:{reader["PRODUCT_NAME"],2}   PROVIDER_NUMBER:{reader["PROVIDER_NUMBER"],2}   COST:{reader["COST"],2}   QUANTITY_IN_STOCK:{reader["QUANTITY_IN_STOCK"],2}");
                }
            }
        }
        public int ClientUserNamePasswordValidation(string userName, int password)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("CHECK_PASSWORD_USERNAME_CLIENT", conn);

                cmd.Parameters.Add(new SqlParameter("@USERNAME", userName));
                cmd.Parameters.Add(new SqlParameter("@PASS", password));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                result = (int)cmd.ExecuteScalar();
            }
            return result;
        }
        public int ReturnClientNumberByUserNameAndPassword(string userName, int password)
        {
            int clientNumberByDataInsert = 0;
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("RETURN_CLIENT_NUMBER_BY_USERNAME_AND_PASSWORD", conn);

                cmd.Parameters.Add(new SqlParameter("@USERNAME", userName));
                cmd.Parameters.Add(new SqlParameter("@PASS", password));
                cmd.Connection.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() == true)
                    {
                        Provider provider = new Provider()
                        {
                            ProvidertNumber = (int)reader["CLIENT_NUMBER"]
                        };
                        clientNumberByDataInsert = provider.ProvidertNumber;
                    }

                }
            }
            return clientNumberByDataInsert;
        }
        public void ShowAllMyOrders(int clientNumber)
        {
            
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                int TotalSum= TotalCostSum(clientNumber);
                SqlCommand cmd = new SqlCommand("SHOW_MY_ORDERS", conn);

                cmd.Parameters.Add(new SqlParameter("@CLIENT_NUMBER", clientNumber));
               
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                //cmd.ExecuteNonQuery();
                while (reader.Read() == true)
                {
                    Console.WriteLine($"ORDER_NUMBER:{reader["ORDER_NUMBER"],2}   CLIENT_NUMBER:{reader["CLIENT_NUMBER"],2} FIRST_NAME:{reader["FIRST_NAME"],2} LAST_NAME:{reader["LAST_NAME"],2}  PRODUCT_NUMBER:{reader["PRODUCT_NUMBER"],2} PRODUCT_NAME:{reader["PRODUCT_NAME"],2}  ORDER_QUANTITY:{reader["ORDER_QUANTITY"],2}   TOTAL_ORDER_COST:{reader["TOTAL_ORDER_COST"],2}");
                }
                Console.WriteLine($"TOTAL_ORDER_COST:{TotalSum}");
            }
        }
        public void ViewAllProducts()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products ", conn);

                //cmd.Parameters.Add(new SqlParameter("@CLIENT_NUMBER", providerNumber));

                cmd.Connection.Open();
                //cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                //cmd.ExecuteNonQuery();
                while (reader.Read() == true)
                {
                    Console.WriteLine($"PRODUCT NUMBER:{reader["PRODUCT_NUMBER"],2}   PRODUCT NAME:{reader["PRODUCT_NAME"],2}   PROVIDER_NUMBER:{reader["PROVIDER_NUMBER"],2}   COST:{reader["COST"],2}   QUANTITY_IN_STOCK:{reader["QUANTITY_IN_STOCK"],2}");
                }
            }
        }
        public void OrderProduct(string productName, int quantity, string userName, int password)
        {
            int clientNumber = ReturnClientNumberByUserNameAndPassword(userName, password);
            int productNumber = ReturnProductNumberByProductName(productName);
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("INSERT_NEW_ORDER", conn);


                cmd.Parameters.Add(new SqlParameter("@CLIENT_NUMBER", clientNumber));
                cmd.Parameters.Add(new SqlParameter("@PRODUCT_NUMBER", productNumber));
                cmd.Parameters.Add(new SqlParameter("@ORDER_QUANTITY", quantity));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public int ReturnProductQuantity(string productName)
        {
            int productQuantity = 0;
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("RETURN_PRODUCT_QUANTITY", conn);

                cmd.Parameters.Add(new SqlParameter("@PRODUCT_NAME", productName));

                cmd.Connection.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() == true)
                    {
                        Product pQuantity = new Product()
                        {
                            QuantityInStock = (int)reader["QUANTITY_IN_STOCK"]
                        };
                        productQuantity = pQuantity.QuantityInStock;
                    }

                }
            }

            return productQuantity;
        }
        public int ReturnProductNumberByProductName(string productName)
        {
            int productNumberByProductName = 0;
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("RETURN_PRODUCT_NUMBER_BY_PRODUCT_NAME", conn);

                cmd.Parameters.Add(new SqlParameter("@PRODUCT_NAME", productName));

                cmd.Connection.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() == true)
                    {
                        Product pNumber = new Product()
                        {
                            ProductNumber = (int)reader["PRODUCT_NUMBER"]
                        };
                        productNumberByProductName = pNumber.ProductNumber;
                    }

                }
            }
            return productNumberByProductName;
        }
        public void UpdateTotalOrderCost(int quantity, string productName)
        {
          int productNumber = ReturnProductNumberByProductName(productName);
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_TOTAL_ORDER_COST", conn);

                cmd.Parameters.Add(new SqlParameter("@PRODUCT_NUMBER", productNumber));
                cmd.Parameters.Add(new SqlParameter("@ORDER_QUANTITY", quantity));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateQuantityInStock(int quantity,string productName)
        {
            int productNumber = ReturnProductNumberByProductName(productName);
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_QUANTITY_IN_STOCK", conn);

                cmd.Parameters.Add(new SqlParameter("@PRODUCT_NUMBER", productNumber));
                cmd.Parameters.Add(new SqlParameter("@ORDER_QUANTITY", quantity));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public int TotalCostSum(int clientNumber)
        {
            int TotalSum = 0;
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=OrderManagementDB;Integrated Security=True"))
            {
                
               SqlCommand cmd = new SqlCommand($"SELECT SUM(TOTAL_ORDER_COST) as TOTAL_SUM FROM Orders WHERE CLIENT_NUMBER = {clientNumber}", conn);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() == true)
                    {
                        Order totalCost = new Order()
                        {
                           TotalCostSum = (int)reader["TOTAL_SUM"]
                        };
                        TotalSum = totalCost.TotalCostSum;
                    }

                }
            }
            return TotalSum;
        }
    }


    
   
}

