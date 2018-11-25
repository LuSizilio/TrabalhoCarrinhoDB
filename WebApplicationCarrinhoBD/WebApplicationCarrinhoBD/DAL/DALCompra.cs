using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationCarrinhoBD.DAL
{
    public class DALCompra
    {
        string connectionString = "";

        public DALCompra()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TrabalhoBDConnectionString"].ConnectionString;
        }
    }
}