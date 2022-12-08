<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ListaCliente.aspx.cs" Inherits="Teko.UI.Pages.ListaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <asp:Label ID="lblSessionMsg" runat="server" class="lead"/>
    <br /><hr /><br />
    <asp:GridView runat="server" ID="gv1" AutoGenerateColumns="false" CssClass="table table-responsive table-striped">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="Nome"/>
            <asp:BoundField DataField="Email" HeaderText="Email"/>
            
            
           
        </Columns>
    </asp:GridView>

</asp:Content>
