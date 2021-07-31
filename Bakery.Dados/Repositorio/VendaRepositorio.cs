using Bakery.Model;
using Bakery.Model.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Dados.Repositorio
{
    public class VendaRepositorio : BaseRepositorio<Venda>, IVendaRepositorio
    {
        public VendaRepositorio(Contexto contexto) : base(contexto)
        {

        }

        public override bool Incluir(Venda venda)
        {
            return base.Incluir(venda);
        }

        public override bool Alterar(Venda venda)
        {
            return base.Alterar(venda);
        }

        public override List<Venda> SelecionarTudo()
        {
            return base.SelecionarTudo();
        }

        public override Venda SelecionarPorId(int id)
        {
            return contexto.Venda.Include(v => v.ItemVendas).ThenInclude(c => c.Produto).FirstOrDefault(c => c.Id == id);
        }
    }
}
