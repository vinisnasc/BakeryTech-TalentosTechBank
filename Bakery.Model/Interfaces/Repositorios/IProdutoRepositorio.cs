using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model.Interfaces.Repositorios
{
    public interface IProdutoRepositorio
    {
        Produto SelecionarPorId(int id);
        bool Incluir(Produto produto);
        List<Produto> SelecionarTudo();
        bool Alterar(Produto produto);
        Produto VisualizarReceita(int id);
        Produto ProcurarPorNome(string nome);
    }
}
