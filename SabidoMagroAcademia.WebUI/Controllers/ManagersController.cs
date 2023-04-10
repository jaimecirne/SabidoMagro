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
    public class ManagersController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly IPlanService _planService;
        private readonly IWebHostEnvironment _environment;

        public ManagersController(IManagerService managerAppService, IPlanService planAppService, IWebHostEnvironment environment)
        {
            _managerService = managerAppService;
            _planService = planAppService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var managers = await _managerService.GetManagers();
            return View(managers);
        }

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ManagerDTO managerDto)
        {
            if (ModelState.IsValid)
            {
                await _managerService.Add(managerDto);
                return RedirectToAction(nameof(Index));
            }
            return View(managerDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var managerDto = await _managerService.GetById(id);

            if (managerDto == null) return NotFound();


            return View(managerDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ManagerDTO managerDto)
        {
            if (ModelState.IsValid)
            {
                await _managerService.Update(managerDto);
                return RedirectToAction(nameof(Index));
            }
            return View(managerDto);
        }

        //só podem acessar os usuários autenticados e que façam parte desta role
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var managerDto = await _managerService.GetById(id);

            if (managerDto == null) return NotFound();

            return View(managerDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _managerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var managerDto = await _managerService.GetById(id);

            if (managerDto == null) return NotFound();
         
            return View(managerDto);
        }
    }
}
