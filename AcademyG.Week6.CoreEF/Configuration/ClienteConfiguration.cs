using AcademyG.Week6.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6.CoreEF.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Nome)
                .HasMaxLength(50)
                .IsRequired(false);

            builder
                .Property(c => c.Cognome)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(c => c.CodiceCliente)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .HasMany(c => c.Ordini)
                .WithOne(o => o.Cliente);
        }
    }
}
