using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Infra.Data.Context;

namespace SabidoMagroAcademia.WebUI.Controllers
{
    public class DayOfTrains1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public DayOfTrains1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DayOfTrains1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DayOfTrains.Include(d => d.WorkoutInDay);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DayOfTrains1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayOfTrain = await _context.DayOfTrains
                .Include(d => d.WorkoutInDay)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dayOfTrain == null)
            {
                return NotFound();
            }

            return View(dayOfTrain);
        }

        // GET: DayOfTrains1/Create
        public IActionResult Create()
        {
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Label");
            return View();
        }

        // POST: DayOfTrains1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Day,WorkoutId,Id")] DayOfTrain dayOfTrain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dayOfTrain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Label", dayOfTrain.WorkoutId);
            return View(dayOfTrain);
        }

        // GET: DayOfTrains1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayOfTrain = await _context.DayOfTrains.FindAsync(id);
            if (dayOfTrain == null)
            {
                return NotFound();
            }
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Label", dayOfTrain.WorkoutId);
            return View(dayOfTrain);
        }

        // POST: DayOfTrains1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Day,WorkoutId,Id")] DayOfTrain dayOfTrain)
        {
            if (id != dayOfTrain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dayOfTrain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DayOfTrainExists(dayOfTrain.Id))
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
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Label", dayOfTrain.WorkoutId);
            return View(dayOfTrain);
        }

        // GET: DayOfTrains1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dayOfTrain = await _context.DayOfTrains
                .Include(d => d.WorkoutInDay)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dayOfTrain == null)
            {
                return NotFound();
            }

            return View(dayOfTrain);
        }

        // POST: DayOfTrains1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dayOfTrain = await _context.DayOfTrains.FindAsync(id);
            _context.DayOfTrains.Remove(dayOfTrain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DayOfTrainExists(int id)
        {
            return _context.DayOfTrains.Any(e => e.Id == id);
        }
    }
}
