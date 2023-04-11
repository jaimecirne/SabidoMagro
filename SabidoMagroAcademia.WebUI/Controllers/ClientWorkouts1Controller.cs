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
    public class ClientWorkouts1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientWorkouts1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientWorkouts1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClientWorkouts.Include(c => c.Client);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClientWorkouts1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientWorkout = await _context.ClientWorkouts
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientWorkout == null)
            {
                return NotFound();
            }

            return View(clientWorkout);
        }

        // GET: ClientWorkouts1/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            return View();
        }

        // POST: ClientWorkouts1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Start,End,ClientId,Id")] ClientWorkout clientWorkout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientWorkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", clientWorkout.ClientId);
            return View(clientWorkout);
        }

        // GET: ClientWorkouts1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientWorkout = await _context.ClientWorkouts.FindAsync(id);
            if (clientWorkout == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", clientWorkout.ClientId);
            return View(clientWorkout);
        }

        // POST: ClientWorkouts1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Start,End,ClientId,Id")] ClientWorkout clientWorkout)
        {
            if (id != clientWorkout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientWorkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientWorkoutExists(clientWorkout.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", clientWorkout.ClientId);
            return View(clientWorkout);
        }

        // GET: ClientWorkouts1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientWorkout = await _context.ClientWorkouts
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientWorkout == null)
            {
                return NotFound();
            }

            return View(clientWorkout);
        }

        // POST: ClientWorkouts1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientWorkout = await _context.ClientWorkouts.FindAsync(id);
            _context.ClientWorkouts.Remove(clientWorkout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientWorkoutExists(int id)
        {
            return _context.ClientWorkouts.Any(e => e.Id == id);
        }
    }
}
