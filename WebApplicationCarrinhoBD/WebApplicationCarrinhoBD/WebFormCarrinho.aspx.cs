using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplicationCarrinhoBD
{
    public partial class WebFormCarrinho : System.Web.UI.Page
    {
        List<Modelo.Carrinho> carrinho = Modelo.Carrinho.Listar();
        protected void Page_Load(object sender, EventArgs e)
        {
            TableRow tr;
            TableCell tc1, tc2, tc3, tc4;
            foreach(Modelo.Carrinho c in carrinho)
            {
                tr = new TableRow();
                tc1 = new TableCell();
                tc1.Text = c.cod;
                tr.Cells.Add(tc1);

                tc2 = new TableCell();
                tc2.Text = c.descricao;
                tr.Cells.Add(tc2);

                tc3 = new TableCell();
                tc3.Text = c.qnt.ToString();
                tr.Cells.Add(tc3);

                tc4 = new TableCell();
                tc4.Text = (c.valorUni * c.qnt).ToString();
                tr.Cells.Add(tc4);

                Table1.Rows.Add(tr);
            }
        }

        protected void Button_Finalizar_Click(object sender, EventArgs e)
        {
            decimal valorTotal;
            DAL.DALVenda DALVenda;
            Modelo.Venda Venda;
            Modelo.ItensVenda ItensVenda;

            string connectionString = ConfigurationManager.ConnectionStrings["TrabalhoBDConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                Venda = new Modelo.Venda(TextBox_Nome.Text);
                SqlCommand com = conn.CreateCommand();

                //Cria Venda sem valor
                SqlCommand cmd1 = new SqlCommand("insert into Venda values(GetDate(), @nomeCliente, -1)", conn);
                cmd1.Parameters.AddWithValue("@nomeCliente", Venda.nomeCliente);
                cmd1.Transaction = trans;
                cmd1.ExecuteNonQuery();

                //Pega id da venda criada
                DALVenda = new DAL.DALVenda();
                SqlCommand cmd4 = new SqlCommand("SELECT ident_current('Venda')", conn);
                cmd4.Transaction = trans;
                string idVenda = cmd4.ExecuteScalar().ToString();

                //Cria Itens venda e Pega valor total para venda
                valorTotal = 0;
                foreach (Modelo.Carrinho c in carrinho)
                {
                    ItensVenda = new Modelo.ItensVenda(int.Parse(idVenda),c.cod,c.qnt,c.valorUni,c.valorUni*c.qnt);
                    SqlCommand cmd2 = new SqlCommand("insert into ItensVenda values(@idVenda, @codProd, @quant, @valorUni, @valorTotal)", conn);
                    cmd2.Parameters.AddWithValue("@idVenda", ItensVenda.idVenda);
                    cmd2.Parameters.AddWithValue("@codProd", ItensVenda.codProd);
                    cmd2.Parameters.AddWithValue("@quant", ItensVenda.quant);
                    cmd2.Parameters.AddWithValue("@valorUni", ItensVenda.valorUni);
                    cmd2.Parameters.AddWithValue("@valorTotal", ItensVenda.valorTotal);
                    cmd2.Transaction = trans;
                    cmd2.ExecuteNonQuery();
                    valorTotal += (c.qnt * c.valorUni);
                }

                //Update no valor total da Venda
                SqlCommand cmd3 = new SqlCommand("UPDATE Venda SET valorTotal = @valorTotal WHERE id = @id", conn);
                cmd3.Parameters.AddWithValue("@id", idVenda);
                cmd3.Parameters.AddWithValue("@valorTotal", valorTotal);
                cmd3.Transaction = trans;
                cmd3.ExecuteNonQuery();

                if (valorTotal == 0) throw new Exception();
                
                //Finalizado com sucesso
                trans.Commit();
                Modelo.Carrinho.Limpar();
                Response.Redirect("~/WebFormProdutos.aspx");
            }
            catch
            {
                //Erro
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}