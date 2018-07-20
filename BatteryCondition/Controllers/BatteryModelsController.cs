using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BatteryConditionInventory.Core.Entities;
using BatteryConditionInventory.Infrastructure.Data;

namespace BatteryConditionInventory.Controllers
{
    public class BatteryModelsController : Controller
    {
        private readonly BatteryContext _context;

        public BatteryModelsController(BatteryContext context)
        {
            _context = context;
        }

        // GET: BatteryModels
        public async Task<IActionResult> Index()
        {
            var batteryContext = _context.BatteryModels.Include(b => b.BatteryBrand).ThenInclude(bb=>bb.BatteryModels);
            return View(await batteryContext.ToListAsync());
        }

        // GET: BatteryModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batteryModel = await _context.BatteryModels
                .Include(b => b.BatteryBrand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batteryModel == null)
            {
                return NotFound();
            }

            return View(batteryModel);
        }

        // GET: BatteryModels/Create
        public IActionResult Create()
        {
            ViewData["BatteryBrandId"] = new SelectList(_context.Brands, "Id", "Id");
            return View();
        }

        // POST: BatteryModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BatteryModelName,BatteryCapacity,BatteryBrandId,Id")] BatteryModel batteryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batteryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatteryBrandId"] = new SelectList(_context.Brands, "Id", "Id", batteryModel.BatteryBrandId);
            return View(batteryModel);
        }

        // GET: BatteryModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batteryModel = await _context.BatteryModels.FindAsync(id);
            if (batteryModel == null)
            {
                return NotFound();
            }
            ViewData["BatteryBrandId"] = new SelectList(_context.Brands, "Id", "Id", batteryModel.BatteryBrandId);
            return View(batteryModel);
        }

        // POST: BatteryModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BatteryModelName,BatteryCapacity,BatteryBrandId,Id")] BatteryModel batteryModel)
        {
            if (id != batteryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batteryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatteryModelExists(batteryModel.Id))
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
            ViewData["BatteryBrandId"] = new SelectList(_context.Brands, "Id", "Id", batteryModel.BatteryBrandId);
            return View(batteryModel);
        }

        // GET: BatteryModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batteryModel = await _context.BatteryModels
                .Include(b => b.BatteryBrand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batteryModel == null)
            {
                return NotFound();
            }

            return View(batteryModel);
        }

        // POST: BatteryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batteryModel = await _context.BatteryModels.FindAsync(id);
            _context.BatteryModels.Remove(batteryModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatteryModelExists(int id)
        {
            return _context.BatteryModels.Any(e => e.Id == id);
        }
    }
}
