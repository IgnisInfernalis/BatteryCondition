using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BatteryConditionInventory.Models.ViewModels;
using BatteryConditionInventory.Core.Interfaces;
using BatteryConditionInventory.Core.Entities;
using BatteryConditionInventory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BatteryConditionInventory.Models
{
    public static class GetBatteryPackViewModel
    {
        
        public static BatteryPackViewModel GetViewModel(BatteryContext context, int Id)
        {
            BatteryPackViewModel viewModel = new BatteryPackViewModel();
            viewModel.Date = context.BatteryPacks.Include(ad => ad.AddressByDate).First(bp=>bp.Id==1).AddressByDate.DateTime.Date;
            viewModel.BatteryConditionBatteryPacksList = context.BatteryPacks.Include(bcbp => bcbp.BatteryConditionBatteryPacks)
                .First(bp => bp.Id == Id).BatteryConditionBatteryPacks.ToList();
            

            foreach (BatteryConditionBatteryPack b in viewModel.BatteryConditionBatteryPacksList)
            {
                viewModel.BatteryConditionList.Add(b.BatteryCondition);
            }
            return viewModel;
        }
    }
}
