using Bakery.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Model
{
    public class Compra : IEntity
    {
        public int Id { get; set; }
        public List<ItemCompra> ItemCompras { get; set; }
        public double ValorTotal { get; set; }
        public bool Realizada { get; set; }
    }
}
