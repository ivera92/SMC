﻿using Project;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace CapaDePresentacion.Evaluador
{
    public partial class ResultadosEspecificos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutEvaluador"].ToString();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignaturas = cAsignatura.listarAsignaturas();
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ocultar();
                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Cod_asignatura";
                this.ddAsignatura.DataSource = lAsignaturas;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }
        public void ocultar()
        {
            gvDesempenos.Visible = false;
            divAlumno.Visible = false;
            divOtrosResultados.Visible = false;
            divRut.Visible = false;
            divPreguntas.Visible = false;
            divAno1.Visible = false;
            divAno2.Visible = false;
            divCP.Visible = false;
            chartColumna.Visible = false;
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            this.ocultar();
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            if (ddAsignatura.SelectedValue == "0" || ddEvaluacion.SelectedValue == "0" || ddOpcion.SelectedValue == "0")
            {
                Response.Write("<script>alert('Seleccione una Asignatura, Evaluación, y el resultado que desea obtener');</script>");
            }
            else
            {
                if (ddOpcion.SelectedValue == "1")
                {
                    List<string> lResultados1 = cEvaluacion.resultadosEspecificos(int.Parse(ddEvaluacion.SelectedValue), 1);
                    List<string> lResultados2 = cEvaluacion.resultadosEspecificos(int.Parse(ddEvaluacion.SelectedValue), 2);
                    List<string> lResultados3 = cEvaluacion.resultadosEspecificos(int.Parse(ddEvaluacion.SelectedValue), 3);
                    List<string> lResultados4 = cEvaluacion.resultadosEspecificos(int.Parse(ddEvaluacion.SelectedValue), 4);
                    divOtrosResultados.Visible = true;
                    lblCorrectasMAC.InnerText = lResultados1[1];
                    lblCorrectasMAI.InnerText = lResultados1[2];
                    lblCorrectasMBC.InnerText = lResultados2[1];
                    lblCorrectasMBI.InnerText = lResultados2[2];

                    txtAPreguntaMC.InnerText = lResultados3[0];
                    lblCorrectasPMC.InnerText = lResultados3[1];

                    txtAPreguntaPC.InnerText = lResultados4[0];
                    lblCorrectasPPC.InnerText = lResultados4[1];
                }
                else if (ddOpcion.SelectedValue == "2")
                {
                    try
                    {
                        List<string> lResultados = cEvaluacion.mostrarResumenA(int.Parse(ddEvaluacion.SelectedValue), txtRut.Text);
                        lblCorrectas.InnerText = "Respuestas Correctas: " + lResultados[1].ToString();
                        lblIncorrectas.InnerText = "Respuestas Incorrectas: " + lResultados[2].ToString();
                        lblCorrectas.Attributes.Add("style", "Color: Green; font-weight:bold");
                        lblIncorrectas.Attributes.Add("style", "Color: Red; font-weight:bold");
                        crearControles(txtRut.Text);
                        divPreguntas.Visible = true;
                        lblnEvaluacion.InnerText = ddEvaluacion.SelectedItem.Text;
                        divRut.Visible = true;
                        graficoColumna(txtRut.Text);
                        divAlumno.Visible = true;
                        divOtrosResultados.Visible = false;
                        gvDesempenos.Visible = true;

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
                        lblNota.InnerText = "Nota: " + promedio;

                        divAlumno.Visible = true;                        
                    }
                    catch
                    {
                        Response.Write("<script>alert('Rut no registra respuestas para esta Evaluación');</script>");
                    }
                }
                else if (ddOpcion.SelectedValue == "3")
                {
                    if (ddAno1.SelectedValue != ddAno2.SelectedValue && ddAsignatura.SelectedValue != "0" && ddEvaluacion.SelectedValue != "0")
                    {
                        try
                        {
                            this.mostrar();
                            DataTable g1 = cEvaluacion.mostrarResumenDEvaluacion(int.Parse(ddEvaluacion.SelectedValue), int.Parse(ddAno1.SelectedItem.ToString()));
                            DataTable g2 = cEvaluacion.mostrarResumenDEvaluacion(int.Parse(ddEvaluacion.SelectedValue), int.Parse(ddAno2.SelectedItem.ToString()));
                            this.graficoPuntos(ddAno1.SelectedValue, ddAno2.SelectedValue, g1, g2);
                            gvDesempenos.Visible = true;
                            divCP.Visible = true;
                        }
                        catch { }
                    }
                    else
                    {
                        Response.Write("<script>alert('Seleccione Generaciones distintas');</script>");
                    }
                }
            }
        }

        public void graficoColumna(string rut_alumno)
        {
            this.mostrar();
            chartColumna.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<string> result = cEvaluacion.obtenerResultadosEvaluacionGeneralAlumno(int.Parse(ddEvaluacion.SelectedValue), rut_alumno);

            int i = 0;
            while (i < result.Count)
            {
                this.chartColumna.Series["Correctas"].Points.AddXY(result[i], int.Parse(result[i + 1]));
                this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i], int.Parse(result[i + 2]));
                i = i + 3;
            }
            //Sacar cuadricula
            chartColumna.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chartColumna.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            System.Web.UI.DataVisualization.Charting.Title title = chartColumna.Titles.Add(ddEvaluacion.SelectedItem.ToString());
            title.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            title.ForeColor = Color.White;
        }

        protected void ddAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<Evaluacion> lEvaluaciones = cEvaluacion.listarEvaluacionesAsignatura(ddAsignatura.SelectedValue);

            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencia = cCompetencia.listarCompetenciasAsignatura(ddAsignatura.SelectedValue);

            this.ddEvaluacion.Items.Clear();
            this.ddEvaluacion.DataTextField = "Nombre_evaluacion";
            this.ddEvaluacion.DataValueField = "Id_evaluacion";
            this.ddEvaluacion.DataSource = lEvaluaciones;
            this.DataBind();//enlaza los datos a un dropdownlist  
            gvDesempenos.Visible = false;
            divAlumno.Visible = false;
            divOtrosResultados.Visible = false;
            divPreguntas.Visible = false;
        }

        protected void ddOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ocultar();
            if (ddOpcion.SelectedValue == "2")
            {
                txtRut.Text = "";
                divRut.Visible = true;
            }
            else if (ddOpcion.SelectedValue == "3")
            {
                divAno1.Visible = true;
                divAno2.Visible = true;
                CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                List<Cursa> lGeneraciones = cEvaluacion.listarGeneracionesEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
                this.ddAno1.Items.Clear();
                this.ddAno1.DataTextField = "ano_asignatura";
                this.ddAno1.DataValueField = "ano_asignatura";
                this.ddAno1.DataSource = lGeneraciones;
                this.ddAno2.Items.Clear();
                this.ddAno2.DataTextField = "ano_asignatura";
                this.ddAno2.DataValueField = "ano_asignatura";
                this.ddAno2.DataSource = lGeneraciones;
                this.DataBind();//enlaza los datos a un dropdownlist  
            }
        }

        public void mostrar()
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            List<Desempeno> lDesempenos = cDesempeno.listarDesempenosEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
            this.gvDesempenos.DataSource = lDesempenos;
            this.DataBind();
        }
        public void graficoPuntos(string serie1, string serie2, DataTable g1, DataTable g2)
        {
            chartPuntos.Series.Add(serie1);
            chartPuntos.Series.Add(serie2);
            chartPuntos.Series[serie1].IsValueShownAsLabel = true;
            chartPuntos.Series[serie1].IsXValueIndexed = true;
            chartPuntos.Series[serie2].IsValueShownAsLabel = true;
            chartPuntos.Series[serie2].IsXValueIndexed = true;
            this.chartPuntos.Series[serie1].MarkerSize = 10;
            this.chartPuntos.Series[serie2].MarkerSize = 10;
            string rut = "";
            double promedio = 0;
            int i = 0;
            int j = 0;

            foreach (DataRow row in g1.Rows)
            {
                i += 1;
                rut = row[0].ToString();
                promedio = double.Parse(row[3].ToString());
                this.chartPuntos.Series[serie1].Points.AddXY("D" + i, promedio);
            }
            foreach (DataRow row in g2.Rows)
            {
                j += 1;
                rut = row[0].ToString();
                promedio = double.Parse(row[3].ToString());
                this.chartPuntos.Series[serie2].Points.AddXY("D" + j, promedio);
            }

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
            System.Web.UI.DataVisualization.Charting.Title title = chartPuntos.Titles.Add(ddEvaluacion.SelectedItem.ToString() + "-COMPARANDO 2 GENERACIONES");
            title.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            title.ForeColor = Color.White;
        }
        public void crearControles(string rut)
        {
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