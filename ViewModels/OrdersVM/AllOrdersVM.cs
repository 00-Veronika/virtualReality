﻿using System.Collections.Generic;
using virtualReality.Entities;

namespace virtualReality.ViewModels.OrdersVM
{
    public class OrdersVM
    {
        public List<Order> Orders { get; set; }
        public string UserRole { get; set; }
    }
}
