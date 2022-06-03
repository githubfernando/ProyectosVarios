using System;
using System.Collections.Generic;

#nullable disable

namespace TestDBfirst.Data
{
    public partial class Invoice
    {
        public Invoice()
        {
            ServiceDetails = new HashSet<ServiceDetail>();
        }

        public int IdInvoice { get; set; }
        public string Cude { get; set; }
        public decimal TipoDocumentoPrestador { get; set; }
        public decimal NitPrestador { get; set; }
        public decimal? DigitoVerificacionPrestador { get; set; }
        public string NombrePrestador { get; set; }
        public decimal SucursalPrincipalDepto { get; set; }
        public decimal SucursalPrincipalMun { get; set; }
        public string SucursalPrincipalDireccion { get; set; }
        public decimal? SucursalSegundalDepto { get; set; }
        public decimal? SucursalSegundalMun { get; set; }
        public string SucursalSegundalDireccion { get; set; }
        public string CodigoHabilitacion { get; set; }
        public decimal TipoIdentificacionPagador { get; set; }
        public decimal NitPagador { get; set; }
        public decimal DigitoVerificacionPagador { get; set; }
        public string NombrePagador { get; set; }
        public string TipoDocumentoFact91N92 { get; set; }
        public string TipoOperacion { get; set; }
        public string PrefijoFactura { get; set; }
        public decimal NumeroFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal? Anticipo { get; set; }
        public decimal? CuotaModeradora { get; set; }
        public decimal? Copago { get; set; }
        public decimal? ValorIva { get; set; }
        public decimal? ValorDescuento { get; set; }
        public decimal? Cargos { get; set; }
        public decimal ValorNeto { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string NumeroImpres { get; set; }
        public string NumeroIdsuministroMipres { get; set; }
        public string NumeroContrato { get; set; }
        public string NumeroPoliza { get; set; }
        public string CamposObservaciones { get; set; }
        public string TipoIdentificacionAfiliado { get; set; }
        public decimal? NumeroidentificacionAfiliado { get; set; }
        public string PrimerApellidoAfiliado { get; set; }
        public string SegundoApellidoAfiliado { get; set; }
        public string PrimerNombreAfiliado { get; set; }
        public string SegundoNombreAfiliado { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }

        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; }
    }
}
