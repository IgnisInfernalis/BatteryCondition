using System;
using BatteryConditionInventory.Core.SharedKernel;

namespace BatteryConditionInventory.Core.Entities
{
    public class CapacityByDate : BaseEntity
    {
        public float Capacity { get; set; }
        public DateTime DateTime { get; set; }

        public int? BatteryConditionId { get; set; }
        public BatteryCondition BatteryCondition { get; set; }
    }
}