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
    public class AvaliationsController : ControllerBase
    {
        private readonly IAvaliationService _avaliationService;
        public AvaliationsController(IAvaliationService avaliationService)
        {
            _avaliationService = avaliationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvaliationDTO>>> Get()
        {
            var avaliations = await _avaliationService.GetAvaliations();
            if (avaliations == null)
            {
                return NotFound("Avaliations not found");
            }
            return Ok(avaliations);
        }

        [HttpGet("{id}", Name = "GetAvaliation")]
        public async Task<ActionResult<AvaliationDTO>> Get(int id)
        {
            var avaliation = await _avaliationService.GetById(id);
            if (avaliation == null)
            {
                return NotFound("Avaliation not found");
            }
            return Ok(avaliation);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AvaliationDTO avaliationDto)
        {
            if (avaliationDto == null)
                return BadRequest("Data Invalid");

            await _avaliationService.Add(avaliationDto);

            return new CreatedAtRouteResult("Getavaliation",
                new { id = avaliationDto.Id }, avaliationDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AvaliationDTO avaliationDto)
        {
            if (id != avaliationDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (avaliationDto == null)
                return BadRequest("Data invalid");

            await _avaliationService.Update(avaliationDto);

            return Ok(avaliationDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AvaliationDTO>> Delete(int id)
        {
            var avaliationDto = await _avaliationService.GetById(id);

            if (avaliationDto == null)
            {
                return NotFound("Avaliation not found");
            }

            await _avaliationService.Remove(id);

            return Ok(avaliationDto);
        }
    }
}
