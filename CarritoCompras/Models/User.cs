using System.Data.SqlClient;
using System.Data;

namespace CarritoCompras.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Models.ResponseMessage UserLogin()
        {
            Models.ResponseMessage responseMessage=new Models.ResponseMessage();
            SqlConnection conx = Models.Connection.Connect();
            SqlCommand command = new SqlCommand("spUserLogin", conx);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Password", Password);
            User c = new User();
            conx.Open();
            SqlDataReader dr=command.ExecuteReader();
            try
            {
                if(dr.Read())
                {
                    responseMessage.Id = int.Parse(dr["Id"].ToString()!);
                    responseMessage.Name = dr["Name"].ToString();
                }
                dr.Close();
                conx.Close();
                
            }
            catch (Exception error)
            {
                responseMessage.Name = error.Message;
                if (conx.State == ConnectionState.Open)
                {
                    dr.Close();
                    conx.Close();
                }
            }
            return responseMessage;
        }
    }
}
