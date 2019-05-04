using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    class Provider
    {
        public int ProvidertNumber { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
        public string CompanyName { get; set; }
       
        public static bool operator ==(Provider x1, Provider x2)
        {
            if (ReferenceEquals(x1, null) && ReferenceEquals(x2, null))
            {
                return true;
            }

            if (ReferenceEquals(x1, null) || ReferenceEquals(x2, null))
            {
                return false;
            }

            if (x1.ProvidertNumber == x2.ProvidertNumber)
                return true;

            return false;
        }
        public static bool operator !=(Provider x1, Provider x2)
        {
            return !(x1 == x2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Provider otherProvider = obj as Provider;

            return this.ProvidertNumber == otherProvider.ProvidertNumber;
        }
        public override int GetHashCode()
        {
            return (int)this.ProvidertNumber;
        }
    }
}
