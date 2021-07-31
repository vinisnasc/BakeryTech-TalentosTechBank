using Bakery.Model.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model.Interfaces.Services
{
    public interface IBibliotecaRepositorio
    {
        public IProdutoRepositorio ProdutoRepositorio { get; }
        public IEstoqueRepositorio EstoqueRepositorio { get; }
        public IMaterialReceitaRepositorio MaterialReceitaRepositorio { get; }
        public IVendaRepositorio VendaRepositorio { get; }
        public IItemVendaRepositorio ItemVendaRepositorio { get; }
        public IFinanceiroRepositorio FinanceiroRepositorio { get; }
        public ICompraRepositorio CompraRepositorio { get; }
    }
}
