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
    public class PlansController : ControllerBase
    {
        private readonly IPlanService _planService;
        public PlansController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanDTO>>> Get()
        {
            var plans = await _planService.GetPlans();
            if (plans == null)
            {
                return NotFound("Plans not found");
            }
            return Ok(plans);
        }

        [HttpGet("{id}", Name = "GetPlan")]
        public async Task<ActionResult<PlanDTO>> Get(int id)
        {
            var plan = await _planService.GetById(id);
            if (plan == null)
            {
                return NotFound("Plan not found");
            }
            return Ok(plan);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PlanDTO planDto)
        {
            if (planDto == null)
                return BadRequest("Data Invalid");

            await _planService.Add(planDto);

            return new CreatedAtRouteResult("Getplan",
                new { id = planDto.Id }, planDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PlanDTO planDto)
        {
            if (id != planDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (planDto == null)
                return BadRequest("Data invalid");

            await _planService.Update(planDto);

            return Ok(planDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlanDTO>> Delete(int id)
        {
            var planDto = await _planService.GetById(id);

            if (planDto == null)
            {
                return NotFound("Plan not found");
            }

            await _planService.Remove(id);

            return Ok(planDto);
        }
    }
}
