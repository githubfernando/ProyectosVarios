using IQCleanRepositoryDAO;
using IQCleanRepositoryUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryDAL
{
    public class FileCleanUp
    {
        public List<ImagesCleanUpDAO> GetFilesToCleanUp(int repositoryId, string user)
        {
            try
            {
                using (SqlConnection conexion = OrigenDb.ObtenerConexion("ConexionCleanRepository"))
                {
                    List<ImagesCleanUpDAO> result = new List<ImagesCleanUpDAO>();
                    SqlCommand comando = new SqlCommand(CleanRepositoryProcedure.spGetFilesToCleanUp, conexion);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("@repository_Id", SqlDbType.Int).Value = repositoryId;
                    comando.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
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
                        obj.Blob = string.IsNullOrEmpty(reader.GetString(6))?"":"";
                        obj.Directory = reader.GetString(7);
                        obj.FileName = reader.GetString(8);
                        result.Add(obj);
                    }

                    conexion.Dispose();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int SaveFilesCleanup(List<ImagesCleanUpDAO> list, int repositoryId, string user)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Solicitud_id", typeof(Guid));
                dt.Columns.Add("Radicado", typeof(string));
                dt.Columns.Add("fechaCreacion", typeof(DateTime));
                dt.Columns.Add("rutaImagen", typeof(string));
                dt.Columns.Add("Usuario", typeof(string));
                dt.Columns.Add("FechaConsultaDatos", typeof(DateTime));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("FechaEliminacion", typeof(DateTime));

                foreach (var d in list)
                {
                    dt.Rows.Add(d.Solicitud_id, d.Radicado, d.FechaCreacion, d.RutaImagen, d.Usuario, d.FechaConsultaDatos
                        ,d.EstadoLimpieza, d.FechaEliminacion);
                }

                using (SqlConnection conexion = OrigenDb.ObtenerConexion("ConexionCleanRepository"))
                {

                    List<ImagesCleanUpDAO> result = new List<ImagesCleanUpDAO>();
                    SqlCommand comando = new SqlCommand(CleanRepositoryProcedure.spSaveImageCleanUp, conexion);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    var parametro = new SqlParameter("@radicados", SqlDbType.Structured);
                    parametro.Value = dt;
                    parametro.TypeName = "dbo.Clean_TypeFileCleanUpSave";
                    comando.Parameters.Add(parametro);
                    comando.Parameters.Add("@repositoryId", SqlDbType.Int).Value = repositoryId;
                    comando.Parameters.Add("@usuario", SqlDbType.VarChar).Value = user;
                    conexion.Open();

                    var reader = comando.ExecuteNonQuery();

                    conexion.Dispose();
                    return reader;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
