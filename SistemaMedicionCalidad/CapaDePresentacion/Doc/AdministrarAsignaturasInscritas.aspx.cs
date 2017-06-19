using Project;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Doc
{
    public partial class AdministrarAsignaturasInscritas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutDocente"].ToString();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string rut = Session["rutDocente"].ToString();
            this.txtId.Visible = false;
            this.gvCursa.Visible = true;
            CatalogCursa cCursa = new CatalogCursa();
            List<Cursa> lCursa = cCursa.listarCursaDocenteBusqueda(rut, txtBuscar.Text);
            this.gvCursa.DataSource = lCursa;
            this.DataBind();
        }

        protected void gvCursa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCursa.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
                this.gvCursa.Visible = true;
                CatalogCursa cCursa = new CatalogCursa();
                List<Cursa> lCursa = cCursa.listarAsignaturasInscritasBusqueda(txtBuscar.Text);
                this.gvCursa.DataSource = lCursa;
                this.DataBind();
            }
            else
            {
                this.mostrar();
            }
        }
        public void mostrar()
        {
            string rut = Session["rutDocente"].ToString();
            this.txtId.Visible = false;
            this.gvCursa.Visible = true;
            CatalogCursa cCursa = new CatalogCursa();
            List<Cursa> lCursa = cCursa.listarCursaDocente(rut);
            this.gvCursa.DataSource = lCursa;
            this.DataBind();
        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string nombre_alumno = HttpUtility.HtmlDecode((string)(this.gvCursa.Rows[e.RowIndex].Cells[1].Text));
                string nombre_asignatura = HttpUtility.HtmlDecode((string)(this.gvCursa.Rows[e.RowIndex].Cells[2].Text));
                CatalogCursa cCursa = new CatalogCursa();
                CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                if (cEvaluacion.verificarAlumnoEvaluadoAsignatura(nombre_alumno, nombre_asignatura) == 0)
                {
                    cCursa.eliminarCursaDocente(nombre_alumno, nombre_asignatura);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Registro eliminado satisfactoriamente');window.location='AdministrarAsignaturasInscritas.aspx';</script>'");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Registro no a podido ser eliminado puesto que el alumno ya se encuentra evaluado');window.location='AdministrarAsignaturasInscritas.aspx';</script>'");
                }
            }
            catch { }
        }
    }
}