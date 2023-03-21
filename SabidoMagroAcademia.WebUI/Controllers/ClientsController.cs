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
        private readonly IPlanService _planService;
        private readonly IWebHostEnvironment _environment;

        public ClientsController(IClientService productAppService, IPlanService planAppService, IWebHostEnvironment environment)
        {
            _clientService = productAppService;
            _planService = planAppService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _clientService.GetClients();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.planId =
            new SelectList(await _planService.GetCategories(), "Id", "Name");

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

            var categories = await _planService.GetCategories();
            ViewBag.planId = new SelectList(categories, "Id", "Name", clientDto.planId);

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
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + clientDto.Image);//caminho completo da imagem
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(clientDto);
        }
    }
}
