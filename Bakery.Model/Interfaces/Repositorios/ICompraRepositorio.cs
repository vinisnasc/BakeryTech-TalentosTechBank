using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model.Interfaces.Repositorios
{
    public interface ICompraRepositorio
    {
        List<Compra> SelecionarTudo();
        Compra SelecionarPorId(int id);
        bool Incluir(Compra compra);
        bool Alterar(Compra compra);
    }
}
