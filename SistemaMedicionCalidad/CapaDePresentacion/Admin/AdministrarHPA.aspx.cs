using Project;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Admin
{
    public partial class AdministrarHPA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.mostrar();
            }
        }

        protected void gvHPA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHPA.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
                this.gvHPA.Visible = true;
                CatalogHPA cHPA = new CatalogHPA();
                List<HistoricoPruebaAlumno> lHPA = cHPA.listarHPABusqueda(txtBuscar.Text);
                this.gvHPA.DataSource = lHPA;
                this.DataBind();
            }
            else
            {
                this.mostrar();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.gvHPA.Visible = true;
            CatalogHPA cHPA = new CatalogHPA();
            List<HistoricoPruebaAlumno> lHPA = cHPA.listarHPABusqueda(txtBuscar.Text);
            this.gvHPA.DataSource = lHPA;
            this.DataBind();
        }
        public void mostrar()
        {
            this.gvHPA.Visible = true;
            CatalogHPA cHPA = new CatalogHPA();
            List<HistoricoPruebaAlumno> lHPA = cHPA.listarHPA();
            this.gvHPA.DataSource = lHPA;
            this.DataBind();
        }
    }
}