using IQCleanRepositoryDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryBLL.Interfaces
{
    public interface IRepositoryBLL
    {
        public List<RepositoryDAO> GetRepository(int idProject);
    }
}
