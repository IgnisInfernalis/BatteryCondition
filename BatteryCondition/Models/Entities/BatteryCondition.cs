using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatteryCondition.Models
{
    public class BatteryCondition
    {
        public int BatteryConditionId { get; set; }
        public int BatteryLocalId { get; set; }
        
        public int? BatteryModelId { get; set; }
        public BatteryModel BatteryModel { get; set; }
        
        public ICollection<AddressByDate> AddressByDates { get; set; }
        public ICollection<CapacityByDate> CapacityByDates { get; set; }
        public ICollection<BatteryConditionBatteryPack> BatteryConditionBatteryPacks { get; set; }
        
        public BatteryCondition()
        {
            BatteryConditionBatteryPacks = new List<BatteryConditionBatteryPack>();
            AddressByDates = new List<AddressByDate>();
        }
    }
}
