using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCarrinhoBD.Modelo
{
    public class Carrinho
    {
        public string cod;
        public string descricao;
        public decimal valorUni;
        public int qnt;

        public Carrinho(string acod, string adescricao, decimal avalorUni)
        {
            cod = acod;
            descricao = adescricao;
            valorUni = avalorUni;
            qnt = 1;
        }

        private static List<Carrinho> carrinho = new List<Carrinho>();

        public static void Adicionar(Carrinho c)
        {
            foreach(Carrinho item in carrinho)
            {
                if(item.cod == c.cod)
                {
                    c.qnt = item.qnt + 1;
                    carrinho.Remove(item);
                    break;
                }
            }
            carrinho.Add(c);
        }

        public static List<Carrinho> Listar()
        {
            return carrinho;
        }

        public static void Limpar()
        {
            carrinho.Clear();
        }
    }
}