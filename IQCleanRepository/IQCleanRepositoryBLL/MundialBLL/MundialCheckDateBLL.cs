using IQCleanRepositoryBLL.Interfaces;
using IQCleanRepositoryDAL.Mundial;
using IQCleanRepositoryDAO.SanitasDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryBLL.MundialBLL
{
    public class MundialCheckDateBLL : ICheckRangeDate
    {
        private readonly CheckRangeDateMundial data;
        public MundialCheckDateBLL()
        {
            data = new CheckRangeDateMundial();
        }

        public List<SolicitudDAO> GetCheckRangeDate(DateTime dateIni, DateTime dateEnd, string repository)
        {
            try
            {
                return data.GetConsultRangeDate(dateIni, dateEnd, repository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error consultando solicitudes en BLL: " + ex.Message);
            }

        }

        public List<SolicitudDAO> CheckDataProcessed(List<SolicitudDAO> lista)
        {
            try
            {
                return data.CheckDataProcessed(lista);
            }
            catch (Exception ex)
            {
                throw new Exception("Error consultando solicitudes en BLL: " + ex.Message);
            }
        }

        public List<SolicitudDAO> ListImages(List<SolicitudDAO> lista, string repository)
        {
            try
            {
                return data.ListImages(lista, repository);
            }
            catch (Exception ex)
            {
                throw new Exception("Error consultando solicitudes en BLL: " + ex.Message);
            }
        }

        public int SaveList(List<SolicitudDAO> lista, int repository, string user)
        {
            try
            {
                return data.SaveImageList(lista, repository, user);
            }
            catch (Exception ex)
            {
                throw new Exception("Error consultando solicitudes en BLL: " + ex.Message);
            }
        }
    }
}
