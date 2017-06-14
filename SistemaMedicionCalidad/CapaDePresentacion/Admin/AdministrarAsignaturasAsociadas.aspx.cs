using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Admin
{
    public partial class AdministrarAsignaturasAsociadas : System.Web.UI.Page
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

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id_imparte = int.Parse(HttpUtility.HtmlDecode((string)(this.gvImparte.Rows[e.RowIndex].Cells[1].Text)));
                CatalogImparte cImparte = new CatalogImparte();
                CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                Imparte i = cImparte.buscarUnImparte(id_imparte);
                if (cEvaluacion.verificarDocenteEvaluacion(i.Rut_docente_imparte.Rut_persona) == 0)
                {
                    cImparte.eliminarImparte(i.Id_imparte);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Registro eliminado satisfactoriamente');window.location='AdministrarAsignaturasAsociadas.aspx';</script>'");

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Registro no a podido ser eliminado puesto que el docente ya registra evaluaciones');window.location='AdministrarAsignaturasAsociadas.aspx';</script>'");
                }
            }
            catch { }
        }

        protected void gvImparte_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvImparte.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
                this.txtId.Visible = false;
                this.gvImparte.Visible = true;
                CatalogImparte cImparte = new CatalogImparte();
                List<Imparte> lImparte = cImparte.listarAsignaturasAsociadasBusqueda(txtBuscar.Text);
                this.gvImparte.DataSource = lImparte;
                this.DataBind();
            }
            else
            {
                this.mostrar();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.txtId.Visible = false;
            this.gvImparte.Visible = true;
            CatalogImparte cImparte = new CatalogImparte();
            List<Imparte> lImparte = cImparte.listarAsignaturasAsociadasBusqueda(txtBuscar.Text);
            this.gvImparte.DataSource = lImparte;
            this.DataBind();
        }
        public void mostrar()
        {
            this.txtId.Visible = false;
            this.gvImparte.Visible = true;
            CatalogImparte cImparte = new CatalogImparte();
            List<Imparte> lImparte = cImparte.listarAsignaturasAsociadas();
            this.gvImparte.DataSource = lImparte;
            this.DataBind();
        }
    }
}