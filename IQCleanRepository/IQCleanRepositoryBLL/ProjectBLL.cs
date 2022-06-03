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
    public class ProjectBLL : IProjectBLL
    {
        private readonly Project data;
        //private readonly IProjectBLL data;

        public ProjectBLL()
        {
            data = new Project();
        }
        public List<ProjectDAO> GetProjects()
        {
            try
            {
                return data.GetProjects();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error obteniendo los Proyecto en BLL: " + ex.Message);
            }  
        } 
    }
}
