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
    public class Avaliations1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Avaliations1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Avaliations1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Avaliations.Include(a => a.Client).Include(a => a.Coach);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Avaliations1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliation = await _context.Avaliations
                .Include(a => a.Client)
                .Include(a => a.Coach)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avaliation == null)
            {
                return NotFound();
            }

            return View(avaliation);
        }

        // GET: Avaliations1/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["CoachId"] = new SelectList(_context.Managers, "Id", "Id");
            return View();
        }

        // POST: Avaliations1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Label,Weight,Height,CoachsComments,Date,ClientId,CoachId,Id")] Avaliation avaliation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avaliation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", avaliation.ClientId);
            ViewData["CoachId"] = new SelectList(_context.Managers, "Id", "Id", avaliation.CoachId);
            return View(avaliation);
        }

        // GET: Avaliations1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliation = await _context.Avaliations.FindAsync(id);
            if (avaliation == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", avaliation.ClientId);
            ViewData["CoachId"] = new SelectList(_context.Managers, "Id", "Id", avaliation.CoachId);
            return View(avaliation);
        }

        // POST: Avaliations1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Label,Weight,Height,CoachsComments,Date,ClientId,CoachId,Id")] Avaliation avaliation)
        {
            if (id != avaliation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliationExists(avaliation.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", avaliation.ClientId);
            ViewData["CoachId"] = new SelectList(_context.Managers, "Id", "Id", avaliation.CoachId);
            return View(avaliation);
        }

        // GET: Avaliations1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliation = await _context.Avaliations
                .Include(a => a.Client)
                .Include(a => a.Coach)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avaliation == null)
            {
                return NotFound();
            }

            return View(avaliation);
        }

        // POST: Avaliations1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avaliation = await _context.Avaliations.FindAsync(id);
            _context.Avaliations.Remove(avaliation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliationExists(int id)
        {
            return _context.Avaliations.Any(e => e.Id == id);
        }
    }
}
