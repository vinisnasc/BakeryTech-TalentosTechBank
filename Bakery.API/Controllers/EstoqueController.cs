using Bakery.Model;
using Bakery.Model.DTO;
using Bakery.Model.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bakery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet]
        public List<Estoque> Get()
        {
            return _estoqueService.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Estoque Get(int id)
        {
            return _estoqueService.SelecionarPorId(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] EstoqueDTO dto)
        {
            var result = _estoqueService.CadastrarProdutoNoEstoque(dto);
            if (result == true)
            {
                return Ok("Produto cadastrado");
            }
            else
            {
                return BadRequest("Produto já cadastrado");
            }
        }

        [HttpPut("{id}/AlterarLocal")]
        public IActionResult AlterarLocalProduto(int id, [FromQuery] EstoqueDTO dto)
        {
            _estoqueService.AlterarLocal(id, dto);
            return Ok("Localidade do produto alterada");
        }

        [HttpPut("{id}/AlterarQuantidadeMinima")]
        public IActionResult AlterarQuantidadeMinima(int id, [FromQuery] EstoqueDTO dto)
        {
            _estoqueService.AlterarQuantidadeMinima(id, dto);
            return Ok("Quantidade Minima em estoque alterada!");
        }

        [HttpPut("{id}/Fabricar")]
        public IActionResult FabricarProduto(int id, [FromQuery] int quantidade)
        {
            _estoqueService.FabricarProduto(id, quantidade);
            return Ok("Produto fabricado");
        }
    }
}
