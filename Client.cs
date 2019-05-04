using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    class Client
    {
        public int ClientNumber { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal CreditCardNumber { get; set; }

        public static bool operator ==(Client x1, Client x2)
        {
            if (ReferenceEquals(x1, null) && ReferenceEquals(x2, null))
            {
                return true;
            }

            if (ReferenceEquals(x1, null) || ReferenceEquals(x2, null))
            {
                return false;
            }

            if (x1.ClientNumber == x2.ClientNumber)
                return true;

            return false;
        }
        public static bool operator !=(Client x1, Client x2)
        {
            return !(x1 == x2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Client otherClient = obj as Client;

            return this.ClientNumber == otherClient.ClientNumber;
        }
        public override int GetHashCode()
        {
            return (int)this.ClientNumber;
        }
    }
}
