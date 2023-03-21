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
    public class ProductsController : ControllerBase
    {
        private readonly IClientService _productService;
        public ProductsController(IClientService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> Get()
        {
            var produtos = await _productService.GetClients();
            if (produtos == null)
            {
                return NotFound("Products not found");
            }
            return Ok(produtos);
        }

        [HttpGet("{id}", Name = "GetClient")]
        public async Task<ActionResult<ClientDTO>> Get(int id)
        {
            var produto = await _productService.GetById(id);
            if (produto == null)
            {
                return NotFound("Client not found");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientDTO clientDto)
        {
            if (clientDto == null)
                return BadRequest("Data Invalid");

            await _productService.Add(clientDto);

            return new CreatedAtRouteResult("Getclient",
                new { id = clientDto.Id }, clientDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientDTO clientDto)
        {
            if (id != clientDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (clientDto == null)
                return BadRequest("Data invalid");

            await _productService.Update(clientDto);

            return Ok(clientDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientDTO>> Delete(int id)
        {
            var produtoDto = await _productService.GetById(id);

            if (produtoDto == null)
            {
                return NotFound("Product not found");
            }

            await _productService.Remove(id);

            return Ok(produtoDto);
        }
    }
}
