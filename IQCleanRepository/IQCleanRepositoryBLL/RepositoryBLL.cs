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
    public class RepositoryBLL : IRepositoryBLL
    {
        private readonly Repository data;
        public RepositoryBLL()
        {
            data = new Repository();
        }

        public List<RepositoryDAO> GetRepository(int idProject)
        {
            try
            {
                return data.GetRepository(idProject);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error obteniendo los Repositorios en BLL: " + ex.Message);
            }
        }

    }
}
