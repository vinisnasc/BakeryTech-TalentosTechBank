using Bakery.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model
{
    public class Estoque : IEntity
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public double Quantidade { get; set; }
        public double QuantidadeMin { get; set; }
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }
    }
}
