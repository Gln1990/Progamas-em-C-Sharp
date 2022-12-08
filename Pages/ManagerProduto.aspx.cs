using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teko.BLL;//
using Teko.DTO;//

namespace Teko.UI.Pages
{
    public partial class ManagerProduto : System.Web.UI.Page
    {
        ProdutoDTO objModelo = new ProdutoDTO();
        ProdutoBLL objBLL = new ProdutoBLL();

        public void PopularGV()
        {
            gv2.DataSource = objBLL.ListarProduto();
            gv2.DataBind();
            lblMessage.Text = string.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopularGV();
            }

        }


        //cadastrar (add)
        protected void gv2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Adicionar"))
            {
                objModelo.NomeProduto = (gv2.FooterRow.FindControl("txtNomeProdutoFooter") as TextBox).Text.Trim();

                objModelo.PrecoProduto = (gv2.FooterRow.FindControl("txtPrecoProdutoFooter") as TextBox).Text.Trim();


                //saving image
                if ((gv2.FooterRow.FindControl("fUp1") as FileUpload).HasFile)
                {
                    var str = (gv2.FooterRow.FindControl("fUp1") as FileUpload).FileName.Trim();

                    (gv2.FooterRow.FindControl("fUp1") as FileUpload).PostedFile.SaveAs(Server.MapPath("~/Img" + "/" + str));
                    string CaminhoImg = "~/Img" + "/" + str.ToString();
                    objModelo.UrlImagemProduto = CaminhoImg;

                }
                objModelo.FKCategoriaProduto = (gv2.FooterRow.FindControl("ddl1") as DropDownList).Text.Trim();
                //chamando o metodo
                objBLL.CadastraProduto(objModelo);
                PopularGV();
                (gv2.FooterRow.FindControl("txtNomeProdutoFooter") as TextBox).Focus();
                lblMessage.Text = "Produto " + objModelo.NomeProduto + " cadastrado com sucesso!!";



            }

        }

        //edit
        protected void gv2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv2.EditIndex = e.NewEditIndex;
            PopularGV();
        }

        //cancel
        protected void gv2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv2.EditIndex = -1;
            PopularGV();
        }

        //save
        protected void gv2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objModelo.NomeProduto = (gv2.Rows[e.RowIndex].FindControl("txtNomeProduto") as TextBox).Text.Trim();

            objModelo.PrecoProduto =(gv2.Rows[e.RowIndex].FindControl("txtPrecoProduto") as TextBox).Text.Trim();

            //saving image
            if ((gv2.Rows[e.RowIndex].FindControl("fUp1") as FileUpload).HasFile)
            {
                var str = (gv2.Rows[e.RowIndex].FindControl("fUp1") as FileUpload).FileName.Trim();

                (gv2.Rows[e.RowIndex].FindControl("fUp1") as FileUpload).PostedFile.SaveAs(Server.MapPath("~/Img" + "/" + str));
                string CaminhoImg = "~/Img" + "/" + str.ToString();
                objModelo.UrlImagemProduto = CaminhoImg;

            }


            objModelo.FKCategoriaProduto = (gv2.Rows[e.RowIndex].FindControl("ddl1") as DropDownList).Text.Trim();

            objModelo.IdProduto = Convert.ToInt32(gv2.DataKeys[e.RowIndex].Value.ToString());

            //chamando o metodo
            objBLL.EditarProduto(objModelo);

            gv2.EditIndex = -1;
            PopularGV();
            lblMessage.Text = "O Produto " + objModelo.NomeProduto + " foi editado com sucesso!!";

            
        }

        protected void gv2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objModelo.IdProduto = Convert.ToInt32(gv2.DataKeys[e.RowIndex].Value.ToString());
            objBLL.ExcluirProduto(objModelo.IdProduto);
            PopularGV();
            (gv2.FooterRow.FindControl("txtNomeProdutoFooter") as TextBox).Focus();

            lblMessage.Text = "O Produto " + objModelo.NomeProduto + " foi eliminado com sucesso!!";

            
           
        }

        protected void gv2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv2.PageIndex = e.NewPageIndex;
            this.PopularGV();
        }
    }
}