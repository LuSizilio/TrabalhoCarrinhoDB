using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCarrinhoBD.Modelo
{
    public class ItensVenda
    {
        public int id { get; set; }
        public int idVenda { get; set; }
        public string codProd { get; set; }
        public int quant { get; set; }
        public decimal valorUni { get; set; }
        public decimal valorTotal { get; set; }

        public ItensVenda(int aidVenda, string acodProd, int aquant, decimal avalorUni, decimal avalorTotal)
        {
            idVenda = aidVenda;
            codProd = acodProd;
            quant = aquant;
            valorUni = avalorUni;
            valorTotal = avalorTotal;
        }
    }
}