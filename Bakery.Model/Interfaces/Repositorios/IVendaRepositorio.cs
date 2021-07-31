using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model.Interfaces.Repositorios
{
    public interface IVendaRepositorio
    {
        bool Incluir(Venda venda);
        bool Alterar(Venda venda);
        Venda SelecionarPorId(int id);
        List<Venda> SelecionarTudo();
    }
}
