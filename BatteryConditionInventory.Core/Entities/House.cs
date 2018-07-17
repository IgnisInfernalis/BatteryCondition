using System;
using System.Collections.Generic;
using System.Text;
using BatteryConditionInventory.Core.SharedKernel;

namespace BatteryConditionInventory.Core.Entities
{
    public class House : BaseEntity
    {
        public string HouseNumber { get; set; }

        public Street Street { get; set; }
    }
}
