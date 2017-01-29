using System;
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
            Pregunta p = new Pregunta(int.Parse(this.ddCompetencia.SelectedValue), int.Parse(this.ddTipoPregunta.SelectedValue), this.txtPregunta.Text);
            cp.agregarPregunta(p);
            int id = cp.ultimaPregunta();

            if (cbCorrecta.Checked)
            {
                Respuesta r = new Respuesta(id, txtRespuesta.Text, true);
                cr.agregarRespuesta(r);
            }
            else
            {
                Respuesta r = new Respuesta(id, txtRespuesta.Text, false);
                cr.agregarRespuesta(r);
            }

            while (arrTextBoxs[i]!=null)
            {
                if (arrCheckBox[i].Checked)
                {
                    Respuesta r = new Respuesta(id, arrTextBoxs[i].Text, true);
                    cr.agregarRespuesta(r);
                }
                else
                {
                    Respuesta r = new Respuesta(id, arrTextBoxs[i].Text, false);
                    cr.agregarRespuesta(r);
                }
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