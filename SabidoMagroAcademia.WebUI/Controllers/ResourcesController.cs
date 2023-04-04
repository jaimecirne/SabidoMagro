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
    public class ResourcesController : Controller
    {
        private readonly IResourceService _resourceService;
        private readonly IPlanService _planService;
        private readonly IWebHostEnvironment _environment;

        public ResourcesController(IResourceService resourceAppService, IPlanService planAppService, IWebHostEnvironment environment)
        {
            _resourceService = resourceAppService;
            _planService = planAppService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var resources = await _resourceService.GetResources();
            return View(resources);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.planId =
            new SelectList(await _planService.GetCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ResourceDTO resourceDto)
        {
            if (ModelState.IsValid)
            {
                await _resourceService.Add(resourceDto);
                return RedirectToAction(nameof(Index));
            }
            return View(resourceDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var resourceDto = await _resourceService.GetById(id);

            if (resourceDto == null) return NotFound();

            var categories = await _planService.GetCategories();
            ViewBag.planId = new SelectList(categories, "Id", "Name", resourceDto.planId);

            return View(resourceDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ResourceDTO resourceDto)
        {
            if (ModelState.IsValid)
            {
                await _resourceService.Update(resourceDto);
                return RedirectToAction(nameof(Index));
            }
            return View(resourceDto);
        }

        //só podem acessar os usuários autenticados e que façam parte desta role
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var resourceDto = await _resourceService.GetById(id);

            if (resourceDto == null) return NotFound();

            return View(resourceDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _resourceService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var resourceDto = await _resourceService.GetById(id);

            if (resourceDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + resourceDto.Image);//caminho completo da imagem
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(resourceDto);
        }
    }
}
