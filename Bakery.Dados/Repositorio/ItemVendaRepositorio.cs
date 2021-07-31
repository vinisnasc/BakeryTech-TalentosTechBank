using Bakery.Model;
using Bakery.Model.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Dados.Repositorio
{
    public class ItemVendaRepositorio : BaseRepositorio<ItemVenda>, IItemVendaRepositorio
    {
        public ItemVendaRepositorio(Contexto contexto) : base(contexto)
        {

        }
    }
}
