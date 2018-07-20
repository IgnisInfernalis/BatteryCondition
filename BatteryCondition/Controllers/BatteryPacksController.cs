using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BatteryConditionInventory.Core.Entities;
using BatteryConditionInventory.Infrastructure.Data;
using BatteryConditionInventory.Core.Interfaces;
using BatteryConditionInventory.Models.ViewModels;
using BatteryConditionInventory.Models;

namespace BatteryConditionInventory.Controllers
{
    public class BatteryPacksController : Controller
    {
        private readonly BatteryContext _context;

        public BatteryPacksController(BatteryContext context)
        {
            _context = context;
        }

        // GET: BatteryPacks
        public async Task<IActionResult> Index(int Id)
        {
            EFGenericRepository<BatteryPack> batteryPack = new EFGenericRepository<BatteryPack>(_context);
            BatteryPackViewModel batteryPackViewModel = GetBatteryPackViewModel.GetViewModel(_context, Id);
            return View(batteryPackViewModel);
        }

        // GET: BatteryPacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batteryPack = await _context.BatteryPacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batteryPack == null)
            {
                return NotFound();
            }

            return View(batteryPack);
        }

        // GET: BatteryPacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BatteryPacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] BatteryPack batteryPack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batteryPack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batteryPack);
        }

        // GET: BatteryPacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batteryPack = await _context.BatteryPacks.FindAsync(id);
            if (batteryPack == null)
            {
                return NotFound();
            }
            return View(batteryPack);
        }

        // POST: BatteryPacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] BatteryPack batteryPack)
        {
            if (id != batteryPack.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batteryPack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatteryPackExists(batteryPack.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(batteryPack);
        }

        // GET: BatteryPacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batteryPack = await _context.BatteryPacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batteryPack == null)
            {
                return NotFound();
            }

            return View(batteryPack);
        }

        // POST: BatteryPacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batteryPack = await _context.BatteryPacks.FindAsync(id);
            _context.BatteryPacks.Remove(batteryPack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatteryPackExists(int id)
        {
            return _context.BatteryPacks.Any(e => e.Id == id);
        }
    }
}
