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
    public class VendaService : IVendaService
    {
        private readonly IBibliotecaRepositorio _bibliotecaRepositorio;

        public VendaService(IBibliotecaRepositorio bibliotecaRepositorio)
        {
            _bibliotecaRepositorio = bibliotecaRepositorio;
        }

        public List<Venda> SelecionarTudo()
        {
            return _bibliotecaRepositorio.VendaRepositorio.SelecionarTudo();
        }

        public Venda SelecionarPorId(int id)
        {
            return _bibliotecaRepositorio.VendaRepositorio.SelecionarPorId(id);
        }

        public bool RealizarVenda(List<ItemVendaDTO> dto)
        {
            // Inclusão do objeto venda no repositorio e atribuição dos 'itemvenda' a ele
            Venda venda = new();
            _bibliotecaRepositorio.VendaRepositorio.Incluir(venda);

            List<ItemVenda> itemVenda = new();

            foreach (var x in dto)
            {
                itemVenda.Add(new ItemVenda
                {
                    IdProduto = x.IdProduto,
                    Quantidade = x.Quantidade,
                    IdVenda = venda.Id
                });
            }
            venda.ItemVendas = itemVenda;
            _bibliotecaRepositorio.VendaRepositorio.Alterar(venda);

            // Realização da venda:

            // Calculo de valor total da venda

            var vendaCompleta = _bibliotecaRepositorio.VendaRepositorio.SelecionarPorId(venda.Id);

            foreach (var iV in vendaCompleta.ItemVendas)
            {
                vendaCompleta.ValorTotal += iV.Quantidade * iV.Produto.ValorVenda;
            }
            _bibliotecaRepositorio.VendaRepositorio.Alterar(vendaCompleta);

            // Validação da realização da venda:
            if(VerificarEstoque(itemVenda) == 0)
            {
                Financeiro financeiro = _bibliotecaRepositorio.FinanceiroRepositorio.SelecionarPorId(1);
                financeiro.SaldoEmCaixa += vendaCompleta.ValorTotal;
                _bibliotecaRepositorio.FinanceiroRepositorio.Alterar(financeiro);

                foreach(ItemVenda iV in vendaCompleta.ItemVendas)
                {
                    Estoque estoqueVenda = _bibliotecaRepositorio.EstoqueRepositorio.PesquisarPorProduto(iV.IdProduto);
                    estoqueVenda.Quantidade -= iV.Quantidade;
                    _bibliotecaRepositorio.EstoqueRepositorio.Alterar(estoqueVenda);
                }

                vendaCompleta.Realizada = true;
                _bibliotecaRepositorio.VendaRepositorio.Alterar(vendaCompleta);
                return true;
            }
            else
            {
                vendaCompleta.Realizada = false;
                _bibliotecaRepositorio.VendaRepositorio.Alterar(vendaCompleta);
                return false;
            }
        }

        private int VerificarEstoque(List<ItemVenda> itemVenda)
        {
            int count = 0;
            foreach (ItemVenda x in itemVenda)
            {
                Estoque estoqueVenda = _bibliotecaRepositorio.EstoqueRepositorio.PesquisarPorProduto(x.IdProduto);
                if (estoqueVenda.Quantidade <= x.Quantidade)
                {
                    count += 1;
                }
                else
                    count += 0;
            }
            return count;
        }
    }
}
