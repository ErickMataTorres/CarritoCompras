using System.Data.SqlClient;
using System.Data;

namespace CarritoCompras.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public static string LoginUsuario(string correo, string contrasena)
        {
            SqlConnection conx = Models.Conexion.Conectar();
            SqlCommand command = new SqlCommand("spLoginUsuario", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Correo", correo);
            command.Parameters.AddWithValue("@Contrasena", contrasena);
            Usuario c = new Usuario();
            conx.Open();
            string respuesta = "";
            try
            {
                respuesta = command.ExecuteScalar().ToString()!;
            }
            catch (Exception error)
            {
                respuesta = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    conx.Close();
                }
            }
            return respuesta;
        }
    }
}
