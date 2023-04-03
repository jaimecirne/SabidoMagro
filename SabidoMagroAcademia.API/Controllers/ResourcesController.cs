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
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        public ResourcesController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceDTO>>> Get()
        {
            var resources = await _resourceService.GetResources();
            if (resources == null)
            {
                return NotFound("Resources not found");
            }
            return Ok(resources);
        }

        [HttpGet("{id}", Name = "GetResource")]
        public async Task<ActionResult<ResourceDTO>> Get(int id)
        {
            var resource = await _resourceService.GetById(id);
            if (resource == null)
            {
                return NotFound("Resource not found");
            }
            return Ok(resource);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ResourceDTO resourceDto)
        {
            if (resourceDto == null)
                return BadRequest("Data Invalid");

            await _resourceService.Add(resourceDto);

            return new CreatedAtRouteResult("Getresource",
                new { id = resourceDto.Id }, resourceDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ResourceDTO resourceDto)
        {
            if (id != resourceDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (resourceDto == null)
                return BadRequest("Data invalid");

            await _resourceService.Update(resourceDto);

            return Ok(resourceDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResourceDTO>> Delete(int id)
        {
            var resourceDto = await _resourceService.GetById(id);

            if (resourceDto == null)
            {
                return NotFound("Resource not found");
            }

            await _resourceService.Remove(id);

            return Ok(resourceDto);
        }
    }
}
