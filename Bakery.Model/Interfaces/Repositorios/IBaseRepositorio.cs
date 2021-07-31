using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model.Interfaces.Repositorios
{
    public interface IBaseRepositorio<T>
    {
        T SelecionarPorId(int id);
        List<T> SelecionarTudo();
    }
}
