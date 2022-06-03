using IQCleanRepositoryDAO.SanitasDAO;
using IQCleanRepositoryUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryDAL.Mundial
{
    public class CheckRangeDateMundial
    {
        public List<SolicitudDAO> GetConsultRangeDate(DateTime dateIni, DateTime dateEnd, string repository)
        {
            List<SolicitudDAO> result = new List<SolicitudDAO>();

            try
            {
                using (SqlConnection conexion = OrigenDb.ObtenerConexion("MundialConexionIQDoc"))
                {
                    SqlCommand comando = new SqlCommand(MundialProcedure.spCleanCheckRangeDate, conexion);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Fechainicio", dateIni);
                    comando.Parameters.AddWithValue("@FechaFin", dateEnd);
                    comando.Parameters.AddWithValue("@Repository", repository);
                    conexion.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        SolicitudDAO obj = new SolicitudDAO();
                        obj.Solicitud_id = reader.GetGuid(0);
                        obj.Radicado = reader.GetString(1);
                        obj.FechaCreacion = reader.GetDateTime(2);
                        result.Add(obj);
                    }
                    conexion.Dispose();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error consultando las solicitudes por rango de fecha en IQDoc: " + ex.Message);
            }
        }

        public List<SolicitudDAO> CheckDataProcessed(List<SolicitudDAO> lista)
        {
            List<SolicitudDAO> result = new List<SolicitudDAO>();

            var dt = new DataTable();
            dt.Columns.Add("radicado", typeof(string));
            dt.Columns.Add("solicitud_id", typeof(Guid));
            dt.Columns.Add("fechaCreacion", typeof(DateTime));

            foreach (var l in lista)
            {
                dt.Rows.Add(l.Radicado, l.Solicitud_id, l.FechaCreacion);
            }

            using (SqlConnection conexion = OrigenDb.ObtenerConexion("MundialConexionIQDoc"))
            {
                SqlCommand comando = new SqlCommand(MundialProcedure.spCleanCheckInBizagi, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                var parametro = new SqlParameter("@Radicados", SqlDbType.Structured);
                parametro.Value = dt;
                parametro.TypeName = "dbo.Clean_Type_CheckProcessedRad";
                comando.Parameters.Add(parametro);
                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    SolicitudDAO obj = new SolicitudDAO();
                    obj.Solicitud_id = reader.GetGuid(0);
                    obj.Radicado = reader.GetString(1);
                    obj.FechaCreacion = reader.GetDateTime(2);
                    result.Add(obj);
                }
                conexion.Dispose();
                return result;
            }
        }

        public List<SolicitudDAO> ListImages(List<SolicitudDAO> lista, string repository )
        {
            List<SolicitudDAO> result = new List<SolicitudDAO>();
            var dt = new DataTable();
            dt.Columns.Add("radicado", typeof(string));
            dt.Columns.Add("solicitud_id", typeof(Guid));
            dt.Columns.Add("fechaCreacion", typeof(DateTime));
            foreach (var l in lista)
            {
                dt.Rows.Add(l.Radicado, l.Solicitud_id, l.FechaCreacion);
            }

            if (repository == "Flash")
            {
                using (SqlConnection conexion = OrigenDb.ObtenerConexion("MundialConexionFlash"))
                {

                    SqlCommand comando = new SqlCommand(MundialProcedure.spCleanListImages, conexion);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    var parametro = new SqlParameter("@Radicados", SqlDbType.Structured);
                    parametro.Value = dt;
                    parametro.TypeName = "dbo.Clean_Type_CheckProcessedRad";
                    comando.Parameters.Add(parametro);
                    conexion.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        SolicitudDAO obj = new SolicitudDAO();
                        obj.Solicitud_id = reader.GetGuid(0);
                        obj.Radicado = reader.GetString(1);
                        obj.FechaCreacion = reader.GetDateTime(2);
                        obj.rutaImagen = reader.GetString(3);
                        result.Add(obj);
                    }
                    conexion.Dispose();
                    return result;
                }

            }
            else if (repository == "Blob Storage")
            {
                using (SqlConnection conexion = OrigenDb.ObtenerConexion("MundialConexionIQDoc"))
                {

                    SqlCommand comando = new SqlCommand(MundialProcedure.spCleanListImages, conexion);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    var parametro = new SqlParameter("@Radicados", SqlDbType.Structured);
                    parametro.Value = dt;
                    parametro.TypeName = "dbo.Clean_Type_CheckProcessedRad";
                    comando.Parameters.Add(parametro);
                    conexion.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        SolicitudDAO obj = new SolicitudDAO();
                        obj.Solicitud_id = reader.GetGuid(0);
                        obj.Radicado = reader.GetString(1);
                        obj.FechaCreacion = reader.GetDateTime(2);
                        obj.Blob = reader.GetString(3);
                        obj.Directory = reader.GetString(4);
                        obj.FileName = reader.GetString(5);
                        result.Add(obj);
                    }
                    conexion.Dispose();
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public int SaveImageList(List<SolicitudDAO> list, int repository, string user)
        {
            DataTable dts = new DataTable();
            dts.Columns.Add("radicado", typeof(string));
            dts.Columns.Add("solicitud_id", typeof(Guid));
            dts.Columns.Add("fechaCreacion", typeof(DateTime));
            dts.Columns.Add("rutaImagen", typeof(string));
            dts.Columns.Add("Blob", typeof(string));
            dts.Columns.Add("directory", typeof(string));
            dts.Columns.Add("fileName", typeof(string));

            foreach (var l in list)
            {
                dts.Rows.Add(l.Radicado, l.Solicitud_id, l.FechaCreacion, l.rutaImagen,l.Blob,
                    l.Directory,l.FileName);
            }

            using (SqlConnection conexion = OrigenDb.ObtenerConexion("ConexionCleanRepository"))
            {

                SqlCommand comando = new SqlCommand(CleanRepositoryProcedure.spSaveImageListBlob, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                var parametro = new SqlParameter("@radicados", SqlDbType.Structured);
                parametro.Value = dts;
                parametro.TypeName = "dbo.Clean_TypeImageList_Blob";
                comando.Parameters.Add(parametro);
                comando.Parameters.Add("@repository", SqlDbType.Int).Value = repository;
                comando.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                conexion.Open();

                var result = comando.ExecuteNonQuery();

                conexion.Dispose();
                return result;
            }
        }

        public int SaveRepositoryCleanUp(List<SolicitudDAO> list, int repository, string user)
        {
            DataTable dts = new DataTable();
            dts.Columns.Add("radicado", typeof(string));
            dts.Columns.Add("solicitud_id", typeof(Guid));
            dts.Columns.Add("fechaCreacion", typeof(DateTime));
            dts.Columns.Add("rutaImagen", typeof(string));

            foreach (var l in list)
            {
                dts.Rows.Add(l.Radicado, l.Solicitud_id, l.FechaCreacion, l.rutaImagen);
            }

            using (SqlConnection conexion = OrigenDb.ObtenerConexion("ConexionCleanRepository"))
            {

                SqlCommand comando = new SqlCommand(CleanRepositoryProcedure.spSaveImageCleanUp, conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                var parametro = new SqlParameter("@Radicados", SqlDbType.Structured);
                parametro.Value = dts;
                parametro.TypeName = "dbo.Clean_TypeImageList";
                comando.Parameters.Add(parametro);
                comando.Parameters.Add("@repository", SqlDbType.Int).Value = repository;
                comando.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                conexion.Open();

                var result = comando.ExecuteNonQuery();

                conexion.Dispose();
                return result;
            }
        }
    }
}
