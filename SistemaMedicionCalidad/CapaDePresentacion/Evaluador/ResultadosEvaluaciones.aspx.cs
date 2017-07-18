using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Project;
using System.IO;
using ClosedXML.Excel;
using System.Web;
using System.Drawing;

namespace CapaDePresentacion.Evaluador
{
    public partial class ResultadosEvaluaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutEvaluador"].ToString();
                btnExportar.Visible = false;

                if (!Page.IsPostBack)
                {
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
        }

        public void listarAsignaturas()
        {
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignaturas = cAsignatura.listarAsignaturas();
            this.ddAsignatura.Items.Clear();
            ddAsignatura.Items.Add(new ListItem("Seleccione una Asignatura", "0"));
            this.ddAsignatura.DataTextField = "Nombre_asignatura";
            this.ddAsignatura.DataValueField = "Cod_asignatura";
            this.ddAsignatura.DataSource = lAsignaturas;
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

        public void graficoPuntos()
        {
            chartPuntos.Series["Aprobado"].IsXValueIndexed = false;
            chartPuntos.Series["Reprobado"].IsXValueIndexed = false;
            chartPuntos.Series["Promedio Curso"].IsXValueIndexed = false;
            this.chartPuntos.Series["Reprobado"].MarkerSize = 10;
            this.chartPuntos.Series["Aprobado"].MarkerSize = 10;
            this.chartPuntos.Series["Promedio Curso"].MarkerSize = 10;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            DataTable dtPromedio = cEvaluacion.promedio(cEvaluacion.mostrarResumen(int.Parse(ddEvaluacion.SelectedValue)));
            string rut = "";
            double promedio = 0;
            double promedio_curso = 0;
            int i = 0;
            foreach (DataRow row in dtPromedio.Rows)
            {
                i += 1;
                promedio = double.Parse(row[5].ToString());

                if (promedio >= 4.0)
                {
                    this.chartPuntos.Series["Aprobado"].Points.AddXY("", promedio);
                }
                else
                {
                    this.chartPuntos.Series["Reprobado"].Points.AddXY("", promedio);
                }
                promedio_curso += promedio;
            }
            promedio_curso = Math.Round(promedio_curso / i, 1, MidpointRounding.AwayFromZero);
            this.chartPuntos.Series["Promedio Curso"].Points.AddXY("", promedio_curso);

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
            btnExportar.Visible = true;
            if (ddAsignatura.SelectedValue == "0" || ddEvaluacion.SelectedValue == "0" || ddEvaluacion.SelectedValue == "" || ddTipo.SelectedValue == "0")
            {
                Response.Write("<script>alert('Seleccione una Asignatura y Evaluación para poder graficar');</script>");
            }
            else
            {
                if (ddTipo.SelectedValue == "1")
                {
                    this.graficoColumna();
                    CatalogDesempeno cDesempeno = new CatalogDesempeno();
                    List<Desempeno> lDesempenos = cDesempeno.listarDesempenosEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
                    this.gvDesempenos.DataSource = lDesempenos;
                    this.DataBind();
                    gvDesempenos.Visible = true;
                    divCC.Visible = true;
                }
                else
                {
                    this.graficoPuntos();
                    CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                    DataTable dt = cEvaluacion.mostrarResumen(int.Parse(ddEvaluacion.SelectedValue));
                    DataTable promedio = cEvaluacion.promedio(dt);
                    this.gvResumen.DataSource = promedio;
                    this.DataBind();
                    gvResumen.Visible = true;
                    divCP.Visible = true;
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
    }
}