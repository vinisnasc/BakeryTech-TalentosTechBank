using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model.Interfaces.Repositorios
{
    public interface IEstoqueRepositorio
    {
        Estoque SelecionarPorId(int id);
        bool Incluir(Estoque estoque);
        bool Alterar(Estoque estoque);
        Estoque PesquisarPorProduto(int idProduto);
        List<Estoque> SelecionarTudo();
    }
}
