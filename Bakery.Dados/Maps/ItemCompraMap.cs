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
    public class ItemCompraMap : IEntityTypeConfiguration<ItemCompra>
    {
        public void Configure(EntityTypeBuilder<ItemCompra> builder)
        {
            builder.ToTable("ItemCompra");

            builder.HasKey(x => new { x.IdProduto, x.IdCompra });

            builder.HasOne<Produto>(f => f.Produto)
                .WithMany(d => d.ItemCompras)
                .HasForeignKey(k => k.IdProduto);

            builder.HasOne<Compra>(f => f.Compra)
                .WithMany(d => d.ItemCompras)
                .HasForeignKey(k => k.IdCompra);
        }
    }
}
