using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6.Core.Model
{
    public class Ordine
    {
        public int Id { get; set; }
        public DateTime DataOrdine { get; set; }
        public string CodiceOrdine { get; set; }
        public string CodiceProdotto { get; set; }
        public decimal Importo { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
