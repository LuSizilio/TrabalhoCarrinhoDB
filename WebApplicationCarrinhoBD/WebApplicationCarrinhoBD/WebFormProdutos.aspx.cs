using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCarrinhoBD
{
    public partial class WebFormProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView_Produtos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Adicionar")
            {
                string codigo;

                // Le o numero da linha selecionada
                int index = Convert.ToInt32(e.CommandArgument);

                // Copia o conteúdo da primeira célula da linha -> Código do Livro
                codigo = GridView_Produtos.Rows[index].Cells[0].Text;

                DAL.DALProduto DALProduto = new DAL.DALProduto();
                Modelo.Produto p = DALProduto.Select(int.Parse(codigo));
                Modelo.Carrinho c = new Modelo.Carrinho(p.cod,p.descricao,p.valorUni);
                Modelo.Carrinho.Adicionar(c);
            }
        }
    }
}