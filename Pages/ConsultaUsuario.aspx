<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ConsultaUsuario.aspx.cs" Inherits="Teko.UI.Pages.ConsultaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <asp:Label ID="lblSessionMsg" runat="server" class="lead"/>
    <br /><hr /><br />
    <asp:GridView runat="server" ID="gv1" AutoGenerateColumns="false" CssClass="table table-responsive table-striped">
        <Columns>
            <asp:BoundField DataField="NomeUsuario" HeaderText="Nome"/>
            <asp:BoundField DataField="EmailUsuario" HeaderText="Email"/>
            <asp:BoundField DataField="DescricaoTpUsuario" HeaderText="Tipo Usuário"/>
            
           
        </Columns>
    </asp:GridView>





</asp:Content>
