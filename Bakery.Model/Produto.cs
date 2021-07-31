using Bakery.Model.Enums;
using Bakery.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace Bakery.Model
{
    public class Produto : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public TipoDeMedida TipoDeMedida { get; set; }
        public TipoDeProduto TipoDeProduto { get; set; }
        public double ValorVenda { get; set; }
        public Estoque Estoque { get; set; }
        public List<ItemVenda> ItemVendas { get; set; }
        public List<ItemCompra> ItemCompras { get; set; }
        public List<MaterialReceita> MaterialReceitas { get; set; }
    }
}
