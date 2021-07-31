using Bakery.Model;
using Bakery.Model.DTO;
using Bakery.Model.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bakery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public IEnumerable<Venda> Get()
        {
            return _vendaService.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Venda Get(int id)
        {
            return _vendaService.SelecionarPorId(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<ItemVendaDTO> dto)
        {
            var result = _vendaService.RealizarVenda(dto);
            if (result == true)
                return Ok("Venda Realizada");
            else
                return BadRequest("Um ou mais produtos estão em falta no estoque!");
        }
    }
}