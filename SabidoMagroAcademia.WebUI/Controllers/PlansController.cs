using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SabidoMagroAcademia.Application.DTOs;
using SabidoMagroAcademia.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.WebUI.Controllers
{
    //propriedade define que todos os actions deste controlador so poderão ser acessados por usuários autenticados
    [Authorize]
    public class PlansController : Controller
    {
        private readonly IPlanService _planService;

        public PlansController(IPlanService planService)
        {
            _planService = planService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _planService.GetCategories();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlanDTO plan)
        {
            if (ModelState.IsValid)
            {
                await _planService.Add(plan);
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var planDto = await _planService.GetById(id);
            if (planDto == null) return NotFound();
            return View(planDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PlanDTO planDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _planService.Update(planDto);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(planDto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var planDto = await _planService.GetById(id);

            if (planDto == null) return NotFound();

            return View(planDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _planService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var planDto = await _planService.GetById(id);

            if (planDto == null)
                return NotFound();

            return View(planDto);
        }
    }
}
