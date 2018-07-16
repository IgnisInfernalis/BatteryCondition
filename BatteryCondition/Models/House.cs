﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryConditionsInventory.Models
{
    public class House
    {
        public int HouseId { get; set; }
        public string HouseNumber { get; set; }

        public Street Street { get; set; }  // односторонняя связь один-ко-многим
    }   
}
