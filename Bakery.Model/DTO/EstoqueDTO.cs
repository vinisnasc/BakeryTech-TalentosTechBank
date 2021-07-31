using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model.DTO
{
    public class EstoqueDTO
    {
        public string Local { get; set; }
        public double QuantidadeMin { get; set; }
        public int IdProduto { get; set; }
    }
}
