﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion.Doc
{
    public partial class CrearPregunta : System.Web.UI.Page
    {
        private static List<TextBox> lTxbRespuestas;
        private static List<CheckBox> lCbRespuestas;
        private static TextBox txt;
        private static CheckBox cb;
        private static int contadorControles;
        private static string ruta;
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
            CatalogTipoPregunta cTipoPregunta = new CatalogTipoPregunta();
            List<Tipo_Pregunta> lTiposPregunta = cTipoPregunta.listarTipoPreguntas();
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencias = cCompetencia.listarCompetencias();
            this.crearRespuestas();
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                ruta = "";
                this.VoF.Visible = false;
                this.AltOCas.Visible = false;
                this.btnCrear.Visible = false;
                this.btnSeguir.Visible = false;
                contadorControles = 0;

                this.ddTipoPregunta.DataTextField = "Nombre_tipo_pregunta";
                this.ddTipoPregunta.DataValueField = "Id_tipo_pregunta";                
                this.ddTipoPregunta.DataSource = lTiposPregunta;

                this.ddCompetencia.DataTextField = "Nombre_competencia";
                this.ddCompetencia.DataValueField = "Id_competencia";
                //ddCompetencia.ToolTip = ddCompetencia.DataValueField = "Descripcion_Competencia";
                this.ddCompetencia.DataSource = lCompetencias;
                int i= 0;
                foreach (ListItem item in ddCompetencia.Items)
                {
                    if (i == 0) { }
                    else {
                        //item.Attributes.Add("Title", lCompetencias[i].Descripcion_competencia+"Si entro");
                    }
                    i += 1;
                }

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
            try
            {
                for (int i = 0; i < contadorControles; i++)
                {
                    agregarControles(lTxbRespuestas[i], lCbRespuestas[i]);
                }
            }
            catch
            {
            }
        }

        public void Tooltip(DropDownList dd)
        {
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencias = cCompetencia.listarCompetencias();
            for (int d = 0; d < dd.Items.Count; d++)
            {
                //dd.Items[d].Attributes.Add("title", lCompetencias[d].Descripcion_competencia);
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            this.divCrear.Visible = false;
            this.btnSeguir.Visible = true;
            int i = 0;
            CatalogPregunta cp = new CatalogPregunta();
            CatalogRespuesta cr = new CatalogRespuesta();

            Pregunta p = new Pregunta();
            Tipo_Pregunta tp = new Tipo_Pregunta();
            p.Tipo_pregunta_pregunta = tp;
            int id = 0;
            try
            {
                try
                {
                    this.subirImagen();//Guarda la imagen en la carpeta ImagenesPreguntas ubicada en la carpeta Doc
                }
                catch { }
                //p.Competencia_pregunta.Id_competencia = int.Parse(this.ddCompetencia.SelectedValue);
                p.Tipo_pregunta_pregunta.Id_tipo_pregunta = int.Parse(this.ddTipoPregunta.SelectedValue);
                p.Enunciado_pregunta = this.txtAPregunta.InnerText;
                p.Imagen_pregunta = ruta;
                //p.Nivel_pregunta = txtNivel.Text.ToUpper().Trim();
                cp.insertarPregunta(p);
                id = cp.ultimaPregunta();

                Pregunta pp = new Pregunta();
                //Preguntamos si es Tipo Verdadero o falso
                if (int.Parse(ddTipoPregunta.SelectedValue) == 3)
                {
                    Respuesta rV = new Respuesta();
                    rV.Pregunta_respuesta = pp;

                    rV.Pregunta_respuesta.Id_pregunta = id;
                    rV.Nombre_respuesta = lblV.InnerText;
                    rV.Correcta_respuesta = cbV.Checked;


                    Respuesta rF = new Respuesta();
                    rF.Pregunta_respuesta = pp;

                    rF.Pregunta_respuesta.Id_pregunta = id;
                    rF.Nombre_respuesta = lblF.InnerText;
                    rF.Correcta_respuesta = cbF.Checked;

                    cr.insertarRespuesta(rV);
                    cr.insertarRespuesta(rF);
                }
                else
                {
                    while (lTxbRespuestas[i] != null)
                    {
                        Respuesta rr = new Respuesta();
                        rr.Pregunta_respuesta = pp;

                        rr.Pregunta_respuesta.Id_pregunta = id;
                        rr.Nombre_respuesta = lTxbRespuestas[i].Text;
                        rr.Correcta_respuesta = lCbRespuestas[i].Checked;
                        cr.insertarRespuesta(rr);
                        i++;
                    }
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Pregunta creada satisfactoriamente');window.location='CrearPregunta.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Pregunta no a podido ser creada');window.location='CrearPregunta.aspx';</script>'");
            }
        }
        public void agregarControles(TextBox txt, CheckBox cb)
        {
            Panel p1 = new Panel();
            Panel p2 = new Panel();
            Panel p3 = new Panel();
            p3.CssClass = "row";
            p1.CssClass = "col-sm-offset-3 col-sm-5";
            p2.CssClass = "col-sm-1";
            p1.Controls.Add(txt);
            p2.Controls.Add(cb);
            p3.Controls.Add(p1);
            p3.Controls.Add(p2);
            Panel1.Controls.Add(p3);
            Panel1.Controls.Add(new LiteralControl("<br/>"));
        }

        public void crearRespuestas()
        {
            lTxbRespuestas = new List<TextBox>();
            lCbRespuestas = new List<CheckBox>();
            for (int i = 0; i < 4; i++)
            {
                txt = new TextBox();
                cb = new CheckBox();
                txt.CssClass = "form-control";
                lTxbRespuestas.Add(txt);
                lCbRespuestas.Add(cb);

                agregarControles(txt, cb);
            }
        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            this.crearRespuestas();
        }

        protected void ddTipoPregunta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(ddTipoPregunta.SelectedValue) == 1 || int.Parse(ddTipoPregunta.SelectedValue) == 2)
            {
                this.btnCrear.Visible = true;
                this.VoF.Visible = false;
                this.AltOCas.Visible = true;
            }
            else if (int.Parse(ddTipoPregunta.SelectedValue) == 3)
            {
                this.btnCrear.Visible = true;
                this.AltOCas.Visible = false;
                this.VoF.Visible = true;
            }
        }
        public void subirImagen()
        {
            if (IsPostBack)
            {
                bool fileOK = false;
                string path = Server.MapPath("~/ImagenesPreguntas/");
                if (fileImagen.HasFile)
                {
                    string extension = Path.GetExtension(fileImagen.FileName).ToLower();
                    string[] posiblesExtensiones = { ".gif", ".png", ".jpeg", ".jpg", ".GIF", ".PNG", ".JPEG", ".JPG" };
                    for (int i = 0; i < posiblesExtensiones.Length; i++)
                    {
                        if (extension == posiblesExtensiones[i])
                        {
                            fileOK = true;
                        }
                    }
                }

                if (fileOK)
                {
                    try
                    {
                        fileImagen.PostedFile.SaveAs(path + fileImagen.FileName);
                        Response.Write("<script>window.alert('La imagen fue grabada en el servidor');</script>");
                        ruta = fileImagen.FileName;
                    }
                    catch
                    {
                        Response.Write("<script>window.alert('La imagen no pudo ser grabada en el servidor');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('El formato de archivo no es soportado');</script>");
                }
            }
        }

        protected void btnSeguir_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearPregunta.aspx");
        }
    }
}
