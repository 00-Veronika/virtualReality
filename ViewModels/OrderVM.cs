﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace virtualReality.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }
        public int user_Id { get; set; }
        public int genre_Id { get; set; }
        public int games_Id { get; set; }
        public string Status { get; set; }
    }
}
