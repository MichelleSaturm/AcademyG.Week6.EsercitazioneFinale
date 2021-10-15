using AcademyG.Week6.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6.CoreEF.Configuration
{
    public class OrdineConfiguration : IEntityTypeConfiguration<Ordine>
    {
        public void Configure(EntityTypeBuilder<Ordine> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.CodiceOrdine)
                .HasMaxLength(15)
                .IsRequired(false);

            builder
                .Property(c => c.DataOrdine)
                .IsRequired();

            builder
                .Property(c => c.CodiceProdotto)
                .HasMaxLength(15)
                .IsRequired();

            builder
                .Property(o => o.Importo)
                .IsRequired();

            builder
                .HasOne(o => o.Cliente)
                .WithMany(c => c.Ordini)
                .HasForeignKey(o => o.ClienteId);
        }
    }
}
