using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BatteryConditionInventory.Core.Interfaces;
using BatteryConditionInventory.Core.Entities;

namespace BatteryConditionInventory.Models.ViewModels
{
    public class BatteryPackViewModel
    {
        public DateTime Date { get; set; }

        public List<BatteryConditionBatteryPack> BatteryConditionBatteryPacksList { get; set; }
        public List<BatteryCondition> BatteryConditionList { get; set; }
        
    }
}
