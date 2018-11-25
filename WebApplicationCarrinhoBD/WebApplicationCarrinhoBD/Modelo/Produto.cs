using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCarrinhoBD.Modelo
{
    public class Produto
    {
        public int id { get; set; }   
        public string cod { get; set; }
        public string descricao { get; set; }
        public decimal valorUni { get; set; }

        public Produto()
        {
            id = 0;
            cod = "";
            descricao = "";
            valorUni = 0;
        }

        public Produto(int aid, string acod, string adescricao, decimal avalorUni)
        {
            id = aid;
            cod = acod;
            descricao = adescricao;
            valorUni = avalorUni;
        }
    }
}