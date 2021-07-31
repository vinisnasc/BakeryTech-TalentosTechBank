using Bakery.Dados.Repositorio;
using Bakery.Model;
using Bakery.Model.DTO;
using Bakery.Model.Enums;
using Bakery.Model.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Bakery.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IBibliotecaRepositorio _bibliotecaRepositorio;

        public ProdutoService(IBibliotecaRepositorio bibliotecaRepositorio)
        {
            _bibliotecaRepositorio = bibliotecaRepositorio;
        }

        public bool CadastrarProduto(ProdutoDTO dto)
        {
            Produto produtoValidacao = _bibliotecaRepositorio.ProdutoRepositorio.ProcurarPorNome(dto.Nome);

            if (produtoValidacao == null)
            {
                Produto produto = new();
                produto.Nome = dto.Nome;
                produto.TipoDeMedida = dto.TipoDeMedida;
                produto.TipoDeProduto = dto.TipoDeProduto;
                produto.ValorVenda = dto.ValorVenda;
                produto.Status = false;
                _bibliotecaRepositorio.ProdutoRepositorio.Incluir(produto);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AlterarDadosProduto(int id, ProdutoDTO dto)
        {
            Produto produto = _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(id);

            produto.Nome = string.IsNullOrEmpty(dto.Nome.Trim()) ? produto.Nome : dto.Nome;
            produto.TipoDeMedida = dto.TipoDeMedida;
            produto.TipoDeProduto = dto.TipoDeProduto;
            produto.ValorVenda = dto.ValorVenda <= 0 ? produto.ValorVenda : dto.ValorVenda;
            _bibliotecaRepositorio.ProdutoRepositorio.Alterar(produto);
            return true;
        }

        public List<Produto> SelecionarTudo()
        {
            return _bibliotecaRepositorio.ProdutoRepositorio.SelecionarTudo();
        }

        public Produto SelecionarPorId(int id)
        {
            return _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(id);
        }

        public bool AlterarValorVenda(int id, ProdutoDTO dto)
        {
            Produto produto = _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(id);
            produto.ValorVenda = dto.ValorVenda <= 0 ? produto.ValorVenda : dto.ValorVenda;
            _bibliotecaRepositorio.ProdutoRepositorio.Alterar(produto);
            return true;
        }

        public Produto VisualizarReceita(int id)
        {
            return _bibliotecaRepositorio.ProdutoRepositorio.VisualizarReceita(id);
        }

        public void AlterarStatus(int id)
        {
            Produto produto = _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(id);

            produto.Status = !produto.Status;

            _bibliotecaRepositorio.ProdutoRepositorio.Alterar(produto);
        }

        public bool VincularReceita(int id, List<MaterialReceitaDTO> dto)
        {
            Produto produto = _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(id);

            if (produto.TipoDeProduto != (TipoDeProduto)3)
            {
                return false;
            }
            else
            {
                List<MaterialReceita> materiais = new();

                foreach (var x in dto)
                {
                    var material = new MaterialReceita()
                    {
                        IdProduto = x.IdProduto,
                        Quantidade = x.Quantidade
                    };
                    _bibliotecaRepositorio.MaterialReceitaRepositorio.Incluir(material);
                    produto.MaterialReceitas.Add(material);
                }

                _bibliotecaRepositorio.ProdutoRepositorio.Alterar(produto);
                return true;
            }
        }
    }
}
