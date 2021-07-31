using Bakery.Model;
using Bakery.Model.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Dados.Repositorio
{
    public class FinanceiroRepositorio : BaseRepositorio<Financeiro>, IFinanceiroRepositorio
    {
        public FinanceiroRepositorio(Contexto contexto) : base(contexto)
        {


        }

        public override bool Alterar(Financeiro financeiro)
        {
            return base.Alterar(financeiro);
        }

        public override Financeiro SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }
    }
}
