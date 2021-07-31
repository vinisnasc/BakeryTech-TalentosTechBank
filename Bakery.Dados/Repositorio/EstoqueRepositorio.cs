using Bakery.Model;
using Bakery.Model.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Dados.Repositorio
{
    public class EstoqueRepositorio : BaseRepositorio<Estoque>, IEstoqueRepositorio
    {
        public EstoqueRepositorio(Contexto contexto) : base(contexto)
        {

        }
        public override bool Incluir(Estoque estoque)
        {
            return base.Incluir(estoque);
        }

        public override bool Alterar(Estoque estoque)
        {
            return base.Alterar(estoque);
        }

        public Estoque PesquisarPorProduto(int idProduto)
        {
            return contexto.Estoque.FirstOrDefault(x => x.IdProduto == idProduto);
        }

        public override List<Estoque> SelecionarTudo()
        {
            return base.SelecionarTudo();
        }

        public override Estoque SelecionarPorId(int id)
        {
            return base.SelecionarPorId(id);
        }
    }
}
