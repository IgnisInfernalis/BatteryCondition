using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BatteryCondition.Models;
using BatteryCondition.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BatteryCondition.Controllers
{
    public class CreateController : Controller
    {
        BatteryContext db; // Не нравится мне это решение, как и логика добавления в конроллере CreateBatteryCondition

        public CreateController(BatteryContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateBatteryCondition()
        {
            CreateBatteryConditionViewModel createBattery = new CreateBatteryConditionViewModel();
            createBattery.BatteryModel = new BatteryModel();
            createBattery.BatteryModels = new List<BatteryModel>();
            
            createBattery.BatteryModels = db.BatteryModels.ToList();
            createBattery.BatteryConditionBatteryPack = new BatteryConditionBatteryPack();
            createBattery.CapacityByDate = new CapacityByDate();
            
            return View(createBattery);
        }
        [HttpPost]
        public IActionResult CreateBatteryCondition(CreateBatteryConditionViewModel createBattery)
        {
            Models.BatteryCondition batteryCondition = new Models.BatteryCondition();
            batteryCondition.AddressByDates = new List<AddressByDate>();
            // Проверка на существование уже записи в таблицах House и Street
            if (db.Houses.ToList().Exists(h=>h.HouseNumber== createBattery.AddressByDate.House.HouseNumber)&&
                (db.Houses.Include(s=>s.Street).ToList().Exists(h => h.Street.StreetName == createBattery.AddressByDate.House.Street.StreetName)))
            {
                batteryCondition.AddressByDates.Add(new AddressByDate
                {
                    House = db.Houses.ToList().Find(h=>h.HouseNumber== createBattery.AddressByDate.House.HouseNumber &&
                        h.Street.StreetName== createBattery.AddressByDate.House.Street.StreetName),
                    BatteryCondition = batteryCondition,
                    Date = DateTime.Today
                });
            }
            else
            {
                batteryCondition.AddressByDates.Add(
                new AddressByDate
                {
                    House = createBattery.AddressByDate.House,
                    BatteryCondition = batteryCondition,
                    Date = DateTime.Today
                }
                );
            }         
            
            batteryCondition.BatteryLocalId = createBattery.BatteryLocalId;
            batteryCondition.BatteryModelId = createBattery.BatteryModel.BatteryModelId;
            // batteryCondition.CapacityByDates.Add(createBattery.CapacityByDate);
            db.BatteryConditions.Add(batteryCondition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}