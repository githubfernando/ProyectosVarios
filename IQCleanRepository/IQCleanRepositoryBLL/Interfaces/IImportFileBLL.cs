using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryBLL.Interfaces
{
    public interface IImportFileBLL
    {
        public int ImportFile(string fileName, int repositryId, string user);
    }
}
