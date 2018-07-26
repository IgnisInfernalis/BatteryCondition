using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BatteryCondition.Models;
using BatteryCondition.Models.ViewModels;
using BatteryCondition.Models.GetViewModels;

namespace BatteryCondition.Controllers
{
    public class GetBatteryConditionController : Controller
    {
        BatteryContext db;
        public GetBatteryConditionController(BatteryContext context)
        {
            db = context;
        }

        public IActionResult Details(int Id)
        {

            return View(GetBatteryConditionViewModel.GetViewModel(db, Id));
        }
    }
}