using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryDAO
{
    public class ImagesCleanUpDAO
    {
        public string Cliente { get; set; }
        public Guid Solicitud_id { get; set; }
        public string Radicado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string RutaImagen { get; set; }
        public string Usuario { get; set; }
        public DateTime? FechaConsultaDatos { get; set; }
        public string EstadoLimpieza { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public string? Blob { get; set; }
        public string? Directory { get; set; }
        public string? FileName { get; set; }
    }
}
