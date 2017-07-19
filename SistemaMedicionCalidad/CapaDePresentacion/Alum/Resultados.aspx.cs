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
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                List<Asignatura> lAsignatura = cAsignatura.listarAsignaturasEvaluadas(rut);


                if (!Page.IsPostBack) //para ver si cargo por primera vez
                {
                    panelGraficoColumna.Visible = false;
                    panelGrafico.Visible = false;
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

        protected void btnGraficar_Click(object sender, EventArgs e)
        {
            divPreguntas.Visible = false;
            panelGrafico.Visible = false;
            if (ddAsignatura.SelectedValue != "0" && ddEvaluacion.SelectedValue != "0")
            {
                string rut = Session["rutAlumno"].ToString();
                if (ddOpcion.SelectedValue == "1")
                {
                    CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                    List<string> lResultados = cEvaluacion.mostrarResumenA(int.Parse(ddEvaluacion.SelectedValue), rut);
                    lblnEvaluacion.InnerText = ddEvaluacion.SelectedItem.Text;
                    lblCorrectas.InnerText = "Respuestas Correctas: " + lResultados[1].ToString();
                    lblIncorrectas.InnerText = "Respuestas Incorrectas: " + lResultados[2].ToString();
                    lblCorrectas.Attributes.Add("style", "Color: Green; font-weight:bold");
                    lblIncorrectas.Attributes.Add("style", "Color: Red; font-weight:bold");
                    this.crearControles();
                    divPreguntas.Visible = true;

                    string correctas, incorretas;
                    int puntaje_ideal;
                    double puntaje_exigencia, porcentaje;
                    double promedio = 0;
                    correctas = lResultados[1].ToString();
                    incorretas = lResultados[2].ToString();
                    porcentaje = int.Parse(lResultados[3].ToString()) / 100d;
                    puntaje_ideal = int.Parse(lResultados[1].ToString()) + int.Parse(incorretas);
                    puntaje_exigencia = puntaje_ideal * porcentaje;
                    double a = puntaje_ideal - puntaje_exigencia;
                    double b = int.Parse(lResultados[1].ToString()) - puntaje_exigencia;

                    //MidpointRounding.AwayFromZero si el numero se encunetra en la mitad, es decir .5 aproxima al numero mas alejado del 0
                    if (int.Parse(correctas) <= puntaje_exigencia)
                    {
                        promedio = Math.Round(3f * (double.Parse(lResultados[1].ToString())) / puntaje_exigencia + 1, 1, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        promedio = Math.Round(3f * (double.Parse(lResultados[1].ToString()) - puntaje_exigencia) / (puntaje_ideal - puntaje_exigencia) + 4, 1, MidpointRounding.AwayFromZero);
                    }
                    lblNota.Attributes.Add("style", "font-weight:bold");
                    lblNota.InnerText ="Tu Nota: "+promedio;
                }
                else if (ddOpcion.SelectedValue == "2")
                {
                    graficoPuntos(rut);
                    panelGrafico.Visible = true;
                }
                else
                {
                    Response.Write("<script>alert('Seleccione el resultado que desee ver');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Seleccione una Asignatura y Evaluación para poder graficar');</script>");
            }
        }

        protected void ddAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            divPreguntas.Visible = false;
            panelGrafico.Visible = false;
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

        public void graficoPuntos(string rut_alumno)
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<string> lResultados = cEvaluacion.mostrarResumenA(int.Parse(ddEvaluacion.SelectedValue), rut_alumno);

            string correctas, incorretas;
            int puntaje_ideal;
            double puntaje_exigencia, porcentaje;
            double nota = 0;
            correctas = lResultados[1].ToString();
            incorretas = lResultados[2].ToString();
            porcentaje = int.Parse(lResultados[3].ToString()) / 100d;
            puntaje_ideal = int.Parse(lResultados[1].ToString()) + int.Parse(incorretas);
            puntaje_exigencia = puntaje_ideal * porcentaje;
            double a = puntaje_ideal - puntaje_exigencia;
            double b = int.Parse(lResultados[1].ToString()) - puntaje_exigencia;

            //MidpointRounding.AwayFromZero si el numero se encunetra en la mitad, es decir .5 aproxima al numero mas alejado del 0
            if (int.Parse(correctas) <= puntaje_exigencia)
            {
                nota = Math.Round(3f * (double.Parse(lResultados[1].ToString())) / puntaje_exigencia + 1, 1, MidpointRounding.AwayFromZero);
            }
            else
            {
                nota = Math.Round(3f * (double.Parse(lResultados[1].ToString()) - puntaje_exigencia) / (puntaje_ideal - puntaje_exigencia) + 4, 1, MidpointRounding.AwayFromZero);
            }

            //Se define que no necesariamnente las series van a tener la misma cantidad de valores
            chartPuntos.Series["Tu Nota"].IsXValueIndexed = false;
            chartPuntos.Series["Aprobado"].IsXValueIndexed = false;
            chartPuntos.Series["Reprobado"].IsXValueIndexed = false;
            chartPuntos.Series["Promedio Curso"].IsXValueIndexed = false;

            //Se define el tamaño de la marca en el grafico
            this.chartPuntos.Series["Tu Nota"].MarkerSize = 10;
            this.chartPuntos.Series["Reprobado"].MarkerSize = 10;
            this.chartPuntos.Series["Aprobado"].MarkerSize = 10;
            this.chartPuntos.Series["Promedio Curso"].MarkerSize = 10;

            DataTable dtNota = cEvaluacion.nota(cEvaluacion.mostrarResumenNotasE(int.Parse(ddEvaluacion.SelectedValue)));
            double promedio = 0;
            double promedio_curso = 0;
            int cantidad = 0;
            int i = 0;
            foreach (DataRow row in dtNota.Rows)
            {
                cantidad = int.Parse(row[0].ToString());
                i += cantidad;
                promedio = double.Parse(row[3].ToString());
                promedio_curso += promedio * cantidad;
                if (promedio == nota)
                {
                    this.chartPuntos.Series["Tu Nota"].Points.AddXY(cantidad, promedio);
                }
                else if (promedio >= 4.0)
                {
                    this.chartPuntos.Series["Aprobado"].Points.AddXY(cantidad, promedio);
                }
                else
                {
                    this.chartPuntos.Series["Reprobado"].Points.AddXY(cantidad, promedio);
                }
            }
            promedio_curso = Math.Round(promedio_curso / i, 1, MidpointRounding.AwayFromZero);
            this.chartPuntos.Series["Promedio Curso"].Points.AddXY(1, promedio_curso);

            StripLine stripLine1 = new StripLine();
            stripLine1.StripWidth = 0;
            stripLine1.BorderColor = Color.Green;
            stripLine1.BorderWidth = 2;
            stripLine1.IntervalOffset = 4;
            stripLine1.Text = "Limite de aprobacion nota 4,0";
            Font font = new Font("Segoe UI", 10.0f);
            stripLine1.Font = font;
            chartPuntos.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripLine1);

            //Definir minimo y maximo de escala
            chartPuntos.ChartAreas["ChartArea1"].AxisY.Minimum = 1;
            chartPuntos.ChartAreas["ChartArea1"].AxisY.Maximum = 7;

            //Sacar cuadricula
            chartPuntos.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chartPuntos.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            System.Web.UI.DataVisualization.Charting.Title title = chartPuntos.Titles.Add(ddEvaluacion.SelectedItem.ToString() + "-NOTAS DEL CURSO");
            title.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            title.ForeColor = Color.White;        

            panelGrafico.Controls.Add(chartPuntos);
        }
    }
}