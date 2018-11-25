using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace WebApplicationCarrinhoBD.DAL
{
    public class DALProduto
    {
        string connectionString = "";

        public DALProduto()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TrabalhoBDConnectionString"].ConnectionString;
        }

        public Modelo.Produto Select(int id)
        {
            Modelo.Produto aProduto = new Modelo.Produto();
            // Cria Lista Vazia
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Produtos where id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    aProduto = new Modelo.Produto(
                    dr.GetInt32(0),
                    dr.GetString(1),
                    dr.GetString(2),
                    dr.GetDecimal(3)
                    );
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return aProduto;

        }
    }
}