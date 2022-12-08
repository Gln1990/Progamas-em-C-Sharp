using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teko.BLL;
using Teko.DTO;

namespace Teko.UI.Pages
{
    public partial class ManagerUsuario : System.Web.UI.Page
    {
        UsuarioDTO objModelo = new UsuarioDTO();
        UsuarioBLL objBLL = new UsuarioBLL();
        //metodo Populargv
        public void PopularGV()
        {
            gv1.DataSource = objBLL.ListarUsuario();
            gv1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularGV();
                lblMessage.Text = String.Empty;
            }
            //iniciando session
            //if (Session["Usuario"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            //lblSessionMsg.Text = "Seja bem vindo " + Session["Usuario"] + " a MusiCaos !!";

        }

        protected void gv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Add"))
            {
                objModelo.NomeUsuario = (gv1.FooterRow.FindControl("txtNomeUsuarioFooter") as TextBox).Text.Trim();
                objModelo.SenhaUsuario = (gv1.FooterRow.FindControl("txtSenhaUsuarioFooter") as TextBox).Text.Trim();
                objModelo.EmailUsuario = (gv1.FooterRow.FindControl("txtEmailUsuarioFooter") as TextBox).Text.Trim();
                objModelo.FKTpUsuario = (gv1.FooterRow.FindControl("rbl1") as RadioButtonList).Text.Trim();

                objBLL.CadastraUsuario(objModelo);
                PopularGV();
                (gv1.FooterRow.FindControl("txtNomeUsuarioFooter") as TextBox).Focus();
                lblMessage.Text = "Usuário " + objModelo.NomeUsuario + " cadastrado com Sucesso !!";
            }
        }

        protected void gv1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objModelo.NomeUsuario = (gv1.Rows[e.RowIndex].FindControl("txtNomeUsuario") as TextBox).Text.Trim();
            objModelo.SenhaUsuario = (gv1.Rows[e.RowIndex].FindControl("txtSenhaUsuario") as TextBox).Text.Trim();
            objModelo.EmailUsuario = (gv1.Rows[e.RowIndex].FindControl("txtEmailUsuario") as TextBox).Text.Trim();
            objModelo.FKTpUsuario = (gv1.Rows[e.RowIndex].FindControl("rbl1") as RadioButtonList).Text.Trim();
            objModelo.IdUsuario = Convert.ToInt32(gv1.DataKeys[e.RowIndex].Value.ToString());
            objBLL.EditarUsuario(objModelo);
            gv1.EditIndex = -1;
            PopularGV();
            lblMessage.Text = "Usuário " + objModelo.NomeUsuario + " editado com Sucesso !!";

        }


        protected void gv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objModelo.IdUsuario = Convert.ToInt32(gv1.DataKeys[e.RowIndex].Value.ToString());
            objBLL.ExcluirUsuario(objModelo.IdUsuario);
            PopularGV();
            lblMessage.Text = "Usuário " + objModelo.NomeUsuario + " eliminado com Sucesso !!";
        }

        protected void gv1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv1.EditIndex = e.NewEditIndex;
            PopularGV();
        }

        protected void gv1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv1.EditIndex = -1;
            PopularGV();
        }
    }

}

