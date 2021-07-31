using Bakery.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Dados.Maps
{
    public class ItemVendaMap : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("ItemVenda");

            builder.HasKey(x => new { x.IdProduto, x.IdVenda });

            builder.HasOne<Produto>(f => f.Produto)
                .WithMany(d => d.ItemVendas)
                .HasForeignKey(k => k.IdProduto);

            builder.HasOne<Venda>(f => f.Venda)
                .WithMany(d => d.ItemVendas)
                .HasForeignKey(k => k.IdVenda);
        }
    }
}
