using Bakery.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model.Interfaces.Services
{
    public interface ICompraService
    {
        bool RealizarCompra(List<ItemCompraDTO> dto);
        Compra SelecionarPorId(int id);
        List<Compra> SelecionarTudo();
    }
}
