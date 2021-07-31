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
    public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio
    {
        private readonly Contexto _contexto;
        public ProdutoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public override bool Incluir(Produto produto)
        {
            return base.Incluir(produto);
        }

        public override bool Alterar(Produto produto)
        {
            return base.Alterar(produto);
        }

        public override Produto SelecionarPorId(int id)
        {
            return _contexto.Produto.Include(e => e.MaterialReceitas).FirstOrDefault(p => p.Id == id);
        }

        public override List<Produto> SelecionarTudo()
        {
            return base.SelecionarTudo();
        }

        public Produto VisualizarReceita(int id)
        {
            return _contexto.Produto.Include(e => e.MaterialReceitas).FirstOrDefault(x => x.Id == id);
        }

        public Produto ProcurarPorNome(string nome)
        {
            return contexto.Produto.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
