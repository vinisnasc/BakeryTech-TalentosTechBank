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
    public class FinanceiroMap : IEntityTypeConfiguration<Financeiro>
    {
        public void Configure(EntityTypeBuilder<Financeiro> builder)
        {
            builder.HasData(new Financeiro()
            {
                Id = 1,
                SaldoEmCaixa = 5000
            });

        }
    }
}
