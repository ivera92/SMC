using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Admin
{
    public partial class AdministrarCD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutAdmin"].ToString();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                txtId.Visible = false;
                this.mostrar();
            }
        }

        public void mostrar()
        {
            this.gvCD.Visible = true;
            CatalogCompetenciaDesempeno cCD = new CatalogCompetenciaDesempeno();
            List<Competencia_Desempeno> lCD = cCD.listarCD();
            this.gvCD.DataSource = lCD;
            this.DataBind();
        }

        protected void gvCompetencias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCD.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
                this.gvCD.Visible = true;
                CatalogCompetenciaDesempeno cCD = new CatalogCompetenciaDesempeno();
                List<Competencia_Desempeno> lCD = cCD.listarCDBusqueda(txtBuscar.Text);
                this.gvCD.DataSource = lCD;
                this.DataBind();
            }
            else
            {
                this.mostrar();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.gvCD.Visible = true;
            CatalogCompetenciaDesempeno cCD = new CatalogCompetenciaDesempeno();
            List<Competencia_Desempeno> lCD = cCD.listarCDBusqueda(txtBuscar.Text);
            this.gvCD.DataSource = lCD;
            this.DataBind();
        }
    }
}