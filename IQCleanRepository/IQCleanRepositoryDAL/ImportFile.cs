using IQCleanRepositoryDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQCleanRepositoryUtils;
using System.Data;
using System.Data.SqlClient;

namespace IQCleanRepositoryDAL
{
    public class ImportFile
    {
        public int ImportFileToBD(string fileName, int repositoryId, string user)
        {
            try
            {
                var import = new IQCleanRepositoryUtils.CsvHelper();
                var data = import.ImportFileCsv(fileName);

                DataTable dt = new DataTable();
                dt.Columns.Add("Radicado", typeof(string));
                dt.Columns.Add("Solicitud_id", typeof(Guid));
                dt.Columns.Add("fechaCreacion", typeof(DateTime));
                dt.Columns.Add("rutaImagen", typeof(string));

                foreach (var d in data)
                {
                    dt.Rows.Add(d.Radicado, d.Solicitud_id, d.FechaCreacion, d.RutaImagen);
                }

                using (SqlConnection conexion = OrigenDb.ObtenerConexion("ConexionCleanRepository"))
                {
                    SqlCommand comando = new SqlCommand(CleanRepositoryProcedure.spCrossFileWithData, conexion);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    var parametro = new SqlParameter("@radicados", SqlDbType.Structured);
                    parametro.Value = dt;
                    parametro.TypeName = "dbo.Clean_TypeImageList";
                    comando.Parameters.Add(parametro);
                    comando.Parameters.Add("@repositoryId", SqlDbType.Int).Value = repositoryId;
                    comando.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                    conexion.Open();

                    int reader = comando.ExecuteNonQuery();
                    conexion.Dispose();

                    if (reader >= 1)
                        return reader;
                    else
                        return 0;
                }
            }
            catch ( Exception ex)
            {

                throw new Exception("Ocurrió un error en la carga de archivo: "+ex.Message);
            }
        }
    }
}
