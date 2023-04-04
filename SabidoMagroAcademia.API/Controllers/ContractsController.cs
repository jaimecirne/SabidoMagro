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
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;
        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractDTO>>> Get()
        {
            var contracts = await _contractService.GetContracts();
            if (contracts == null)
            {
                return NotFound("Contracts not found");
            }
            return Ok(contracts);
        }

        [HttpGet("{id}", Name = "GetContract")]
        public async Task<ActionResult<ContractDTO>> Get(int id)
        {
            var contract = await _contractService.GetById(id);
            if (contract == null)
            {
                return NotFound("Contract not found");
            }
            return Ok(contract);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContractDTO contractDto)
        {
            if (contractDto == null)
                return BadRequest("Data Invalid");

            await _contractService.Add(contractDto);

            return new CreatedAtRouteResult("Getcontract",
                new { id = contractDto.Id }, contractDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ContractDTO contractDto)
        {
            if (id != contractDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (contractDto == null)
                return BadRequest("Data invalid");

            await _contractService.Update(contractDto);

            return Ok(contractDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ContractDTO>> Delete(int id)
        {
            var contractDto = await _contractService.GetById(id);

            if (contractDto == null)
            {
                return NotFound("Contract not found");
            }

            await _contractService.Remove(id);

            return Ok(contractDto);
        }
    }
}
