﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryCondition.Models
{
    public class AddressByDate
    {
        public int AddressByDateId { get; set; }
        public House House { get; set; }
        public DateTime DateTime { get; set; }
    }
}
