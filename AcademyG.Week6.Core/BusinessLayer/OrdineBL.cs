using AcademyG.Week6.Core.Interfaces;
using AcademyG.Week6.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyG.Week6.Core.BusinessLayer
{
    public class OrdineBL : IOrdineBL
    {
        private readonly IOrdineRepository ordineRepo;
        private readonly IClienteRepository clienteRepo;

        public OrdineBL(
            IOrdineRepository ordineRepo,
            IClienteRepository clienteRepo
        )
        {
            this.ordineRepo = ordineRepo;
            this.clienteRepo = clienteRepo;
        }

       
        public IEnumerable<Cliente> FetchClienti(Func<Cliente, bool> filter = null)
        {
            var allData = clienteRepo.FetchAll();

            if (filter != null)
                return allData.Where(filter);

            return allData;
        }

        public bool CreaCliente(Cliente newCliente)
        {
            if (newCliente == null)
                throw new ArgumentNullException("Errore. Inserimento non valido.");

            return clienteRepo.Add(newCliente);
        }
        public bool ModificaCliente(Cliente editCliente)
        {
            if (editCliente == null)
                throw new ArgumentNullException("Errore. Inserimento non valido.");

            return clienteRepo.Update(editCliente);
        }

        public bool CancellaCliente(Cliente clienteDaEliminare)
        {
            if (clienteDaEliminare == null)
                throw new ArgumentNullException("Errore. Inserimento non valido.");

            return clienteRepo.Delete(clienteDaEliminare);
        }

        //ORDINI

        public IEnumerable<Ordine> FetchOrdini(Func<Ordine, bool> filter = null)
        {
            var allData = ordineRepo.FetchAll();

            if (filter != null)
                return allData.Where(filter);

            return allData;
        }

        public bool CreaOrdine(Ordine nuovoOrdine)
        {
            if (nuovoOrdine == null)
                throw new ArgumentNullException("Errore. Inserimento non valido.");

            return ordineRepo.Add(nuovoOrdine);
        }

        
        public bool ModificaOrdine(Ordine editOrdine)
        {
            if (editOrdine == null)
                throw new ArgumentNullException("Errore. Inserimento non valido.");

            return ordineRepo.Update(editOrdine);
        }

        public bool CancellaOrdine(Ordine ordineDaEliminare)
        {
            if (ordineDaEliminare == null)
                throw new ArgumentNullException("Errore. Inserimento non valido.");

            return ordineRepo.Delete(ordineDaEliminare);
        }


    

    }
}
