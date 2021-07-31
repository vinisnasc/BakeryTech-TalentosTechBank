using Bakery.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model
{
    public class Financeiro : IEntity
    {
        public int Id { get; set; }
        public double SaldoEmCaixa { get; set; }
    }
}
