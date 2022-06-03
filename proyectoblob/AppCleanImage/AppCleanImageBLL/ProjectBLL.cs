using AppCleanImageDAL;
using AppCleanImageDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCleanImageBLL
{
    public class ProjectBLL
    {
        private readonly Project data;

        public ProjectBLL()
        {
            data = new Project();
        }
        public List<ProjectDAO> GetProjects()
        {
            return data.GetProjects();
        }
    }
}
