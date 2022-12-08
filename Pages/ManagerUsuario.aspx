<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ManagerUsuario.aspx.cs" Inherits="Teko.UI.Pages.ManagerUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblSessionMsg" runat="server" class="lead"/>
    <br /><hr /><br />

    <asp:GridView runat="server" ID="gv1" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="IdUsuario"
        OnRowCommand="gv1_RowCommand"
        OnRowUpdating="gv1_RowUpdating"
        OnRowDeleting="gv1_RowDeleting"
        OnRowEditing="gv1_RowEditing"
        OnRowCancelingEdit="gv1_RowCancelingEdit"
        CssClass="table table-responsive table-striped">
        <Columns>

            <asp:TemplateField HeaderText="Nome">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("NomeUsuario") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNomeUsuario" runat="server" MaxLength="50" Text='<%#Eval("NomeUsuario") %>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtNomeUsuarioFooter" runat="server" MaxLength="50" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Senha">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("SenhaUsuario") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtSenhaUsuario" runat="server" MaxLength="6" Text='<%#Eval("SenhaUsuario") %>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtSenhaUsuarioFooter" runat="server" MaxLength="6"/>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("EmailUsuario") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmailUsuario" runat="server" MaxLength="50" Text='<%#Eval("EmailUsuario") %>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtEmailUsuarioFooter" runat="server" MaxLength="50"/>
                </FooterTemplate>
            </asp:TemplateField>


            <%--radio buttons--%>
            <asp:TemplateField HeaderText="Tipo Usuario">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("DescricaoTpUsuario") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:RadioButtonList ID="rbl1" runat="server">
                        <asp:ListItem Value="1" Text=" Administrador" />
                        <asp:ListItem Value="2" Text=" Outros" />
                    </asp:RadioButtonList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:RadioButtonList ID="rbl1" runat="server">
                        <asp:ListItem Value="1" Text=" Administrador" />
                        <asp:ListItem Value="2" Text=" Outros" />
                    </asp:RadioButtonList>
                </FooterTemplate>
            </asp:TemplateField>



            <asp:TemplateField HeaderText="Opções">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Img/edit.png" ToolTip="Editar" Width="30" Height="30" CommandName="Edit" />
                    <asp:ImageButton ID="btnExcluir" runat="server" ImageUrl="~/Img/delete.png" ToolTip="Excluir" Width="30" Height="30" CommandName="Delete" OnClientClick="if (!confirm('Deseja relmente eliminar este registro??'))return false"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="btnSalvar" runat="server" ImageUrl="~/Img/save.png" ToolTip="Salvar" Width="30" Height="30" CommandName="Update" />
                    <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Img/cancel.png" ToolTip="Cancelar" Width="30" Height="30" CommandName="Cancel" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton ID="btnAdicionar" runat="server" ImageUrl="~/Img/add.png" ToolTip="Adicionar" Width="30" Height="30" CommandName="Add" />
                </FooterTemplate>
            </asp:TemplateField>


        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblMessage" runat="server" Text="Label" />


</asp:Content>
