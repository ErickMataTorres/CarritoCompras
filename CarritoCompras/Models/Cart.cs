using System.Data;
using System.Data.SqlClient;

namespace CarritoCompras.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date{ get; set; }
        public static List<Cart> Carts()
        {
            SqlConnection conx = Models.Connection.Connect();
            SqlCommand command = new SqlCommand("spCarts", conx);
            command.CommandType = CommandType.StoredProcedure;
            Cart c;
            List<Cart> list = new List<Cart>();
            conx.Open();
            SqlDataReader dr= command.ExecuteReader();
            while(dr.Read())
            {
                c = new Cart();
                c.Id = int.Parse(dr["Id"].ToString()!);
                c.UserId = int.Parse(dr["UserId"].ToString()!);
                c.Date = Convert.ToDateTime(dr["Date"].ToString());
                list.Add(c);
            }
            dr.Close();
            conx.Close();
            return list;
        }
    }
}
