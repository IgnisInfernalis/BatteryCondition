using BatteryConditionInventory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryConditionInventory.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<BatteryPack> BatteryPacks { get; set; }
        public IEnumerable<BatteryModel> BatteryModels { get; set; }
        
    }
}
