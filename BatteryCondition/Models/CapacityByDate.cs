using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatteryConditionsInventory.Models
{
    //[NotMapped]
    public class CapacityByDate
    {
        public int CapacityByDateId { get; set; }
        public float Capacity { get; set; }
        public DateTime DateTime { get; set; }

        public int? BatteryConditionId { get; set; }
        public BatteryCondition BatteryCondition { get; set; }
    }
}
