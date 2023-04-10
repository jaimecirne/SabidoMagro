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
        private readonly IManagerService _managerService;
        private readonly IClientService _clientService;
        private readonly IWorkoutService _workoutService;
        private readonly IWebHostEnvironment _environment;

        public ClientWorkoutsController(IClientWorkoutService clientworkoutworkoutAppService, IClientService clientService, IManagerService managerService, IWorkoutService workoutService, IWebHostEnvironment environment)
        {
            _clientworkoutService = clientworkoutworkoutAppService;
            _clientService = clientService;
            _managerService = managerService;
            _workoutService = workoutService;
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
            ViewBag.manager =
            new SelectList(await _managerService.GetManagers(), "Id", "Name");

            ViewBag.client =
            new SelectList(await _clientService.GetClients(), "Id", "Name");

            ViewBag.WorkoutDefaults =
            new SelectList(await _clientService.GetClients(), "Id", "Name");


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

            var clients = await _clientService.GetClients();
            ViewBag.planId = new SelectList(clients, "Id", "Name", clientworkoutDto.Client);

            var managers = await _managerService.GetManagers();
            ViewBag.planId = new SelectList(managers, "Id", "Name", clientworkoutDto.Coach);

            var workout = await _workoutService.GetWorkouts();
            ViewBag.planId = new SelectList(workout, "Id", "Label", clientworkoutDto.WorkoutDefaults);


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
//            var wwwroot = _environment.WebRootPath;
//            var image = Path.Combine(wwwroot, "images\\" + clientworkoutDto.Image);//caminho completo da imagem
//            var exists = System.IO.File.Exists(image);
//            ViewBag.ImageExist = exists;

            return View(clientworkoutDto);
        }
    }
}
