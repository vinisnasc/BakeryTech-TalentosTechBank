using Bakery.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Model.DTO
{
    public class ProdutoDTO
    {
        public string Nome { get; set; }
        public TipoDeMedida TipoDeMedida { get; set; }
        public TipoDeProduto TipoDeProduto { get; set; }
        public double ValorVenda { get; set; }
    }
}
