using Bakery.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model
{
    public class ItemVenda : IEntity
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }
        public Venda Venda { get; set; }
        public int IdVenda { get; set; }
        public double Quantidade { get; set; }
    }
}
