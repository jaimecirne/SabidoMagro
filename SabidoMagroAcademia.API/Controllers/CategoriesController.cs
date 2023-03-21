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
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IPlanService _planService;

        public CategoriesController(IPlanService planService)
        {
            this._planService = planService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanDTO>>> Get()
        {
            var categories = await _planService.GetCategories();

            if (categories == null) return NotFound("Categories not found");

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "Getplan")]
        public async Task<ActionResult<IEnumerable<PlanDTO>>> Get(int id)
        {
            var plan = await _planService.GetById(id);

            if (plan == null) return NotFound("plan not found");

            return Ok(plan);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PlanDTO planDto)
        {
            if (planDto == null) return BadRequest("Invalid Data");

            await _planService.Add(planDto);

            //utiliza o método Getplan para retornar, na resposta do post, o obejto criado.
            return new CreatedAtRouteResult("Getplan",
                                             new { id = planDto.Id },
                                             planDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] PlanDTO planDto)
        {
            if (id != planDto.Id) return BadRequest();

            if (planDto == null) return BadRequest();

            await _planService.Update(planDto);
            
            return Ok(planDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PlanDTO>> Delete(int id)
        {
            var plan = await _planService.GetById(id);

            if (plan == null) return NotFound("plan not found");

            await _planService.Remove(id);

            return Ok(plan);
        }

    }
}
