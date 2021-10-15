using AcademyG.Week6.Core.Interfaces;
using AcademyG.Week6.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyG.Week6.CoreEF.Repositories
{
    public class EFOrdineRepository : IOrdineRepository
    {
        private readonly OrdineContext ctx;

        public EFOrdineRepository() : this(new OrdineContext())
        {

        }

        public EFOrdineRepository(OrdineContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Ordine item)
        {
            try
            {
                if (item.Cliente != null && item.Cliente.Id > 0)
                {
                    var customerFound = ctx.Clienti.Find(item.Cliente.Id);
                    if (customerFound != null)
                        item.Cliente = customerFound;
                }

                ctx.Ordini.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                return false;
            }
        }

        public bool Delete(Ordine item)
        {
            try
            {
                var ordine = ctx.Ordini.Find(item.Id);

                if (ordine != null)
                    ctx.Ordini.Remove(ordine);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                return false;
            }
        }

        public List<Ordine> FetchAll()
        {
            try
            {
                return ctx.Ordini.Include(o => o.Cliente).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                return new List<Ordine>();
            }
        }

        public Ordine GetById(int id)
        {
            try
            {
                return ctx.Ordini.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
                return null;
            }
        }

        public bool Update(Ordine item)
        {
            try
            {
                ctx.Ordini.Update(item);
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
