using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabidoMagroAcademia.Application.DTOs;
using SabidoMagroAcademia.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ManagersController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerDTO>>> Get()
        {
            var managers = await _managerService.GetManagers();
            if (managers == null)
            {
                return NotFound("Managers not found");
            }
            return Ok(managers);
        }

        [HttpGet("{id}", Name = "GetManager")]
        public async Task<ActionResult<ManagerDTO>> Get(int id)
        {
            var manager = await _managerService.GetById(id);
            if (manager == null)
            {
                return NotFound("Manager not found");
            }
            return Ok(manager);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ManagerDTO managerDto)
        {
            if (managerDto == null)
                return BadRequest("Data Invalid");

            await _managerService.Add(managerDto);

            return new CreatedAtRouteResult("Getmanager",
                new { id = managerDto.Id }, managerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ManagerDTO managerDto)
        {
            if (id != managerDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (managerDto == null)
                return BadRequest("Data invalid");

            await _managerService.Update(managerDto);

            return Ok(managerDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ManagerDTO>> Delete(int id)
        {
            var managerDto = await _managerService.GetById(id);

            if (managerDto == null)
            {
                return NotFound("Manager not found");
            }

            await _managerService.Remove(id);

            return Ok(managerDto);
        }
    }
}
