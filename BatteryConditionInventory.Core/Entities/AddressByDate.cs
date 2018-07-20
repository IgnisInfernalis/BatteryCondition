﻿using System;
using BatteryConditionInventory.Core.SharedKernel;

namespace BatteryConditionInventory.Core.Entities
{
    public class AddressByDate : BaseEntity
    {
        public House House { get; set; } // односторонняя связь один-ко-многим
        public DateTime DateTime { get; set; }

        public string Address { get
            {
                return House.Street.StreetName + " " + House.HouseNumber;
            } }

        public int? BatteryConditionId { get; set; }
        public BatteryCondition BatteryCondition { get; set; }
    }
}