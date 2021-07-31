using Bakery.Dados.Repositorio;
using Bakery.Model;
using Bakery.Model.DTO;
using Bakery.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Service
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IBibliotecaRepositorio _bibliotecaRepositorio;

        public EstoqueService(IBibliotecaRepositorio bibliotecaRepositorio)
        {
            _bibliotecaRepositorio = bibliotecaRepositorio;
        }

        public bool CadastrarProdutoNoEstoque(EstoqueDTO dto)
        {
            Produto produtoValidador = _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(dto.IdProduto);
            Estoque estoqueValidador = _bibliotecaRepositorio.EstoqueRepositorio.PesquisarPorProduto(produtoValidador.Id);

            if (estoqueValidador == null)
            {
                Estoque produto = new();
                produto.IdProduto = dto.IdProduto;
                produto.Local = dto.Local;
                produto.QuantidadeMin = dto.QuantidadeMin;
                produto.Quantidade = 0;
                _bibliotecaRepositorio.EstoqueRepositorio.Incluir(produto);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AlterarLocal(int idEstoque, EstoqueDTO dto)
        {
            Estoque estoque = _bibliotecaRepositorio.EstoqueRepositorio.SelecionarPorId(idEstoque);

            if (string.IsNullOrEmpty(dto.Local.Trim()))
            {
                return false;
            }
            else
            {
                estoque.Local = dto.Local;
                return _bibliotecaRepositorio.EstoqueRepositorio.Alterar(estoque);
            }
        }

        public bool AlterarQuantidadeMinima(int idEstoque, EstoqueDTO dto)
        {
            Estoque estoque = _bibliotecaRepositorio.EstoqueRepositorio.SelecionarPorId(idEstoque);

            if (dto.QuantidadeMin <= 0)
            {
                return false;
            }
            else
            {
                estoque.QuantidadeMin = dto.QuantidadeMin;
                return _bibliotecaRepositorio.EstoqueRepositorio.Alterar(estoque);
            }
        }

        public void FabricarProduto(int idProduto, int quantidade)
        {
            Produto produto = _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(idProduto);

            Estoque produtofabricado = _bibliotecaRepositorio.EstoqueRepositorio.PesquisarPorProduto(idProduto);
            produtofabricado.Quantidade += quantidade;
            _bibliotecaRepositorio.EstoqueRepositorio.Alterar(produtofabricado);


            foreach (MaterialReceita material in produto.MaterialReceitas)
            {
                Produto materiaPrima = _bibliotecaRepositorio.ProdutoRepositorio.SelecionarPorId(material.IdProduto);
                Estoque materiaPrimaEstoque = _bibliotecaRepositorio.EstoqueRepositorio.PesquisarPorProduto(materiaPrima.Id);
                double qtd = material.Quantidade * quantidade;
                materiaPrimaEstoque.Quantidade -= qtd;
                _bibliotecaRepositorio.EstoqueRepositorio.Alterar(materiaPrimaEstoque);
            }

        }

        public List<Estoque> SelecionarTudo()
        {
            return _bibliotecaRepositorio.EstoqueRepositorio.SelecionarTudo();
        }

        public Estoque SelecionarPorId(int id)
        {
            return _bibliotecaRepositorio.EstoqueRepositorio.SelecionarPorId(id);
        }
    }
}
