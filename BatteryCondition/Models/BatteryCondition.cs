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

        public int BatteryModelId { get; set; }
        public BatteryModel BatteryModel { get; set; }
        public bool BatteryPack { get; set; }
        public virtual List<AddressByDate> AddressByDates { get; set; }
        public virtual List<CapacityByDate> CapacityByDates { get; set; }
    }
}
