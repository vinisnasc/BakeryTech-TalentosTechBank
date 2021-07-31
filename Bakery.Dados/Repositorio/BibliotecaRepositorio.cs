using Bakery.Model.Interfaces.Repositorios;
using Bakery.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Dados.Repositorio
{
    public class BibliotecaRepositorio : IBibliotecaRepositorio
    {
        private readonly Contexto _contexto;
        public IEstoqueRepositorio EstoqueRepositorio { get; }
        public IProdutoRepositorio ProdutoRepositorio { get; }
        public IMaterialReceitaRepositorio MaterialReceitaRepositorio { get; }
        public IVendaRepositorio VendaRepositorio { get; }
        public IItemVendaRepositorio ItemVendaRepositorio { get; }
        public IFinanceiroRepositorio FinanceiroRepositorio { get; }
        public ICompraRepositorio CompraRepositorio { get; }

        public BibliotecaRepositorio(Contexto contexto)
        {
            _contexto = contexto;
            EstoqueRepositorio = new EstoqueRepositorio(contexto);
            ProdutoRepositorio = new ProdutoRepositorio(contexto);
            MaterialReceitaRepositorio = new MaterialReceitaRepositorio(contexto);
            VendaRepositorio = new VendaRepositorio(contexto);
            ItemVendaRepositorio = new ItemVendaRepositorio(contexto);
            FinanceiroRepositorio = new FinanceiroRepositorio(contexto);
            CompraRepositorio = new CompraRepositorio(contexto);
        }
    }
}
