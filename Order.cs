using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    class Order
    {
        public int OrderNumber { get; set; }
        public int ClienttName { get; set; }
        public int ProductNumber { get; set; }
        public int OrderQuantity { get; set; }
        public int TotalOrderCost { get; set; }
        public int TotalCostSum { get; set; }
        public static bool operator ==(Order x1, Order x2)
        {
            if (ReferenceEquals(x1, null) && ReferenceEquals(x2, null))
            {
                return true;
            }

            if (ReferenceEquals(x1, null) || ReferenceEquals(x2, null))
            {
                return false;
            }

            if (x1.OrderNumber == x2.OrderNumber)
                return true;

            return false;
        }
        public static bool operator !=(Order x1, Order x2)
        {
            return !(x1 == x2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Order otherOrder = obj as Order;

            return this.OrderNumber == otherOrder.OrderNumber;
        }
        public override int GetHashCode()
        {
            return (int)this.OrderNumber;
        }
    }
}
