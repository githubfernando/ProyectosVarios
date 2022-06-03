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
    public class Route : IRoute
    {
        private readonly SqlConnection conexion;
        public Route()
        {
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionCleanImage"].ConnectionString);
        }
        public List<ImageRoutingDAO> GetRoutes(int IdProject)
        {
            List<ImageRoutingDAO> result = new List<ImageRoutingDAO>();

            try
            {
                using (conexion)
                {
                    SqlCommand comando = new SqlCommand(ProcedureName.spGetRoutes, conexion);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdProject", IdProject);
                    conexion.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        ImageRoutingDAO obj = new ImageRoutingDAO();
                        obj.Id = reader.GetInt32(0);
                        obj.Route = reader.GetString(1);
                        obj.Active = reader.GetBoolean(2);
                        obj.IdProject = reader.GetInt32(3);
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
