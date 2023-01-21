using System;
using System.Collections.Generic;
using System.Linq;
using static virtualReality.ViewModels.Enums;

namespace virtualReality.ViewModels.OrdersVM
{
    public class EditOrderVM
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public List<string> StatusOptions
        {
            get
            {
                return Enum.GetValues(typeof(OrderStatus)).Cast<string>().ToList();
            }
        }
    }
}
