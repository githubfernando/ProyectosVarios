using IQCleanRepositoryBLL.Interfaces;
using IQCleanRepositoryDAL;
using IQCleanRepositoryDAL.Sanitas;
using IQCleanRepositoryDAO.SanitasDAO;
using IQCleanRepositoryUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryBLL.PPLBLL
{
    public class PPLCheckDateBLL : ICheckRangeDate
    {
        private readonly CheckRangeDatePPL data;
        private readonly string conexiondb= "PPLConexionIQDoc";
        public PPLCheckDateBLL()
        {
            data = new CheckRangeDatePPL();
        }

        public List<SolicitudDAO> GetCheckRangeDate(DateTime dateIni, DateTime dateEnd, string repositoryId)
        {
            try
            {
                return data.GetConsultRangeDate(dateIni, dateEnd);
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
                return data.ListImages(lista);
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
