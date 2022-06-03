using IQCleanRepositoryDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryBLL
{
    public interface IProjectBLL
    {
        public List<ProjectDAO> GetProjects();
    }
}
