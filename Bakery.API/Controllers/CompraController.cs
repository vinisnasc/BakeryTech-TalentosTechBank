using Bakery.Model;
using Bakery.Model.DTO;
using Bakery.Model.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bakery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;

        public CompraController(ICompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpGet]
        public IEnumerable<Compra> Get()
        {
            return _compraService.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Compra Get(int id)
        {
            return _compraService.SelecionarPorId(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<ItemCompraDTO> dto)
        {
            var result =_compraService.RealizarCompra(dto);
            if (result == true)
            {
                return Ok("Compra realizada!");
            }
            else
            {
                return BadRequest("Saldo insuficiente!");
            }
        }
    }
}
