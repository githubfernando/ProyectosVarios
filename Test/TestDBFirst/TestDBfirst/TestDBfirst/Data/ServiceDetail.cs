using System;
using System.Collections.Generic;

#nullable disable

namespace TestDBfirst.Data
{
    public partial class ServiceDetail
    {
        public long Id { get; set; }
        public int IdServiceDetail { get; set; }
        public int IdInvoice { get; set; }
        public string CodigoServicio { get; set; }
        public string DescripcionServicio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal? ValorIva { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual Invoice IdInvoiceNavigation { get; set; }
    }
}
