using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameFileInBlob.Data
{
    public class Audit
    {
        private readonly SqlConnection conexion;
        public Audit()
        {
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString);
        }

        public void CreateAudit(string InvoiceNumber, string NombreInicial, string NombreFinal) 
        {
            try
            {
                using (conexion)
                {
                    string text = string.Format("INSERT INTO [dbo].[_AuditTableInvoice] VALUES('Storage','U','Aplicacion','{0}','{1}',GETDATE())", NombreInicial, NombreFinal);
                    SqlCommand comando = new SqlCommand(text, conexion);
                    conexion.Open();
                    int result = comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("se produjo un error " + ex);
            }
        }
    }
}
