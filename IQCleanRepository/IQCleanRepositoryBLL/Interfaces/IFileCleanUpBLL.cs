using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryBLL.Interfaces
{
    public interface IFileCleanUpBLL
    {
        public string RunFilesCleanUp(int repository_id, string repositoryName, string user);
    }
}
