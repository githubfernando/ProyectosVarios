using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQCleanRepositoryDAL
{
    public class OrigenDb
    {
        public static SqlConnection ObtenerConexion(string conexiontag)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[conexiontag].ConnectionString);
            return conexion;
        }

    }
}
