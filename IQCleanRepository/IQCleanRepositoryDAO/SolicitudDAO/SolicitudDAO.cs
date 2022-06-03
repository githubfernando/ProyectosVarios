using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryDAO.SanitasDAO
{
    public class SolicitudDAO
    {
        public Guid Solicitud_id { get; set; }
        public string Radicado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string rutaImagen { get; set; }
        public string Blob { get; set; }
        public string Directory { get; set; }
        public string FileName { get; set; }
    }
}
