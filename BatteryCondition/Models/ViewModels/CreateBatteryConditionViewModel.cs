using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryConditionInventory.Models.ViewModels
{
    public class CreateBatteryConditionViewModel
    {
        public int BatteryLocalId { get; set; }
        public BatteryModel BatteryModel { get; set; }
        public AddressByDate AddressByDate { get; set; }
        public CapacityByDate CapacityByDate { get; set; }
        public BatteryConditionBatteryPack BatteryConditionBatteryPack { get; set; }
        public ICollection<BatteryModel> BatteryModels { get; set; }
    }
}
