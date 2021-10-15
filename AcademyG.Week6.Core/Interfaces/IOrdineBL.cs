using AcademyG.Week6.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6.Core.Interfaces
{
    public interface IOrdineBL
    {
      
        //CLIENTI
        IEnumerable<Cliente> FetchClienti(Func<Cliente, bool> filter = null);
        bool CreaCliente(Cliente newCustomer);
        bool ModificaCliente(Cliente editedCustomer);
        bool CancellaCliente(Cliente customerToBeDeleted);


        //ORDINI
        IEnumerable<Ordine> FetchOrdini(Func<Ordine, bool> filter = null);
        bool CreaOrdine(Ordine newOrder);
        bool ModificaOrdine(Ordine editedOrder);
        bool CancellaOrdine(Ordine orderToBeDeleted);

    }
}
