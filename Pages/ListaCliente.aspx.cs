using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teko.BLL;

namespace Teko.UI.Pages
{
    public partial class ListaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteBLL objBLL = new ClienteBLL();
            gv1.DataSource = objBLL.ListarCliente();
          
            gv1.DataBind();

            //iniciando session
            //if (Session["Usuario"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            //lblSessionMsg.Text = "Seja bem vindo " + Session["Usuario"] + " a Teko Clothes !!";
        }
    }
}