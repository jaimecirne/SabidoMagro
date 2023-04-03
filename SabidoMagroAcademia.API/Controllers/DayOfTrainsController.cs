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
    public class DayOfTrainsController : ControllerBase
    {
        private readonly IDayOfTrainService _dayoftrainService;
        public DayOfTrainsController(IDayOfTrainService dayoftrainService)
        {
            _dayoftrainService = dayoftrainService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayOfTrainDTO>>> Get()
        {
            var dayoftrains = await _dayoftrainService.GetDayOfTrains();
            if (dayoftrains == null)
            {
                return NotFound("DayOfTrains not found");
            }
            return Ok(dayoftrains);
        }

        [HttpGet("{id}", Name = "GetDayOfTrain")]
        public async Task<ActionResult<DayOfTrainDTO>> Get(int id)
        {
            var dayoftrain = await _dayoftrainService.GetById(id);
            if (dayoftrain == null)
            {
                return NotFound("DayOfTrain not found");
            }
            return Ok(dayoftrain);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DayOfTrainDTO dayoftrainDto)
        {
            if (dayoftrainDto == null)
                return BadRequest("Data Invalid");

            await _dayoftrainService.Add(dayoftrainDto);

            return new CreatedAtRouteResult("Getdayoftrain",
                new { id = dayoftrainDto.Id }, dayoftrainDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DayOfTrainDTO dayoftrainDto)
        {
            if (id != dayoftrainDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (dayoftrainDto == null)
                return BadRequest("Data invalid");

            await _dayoftrainService.Update(dayoftrainDto);

            return Ok(dayoftrainDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DayOfTrainDTO>> Delete(int id)
        {
            var dayoftrainDto = await _dayoftrainService.GetById(id);

            if (dayoftrainDto == null)
            {
                return NotFound("DayOfTrain not found");
            }

            await _dayoftrainService.Remove(id);

            return Ok(dayoftrainDto);
        }
    }
}
