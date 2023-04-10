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
    public class AvaliationsController : Controller
    {
        private readonly IAvaliationService _avaliationService;
        private readonly IClientService _clientService;
        private readonly IManagerService _managerService;
        private readonly IWebHostEnvironment _environment;

        public AvaliationsController(IAvaliationService avaliationAppService, IClientService clientService, IManagerService managerService, IWebHostEnvironment environment)
        {
            _avaliationService = avaliationAppService;
            _clientService = clientService;
            _managerService = managerService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var avaliations = await _avaliationService.GetAvaliations();
            return View(avaliations);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.clients =
            new SelectList(await _clientService.GetClients(), "Id", "Name");

            ViewBag.coach =
            new SelectList(await _managerService.GetManagers(), "Id", "Name");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AvaliationDTO avaliationDto)
        {
            if (ModelState.IsValid)
            {
                await _avaliationService.Add(avaliationDto);
                return RedirectToAction(nameof(Index));
            }
            return View(avaliationDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var avaliationDto = await _avaliationService.GetById(id);

            if (avaliationDto == null) return NotFound();

            var clients = await _clientService.GetClients();

            var managers = await _managerService.GetManagers();

            ViewBag.clients = new SelectList(clients, "Id", "Name", avaliationDto.Client);

            ViewBag.managers = new SelectList(managers, "Id", "Name", avaliationDto.Coach);

            return View(avaliationDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AvaliationDTO avaliationDto)
        {
            if (ModelState.IsValid)
            {
                await _avaliationService.Update(avaliationDto);
                return RedirectToAction(nameof(Index));
            }
            return View(avaliationDto);
        }

        //só podem acessar os usuários autenticados e que façam parte desta role
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var avaliationDto = await _avaliationService.GetById(id);

            if (avaliationDto == null) return NotFound();

            return View(avaliationDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _avaliationService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var avaliationDto = await _avaliationService.GetById(id);

            if (avaliationDto == null) return NotFound();
//            var wwwroot = _environment.WebRootPath;
//            var image = Path.Combine(wwwroot, "images\\" + avaliationDto.Image);//caminho completo da imagem
//            var exists = System.IO.File.Exists(image);
//            ViewBag.ImageExist = exists;

            return View(avaliationDto);
        }
    }
}
