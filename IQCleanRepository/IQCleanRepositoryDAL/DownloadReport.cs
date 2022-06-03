using IQCleanRepositoryDAO;
using IQCleanRepositoryDAO.SanitasDAO;
using IQCleanRepositoryUtils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryDAL
{
    public class DownloadReport
    {
        public string GetImagesPending(int repositoryId)
        {
            List<ImagesCleanUpDAO> result = new List<ImagesCleanUpDAO>();
            try
            {
                using (SqlConnection conexion = OrigenDb.ObtenerConexion("ConexionCleanRepository"))
                {
                    SqlCommand comando = new SqlCommand(CleanRepositoryProcedure.spGetImagesPending, conexion);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@repositoryid", repositoryId);
                    conexion.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        ImagesCleanUpDAO obj = new ImagesCleanUpDAO();
                        obj.Radicado = reader.GetString(0);
                        obj.Solicitud_id = reader.GetGuid(1);
                        obj.FechaCreacion = reader.GetDateTime(2);
                        obj.RutaImagen = reader.GetString(3);
                        obj.Usuario = reader.GetString(4);
                        obj.FechaConsultaDatos = reader.GetDateTime(5);
                        obj.Cliente = reader.GetString(6);
                        result.Add(obj);
                    }
                    conexion.Dispose();

                    var generateFile = new IQCleanRepositoryUtils.CsvHelper();
                    string generateResult = generateFile.GenerateFileCsv(result);

                    return generateResult;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error consultando las solicitudes por rango de fecha en IQDoc Sanitas: " + ex.Message);
            }

        }
    }
}
