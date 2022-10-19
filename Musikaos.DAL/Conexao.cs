using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//
using System.Configuration;

namespace Musikaos.DAL
{
    public class Conexao
    {
        //variaveis
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader dr;

        //metodos
        protected void Conectar()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MusikaosConnectionString"].ConnectionString;

                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        
        }

        protected void Desconectar()
        {
            try
            {
               
                conn.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

    }
}
