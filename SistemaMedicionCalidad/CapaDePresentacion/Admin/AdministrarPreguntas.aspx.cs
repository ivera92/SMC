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
        private static List<TextBox> lTxbRespuestas;
        private static List<CheckBox> lCbRespuestas;
        private static List<TextBox> lIdRespuesta;
        private static List<Respuesta> lRespuestas;
        private static TextBox txt;
        private static CheckBox cb;
        private static TextBox id;
        private static int id_pregunta;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            CatalogPregunta cPregunta = new CatalogPregunta();
            List<Tipo_Pregunta> lTipoPregunta = cPregunta.listarTiposPregunta();
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencia = cCompetencia.listarCompetencias();
            this.crearControles();
            this.editar.Visible = false;
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                lRespuestas = new List<Respuesta>();
                this.imgFoto.Visible = false;
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
            int id_pregunta = int.Parse(HttpUtility.HtmlDecode((string)(this.gvPreguntas.Rows[e.RowIndex].Cells[3].Text)));
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
        public void crearControles()
        {
            lTxbRespuestas = new List<TextBox>();
            lCbRespuestas = new List<CheckBox>();
            lIdRespuesta = new List<TextBox>();
            for (int i = 0; i < 4; i++)
            {
                txt = new TextBox();
                cb = new CheckBox();
                id = new TextBox();
                Panel p1 = new Panel();
                Panel p2 = new Panel();
                Panel p3 = new Panel();
                id.Visible = false;
                txt.Visible = false;
                cb.Visible = false;
                txt.ID = "txt" + i;
                cb.ID = "cb" + i;
                id.ID = "txtID" + i;
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
                lTxbRespuestas.Add(txt);
                lCbRespuestas.Add(cb);
                lIdRespuesta.Add(id);
            }
        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            id_pregunta = int.Parse(HttpUtility.HtmlDecode((string)this.gvPreguntas.Rows[e.NewEditIndex].Cells[3].Text));
            //this.crearControles(int.Parse(id_pregunta));
            CatalogPregunta cPregunta = new CatalogPregunta();
            Pregunta p = cPregunta.buscarUnaPregunta(id_pregunta);

            CatalogRespuesta cRespuesta = new CatalogRespuesta();
            lRespuestas = cRespuesta.listarRespuestasPregunta(id_pregunta);

            this.administrar.Visible = false;
            this.txtAPregunta.InnerText = p.Nombre_pregunta;
            this.ddCompetencia.SelectedValue = p.Competencia_pregunta.Id_competencia + "";
            this.ddTipoPregunta.SelectedValue = p.Tipo_pregunta_pregunta.Id_tipo_pregunta + "";
            
            //Se cargan las respuestas y si son correctas o no, esto mediante datos de la base 
            for(int i=0; i<lRespuestas.Count; i++)
            {
                lTxbRespuestas[i].Text = lRespuestas[i].Nombre_respuesta;
                lCbRespuestas[i].Checked = lRespuestas[i].Correcta_respuesta;
                lIdRespuesta[i].Text = lRespuestas[i].Id_respuesta+"";
                lTxbRespuestas[i].Visible = true;
                lCbRespuestas[i].Visible = true;
            }
            this.editar.Visible = true;
        }


        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            CatalogPregunta cPregunta = new CatalogPregunta();
            Pregunta p = new Pregunta();
            CatalogRespuesta cRespuesta = new CatalogRespuesta();
            Competencia c = new Competencia();
            Tipo_Pregunta tp = new Tipo_Pregunta();
            p.Competencia_pregunta = c;
            p.Tipo_pregunta_pregunta = tp;

            p.Competencia_pregunta.Id_competencia = int.Parse(this.ddCompetencia.SelectedValue);
            p.Tipo_pregunta_pregunta.Id_tipo_pregunta = int.Parse(this.ddTipoPregunta.SelectedValue);
            p.Nombre_pregunta = this.txtAPregunta.InnerText;
            p.Id_pregunta = id_pregunta;

            try
            {
                cPregunta.actualizarPregunta(p);
                for (int i = 0; i < lRespuestas.Count; i++)
                {
                    Respuesta r = new Respuesta();
                    Pregunta pp = new Pregunta();
                    r.Pregunta_respuesta = pp;

                    r.Nombre_respuesta = lTxbRespuestas[i].Text;
                    r.Correcta_respuesta = lCbRespuestas[i].Checked;
                    r.Id_respuesta = int.Parse(lIdRespuesta[i].Text);
                    cRespuesta.actualizarRespuesta(r);
                }
                Response.Write("<script>window.alert('Pregunta actualizada correctamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Pregunta no a podido ser actualizada');</script>");
            }
            this.editar.Visible = false;
        }
    }
}