using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Project;
using System.Data;

namespace CapaDePresentacion.Alum
{
    public partial class Resultados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutAlumno"].ToString();
                panelGraficoColumna.Visible = false;
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                List<Asignatura> lAsignatura = cAsignatura.listarAsignaturasEvaluadas(rut);


                if (!Page.IsPostBack) //para ver si cargo por primera vez
                {
                    divPreguntas.Visible = false;
                    gvDesempenos.Visible = false;
                    this.ddAsignatura.DataTextField = "Nombre_asignatura";
                    this.ddAsignatura.DataValueField = "Cod_asignatura";
                    this.ddAsignatura.DataSource = lAsignatura;

                    this.DataBind();//enlaza los datos a un dropdownlist                
                }
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }

        public void graficoColumna()
        {
            string rut = Session["rutAlumno"].ToString();
            panelGraficoColumna.Visible = true;
            chartColumna.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<string> result = cEvaluacion.obtenerResultadosEvaluacionGeneralAlumno(int.Parse(ddEvaluacion.SelectedValue), rut);

            int i = 0;
            bool primera_vez = true;
            bool estado_anterior = false; ;
            while (i < result.Count)
            {
                if (Boolean.Parse(result[i]) == true && primera_vez)
                {
                    this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i + 2], 0);
                    this.chartColumna.Series["Correctas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                    i = i + 3;
                }
                else if (Boolean.Parse(result[i]) == true && estado_anterior == true)
                {
                    this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i + 2], 0);
                    this.chartColumna.Series["Correctas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                    i = i + 3;
                }
                else if (Boolean.Parse(result[i]) == true)
                {
                    this.chartColumna.Series["Correctas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                    i = i + 3;
                    try
                    {
                        if (Boolean.Parse(result[i]) == false)
                        {
                            this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                            i = i + 3;
                        }
                        else
                        {
                            this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i + 2], 0);
                        }
                    }
                    catch { }
                }
                else if (Boolean.Parse(result[i]) == false)
                {
                    string s = result[i + 2];
                    this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                    i = i + 3;
                    try
                    {
                        if (Boolean.Parse(result[i]) == false)
                        {
                            this.chartColumna.Series["Correctas"].Points.AddXY(s, 0);
                        }
                        else if (Boolean.Parse(result[i]) == true && s == result[i + 2])
                        {
                            this.chartColumna.Series["Correctas"].Points.AddXY(s, int.Parse(result[i + 1]));
                            i = i + 3;
                        }
                        else
                        {
                            this.chartColumna.Series["Correctas"].Points.AddXY(s, 0);
                        }
                    }
                    catch { }

                }
                try
                {
                    estado_anterior = Boolean.Parse(result[i]);
                }
                catch
                {
                }
                primera_vez = false;
            }
            System.Web.UI.DataVisualization.Charting.Title title = chartColumna.Titles.Add(ddEvaluacion.SelectedItem.ToString());
            title.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            title.ForeColor = Color.White;
        }

        protected void btnGraficar_Click(object sender, EventArgs e)
        {
            string rut = Session["rutAlumno"].ToString();
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<string> lResultados = cEvaluacion.mostrarResumenA(int.Parse(ddEvaluacion.SelectedValue), rut);
            lblnEvaluacion.InnerText = ddEvaluacion.SelectedItem.Text;
            lblCorrectas.InnerText = "Respuestas Correctas: " + lResultados[1].ToString();
            lblIncorrectas.InnerText = "Respuestas Incorrectas: " + lResultados[2].ToString();
            lblCorrectas.Attributes.Add("style", "Color: Green; font-weight:bold");
            lblIncorrectas.Attributes.Add("style", "Color: Red; font-weight:bold");
            this.crearControles();
            divPreguntas.Visible = true;
            /*this.graficoColumna();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            List<Desempeno> lDesempenos = cDesempeno.listarDesempenosEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
            this.gvDesempenos.DataSource = lDesempenos;
            this.DataBind();
            gvDesempenos.Visible = true;*/
        }

        protected void ddAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            divPreguntas.Visible = false;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<Evaluacion> lEvaluaciones = cEvaluacion.listarEvaluacionesAsignatura(ddAsignatura.SelectedValue);

            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencia = cCompetencia.listarCompetenciasAsignatura(ddAsignatura.SelectedValue);

            this.ddEvaluacion.Items.Clear();
            this.ddEvaluacion.DataTextField = "Nombre_evaluacion";
            this.ddEvaluacion.DataValueField = "Id_evaluacion";
            this.ddEvaluacion.DataSource = lEvaluaciones;
            this.DataBind();//enlaza los datos a un dropdownlist  
        }

        //Se crean los controles dependiendo del tipo, se agregan al panel para que sean visibles en la interfaz grafica, y a la vez 
        //se crean listas estaticas para que se pueda acceder a los atributos checked posteriormente 
        public void crearControles()
        {
            string rut = Session["rutAlumno"].ToString();
            string ids_preguntas = "";
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            ids_preguntas = cEvaluacion.listarPreguntasEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
            List<int> id_respuestas_alumno = cEvaluacion.listarIDsRA(rut, int.Parse(ddEvaluacion.SelectedValue));
            List<int> ids_respuestas_correctas = cEvaluacion.listarIDsRC(int.Parse(ddEvaluacion.SelectedValue));
            DataTable dt = cEvaluacion.mostrarPyRSeleccionadas(ids_preguntas);
            string s = "";
            int numPregunta = 1;

            RadioButtonList rbl = new RadioButtonList();
            RadioButtonList rblVF = new RadioButtonList();
            CheckBoxList cbxl = new CheckBoxList();
            string x = "";
            foreach (DataRow result in dt.Rows)
            {
                Label pregunta = new Label();
                pregunta.Text = result[2].ToString();

                if (s != pregunta.Text)
                {
                    Label l2 = new Label();
                    l2.Text = numPregunta + ") " + result[2].ToString();

                    if (rbl.Items.Count > 0 && x == "rbl")
                    {
                        rbl.Enabled = false;
                        this.Panel1.Controls.Add(rbl);
                    }
                    else if (cbxl.Items.Count > 0 && x == "cbxl")
                    {
                        cbxl.Enabled = false;
                        this.Panel1.Controls.Add(cbxl);
                    }
                    else if (rblVF.Items.Count > 0 && x == "rblVF")
                    {
                        rblVF.Enabled = false;
                        this.Panel1.Controls.Add(rblVF);
                    }

                    if (result[0].ToString() == "Seleccion multiple")
                    {
                        rbl = new RadioButtonList();
                    }
                    else if (result[0].ToString() == "Casillas de verificacion")
                    {
                        cbxl = new CheckBoxList();
                    }
                    else if (result[0].ToString() == "Verdadero o falso")
                    {
                        rblVF = new RadioButtonList();
                    }

                    this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                    this.Panel1.Controls.Add(l2);
                    this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                    if (result[3].ToString() != "" && result[3].ToString() != null)
                    {
                        System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                        //string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ImagenesPreguntas\" + result.GetString(5));
                        //ruta = Path.GetFullPath(ruta);
                        img.ImageUrl = "../ImagenesPreguntas/" + result[3].ToString();
                        Panel1.Controls.Add(img);
                    }
                    numPregunta = numPregunta + 1;
                    s = pregunta.Text;
                }
                if (result[0].ToString() == "Seleccion multiple" && s == pregunta.Text)
                {
                    rbl.Enabled = false;
                    
                    ListItem l = new ListItem(result[1].ToString(), result[5].ToString());
                    if (ids_respuestas_correctas.Contains(int.Parse(result[5].ToString())))
                    {
                        l.Attributes.Add("style", "Color: Green; font-weight:bold");
                    }
                    if (id_respuestas_alumno.Contains(int.Parse(result[5].ToString())) && ids_respuestas_correctas.Contains(int.Parse(result[5].ToString())))
                    {
                        l.Selected = true;
                        l.Attributes.Add("style", "Color: Green; font-weight:bold");
                    }

                    else if (id_respuestas_alumno.Contains(int.Parse(result[5].ToString())) && !ids_respuestas_correctas.Contains(int.Parse(result[5].ToString())))
                    {
                        l.Selected = true;
                        l.Attributes.Add("style", "Color: Red; font-weight:bold");
                    }
                    rbl.Items.Add(l);
                    x = "rbl";
                }

                else if (result[0].ToString() == "Casillas de verificacion" && s == pregunta.Text)
                {
                    cbxl.Enabled = false;
                    ListItem l = new ListItem(result[1].ToString(), result[5].ToString());
                    if (id_respuestas_alumno.Contains(int.Parse(result[5].ToString())))
                    {
                        l.Selected = true;
                    }
                    if (ids_respuestas_correctas.Contains(int.Parse(result[5].ToString())))
                    {
                        l.Attributes.Add("style", "Color: Green");
                    }
                    cbxl.Items.Add(l);
                    x = "cbxl";
                }
                else if (result[0].ToString() == "Verdadero o falso" && s == pregunta.Text)
                {
                    rblVF.Enabled = false;
                    ListItem l = new ListItem(result[1].ToString(), result[5].ToString());
                    if (id_respuestas_alumno.Contains(int.Parse(result[5].ToString())))
                    {
                        l.Selected = true;
                    }
                    if (ids_respuestas_correctas.Contains(int.Parse(result[5].ToString())))
                    {
                        l.Attributes.Add("style", "Color: Green");
                    }
                    rblVF.Items.Add(l);
                    x = "rblVF";
                }
                s = result[2].ToString();
            }
            if (rbl.Items.Count > 0 && x == "rbl")
            {
                this.Panel1.Controls.Add(rbl);
                this.Panel1.Controls.Add(new LiteralControl("<br/>"));
            }
            else if (cbxl.Items.Count > 0 && x == "cbxl")
            {
                this.Panel1.Controls.Add(cbxl);
            }
            else if (rblVF.Items.Count > 0 && x == "rblVF")
            {
                this.Panel1.Controls.Add(rblVF);
                this.Panel1.Controls.Add(new LiteralControl("<br/>"));
            }
        }
    }
}