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
    public class CompraRepositorio : BaseRepositorio<Compra>, ICompraRepositorio
    {
        public CompraRepositorio(Contexto contexto) : base(contexto)
        {

        }

        public override List<Compra> SelecionarTudo()
        {
            return base.SelecionarTudo();
        }

        public override Compra SelecionarPorId(int id)
        {
            return contexto.Compra.Include(v => v.ItemCompras).ThenInclude(c => c.Produto).FirstOrDefault(c => c.Id == id);
        }

        public override bool Incluir(Compra compra)
        {
            return base.Incluir(compra);
        }

        public override bool Alterar(Compra compra)
        {
            return base.Alterar(compra);
        }
    }
}
