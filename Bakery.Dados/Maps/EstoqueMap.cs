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
    public class EstoqueMap : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoque");

            builder.HasKey(x => x.Id);

            builder.HasOne<Produto>(o => o.Produto)
                   .WithOne(r => r.Estoque)
                   .HasForeignKey<Estoque>(f => f.IdProduto);
        }
    }
}
