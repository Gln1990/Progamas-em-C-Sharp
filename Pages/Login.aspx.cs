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
    public partial class Login : System.Web.UI.Page
    {
        //limpar
        public void Limpar()
        {

            txtUser.Text = txtPassword.Text = string.Empty;
            txtUser.Focus();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {

            }
            txtUser.Focus();
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {

            string objNome = txtUser.Text.Trim();
            string objSenha = txtPassword.Text.Trim();

            UsuarioAutenticaDTO objModelo = new UsuarioAutenticaDTO();
            UsuarioBLL objAutentica = new UsuarioBLL();
            objModelo = objAutentica.AutenticarUser(objNome, objSenha);
            if (objModelo != null && objModelo.FKTpUsuario == "1")
            {
                Session["Usuario"] = txtUser.Text.Trim();
                Response.Redirect("ManagerUsuario.aspx");
            }
            else if (objModelo != null && objModelo.FKTpUsuario == "2")
            {
                lblMensagem.Text = "Você não tem privilégios para esta operação !!!";
                Limpar();
            }
            else
            {
                lblMensagem.Text = "Usuario não cadastrado !!!";
                Limpar();
            }


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}