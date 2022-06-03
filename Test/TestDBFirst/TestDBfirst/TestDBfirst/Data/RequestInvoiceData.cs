using System;
using System.Collections.Generic;

#nullable disable

namespace TestDBfirst.Data
{
    public partial class RequestInvoiceData
    {
        public long Id { get; set; }
        public string RequestJson { get; set; }
        public DateTime? RequestDate { get; set; }
        public byte? RequestStatus { get; set; }
        public string Description { get; set; }
    }
}
