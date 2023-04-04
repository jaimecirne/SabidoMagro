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
    public class ClientWorkoutsController : Controller
    {
        private readonly IClientWorkoutService _clientworkoutService;
        private readonly IPlanService _planService;
        private readonly IWebHostEnvironment _environment;

        public ClientWorkoutsController(IClientWorkoutService clientworkoutworkoutAppService, IPlanService planAppService, IWebHostEnvironment environment)
        {
            _clientworkoutService = clientworkoutworkoutAppService;
            _planService = planAppService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientworkoutworkouts = await _clientworkoutService.GetClientWorkouts();
            return View(clientworkoutworkouts);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.planId =
            new SelectList(await _planService.GetCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientWorkoutDTO clientworkoutDto)
        {
            if (ModelState.IsValid)
            {
                await _clientworkoutService.Add(clientworkoutDto);
                return RedirectToAction(nameof(Index));
            }
            return View(clientworkoutDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var clientworkoutDto = await _clientworkoutService.GetById(id);

            if (clientworkoutDto == null) return NotFound();

            var categories = await _planService.GetCategories();
            ViewBag.planId = new SelectList(categories, "Id", "Name", clientworkoutDto.planId);

            return View(clientworkoutDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientWorkoutDTO clientworkoutDto)
        {
            if (ModelState.IsValid)
            {
                await _clientworkoutService.Update(clientworkoutDto);
                return RedirectToAction(nameof(Index));
            }
            return View(clientworkoutDto);
        }

        //só podem acessar os usuários autenticados e que façam parte desta role
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var clientworkoutworkoutDto = await _clientworkoutService.GetById(id);

            if (clientworkoutworkoutDto == null) return NotFound();

            return View(clientworkoutworkoutDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clientworkoutService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var clientworkoutDto = await _clientworkoutService.GetById(id);

            if (clientworkoutDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + clientworkoutDto.Image);//caminho completo da imagem
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(clientworkoutDto);
        }
    }
}
