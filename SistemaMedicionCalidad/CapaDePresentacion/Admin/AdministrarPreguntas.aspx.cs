using System;
using System.Collections.Generic;
using System.Threading;
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
            CatalogPregunta cPregunta = new CatalogPregunta();
            List<Tipo_Pregunta> lTipoPregunta = cPregunta.listarTiposPregunta();
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencia = cCompetencia.listarCompetencias();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.editar.Visible = false;
                this.mostrar();

                this.ddTipoPregunta.DataTextField = "Nombre_tipo_pregunta";
                this.ddTipoPregunta.DataValueField = "Id_tipo_pregunta";
                this.ddTipoPregunta.DataSource = lTipoPregunta;

                this.ddCompetencia.DataTextField = "Nombre_competencia";
                this.ddCompetencia.DataValueField = "Id_competencia";
                this.ddCompetencia.DataSource = lCompetencia;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }

        public void mostrar()
        {
            this.txtid.Visible = false;
            this.gvPreguntas.Visible = true;
            CatalogPregunta cPregunta = new CatalogPregunta();
            List<Pregunta> lPreguntas = cPregunta.listarPreguntas(); 
            this.gvPreguntas.DataSource = lPreguntas;
            this.DataBind();
        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id_pregunta = int.Parse(HttpUtility.HtmlDecode((string)(this.gvPreguntas.Rows[e.RowIndex].Cells[2].Text)));
            CatalogPregunta cPregunta = new CatalogPregunta();
            CatalogRespuesta cRespuesta = new CatalogRespuesta();

            try
            {
                cRespuesta.eliminarRespuestas(id_pregunta);
                cPregunta.eliminarPregunta(id_pregunta);
                Response.Write("<script>window.alert('Registro eliminado satisfactoriamente');</script>");
                Thread.Sleep(1500);
                this.mostrar();
            }
            catch
            {
                Response.Write("<script>window.alert('Registro no a podido ser eliminado');</script>");
            }

        }
        
        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            string id_pregunta = HttpUtility.HtmlDecode((string)this.gvPreguntas.Rows[e.NewEditIndex].Cells[2].Text);

            CatalogPregunta cPregunta = new CatalogPregunta();
            Pregunta p = cPregunta.buscarUnaPregunta(int.Parse(id_pregunta));

            CatalogRespuesta cRespuesta = new CatalogRespuesta();
            List<Respuesta> lRespuestas = cRespuesta.listarRespuestasPregunta(int.Parse(id_pregunta));

            this.administrar.Visible = false;            
            this.txtAPregunta.InnerText = p.Nombre_pregunta;
            this.ddCompetencia.SelectedValue = p.Competencia_pregunta.Id_competencia+"";
            this.ddTipoPregunta.SelectedValue = p.Tipo_pregunta_pregunta.Id_tipo_pregunta+"";

            foreach (Respuesta item in lRespuestas)
            {
                //Si es seleccion multiple o casilla de verificacion
                if (p.Tipo_pregunta_pregunta.Id_tipo_pregunta == 1 || p.Tipo_pregunta_pregunta.Id_tipo_pregunta == 2)
                {
                    Panel p1 = new Panel();
                    Panel p2 = new Panel();
                    Panel p3 = new Panel();
                    TextBox txt = new TextBox();
                    CheckBox cb = new CheckBox();
                    TextBox id = new TextBox();

                    txt.Text = item.Nombre_respuesta;
                    cb.Checked = item.Correcta_respuesta;
                    id.Text = item.Id_respuesta + "";
                    id.Visible = false;
                    txt.CssClass = "form-control";

                    p3.CssClass = "row";
                    p1.CssClass = "col-sm-offset-3 col-sm-5";
                    p2.CssClass = "col-sm-1";
                    p1.Controls.Add(txt);
                    p2.Controls.Add(cb);
                    p2.Controls.Add(id);
                    p3.Controls.Add(p1);
                    p3.Controls.Add(p2);
                    Panel1.Controls.Add(p3);
                    Panel1.Controls.Add(new LiteralControl("<br/>"));
                }
                //Si es verdadero o falso
                else if(p.Tipo_pregunta_pregunta.Id_tipo_pregunta == 2)
                {

                }                
            }
            this.editar.Visible = true;
        }

        /*protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogPregunta cp = new CatalogPregunta();
            Pregunta p = new Pregunta();
            Competencia c = new Competencia();
            Tipo_Pregunta tp = new Tipo_Pregunta();
            p.Competencia_pregunta = c;
            p.Tipo_pregunta_pregunta = tp;

            p.Competencia_pregunta.Id_competencia = this.ddCompetencia.SelectedIndex;
            p.Tipo_pregunta_pregunta.Id_tipo_pregunta = this.ddTipoPregunta.SelectedIndex;
            p.Nombre_pregunta = this.txtPregunta.Text;
        }*/
    }
}