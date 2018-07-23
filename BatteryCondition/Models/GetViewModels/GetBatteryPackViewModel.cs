using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BatteryCondition.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BatteryCondition.Models.GetViewModels
{
    public static class GetBatteryPackViewModel
    {
        public static BatteryPackViewModel GetViewModel(BatteryContext context, int Id)
        {
            var batteryPack = context.BatteryPacks
                .Include(bcbp => bcbp.BatteryConditionBatteryPacks)
                .ThenInclude(bc => bc.BatteryCondition.BatteryModel.BatteryBrand)
                .Include(q=>q.BatteryConditionBatteryPacks).ThenInclude(w=>w.BatteryCondition.AddressByDates)            
                .Include(ad => ad.AddressByDate.House.Street)
                .First(bp=>bp.BatteryPackId==Id);
            
            BatteryPackViewModel batteryPackViewModel = new BatteryPackViewModel();
            batteryPackViewModel.Address = batteryPack.AddressByDate.House.Street.StreetName + " " 
                                            + batteryPack.AddressByDate.House.HouseNumber;
            batteryPackViewModel.Date = batteryPack.AddressByDate.Date.Date;

            batteryPackViewModel.BatteryConditions = new List<BatteryCondition>();
            //batteryPackViewModel.BatteryConditionDates = new List<DateTime>();
            foreach (var bp in batteryPack.BatteryConditionBatteryPacks)
            {
                batteryPackViewModel.BatteryConditions.Add(bp.BatteryCondition);
                //batteryPackViewModel.BatteryConditionDates.Add(bp.BatteryCondition.AddressByDates.Last().DateTime.Date);
            }
            return batteryPackViewModel;
        }
    }
}
