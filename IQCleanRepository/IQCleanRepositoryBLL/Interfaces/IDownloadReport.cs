using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryBLL.Interfaces
{
    public interface IDownloadReport
    {
        public string GenerateReport(int repositoryId);
    }
}
