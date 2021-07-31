using Bakery.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model.Interfaces.Services
{
    public interface IProdutoService
    {
        public bool CadastrarProduto(ProdutoDTO dto);
        public Produto SelecionarPorId(int id);
        public List<Produto> SelecionarTudo();
        bool AlterarValorVenda(int id, ProdutoDTO dto);
        void AlterarStatus(int id);
        bool AlterarDadosProduto(int id, ProdutoDTO dto);
        bool VincularReceita(int id, List<MaterialReceitaDTO> dto);
        Produto VisualizarReceita(int id);
    }
}
