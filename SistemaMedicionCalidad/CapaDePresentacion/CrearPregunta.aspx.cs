﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion
{
    public partial class CrearPregunta : System.Web.UI.Page
    {
        private static TextBox[] arrTextBoxs;
        private static CheckBox[] arrCheckBox;
        private static int contadorControles;
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogPregunta cp = new CatalogPregunta();
            List<Tipo_Pregunta> ltp = cp.mostrarTiposPregunta();
            CatalogCompetencia cc = new CatalogCompetencia();
            List<Competencia> lc = cc.mostrarCompetencias();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                arrTextBoxs = new TextBox[1000];
                arrCheckBox = new CheckBox[1000];
                contadorControles = 0;

                this.ddTipoPregunta.DataTextField = "Nombre_tipo_pregunta";
                this.ddTipoPregunta.DataValueField = "Id_tipo_pregunta";
                this.ddTipoPregunta.DataSource = ltp;

                this.ddCompetencia.DataTextField = "Nombre_competencia";
                this.ddCompetencia.DataValueField = "Id_competencia";
                this.ddCompetencia.DataSource = lc;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
            try
            {
                for(int i=0 ; i < contadorControles ; i++)
                {
                    agregarControles(arrTextBoxs[i], arrCheckBox[i]);
                }
            }
            catch
            {
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            int i = 0;
            CatalogPregunta cp = new CatalogPregunta();
            CatalogRespuesta cr = new CatalogRespuesta();

            Pregunta p = new Pregunta();
            Competencia c = new Competencia();
            Tipo_Pregunta tp = new Tipo_Pregunta();
            p.Competencia_pregunta = c;
            p.Tipo_pregunta_pregunta = tp;

            p.Competencia_pregunta.Id_competencia = int.Parse(this.ddCompetencia.SelectedValue);
            p.Tipo_pregunta_pregunta.Id_tipo_pregunta = int.Parse(this.ddTipoPregunta.SelectedValue);
            p.Nombre_pregunta = this.txtPregunta.Text;
            cp.agregarPregunta(p);
            int id = cp.ultimaPregunta();
            Pregunta pp = new Pregunta();

            Respuesta r = new Respuesta();
            r.Pregunta_respuesta = pp;

            r.Pregunta_respuesta.Id_pregunta = id;
            r.Nombre_respuesta = txtRespuesta.Text;
            r.Correcta_respuesta = cbCorrecta.Checked;
            cr.agregarRespuesta(r);

            while (arrTextBoxs[i] != null)
            {
                Respuesta rr = new Respuesta();
                rr.Pregunta_respuesta = pp;

                rr.Pregunta_respuesta.Id_pregunta = id;
                rr.Nombre_respuesta = arrTextBoxs[i].Text;
                rr.Correcta_respuesta = arrCheckBox[i].Checked;
                cr.agregarRespuesta(rr);
                i++;
            }
            Response.Write("<script>window.alert('Pregunta creada satisfactoriamente');</script>");
        }
        public void agregarControles(TextBox txt, CheckBox cb)
        {
            Panel p1 = new Panel();
            Panel p2 = new Panel();
            Panel p3 = new Panel();
            p3.CssClass = "row";            
            p1.CssClass = "col-sm-6";
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
            int numeroRegistro = contadorControles;
            TextBox txt = new TextBox();
            CheckBox cb = new CheckBox();
            txt.CssClass = "form-control";
            arrTextBoxs[numeroRegistro] = txt;
            arrCheckBox[numeroRegistro] = cb;

            agregarControles(txt, cb);
            contadorControles++;
        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            this.crearRespuestas();
        }
    }
}