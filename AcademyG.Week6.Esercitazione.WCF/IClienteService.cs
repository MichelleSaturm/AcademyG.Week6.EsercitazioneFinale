using AcademyG.Week6.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AcademyG.Week6.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        List<Cliente> ListaClienti();

        [OperationContract]
        Cliente ClienteById(int id);

        [OperationContract]
        bool AggiungiCliente(Cliente newCustomer);

        [OperationContract]
        bool ModificaCliente(Cliente updatedCustomer);

        [OperationContract]
        bool EliminaClienteById(int id);
    }
}
