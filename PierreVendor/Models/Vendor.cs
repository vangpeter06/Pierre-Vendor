using System.Collections.Generic;

namespace PierreVendor.Models
{
    public class Vendor
    {
        public string VendorName { get; set; }

        public int Id { get; }

        public List<Order> Orders { get; set; }

        private static List<Vendor> _instances = new List<Vendor> { };

        public Vendor(string vendorName)
        {
            VendorName = vendorName;
            Id = _instances.Count;
            _instances.Add(this);
            Orders = new List<Order> { };
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static Vendor Find(int searchId)
        {
            return _instances[searchId - 1];
        }

        public static List<Vendor> GetAll()
        {
            return _instances;
        }

        public void AddOrder(Order order)
        {
            Orders.Add (order);
        }
    }
}
