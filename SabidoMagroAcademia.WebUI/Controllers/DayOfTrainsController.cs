using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SabidoMagroAcademia.Application.DTOs;
using SabidoMagroAcademia.Application.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.WebUI.Controllers
{
    [Authorize]
    public class DayOfTrainsController : Controller
    {
        private readonly IDayOfTrainService _dayoftrainService;
        private readonly IPlanService _planService;
        private readonly IWebHostEnvironment _environment;

        public DayOfTrainsController(IDayOfTrainService dayoftrainAppService, IPlanService planAppService, IWebHostEnvironment environment)
        {
            _dayoftrainService = dayoftrainAppService;
            _planService = planAppService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dayoftrains = await _dayoftrainService.GetDayOfTrains();
            return View(dayoftrains);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.planId =
            new SelectList(await _planService.GetCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DayOfTrainDTO dayoftrainDto)
        {
            if (ModelState.IsValid)
            {
                await _dayoftrainService.Add(dayoftrainDto);
                return RedirectToAction(nameof(Index));
            }
            return View(dayoftrainDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var dayoftrainDto = await _dayoftrainService.GetById(id);

            if (dayoftrainDto == null) return NotFound();

            var categories = await _planService.GetCategories();
            ViewBag.planId = new SelectList(categories, "Id", "Name", dayoftrainDto.planId);

            return View(dayoftrainDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DayOfTrainDTO dayoftrainDto)
        {
            if (ModelState.IsValid)
            {
                await _dayoftrainService.Update(dayoftrainDto);
                return RedirectToAction(nameof(Index));
            }
            return View(dayoftrainDto);
        }

        //só podem acessar os usuários autenticados e que façam parte desta role
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dayoftrainDto = await _dayoftrainService.GetById(id);

            if (dayoftrainDto == null) return NotFound();

            return View(dayoftrainDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _dayoftrainService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var dayoftrainDto = await _dayoftrainService.GetById(id);

            if (dayoftrainDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + dayoftrainDto.Image);//caminho completo da imagem
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(dayoftrainDto);
        }
    }
}
