﻿using Bakery.Model.DTO;
using Bakery.Model.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bakery.Model;

namespace Bakery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _produtoService.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            return _produtoService.SelecionarPorId(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO dto)
        {
            var result = _produtoService.CadastrarProduto(dto);
            if (result == true)
            {
                return Ok("Produto cadastrado!");
            }
            else
            {
                return BadRequest("Ocorreu um erro ao cadastrar!");
            }
        }

        [HttpPut("{id}/AlterarDados")]
        public IActionResult PutAlterarDados(int id, [FromBody] ProdutoDTO dto)
        {
            _produtoService.AlterarDadosProduto(id, dto);
            return Ok("Produto alterado com sucesso!");
        }

        [HttpPut("{id}/VincularReceita")]
        public IActionResult PutVincularReceita(int id, [FromBody] List<MaterialReceitaDTO> dto)
        {
            var result = _produtoService.VincularReceita(id, dto);
            if (result == true)
            {
                return Ok("Receita vinculada!");
            }
            else
            {
                return BadRequest("Um ou mais erros foram encontrados!");
            }
        }

        [HttpPut("{id}/AlterarStatus")]
        public IActionResult PutAlterarStatus(int id)
        {
            _produtoService.AlterarStatus(id);
            return Ok("Status do produto alterado com sucesso!");
        }
    }
}