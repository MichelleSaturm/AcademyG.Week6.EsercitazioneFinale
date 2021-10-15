using AcademyG.Week6.Core.Model;
using AcademyG.Week6.CoreEF.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace AcademyG.Week6.CoreEF
{
    public class OrdineContext : DbContext
    {
        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<Cliente> Clienti { get; set; }

        public OrdineContext() : base()
        {

        }
        public OrdineContext(DbContextOptions<OrdineContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = "Server=(localdb)\\mssqllocaldb;Database=EsercitazioneWeek6;Trusted_Connection=True;MultipleActiveResultSets=True;";
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Ordine>(new OrdineConfiguration());
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
        }
    }
}
