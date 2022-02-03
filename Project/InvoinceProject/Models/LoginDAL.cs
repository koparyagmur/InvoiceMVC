using Microsoft.AspNetCore.Http;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore;

namespace InvoinceProject.Models
{
    public class LoginDAL
    {
        string connectionString = "Server=.;Database=InvoiceDB;Integrated Security=true;";

        //Get the details of a particular Login Data    
        public Login GetLoginData(string UserName, string Password)
        {
            Login Users = new Login();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CheckUserName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Pw", Password);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                
                if (sdr.Read())
                {
                    Users.UserName = sdr["UserName"].ToString();
                    Users.Password = sdr["Pw"].ToString();
                }
                else
                {
                }
            }
            return Users;
        }
    }
}
