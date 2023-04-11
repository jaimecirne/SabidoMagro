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
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IAvaliationService _avaliationService;
        private readonly IDayOfTrainService _dayOfTrainService;
        private readonly IClientWorkoutService _clientWorkoutService;
        private readonly IWebHostEnvironment _environment;

        public ClientsController(IClientService clientService, IAvaliationService avaliationService, IDayOfTrainService dayOfTrainService, IClientWorkoutService clientWorkoutService, IWebHostEnvironment environment)
        {
            _clientService = clientService;
            _avaliationService = avaliationService;
            _dayOfTrainService = dayOfTrainService;
            _clientWorkoutService = clientWorkoutService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetClients();
            return View(clients);
        }

        public IActionResult Create()
        {
          

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientDTO clientDto)
        {
            if (ModelState.IsValid)
            {
                await _clientService.Add(clientDto);
                return RedirectToAction(nameof(Index));
            }
            return View(clientDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var clientDto = await _clientService.GetById(id);

            if (clientDto == null) return NotFound();

            

            return View(clientDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientDTO clientDto)
        {
            if (ModelState.IsValid)
            {
                await _clientService.Update(clientDto);
                return RedirectToAction(nameof(Index));
            }
            return View(clientDto);
        }

        //só podem acessar os usuários autenticados e que façam parte desta role
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var productDto = await _clientService.GetById(id);

            if (productDto == null) return NotFound();

            return View(productDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clientService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var clientDto = await _clientService.GetById(id);

            if (clientDto == null) return NotFound();
       
            return View(clientDto);
        }
    }
}
