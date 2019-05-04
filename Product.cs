using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    class Product
    {
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public int ProviderNumber { get; set; }
        public int Cost { get; set; }
        public int QuantityInStock { get; set; }
        public static bool operator ==(Product x1, Product x2)
        {
            if (ReferenceEquals(x1, null) && ReferenceEquals(x2, null))
            {
                return true;
            }

            if (ReferenceEquals(x1, null) || ReferenceEquals(x2, null))
            {
                return false;
            }

            if (x1.ProductNumber == x2.ProductNumber)
                return true;

            return false;
        }
        public static bool operator !=(Product x1, Product x2)
        {
            return !(x1 == x2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Product otherProduct = obj as Product;

            return this.ProductNumber == otherProduct.ProductNumber;
        }
        public override int GetHashCode()
        {
            return (int)this.ProductNumber;
        }
    }
}
