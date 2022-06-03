using IQCleanRepositoryDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryUtils
{
    public class CleanRepository
    {
        public List<OImgaesCleanUp> RunCleanRepository(List<ImagesCleanUpDAO> list)
        {
            return null;
        }
    }

    public class OImgaesCleanUp
    {
        public Guid Solicitud_id { get; set; }
        public string Radicado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string rutaImagen { get; set; }
        public DateTime fechaEliminacion { get; set; }
        public string estadoEjecucion { get; set; }

    }
}
