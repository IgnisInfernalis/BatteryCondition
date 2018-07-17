using System;
using System.Collections.Generic;
using System.Text;
using BatteryConditionInventory.Core.SharedKernel;

namespace BatteryConditionInventory.Core.Entities
{
    public class Street : BaseEntity
    {
        public string StreetName { get; set; }

        public City City { get; set; }        
    }
}
