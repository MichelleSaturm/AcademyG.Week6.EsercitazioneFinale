using AcademyG.Week6.Core.Interfaces;
using AcademyG.Week6.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyG.Week6.CoreEF.Repositories
{
    public class EFClienteRepository : IClienteRepository
    {
        private readonly OrdineContext ctx;

        public EFClienteRepository() : this(new OrdineContext())
        {

        }

        public EFClienteRepository(OrdineContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Cliente item)
        {
            try
            {
                ctx.Clienti.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                return false;
            }
        }

        public bool Delete(Cliente item)
        {
            try
            {
                var cliente = ctx.Clienti.Find(item.Id);

                if (cliente != null)
                    ctx.Clienti.Remove(cliente);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                return false;
            }
        }

        public List<Cliente> FetchAll()
        {
            try
            {
                return ctx.Clienti.Include(o => o.Ordini).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                return null;
            }
        }

        public Cliente GetById(int id)
        {
            try
            {
                return ctx.Clienti.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                return null;
            }
        }

        public bool Update(Cliente item)
        {
            try
            {
                ctx.Clienti.Update(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                return false;
            }
        }
    }
}
