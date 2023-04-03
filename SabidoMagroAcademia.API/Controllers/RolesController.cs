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
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> Get()
        {
            var roles = await _roleService.GetRoles();
            if (roles == null)
            {
                return NotFound("Roles not found");
            }
            return Ok(roles);
        }

        [HttpGet("{id}", Name = "GetRole")]
        public async Task<ActionResult<RoleDTO>> Get(int id)
        {
            var role = await _roleService.GetById(id);
            if (role == null)
            {
                return NotFound("Role not found");
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoleDTO roleDto)
        {
            if (roleDto == null)
                return BadRequest("Data Invalid");

            await _roleService.Add(roleDto);

            return new CreatedAtRouteResult("Getrole",
                new { id = roleDto.Id }, roleDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RoleDTO roleDto)
        {
            if (id != roleDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (roleDto == null)
                return BadRequest("Data invalid");

            await _roleService.Update(roleDto);

            return Ok(roleDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RoleDTO>> Delete(int id)
        {
            var roleDto = await _roleService.GetById(id);

            if (roleDto == null)
            {
                return NotFound("Role not found");
            }

            await _roleService.Remove(id);

            return Ok(roleDto);
        }
    }
}
