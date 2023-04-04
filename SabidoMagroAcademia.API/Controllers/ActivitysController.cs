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
    public class ActivitysController : ControllerBase
    {
        private readonly IActivityService _activityService;
        public ActivitysController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityDTO>>> Get()
        {
            var activitys = await _activityService.GetActivities();
            if (activitys == null)
            {
                return NotFound("Activitys not found");
            }
            return Ok(activitys);
        }

        [HttpGet("{id}", Name = "GetActivity")]
        public async Task<ActionResult<ActivityDTO>> Get(int id)
        {
            var activity = await _activityService.GetById(id);
            if (activity == null)
            {
                return NotFound("Activity not found");
            }
            return Ok(activity);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ActivityDTO activityDto)
        {
            if (activityDto == null)
                return BadRequest("Data Invalid");

            await _activityService.Add(activityDto);

            return new CreatedAtRouteResult("Getactivity",
                new { id = activityDto.Id }, activityDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ActivityDTO activityDto)
        {
            if (id != activityDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (activityDto == null)
                return BadRequest("Data invalid");

            await _activityService.Update(activityDto);

            return Ok(activityDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivityDTO>> Delete(int id)
        {
            var activityDto = await _activityService.GetById(id);

            if (activityDto == null)
            {
                return NotFound("Activity not found");
            }

            await _activityService.Remove(id);

            return Ok(activityDto);
        }
    }
}
