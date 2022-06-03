using IQCleanRepositoryDAO;
using IQCleanRepositoryUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryDAL
{

    public class Project
    {
        public List<ProjectDAO> GetProjects()
        {
            List<ProjectDAO> result = new List<ProjectDAO>();

            try
            {
                using (SqlConnection conexion = OrigenDb.ObtenerConexion("ConexionCleanRepository"))
                {
                    SqlCommand comando = new SqlCommand(CleanRepositoryProcedure.spGetProjects, conexion);
                    conexion.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        ProjectDAO obj = new ProjectDAO();
                        obj.Id = reader.GetInt32(0);
                        obj.Name = reader.GetString(1);
                        result.Add(obj);
                    }
                    conexion.Dispose();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la consulta a la BD de Proyectos: "+ex.Message);
            }
        }
    }
}
