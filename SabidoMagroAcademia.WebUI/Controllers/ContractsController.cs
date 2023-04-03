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
    public class ContractsController : Controller
    {
        private readonly IContractService _contractService;
        private readonly IPlanService _planService;
        private readonly IWebHostEnvironment _environment;

        public ContractsController(IContractService contractAppService, IPlanService planAppService, IWebHostEnvironment environment)
        {
            _contractService = contractAppService;
            _planService = planAppService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contracts = await _contractService.GetContracts();
            return View(contracts);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.planId =
            new SelectList(await _planService.GetCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContractDTO contractDto)
        {
            if (ModelState.IsValid)
            {
                await _contractService.Add(contractDto);
                return RedirectToAction(nameof(Index));
            }
            return View(contractDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var contractDto = await _contractService.GetById(id);

            if (contractDto == null) return NotFound();

            var categories = await _planService.GetCategories();
            ViewBag.planId = new SelectList(categories, "Id", "Name", contractDto.planId);

            return View(contractDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContractDTO contractDto)
        {
            if (ModelState.IsValid)
            {
                await _contractService.Update(contractDto);
                return RedirectToAction(nameof(Index));
            }
            return View(contractDto);
        }

        //só podem acessar os usuários autenticados e que façam parte desta role
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var contractDto = await _contractService.GetById(id);

            if (contractDto == null) return NotFound();

            return View(contractDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _contractService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var contractDto = await _contractService.GetById(id);

            if (contractDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + contractDto.Image);//caminho completo da imagem
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(contractDto);
        }
    }
}
