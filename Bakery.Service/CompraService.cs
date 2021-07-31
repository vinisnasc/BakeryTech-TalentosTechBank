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
    public class CompraService : ICompraService
    {
        private readonly IBibliotecaRepositorio _bibliotecaRepositorio;

        public CompraService(IBibliotecaRepositorio bibliotecaRepositorio)
        {
            _bibliotecaRepositorio = bibliotecaRepositorio;
        }
        public List<Compra> SelecionarTudo()
        {
            return _bibliotecaRepositorio.CompraRepositorio.SelecionarTudo();
        }

        public Compra SelecionarPorId(int id)
        {
            return _bibliotecaRepositorio.CompraRepositorio.SelecionarPorId(id);
        }

        public bool RealizarCompra(List<ItemCompraDTO> dto)
        {
            // Inclusão do objeto compra no repositorio e atribuição dos 'itemcompra' a ele
            Compra compra = new();
            _bibliotecaRepositorio.CompraRepositorio.Incluir(compra);

            List<ItemCompra> itemCompra = new();

            foreach (var x in dto)
            {
                itemCompra.Add(new ItemCompra
                {
                    IdProduto = x.IdProduto,
                    Quantidade = x.Quantidade,
                    IdCompra = compra.Id
                });
            }
            compra.ItemCompras = itemCompra;
            _bibliotecaRepositorio.CompraRepositorio.Alterar(compra);

            // Realização da compra:

            // Calculo de valor total da venda
            var compraCompleta = _bibliotecaRepositorio.CompraRepositorio.SelecionarPorId(compra.Id);

            foreach (var iV in compraCompleta.ItemCompras)
            {
                compraCompleta.ValorTotal += iV.Quantidade * iV.Produto.ValorVenda; 
            }
            _bibliotecaRepositorio.CompraRepositorio.Alterar(compraCompleta);

            // Verificação valor em caixa, se o valor da compra for maior que o valor em caixa, a compra nao vai ser realizada
            Financeiro financeiro = _bibliotecaRepositorio.FinanceiroRepositorio.SelecionarPorId(1);

            if (financeiro.SaldoEmCaixa < compraCompleta.ValorTotal)
            {
                compraCompleta.Realizada = false;
                _bibliotecaRepositorio.CompraRepositorio.Alterar(compraCompleta);
                return false;
            }

            // A compra sendo realizada, sera abatido o valor no financeiro e adicionado os produtos ao estoque
            else
            {
                financeiro.SaldoEmCaixa -= compraCompleta.ValorTotal;
                _bibliotecaRepositorio.FinanceiroRepositorio.Alterar(financeiro);

                foreach(var produto in compraCompleta.ItemCompras)
                {
                    Produto p1 = produto.Produto;
                    Estoque estoqueProduto = _bibliotecaRepositorio.EstoqueRepositorio.PesquisarPorProduto(p1.Id);
                    estoqueProduto.Quantidade += produto.Quantidade;
                    _bibliotecaRepositorio.EstoqueRepositorio.Alterar(estoqueProduto);
                }

                compraCompleta.Realizada = true;
                _bibliotecaRepositorio.CompraRepositorio.Alterar(compraCompleta);
                return true;
            }
        }
    }
}
