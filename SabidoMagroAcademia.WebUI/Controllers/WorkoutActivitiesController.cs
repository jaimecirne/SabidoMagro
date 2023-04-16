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
    public class WorkoutActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkoutActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkoutActivities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkoutActivity.Include(w => w.Activity).Include(w => w.Workout);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkoutActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutActivity = await _context.WorkoutActivity
                .Include(w => w.Activity)
                .Include(w => w.Workout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutActivity == null)
            {
                return NotFound();
            }

            return View(workoutActivity);
        }

        // GET: WorkoutActivities/Create
        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.Activities, "Id", "Label");
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Label");
            return View();
        }

        // POST: WorkoutActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Order,Sets,Reps,Rest,WorkoutId,ActivityId,Id")] WorkoutActivity workoutActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.Activities, "Id", "Label", workoutActivity.ActivityId);
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Label", workoutActivity.WorkoutId);
            return View(workoutActivity);
        }

        // GET: WorkoutActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutActivity = await _context.WorkoutActivity.FindAsync(id);
            if (workoutActivity == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.Activities, "Id", "Label", workoutActivity.ActivityId);
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Label", workoutActivity.WorkoutId);
            return View(workoutActivity);
        }

        // POST: WorkoutActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Order,Sets,Reps,Rest,WorkoutId,ActivityId,Id")] WorkoutActivity workoutActivity)
        {
            if (id != workoutActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutActivityExists(workoutActivity.Id))
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
            ViewData["ActivityId"] = new SelectList(_context.Activities, "Id", "Label", workoutActivity.ActivityId);
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "Id", "Label", workoutActivity.WorkoutId);
            return View(workoutActivity);
        }

        // GET: WorkoutActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutActivity = await _context.WorkoutActivity
                .Include(w => w.Activity)
                .Include(w => w.Workout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workoutActivity == null)
            {
                return NotFound();
            }

            return View(workoutActivity);
        }

        // POST: WorkoutActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutActivity = await _context.WorkoutActivity.FindAsync(id);
            _context.WorkoutActivity.Remove(workoutActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutActivityExists(int id)
        {
            return _context.WorkoutActivity.Any(e => e.Id == id);
        }
    }
}
