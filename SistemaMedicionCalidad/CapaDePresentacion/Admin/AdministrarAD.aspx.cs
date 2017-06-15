using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Admin
{
    public partial class AdministrarAD : System.Web.UI.Page
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

        protected void gvAD_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAD.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
                this.gvAD.Visible = true;
                CatalogAsignaturaDesempeno cAD = new CatalogAsignaturaDesempeno();
                List<Asignatura_Desempeno> lAD = cAD.listarADBusqueda(txtBuscar.Text);
                this.gvAD.DataSource = lAD;
                this.DataBind();
            }
            else
            {
                this.mostrar();
            }
        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id_ad = HttpUtility.HtmlDecode((string)this.gvAD.Rows[e.RowIndex].Cells[1].Text);
            CatalogAsignaturaDesempeno cAD = new CatalogAsignaturaDesempeno();
            Asignatura_Desempeno ad = cAD.buscarAD(int.Parse(id_ad));
            if (cAD.verificarExistenciaEvaluacionAD(ad.Cod_asignatura.Cod_asignatura) == 0)
            {
                cAD.eliminarAD(ad.Id_ad);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Asociacion eliminada satisfactoriamente');window.location='AdministrarAD.aspx';</script>'");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Asignatura ya registra evaluaciones por ende no puede ser eliminada la asociacion');window.location='AdministrarAD.aspx';</script>'");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.gvAD.Visible = true;
            CatalogAsignaturaDesempeno cAD = new CatalogAsignaturaDesempeno();
            List<Asignatura_Desempeno> lAD = cAD.listarADBusqueda(txtBuscar.Text);
            this.gvAD.DataSource = lAD;
            this.DataBind();
        }

        public void mostrar()
        {
            this.gvAD.Visible = true;
            CatalogAsignaturaDesempeno cAD = new CatalogAsignaturaDesempeno();
            List<Asignatura_Desempeno> lAD = cAD.listarAD();
            this.gvAD.DataSource = lAD;
            this.DataBind();
        }
    }
}