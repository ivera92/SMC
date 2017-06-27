using System;
using System.Collections.Generic;
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
            try
            {
                string rut = Session["rutAdmin"].ToString();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
            
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            List<Desempeno> lDesempenos = cDesempeno.listarDesempenos();
            this.crearControles();
            this.editar.Visible = false;
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                VoF.Visible = false;
                AltOCas.Visible = true;
                lRespuestas = new List<Respuesta>();
                this.mostrar();

                this.ddDesempeno.DataTextField = "Indicador_desempeno";
                this.ddDesempeno.DataValueField = "Id_desempeno";
                this.ddDesempeno.DataSource = lDesempenos;

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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Registro eliminado satisfactoriamente');window.location='AdministrarPreguntas.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Pregunta esta en uso, por tanto no puede ser eliminada');window.location='AdministrarPreguntas.aspx';</script>'");
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
                
                id.Visible = false;
                txt.Visible = false;
                cb.Visible = false;
                Panel p1 = new Panel();
                Panel p2 = new Panel();
                Panel p3 = new Panel();

                txt.ID = "txt" + i;
                cb.ID = "cb" + i;
                id.ID = "txtID" + i;
                txt.CssClass = "form-control";
                p1.CssClass = "col-sm-5";
                p2.CssClass = "col-sm-1";
                p1.Controls.Add(txt);
                p2.Controls.Add(cb);
                p2.Controls.Add(id);
                p3.Controls.Add(p1);
                p3.Controls.Add(p2);
                p3.Controls.Add(new LiteralControl("<br/>"));
                Panel1.Controls.Add(p3);
                Panel1.Controls.Add(new LiteralControl("<br/>"));
                lTxbRespuestas.Add(txt);
                lCbRespuestas.Add(cb);
                lIdRespuesta.Add(id);
            }
        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            this.editar.Visible = true;
            id_pregunta = int.Parse(HttpUtility.HtmlDecode((string)this.gvPreguntas.Rows[e.NewEditIndex].Cells[2].Text));            
            CatalogPregunta cPregunta = new CatalogPregunta();
            Pregunta p = cPregunta.buscarUnaPregunta(id_pregunta);
            this.administrar.Visible = false;
            this.txtAPregunta.InnerText = p.Enunciado_pregunta;
            ddDesempeno.SelectedValue = p.Id_desempeno.Id_desempeno + "";
            this.cargarNiveles();
            ddNivel.SelectedValue = p.Nivel_pregunta.Id_nivel + "";
            CatalogRespuesta cRespuesta = new CatalogRespuesta();
            lRespuestas = cRespuesta.listarRespuestasPregunta(id_pregunta);
            if (p.Tipo_pregunta_pregunta.Nombre_tipo_pregunta== "Seleccion multiple" || p.Tipo_pregunta_pregunta.Nombre_tipo_pregunta== "Casillas de verificacion")
            {
                AltOCas.Visible = true;
                
                //Se cargan las respuestas y si son correctas o no, esto mediante datos de la base 
                for (int i = 0; i < lRespuestas.Count; i++)
                {
                    lTxbRespuestas[i].Text = lRespuestas[i].Nombre_respuesta;
                    lCbRespuestas[i].Checked = lRespuestas[i].Correcta_respuesta;
                    lIdRespuesta[i].Text = lRespuestas[i].Id_respuesta + "";
                    lTxbRespuestas[i].Visible = true;
                    lCbRespuestas[i].Visible = true;
                }                
            }
            else
            {
                cbV.Checked = lRespuestas[0].Correcta_respuesta;
                cbF.Checked = lRespuestas[1].Correcta_respuesta;
                AltOCas.Visible = false;
                VoF.Visible = true;
            }            
        }


        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            CatalogPregunta cPregunta = new CatalogPregunta();
            Pregunta p = new Pregunta();
            CatalogRespuesta cRespuesta = new CatalogRespuesta();
            CatalogTipoPregunta cTP = new CatalogTipoPregunta();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            CatalogNivel cNivel = new CatalogNivel();
            Competencia c = new Competencia();

            p.Id_pregunta = id_pregunta;
            p.Id_desempeno = cDesempeno.buscarUnDesempeno(int.Parse(ddDesempeno.SelectedValue));
            p.Enunciado_pregunta = this.txtAPregunta.InnerText;
            p.Id_pregunta = id_pregunta;
            p.Nivel_pregunta = cNivel.buscarNivel(int.Parse(ddNivel.SelectedValue));
            try
            {
                cPregunta.actualizarPregunta(p);
                if (AltOCas.Visible == true)
                {
                    for (int i = 0; i < lRespuestas.Count; i++)
                    {
                        Respuesta r = new Respuesta();
                        r.Pregunta_respuesta = cPregunta.buscarUnaPregunta(id_pregunta);
                        r.Nombre_respuesta = lTxbRespuestas[i].Text;
                        r.Correcta_respuesta = lCbRespuestas[i].Checked;
                        r.Id_respuesta = int.Parse(lIdRespuesta[i].Text);
                        cRespuesta.actualizarRespuesta(r);
                    }
                }
                else
                {
                    List<Respuesta> lRespuestas = cRespuesta.listarRespuestasPregunta(id_pregunta);
                    Respuesta v = lRespuestas[0];
                    Respuesta f = lRespuestas[1];

                    v.Correcta_respuesta = cbV.Checked;
                    f.Correcta_respuesta = cbF.Checked;

                    cRespuesta.actualizarRespuesta(v);
                    cRespuesta.actualizarRespuesta(f);

                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Pregunta actualizada correctamente');window.location='AdministrarPreguntas.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Pregunta no a podido ser actualizada');window.location='AdministrarPreguntas.aspx';</script>'");
            }
            this.editar.Visible = false;
        }

        protected void gvPreguntas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPreguntas.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
                gvPreguntas.Visible = true;
                CatalogPregunta cPregunta = new CatalogPregunta();
                List<Pregunta> lPreguntas = cPregunta.listarPreguntasBusqueda(txtBuscar.Text);
                this.gvPreguntas.DataSource = lPreguntas;
                this.DataBind();
            }
            else
            {
                this.mostrar();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvPreguntas.Visible = true;
            CatalogPregunta cPregunta = new CatalogPregunta();
            List<Pregunta> lPreguntas = cPregunta.listarPreguntasBusqueda(txtBuscar.Text);
            this.gvPreguntas.DataSource = lPreguntas;
            this.DataBind();
        }

        public void cargarNiveles()
        {
            this.editar.Visible = true;
            CatalogNivel cNivel = new CatalogNivel();
            List<Nivel> lNiveles = cNivel.listarNivelesDesempeno(int.Parse(ddDesempeno.SelectedValue));
            this.ddNivel.DataTextField = "Nombre_nivel";
            this.ddNivel.DataValueField = "Id_nivel";
            this.ddNivel.DataSource = lNiveles;

            this.DataBind();//enlaza los datos a un dropdownlist  
        }

        protected void ddDesempeno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargarNiveles();
        }

        protected void gvPreguntas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "activo")
            {
                // Recupera el índice de fila almacenado en el CommandArgument propiedad.
                int index = Convert.ToInt32(e.CommandArgument);

                // Recuperar la fila que contiene el botón de la Filas.
                GridViewRow row = gvPreguntas.Rows[index];
                int id_pregunta = int.Parse(HttpUtility.HtmlDecode(row.Cells[2].Text));
                string estado = HttpUtility.HtmlDecode(row.Cells[6].Text);
                bool estado_nuevo;
                if (estado == "Activo")
                {
                    estado_nuevo = false;
                }
                else
                {
                    estado_nuevo = true;
                }
                CatalogPregunta cPregunta = new CatalogPregunta();
                cPregunta.actualizarEstadoPregunta(id_pregunta, estado_nuevo);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Estado de pregunta cambiado satisfactoriamente');window.location='AdministrarPreguntas.aspx';</script>'");
            }
        }
    }
}