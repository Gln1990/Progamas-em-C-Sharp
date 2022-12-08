<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ConsultaProduto.aspx.cs" Inherits="Teko.UI.Pages.ConsultaProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:Label runat="server" Text="Selecione a opção desejada" />  
    <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl1_SelectedIndexChanged" CssClass="dropdown dropdown-menu-dark" Width="200">
        <asp:ListItem  Text="Brincos" Value="Brincos"/>
         <asp:ListItem  Text="Correntes" Value="Correntes"/>
         <asp:ListItem  Text="Pulseiras" Value="Pulseiras"/>
         <asp:ListItem  Text="Aneis" Value="Aneis"/>
    </asp:DropDownList> 
    <asp:Button runat="server" Text="Limpar Filtro" ID="btnLimpaFiltro" OnClick="btnLimpaFiltro_Click" CssClass="btn btn-sm btn-dark"/>
      <asp:Label ID="lblSessionMsg" runat="server" class="lead"/>
    <br /><hr /><br />
    <asp:GridView runat="server" ID="gv2" AutoGenerateColumns="false" CssClass="table table-responsive table-striped">
        <Columns>
            <asp:BoundField DataField="NomeProduto" HeaderText="Produto" />
            <asp:BoundField DataField="PrecoProduto" HeaderText="Preço" />
            <asp:ImageField DataImageUrlField="UrlImagemProduto" HeaderText="Imagem" ControlStyle-Width="100" ControlStyle-Height="100" />
            <asp:BoundField DataField="NomeCategoria" HeaderText="Categoria" />
        </Columns>
    </asp:GridView>



</asp:Content>
