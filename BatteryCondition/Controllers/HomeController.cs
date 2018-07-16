using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BatteryConditionsInventory.Models;
using BatteryConditionsInventory.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BatteryConditionsInventory.Controllers
{
    public class HomeController : Controller
    {
        BatteryContext db;
        public HomeController(BatteryContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel
            {
                BatteryModels = db.BatteryModels.Include(bb => bb.BatteryBrand),
                BatteryPacks = db.BatteryPacks.Include(bp => bp.BatteryConditionBatteryPacks)
                .ThenInclude(bcbp => bcbp.BatteryCondition)
                .ThenInclude(bc => bc.BatteryModel)
                .ThenInclude(bm => bm.BatteryBrand)
                .Include(ad => ad.AddressByDate).ThenInclude(h => h.House).ThenInclude(s => s.Street)
            };

            return View(indexViewModel);
        }

        [HttpGet]
        public IActionResult GetBatteryConditionsByBatteryModel(int id)
        {
            BatteryModel batteryModel = db.BatteryModels.Include(bb => bb.BatteryBrand)
                .ToList().Find(bm => bm.BatteryModelId == id);
            ViewBag.BatteryModel = batteryModel;
            return View(db.BatteryConditions.Include(ad => ad.AddressByDates)
                .ThenInclude(h => h.House)
                .ThenInclude(s => s.Street)
                .ToList().FindAll(b => b.BatteryModel == batteryModel)
                );
        }
        [HttpGet]
        public IActionResult GetBatteryCondition(int id)
        {
            Models.BatteryCondition batteryCondition = new Models.BatteryCondition();
            batteryCondition = db.BatteryConditions
                .Include(ad => ad.AddressByDates).ThenInclude(h => h.House).ThenInclude(s => s.Street)
                .Include(bm => bm.BatteryModel).ThenInclude(bb => bb.BatteryBrand)
                .Include(bcbp => bcbp.BatteryConditionBatteryPack) //пустая таблица сейчас при генерации!
                    .ThenInclude(bp => bp.BatteryPack).ThenInclude(ad => ad.AddressByDate).ThenInclude(h => h.House).ThenInclude(s => s.Street)
                .Include(cd => cd.CapacityByDates)
                .First(i => i.BatteryConditionId == id);
            return View(batteryCondition);
        }

        [HttpGet]
        public IActionResult GetBatteryPack(int id)
        {
            BatteryPack batteryPack = new BatteryPack();
            batteryPack = db.BatteryPacks.Include(ad => ad.AddressByDate).ThenInclude(h => h.House).ThenInclude(s => s.Street)
                .Include(b => b.BatteryConditionBatteryPacks).ThenInclude(bcbp => bcbp.BatteryCondition).First(bp => bp.BatteryPackId == id);
            return View(batteryPack);
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
