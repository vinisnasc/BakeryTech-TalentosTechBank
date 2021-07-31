using Bakery.Model.DTO;
using System.Collections.Generic;

namespace Bakery.Model.Interfaces.Services
{
    public interface IVendaService
    {
        bool RealizarVenda(List<ItemVendaDTO> dto);
        List<Venda> SelecionarTudo();
        Venda SelecionarPorId(int id);
    }
}
