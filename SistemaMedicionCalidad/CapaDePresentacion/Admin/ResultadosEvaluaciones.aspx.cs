using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using System.IO;
using ClosedXML.Excel;
using System.Web;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace CapaDePresentacion.Admin
{
    public partial class ResultadosEvaluaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutAdmin"].ToString();
                btnExportar.Visible = false;

                if (!Page.IsPostBack)
                {
                    divRut.Visible = false;
                    divRAsignatura.Visible = false;
                    divDDA.Visible = false;
                    divResultado.Visible = false;
                    btnVerR.Visible = false;
                    this.ocultar();
                    this.listarAsignaturas();
                }
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }

        public void ocultar()
        {
            gvDesempenos.Visible = false;
            gvResultados.Visible = false;
            gvResultadosGenerales.Visible = false;
            gvResumen.Visible = false;
            divCC.Visible = false;
            divCP.Visible = false;
            divCCompe.Visible = false;
            divAno1.Visible = false;
            divAno2.Visible = false;
            divOtrosResultados.Visible = false;
            div2Generaciones.Visible = false;
            divPreguntas.Visible = false;
            divAlumno.Visible = false;            
            divCompetenciasAsignatura.Visible = false;
            divDesempeñosAsignatura.Visible = false;
        }

        public void listarAsignaturas()
        {
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignaturas = cAsignatura.listarAsignaturas();
            this.ddAsignatura.Items.Clear();
            this.ddAsignatura2.Items.Clear();
            ddAsignatura2.Items.Add(new ListItem("Seleccione una Asignatura", "0"));
            ddAsignatura.Items.Add(new ListItem("Seleccione una Asignatura", "0"));
            this.ddAsignatura.DataTextField = "Nombre_asignatura";
            this.ddAsignatura.DataValueField = "Cod_asignatura";
            this.ddAsignatura.DataSource = lAsignaturas;
            this.ddAsignatura2.DataTextField = "Nombre_asignatura";
            this.ddAsignatura2.DataValueField = "Cod_asignatura";
            this.ddAsignatura2.DataSource = lAsignaturas;
            this.ddAsignatura2.DataBind();
            this.ddAsignatura.DataBind();
        }

        public void graficoColumna()
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<string> result = cEvaluacion.obtenerResultadosEvaluacionGeneral(int.Parse(ddEvaluacion.SelectedValue));

            int i = 0;
            while (i < result.Count)
            {
                this.chartColumna.Series["Correctas"].Points.AddXY(result[i], int.Parse(result[i + 1]));
                this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i], int.Parse(result[i + 2]));
                i = i + 3;
            }
            System.Web.UI.DataVisualization.Charting.Title title = chartColumna.Titles.Add(ddEvaluacion.SelectedItem.ToString());
            title.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            title.ForeColor = Color.White;

            //Sacar cuadricula
            chartColumna.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chartColumna.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        }

        public void graficoColumnaDesempeñoAsignatura()
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            DataTable result = cEvaluacion.mostrarResumenDAsignatura(ddAsignatura2.SelectedValue);
            int i = 1;
            foreach (DataRow row in result.Rows)
            {
                this.chartDesempeñosAsignatura.Series["Correctas"].Points.AddXY("D"+i, int.Parse(row[1].ToString()));
                this.chartDesempeñosAsignatura.Series["Incorrectas"].Points.AddXY("D" + i, int.Parse(row[1].ToString()));
                i += 1;
            }
            System.Web.UI.DataVisualization.Charting.Title title = chartDesempeñosAsignatura.Titles.Add(ddAsignatura2.SelectedItem.ToString()+"-DESEMPEÑOS");
            title.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            title.ForeColor = Color.White;

            //Sacar cuadricula
            chartDesempeñosAsignatura.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chartDesempeñosAsignatura.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

        }
        public void graficoColumnaCompe()
        {
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            DataTable dtCompetencias = cCompetencia.mostrarResumenCompetenciasEvaluacion(int.Parse(ddEvaluacion.SelectedValue));

            int i = 1;
            foreach (DataRow row in dtCompetencias.Rows)
            {
                this.chartCompe.Series["Correctas"].Points.AddXY("C" + i, int.Parse(row[1].ToString()));
                this.chartCompe.Series["Incorrectas"].Points.AddXY("C" + i, int.Parse(row[2].ToString()));
                i += 1;
            }
            System.Web.UI.DataVisualization.Charting.Title title = chartColumna.Titles.Add(ddEvaluacion.SelectedItem.ToString() + "-COMPETENCIAS");
            title.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            title.ForeColor = Color.White;

            //Sacar cuadricula
            chartCompe.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chartCompe.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        }

        public void graficoColumnaCompeAsignatura()
        {
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            DataTable dtCompetencias = cCompetencia.mostrarResumenCompetenciasAsignatura(ddAsignatura2.SelectedValue);

            int i = 1;
            foreach (DataRow row in dtCompetencias.Rows)
            {
                this.chartCompetenciasAsignatura.Series["Correctas"].Points.AddXY("C" + i, int.Parse(row[1].ToString()));
                this.chartCompetenciasAsignatura.Series["Incorrectas"].Points.AddXY("C" + i, int.Parse(row[2].ToString()));
                i += 1;
            }
            System.Web.UI.DataVisualization.Charting.Title title = chartCompetenciasAsignatura.Titles.Add(ddAsignatura2.SelectedItem.ToString() + "-COMPETENCIAS");
            title.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            title.ForeColor = Color.White;

            //Sacar cuadricula
            chartCompetenciasAsignatura.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chartCompetenciasAsignatura.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        }

        public void grafico2Generaciones(string serie1, string serie2, DataTable g1, DataTable g2)
        {
            chart2Generaciones.Series.Add(serie1);
            chart2Generaciones.Series.Add(serie2);
            chart2Generaciones.Series[serie1].IsValueShownAsLabel = true;
            chart2Generaciones.Series[serie1].IsXValueIndexed = true;
            chart2Generaciones.Series[serie2].IsValueShownAsLabel = true;
            chart2Generaciones.Series[serie2].IsXValueIndexed = true;
            this.chart2Generaciones.Series[serie1].MarkerSize = 10;
            this.chart2Generaciones.Series[serie2].MarkerSize = 10;
            chart2Generaciones.Visible = true;
            panelGrafico.Visible = true;
            string rut = "";
            double promedio = 0;
            int i = 0;
            int j = 0;

            foreach (DataRow row in g1.Rows)
            {
                i += 1;
                rut = row[0].ToString();
                promedio = double.Parse(row[3].ToString());
                this.chart2Generaciones.Series[serie1].Points.AddXY("D" + i, promedio);
            }
            foreach (DataRow row in g2.Rows)
            {
                j += 1;
                rut = row[0].ToString();
                promedio = double.Parse(row[3].ToString());
                this.chart2Generaciones.Series[serie2].Points.AddXY("D" + j, promedio);
            }

            StripLine stripLine1 = new StripLine();
            stripLine1.StripWidth = 0;
            stripLine1.BorderColor = Color.Green;
            stripLine1.BorderWidth = 2;
            stripLine1.IntervalOffset = 4;
            stripLine1.Text = "Limite de aprobacion nota 4,0";
            Font font = new Font("Segoe UI", 10.0f);
            stripLine1.Font = font;
            chart2Generaciones.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripLine1);

            //Definir minimo y maximo de escala
            chart2Generaciones.ChartAreas["ChartArea1"].AxisY.Minimum = 1;
            chart2Generaciones.ChartAreas["ChartArea1"].AxisY.Maximum = 7;

            //Sacar cuadricula
            chart2Generaciones.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart2Generaciones.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            System.Web.UI.DataVisualization.Charting.Title title = chart2Generaciones.Titles.Add(ddEvaluacion.SelectedItem.ToString() + "-COMPARANDO 2 GENERACIONES");
            title.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            title.ForeColor = Color.White;

            panelGrafico.Controls.Add(chart2Generaciones);
        }

        public void graficoPuntos()
        {
            //Se define que no necesariamnente las series van a tener la misma cantidad de valores
            chartPuntos.Series["Aprobado"].IsXValueIndexed = false;
            chartPuntos.Series["Reprobado"].IsXValueIndexed = false;
            chartPuntos.Series["Promedio Curso"].IsXValueIndexed = false;

            //Se define el tamaño de la marca en el grafico
            this.chartPuntos.Series["Reprobado"].MarkerSize = 10;
            this.chartPuntos.Series["Aprobado"].MarkerSize = 10;
            this.chartPuntos.Series["Promedio Curso"].MarkerSize = 10;

            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
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
                if (promedio >= 4.0)
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
        }

        protected void btnGraficar_Click(object sender, EventArgs e)
        {
            this.ocultar();
            if (ddAsignatura.SelectedValue == "0" || ddEvaluacion.SelectedValue == "0" || ddEvaluacion.SelectedValue == "" || ddTipo.SelectedValue == "0")
            {
                Response.Write("<script>alert('Seleccione una Asignatura y Evaluación para poder graficar');</script>");
            }
            else
            {
                if (ddTipo.SelectedValue == "1")
                {
                    btnExportar.Visible = true;
                    graficoColumnaCompe();
                    CatalogCompetencia cCompetencia = new CatalogCompetencia();
                    DataTable dtCompetencias = cCompetencia.mostrarCompetenciasEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
                    this.gvCompetencias.DataSource = dtCompetencias;
                    this.DataBind();
                    gvCompetencias.Visible = true;
                    divCCompe.Visible = true;
                }
                else if (ddTipo.SelectedValue == "2")
                {
                    btnExportar.Visible = true;
                    this.graficoColumna();
                    CatalogDesempeno cDesempeno = new CatalogDesempeno();
                    List<Desempeno> lDesempenos = cDesempeno.listarDesempenosEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
                    this.gvDesempenos.DataSource = lDesempenos;
                    this.DataBind();
                    gvDesempenos.Visible = true;
                    divCC.Visible = true;
                }
                else if (ddTipo.SelectedValue == "3")
                {
                    if (ddAno1.SelectedValue != ddAno2.SelectedValue && ddAsignatura.SelectedValue != "0" && ddEvaluacion.SelectedValue != "0")
                    {
                        try
                        {
                            CatalogDesempeno cDesempeno = new CatalogDesempeno();
                            List<Desempeno> lDesempenos = cDesempeno.listarDesempenosEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
                            this.gvDesempenos.DataSource = lDesempenos;
                            this.DataBind();

                            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                            DataTable g1 = cEvaluacion.mostrarResumenDEvaluacion(int.Parse(ddEvaluacion.SelectedValue), int.Parse(ddAno1.SelectedItem.ToString()));
                            DataTable g2 = cEvaluacion.mostrarResumenDEvaluacion(int.Parse(ddEvaluacion.SelectedValue), int.Parse(ddAno2.SelectedItem.ToString()));
                            this.grafico2Generaciones(ddAno1.SelectedValue, ddAno2.SelectedValue, g1, g2);
                            panelGrafico.Visible = true;
                            gvDesempenos.Visible = true;
                            div2Generaciones.Visible = true;
                        }
                        catch { }
                    }
                    else
                    {
                        Response.Write("<script>alert('Seleccione Generaciones distintas');</script>");
                    }
                }
                else if (ddTipo.SelectedValue == "4")
                {
                    btnExportar.Visible = true;
                    this.graficoPuntos();
                    CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                    DataTable dt = cEvaluacion.mostrarResumen(int.Parse(ddEvaluacion.SelectedValue));
                    DataTable promedio = cEvaluacion.promedio(dt);
                    this.gvResumen.DataSource = promedio;
                    this.DataBind();
                    gvResumen.Visible = true;
                    divCP.Visible = true;
                }
                else if (ddTipo.SelectedValue == "5")
                {
                    try
                    {
                        CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                        List<string> lResultados = cEvaluacion.mostrarResumenA(int.Parse(ddEvaluacion.SelectedValue), txtRut.Text);
                        lblCorrectas.InnerText = "Respuestas Correctas: " + lResultados[1].ToString();
                        lblIncorrectas.InnerText = "Respuestas Incorrectas: " + lResultados[2].ToString();
                        lblCorrectas.Attributes.Add("style", "Color: Green; font-weight:bold");
                        lblIncorrectas.Attributes.Add("style", "Color: Red; font-weight:bold");
                        crearControles(txtRut.Text);
                        divPreguntas.Visible = true;
                        lblnEvaluacion.InnerText = ddEvaluacion.SelectedItem.Text;
                        graficoColumna(txtRut.Text);
                        divAlumno.Visible = true;
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
                    }
                    catch
                    {
                        Response.Write("<script>alert('Rut no registra respuestas para esta Evaluación');</script>");
                    }
                }
                else if (ddTipo.SelectedValue == "6")
                {
                    CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
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
                    divOtrosResultados.Visible = true;
                }
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }
        public void mostrar()
        {
            this.gvResultados.Visible = true;
            this.gvDesempenos.Visible = true;
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            DataTable dtRPA = cEvaluacion.obtenerResultadosEvaluacionGeneralPorAlumnoGV(int.Parse(ddEvaluacion.SelectedValue));
            List<Desempeno> lDesempenos = cDesempeno.listarDesempenosEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
            List<Resultados> lResultadosGenerales = cEvaluacion.obtenerResultadosEvaluacionGeneralesGV(int.Parse(ddEvaluacion.SelectedValue));
            this.gvResultados.DataSource = dtRPA;
            this.gvDesempenos.DataSource = lDesempenos;
            this.gvResultadosGenerales.DataSource = lResultadosGenerales;
            this.DataBind();
        }

        //Exporta a Excel datos mediante ClosedXml
        protected void ExportExcel()
        {
            this.mostrar();
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            DataTable dtResumen = cEvaluacion.mostrarResumen(int.Parse(ddEvaluacion.SelectedValue));
            DataTable promedio = cEvaluacion.promedio(dtResumen);
            promedio.TableName = "Resumen Notas Alumnos";
            DataTable dt3 = new DataTable("Resultados Generales Desempeño");
            foreach (TableCell cell in gvResultadosGenerales.HeaderRow.Cells)
            {
                dt3.Columns.Add(HttpUtility.HtmlDecode(cell.Text));
            }
            foreach (GridViewRow row in gvResultadosGenerales.Rows)
            {
                dt3.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt3.Rows[dt3.Rows.Count - 1][i] = HttpUtility.HtmlDecode(row.Cells[i].Text);
                }
            }
            DataTable dt = new DataTable("Alumnos por Desempeño");
            foreach (TableCell cell in gvResultados.HeaderRow.Cells)
            {
                dt.Columns.Add(HttpUtility.HtmlDecode(cell.Text));
            }
            foreach (GridViewRow row in gvResultados.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i] = HttpUtility.HtmlDecode(row.Cells[i].Text);
                }
            }

            DataTable dtDesempenos = new DataTable("Desempeños");
            foreach (TableCell cell in gvDesempenos.HeaderRow.Cells)
            {
                dtDesempenos.Columns.Add(HttpUtility.HtmlDecode(cell.Text));
            }
            foreach (GridViewRow row in gvDesempenos.Rows)
            {
                dtDesempenos.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dtDesempenos.Rows[dtDesempenos.Rows.Count - 1][i] = HttpUtility.HtmlDecode(row.Cells[i].Text);
                }
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt3);
                wb.Worksheets.Add(dt);
                wb.Worksheets.Add(dtDesempenos);
                wb.Worksheets.Add(promedio);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Resultados.xlsx");


                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        protected void ddAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartPuntos.Visible = false;
            divEvaluacion.Visible = true;
            gvDesempenos.Visible = false;
            gvResultados.Visible = false;
            gvResultadosGenerales.Visible = false;
            gvResumen.Visible = false;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<Evaluacion> lEvaluaciones = cEvaluacion.listarEvaluacionesAsignatura(ddAsignatura.SelectedValue);

            this.ddEvaluacion.Items.Clear();
            if (lEvaluaciones.Count > 0)
                this.ddEvaluacion.Items.Add(new ListItem("Seleccione una Evaluación", "0"));

            this.ddEvaluacion.DataTextField = "Nombre_evaluacion";
            this.ddEvaluacion.DataValueField = "Id_evaluacion";
            this.ddEvaluacion.DataSource = lEvaluaciones;
            this.DataBind();//enlaza los datos a un dropdownlist  
        }
        

        protected void btnAsignatura_Click(object sender, EventArgs e)
        {
            divRA.Visible = true;
            divDDA.Visible = true;
            divResultado.Visible = true;
            btnVerR.Visible = true;
            divBotones.Visible = false;
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            divBotones.Visible = false;
            divRAsignatura.Visible = true;
        }

        protected void ddTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRut.Text = "";
            divRut.Visible = false;
            this.ocultar();
            if (ddTipo.SelectedValue == "3")
            {
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
                divAno1.Visible = true;
                divAno2.Visible = true;
            }
            else if (ddTipo.SelectedValue == "5")
            {
                divRut.Visible = true;
            }
        }

        public void graficoColumna(string rut_alumno)
        {
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            List<Desempeno> lDesempenos = cDesempeno.listarDesempenosEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
            this.gvDesempenos.DataSource = lDesempenos;
            this.DataBind();

            panelGraficoColumna.Visible = true;
            chartColumnaAE.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<string> result = cEvaluacion.obtenerResultadosEvaluacionGeneralAlumno(int.Parse(ddEvaluacion.SelectedValue), rut_alumno);

            int i = 0;
            while (i < result.Count)
            {
                this.chartColumnaAE.Series["Correctas"].Points.AddXY(result[i], int.Parse(result[i + 1]));
                this.chartColumnaAE.Series["Incorrectas"].Points.AddXY(result[i], int.Parse(result[i + 2]));
                i = i + 3;
            }
            //Sacar cuadricula
            chartColumnaAE.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chartColumnaAE.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            System.Web.UI.DataVisualization.Charting.Title title = chartColumnaAE.Titles.Add(ddEvaluacion.SelectedItem.ToString());
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

        protected void btnVerR_Click(object sender, EventArgs e)
        {
            if (ddAsignatura2.SelectedValue != "0")
            {
                if (ddResultado.SelectedValue == "1")
                {
                    divDDA.Visible = true;
                    divResultado.Visible = true;
                    btnVerR.Visible = true;
                    graficoColumnaCompeAsignatura();
                    CatalogCompetencia cCompetencia = new CatalogCompetencia();
                    DataTable dtCompetencias = cCompetencia.mostrarCompetenciasAsignatura(ddAsignatura2.SelectedValue);
                    this.gvCompetencias.DataSource = dtCompetencias;
                    this.DataBind();
                    gvCompetencias.Visible = true;
                    divCompetenciasAsignatura.Visible = true;
                }
                else
                {
                    divDDA.Visible = true;
                    divResultado.Visible = true;
                    btnVerR.Visible = true;

                    graficoColumnaDesempeñoAsignatura();
                    CatalogDesempeno cDesempeno = new CatalogDesempeno();
                    List<Desempeno> lDesempenos = cDesempeno.listarDesempenosAsignatura(ddAsignatura2.SelectedValue);
                    this.gvDesempenos.DataSource = lDesempenos;
                    this.DataBind();
                    gvDesempenos.Visible = true;
                    divDesempeñosAsignatura.Visible = true;
                }
            }
            else
            {

            }
        }

        protected void ddResultado_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvDesempenos.Visible = false;
            gvCompetencias.Visible = false;
            divCompetenciasAsignatura.Visible = false;
            divDesempeñosAsignatura.Visible = false;
        }
    }
}