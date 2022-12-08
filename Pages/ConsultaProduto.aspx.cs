using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;//
using System.Data;//
using System.Data.SqlClient;//
using Teko.BLL;//

namespace Teko.UI.Pages
{
    public partial class ConsultaProduto : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        ProdutoBLL objBLL = new ProdutoBLL();


        //metodo popular gv
        public void PopularGV()
        {
            gv2.DataSource = objBLL.FiltrarProduto();
            gv2.DataBind();
        }

        //metodo limpar filtro
        protected void btnLimpaFiltro_Click(object sender, EventArgs e)
        {
            PopularGV();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            PopularGV();
        }

        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TekoConnectionString"].ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT NomeProduto,UrlImagemProduto,PrecoProduto,NomeCategoria FROM Produto JOIN Categoria ON FKCategoriaProduto=IdCategoria WHERE NomeCategoria='" + ddl1.SelectedItem.ToString() + "'", conn))
                    {
                        da.Fill(dt);
                        gv2.DataSource = dt;
                        gv2.DataBind();
                    };
                }
            };
        }
    }
}