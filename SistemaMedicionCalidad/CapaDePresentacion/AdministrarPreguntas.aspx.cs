using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion
{
    public partial class AdministrarPreguntas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogPregunta cp = new CatalogPregunta();
            List<Tipo_Pregunta> ltp = cp.mostrarTiposPregunta();
            CatalogCompetencia cc = new CatalogCompetencia();
            List<Competencia> lc = cc.mostrarCompetencias();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.editar.Visible = false;
                this.mostrar();

                this.ddTipoPregunta.DataTextField = "Nombre_tipo_pregunta";
                this.ddTipoPregunta.DataValueField = "Id_tipo_pregunta";
                this.ddTipoPregunta.DataSource = ltp;

                this.ddCompetencia.DataTextField = "Nombre_competencia";
                this.ddCompetencia.DataValueField = "Id_competencia";
                this.ddCompetencia.DataSource = lc;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }

        public void mostrar()
        {
            this.txtid.Visible = false;
            this.gvPreguntas.Visible = true;
            CatalogPregunta cp = new CatalogPregunta();
            List<Pregunta> lp = cp.mostrarPreguntas(); 
            this.gvPreguntas.DataSource = lp;
            this.DataBind();
        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id_pregunta = int.Parse(HttpUtility.HtmlDecode((string)(this.gvPreguntas.Rows[e.RowIndex].Cells[2].Text)));
            CatalogPregunta cp = new CatalogPregunta();
            cp.eliminarPregunta(id_pregunta);
            Response.Redirect("AdministrarPreguntas.aspx");
        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            /*string id_pregunta = HttpUtility.HtmlDecode((string)this.gvPreguntas.Rows[e.NewEditIndex].Cells[2].Text);
            CatalogPregunta cp = new CatalogPregunta();
            Pregunta p = cp.buscarUnaPregunta(int.Parse(id_pregunta));
            CatalogCompetencia cc = new CatalogCompetencia();
            Competencia c = cc.buscarID(p.Id_competencia_pregunta);
            CatalogPregunta cpre = new CatalogPregunta();
            this.txtPregunta.Text = p.Nombre_pregunta;
            this.ddCompetencia.SelectedValue =c.Nombre_competencia;
            //this.ddTipoPregunta.SelectedIndex = p.Id_tipo_pregunta_pregunta - 1;
            this.administrar.Visible = false;
            this.editar.Visible = true;*/
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}