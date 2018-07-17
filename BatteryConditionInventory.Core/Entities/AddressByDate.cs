using System;
using BatteryConditionInventory.Core.SharedKernel;

namespace BatteryConditionInventory.Core.Entities
{
    public class AddressByDate : BaseEntity
    {
        public House House { get; set; } // односторонняя связь один-ко-многим
        public DateTime DateTime { get; set; }

        public int? BatteryConditionId { get; set; }
        public BatteryCondition BatteryCondition { get; set; }
    }
}