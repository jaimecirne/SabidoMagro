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
    public class ClientWorkoutWorkoutsController : ControllerBase
    {
        private readonly IClientWorkoutService _clientworkoutworkoutService;
        public ClientWorkoutWorkoutsController(IClientWorkoutService clientworkoutworkoutService)
        {
            _clientworkoutworkoutService = clientworkoutworkoutService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientWorkoutDTO>>> Get()
        {
            var clientworkoutworkouts = await _clientworkoutworkoutService.GetClientWorkouts();
            if (clientworkoutworkouts == null)
            {
                return NotFound("ClientWorkoutWorkouts not found");
            }
            return Ok(clientworkoutworkouts);
        }

        [HttpGet("{id}", Name = "GetClientWorkout")]
        public async Task<ActionResult<ClientWorkoutDTO>> Get(int id)
        {
            var clientworkoutworkout = await _clientworkoutworkoutService.GetById(id);
            if (clientworkoutworkout == null)
            {
                return NotFound("ClientWorkout not found");
            }
            return Ok(clientworkoutworkout);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientWorkoutDTO clientworkoutDto)
        {
            if (clientworkoutDto == null)
                return BadRequest("Data Invalid");

            await _clientworkoutworkoutService.Add(clientworkoutDto);

            return new CreatedAtRouteResult("Getclientworkout",
                new { id = clientworkoutDto.Id }, clientworkoutDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientWorkoutDTO clientworkoutDto)
        {
            if (id != clientworkoutDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (clientworkoutDto == null)
                return BadRequest("Data invalid");

            await _clientworkoutworkoutService.Update(clientworkoutDto);

            return Ok(clientworkoutDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientWorkoutDTO>> Delete(int id)
        {
            var clientworkoutworkoutDto = await _clientworkoutworkoutService.GetById(id);

            if (clientworkoutworkoutDto == null)
            {
                return NotFound("ClientWorkoutWorkout not found");
            }

            await _clientworkoutworkoutService.Remove(id);

            return Ok(clientworkoutworkoutDto);
        }
    }
}
