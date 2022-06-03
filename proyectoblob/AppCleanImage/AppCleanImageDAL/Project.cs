using AppCleanImageDAO;
using AppCleanImageUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCleanImageDAL
{
    public class Project : IProject
    {
        private readonly SqlConnection conexion;

        public Project()    
        {
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionCleanImage"].ConnectionString);
        }

        public List<ProjectDAO> GetProjects()
        {
            List<ProjectDAO> result = new List<ProjectDAO>();

            try
            {
                using (conexion)
                {
                    SqlCommand comando = new SqlCommand(ProcedureName.spGetProjects, conexion);
                    conexion.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        ProjectDAO obj = new ProjectDAO();
                        obj.Id = reader.GetInt32(0);
                        obj.Name = reader.GetString(1);
                        obj.Origin = reader.GetString(2);
                        result.Add(obj);
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
            }
        }
    }
}
