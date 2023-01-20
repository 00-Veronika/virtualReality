using System.Collections.Generic;

namespace virtualReality.ViewModels.OrdersVM
{
    public class OrdersVM
    {
        public List<OrderVM> Orders = new List<OrderVM>();
        public string UserRole { get; set; }
    }
}
