using IQCleanRepositoryDAO;
using IQCleanRepositoryUtils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryDAL
{
    public class Repository
    {
        public List<RepositoryDAO> GetRepository(int IdProject)
        {
            List<RepositoryDAO> result = new List<RepositoryDAO>();

            try
            {
                using (SqlConnection conexion = OrigenDb.ObtenerConexion("ConexionCleanRepository"))
                {
                    SqlCommand comando = new SqlCommand(CleanRepositoryProcedure.spGetRepository, conexion);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Projectid", IdProject);
                    conexion.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        RepositoryDAO obj = new RepositoryDAO();
                        obj.Id = reader.GetInt32(0);
                        obj.IdProject = reader.GetInt32(1);
                        obj.Name = reader.GetString(2);
                        result.Add(obj);
                    }
                    conexion.Dispose();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la consulta a la BD: " + ex.Message);
            }
        }
    }
}

