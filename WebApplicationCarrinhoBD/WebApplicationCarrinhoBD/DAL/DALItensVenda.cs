using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationCarrinhoBD.DAL
{
    public class DALItensVenda
    {
        string connectionString = "";

        public DALItensVenda()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TrabalhoBDConnectionString"].ConnectionString;
        }

        public void Insert(Modelo.ItensVenda obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("insert into ItensVenda values(@idVenda, @codProd, @quant, @valorUni)", conn);
            cmd.Parameters.AddWithValue("@idVenda", obj.idVenda);
            cmd.Parameters.AddWithValue("@codProd", obj.codProd);
            cmd.Parameters.AddWithValue("@quant", obj.quant);
            cmd.Parameters.AddWithValue("@valorUni", obj.valorUni);
            // Executa Comando
            cmd.ExecuteNonQuery();

        }
    }
}