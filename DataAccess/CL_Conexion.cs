using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//conexion
using System.Data.SqlClient;

namespace DataAccess
{
    public class CL_Conexion
    {
        private SqlConnection cone;
        private String cadena = @"Data Source=(localdb)\MyInstance;Initial Catalog=BD_SFSF; integrated Security =True";

        public CL_Conexion()
        {
            if (cone == null)
            {
                cone = new SqlConnection();
                cone.ConnectionString = cadena;
            }
        }

        public SqlConnection obtenerConexion()
        {
            return cone;
        }
    }
}
