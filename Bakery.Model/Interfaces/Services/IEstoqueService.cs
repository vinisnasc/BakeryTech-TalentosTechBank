using Bakery.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model.Interfaces.Services
{
    public interface IEstoqueService
    {
        bool CadastrarProdutoNoEstoque(EstoqueDTO dto);
        bool AlterarLocal(int idEstoque, EstoqueDTO dto);
        bool AlterarQuantidadeMinima(int idEstoque, EstoqueDTO dto);
        void FabricarProduto(int idProduto, int quantidade);
        List<Estoque> SelecionarTudo();
        Estoque SelecionarPorId(int id);
    }
}
