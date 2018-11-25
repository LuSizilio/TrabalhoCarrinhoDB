using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationCarrinhoBD.DAL
{
    public class DALVenda
    {
        string connectionString = "";

        public DALVenda()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TrabalhoBDConnectionString"].ConnectionString;
        }

        public int getLastId()
        {
            // Cria Lista Vazia
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "SELECT SCOPE_IDENTITY()";
            Int32 count = (Int32)cmd.ExecuteScalar();
            // Fecha Conexão
            conn.Close();

            return count;
        }

        public void Update(int id, decimal valorTotal)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("UPDATE Venda SET valorTotal = @valorTotal WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@valorTotal", valorTotal);
            cmd.ExecuteNonQuery();
        }

    }
}