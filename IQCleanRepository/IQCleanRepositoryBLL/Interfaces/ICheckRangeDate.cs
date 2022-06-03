using IQCleanRepositoryDAO.SanitasDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryBLL.Interfaces
{
    public interface ICheckRangeDate
    {
        public List<SolicitudDAO> GetCheckRangeDate(DateTime dateIni, DateTime dateEnd, string repositoryId=null);
        public List<SolicitudDAO> CheckDataProcessed(List<SolicitudDAO> lista);
        public List<SolicitudDAO> ListImages(List<SolicitudDAO> lista, string repository=null);
        public int SaveList(List<SolicitudDAO> lista, int repository, string user);

    }
}
