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
    public class ActivitysController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly IPlanService _planService;
        private readonly IWebHostEnvironment _environment;

        public ActivitysController(IActivityService activityAppService, IPlanService planAppService, IWebHostEnvironment environment)
        {
            _activityService = activityAppService;
            _planService = planAppService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var activitys = await _activityService.GetActivities();
            return View(activitys);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.planId =
            new SelectList(await _planService.GetCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActivityDTO activityDto)
        {
            if (ModelState.IsValid)
            {
                await _activityService.Add(activityDto);
                return RedirectToAction(nameof(Index));
            }
            return View(activityDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var activityDto = await _activityService.GetById(id);

            if (activityDto == null) return NotFound();

            var categories = await _planService.GetCategories();
            ViewBag.planId = new SelectList(categories, "Id", "Name", activityDto.planId);

            return View(activityDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ActivityDTO activityDto)
        {
            if (ModelState.IsValid)
            {
                await _activityService.Update(activityDto);
                return RedirectToAction(nameof(Index));
            }
            return View(activityDto);
        }

        //só podem acessar os usuários autenticados e que façam parte desta role
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var activityDto = await _activityService.GetById(id);

            if (activityDto == null) return NotFound();

            return View(activityDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _activityService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var activityDto = await _activityService.GetById(id);

            if (activityDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + activityDto.Image);//caminho completo da imagem
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(activityDto);
        }
    }
}
