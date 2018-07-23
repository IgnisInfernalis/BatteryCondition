using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatteryCondition.Models.ViewModels
{
    public class BatteryConditionViewModel
    {
        public int BatteryLocalId { get; set; }
        public string BatteryModelName { get; set; }
        public string BatteryBrandName { get; set; }
        public DateTime LastDate { get; set; }  // Дата установки на последнем адресе
        public float LastCapacity { get; set; }   // Последние измерения "Кулоном"
        public DateTime LastCapacityDate { get; set; }   // Дата последних измерений "Кулоном"
        public BatteryPack LastBatteryPack { get; set; }
        
        public List<CapacityByDate> CapacityByDates { get; set; }
        public List<AddressByDate> AddressByDates { get; set; }
    }
}
