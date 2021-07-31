using Bakery.Model;
using Bakery.Model.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Dados.Repositorio
{
    public class MaterialReceitaRepositorio : BaseRepositorio<MaterialReceita>, IMaterialReceitaRepositorio
    {
        public MaterialReceitaRepositorio(Contexto contexto) : base(contexto)
        {

        }

        public override bool Incluir(MaterialReceita materialReceita)
        {
            return base.Incluir(materialReceita);
        }
    }
}
