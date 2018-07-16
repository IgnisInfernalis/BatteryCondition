using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatteryConditionInventory.Models
{
    public class BatteryCondition
    {
        public int BatteryConditionId { get; set; }
        public int BatteryLocalId { get; set; }
        
        public int? BatteryModelId { get; set; }
        public BatteryModel BatteryModel { get; set; }
        
        public virtual ICollection<AddressByDate> AddressByDates { get; set; }
        public virtual ICollection<CapacityByDate> CapacityByDates { get; set; }
        public virtual ICollection<BatteryConditionBatteryPack> BatteryConditionBatteryPack { get; set; }
        
        public BatteryCondition()
        {
            BatteryConditionBatteryPack = new List<BatteryConditionBatteryPack>();
        }
    }
}
