using AcademyG.Week6.Core.Interfaces;
using AcademyG.Week6.Core.Model;
using AcademyG.Week6.CoreEF.Repositories;
using System.Collections.Generic;
using System.Linq;
using AcademyG.Week6.Core.BusinessLayer;

namespace AcademyG.Week6.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ClienteService : IClienteService
    {
        private readonly IOrdineBL mainBusinessLayer;

        public ClienteService()
        {
            mainBusinessLayer = new OrdineBL(
                new EFOrdineRepository(),
                new EFClienteRepository()
            );
        }
        public bool AggiungiCliente(Cliente nuovoCliente)
        {
            if (nuovoCliente == null)
                return false;

            var result = mainBusinessLayer
                .CreaCliente(nuovoCliente);

            return result;
        }

        public bool EliminaClienteById(int id)
        {
            if (id <= 0)
                return false;

            var daCancellare = mainBusinessLayer
                .FetchClienti(c => c.Id == id)
                .FirstOrDefault();

            if (daCancellare == null)
                return false;

            var result = mainBusinessLayer
                .CancellaCliente(daCancellare);

            return result;
        }

        public List<Cliente> ListaClienti()
        {
            var result = mainBusinessLayer.FetchClienti().ToList();
            return result;
        }

        public Cliente ClienteById(int id)
        {
            if (id <= 0)
                return null;

            var cliente = mainBusinessLayer
                .FetchClienti(c => c.Id == id)
                .FirstOrDefault();

            return cliente;
        }

        public bool ModificaCliente(Cliente clienteModificato)
        {
            if (clienteModificato == null)
                return false;

            var result = mainBusinessLayer
                .ModificaCliente(clienteModificato);

            return result;
        }
    }
}
