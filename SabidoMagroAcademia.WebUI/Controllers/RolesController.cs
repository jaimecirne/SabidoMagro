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
    public class RolesController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IPlanService _planService;
        private readonly IWebHostEnvironment _environment;

        public RolesController(IRoleService roleAppService, IPlanService planAppService, IWebHostEnvironment environment)
        {
            _roleService = roleAppService;
            _planService = planAppService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleService.GetRoles();
            return View(roles);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.planId =
            new SelectList(await _planService.GetCategories(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleDTO roleDto)
        {
            if (ModelState.IsValid)
            {
                await _roleService.Add(roleDto);
                return RedirectToAction(nameof(Index));
            }
            return View(roleDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var roleDto = await _roleService.GetById(id);

            if (roleDto == null) return NotFound();

            var categories = await _planService.GetCategories();
            ViewBag.planId = new SelectList(categories, "Id", "Name", roleDto.planId);

            return View(roleDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleDTO roleDto)
        {
            if (ModelState.IsValid)
            {
                await _roleService.Update(roleDto);
                return RedirectToAction(nameof(Index));
            }
            return View(roleDto);
        }

        //só podem acessar os usuários autenticados e que façam parte desta role
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var roleDto = await _roleService.GetById(id);

            if (roleDto == null) return NotFound();

            return View(roleDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _roleService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var roleDto = await _roleService.GetById(id);

            if (roleDto == null) return NotFound();
            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + roleDto.Image);//caminho completo da imagem
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(roleDto);
        }
    }
}
