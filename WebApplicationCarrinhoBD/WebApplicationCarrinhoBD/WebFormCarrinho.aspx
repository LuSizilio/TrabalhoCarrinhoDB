<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCarrinho.aspx.cs" Inherits="WebApplicationCarrinhoBD.WebFormCarrinho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        td {
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Carrinho"></asp:Label><br />
            <br />
            <asp:TextBox ID="TextBox_Nome" runat="server" placeholder="Insira seu Nome"></asp:TextBox>
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" style="border: 1px solid black">
            </asp:Table>
            <asp:Button ID="Button1" runat="server" Text="Voltar" PostBackUrl="~/WebFormProdutos.aspx" />
            <asp:Button ID="Button_Finalizar" runat="server" Text="Finalizar Compra" OnClick="Button_Finalizar_Click" />
        </div>
    </form>
</body>
</html>
