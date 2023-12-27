using System.Data.SqlClient;

namespace CarritoCompras.Models
{
    public class Conexion
    {
        public static SqlConnection Conectar()
        {
            string conx = "DATA SOURCE = A; INITIAL CATALOG = CarritoCompras; INTEGRATED SECURITY = YES;";
            SqlConnection s = new SqlConnection(conx);
            return s;
        }
    }
}
