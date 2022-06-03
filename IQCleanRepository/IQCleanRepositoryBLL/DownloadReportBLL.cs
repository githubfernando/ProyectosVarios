using IQCleanRepositoryBLL.Interfaces;
using IQCleanRepositoryDAL;
using IQCleanRepositoryDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryBLL
{
    public class DownloadReportBLL : IDownloadReport
    {
        private readonly DownloadReport _generateFile;
        public DownloadReportBLL()
        {
            _generateFile = new DownloadReport();
        }

        public string GenerateReport(int repositoryId)
        {
            try
            {
                return _generateFile.GetImagesPending(repositoryId);
            }
            catch (Exception ex)
            {
                throw new Exception("Se generó un error exportando el archivo: "+ex.Message);
            }
        }
    }
}
