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
                panelGrafico.Visible = false;
                if (!Page.IsPostBack)
                {
                    this.listarAsignaturas();
                }
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }

            if (!Page.IsPostBack)
            {
                this.listarAsignaturas();
            }
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
            gvDesempenos.Visible = true;
            gvResumen.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            panelGrafico.Visible = true;
            List<string> result = cEvaluacion.obtenerResultadosEvaluacionGeneral(int.Parse(ddEvaluacion.SelectedValue));

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

            panelGrafico.Controls.Add(chartColumna);
        }

        public void graficoPuntos()
        {
            chartPuntos.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            panelGrafico.Visible = true;
            DataTable dtPromedio = cEvaluacion.promedio(cEvaluacion.mostrarResumen(int.Parse(ddEvaluacion.SelectedValue)));
            string rut = "";
            double promedio = 0;
            int i = 0;
            foreach (DataRow row in dtPromedio.Rows)
            {
                i += 1;
                rut = row[0].ToString();
                promedio = double.Parse(row[3].ToString());
                this.chartPuntos.Series["Rut"].Points.AddXY("A"+i, promedio);
            }
            chartPuntos.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chartPuntos.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            System.Web.UI.DataVisualization.Charting.Title title = chartPuntos.Titles.Add(ddEvaluacion.SelectedItem.ToString());
            title.Font = new Font("Segoe UI", 16, FontStyle.Regular);
            title.ForeColor = Color.White;

            panelGrafico.Controls.Add(chartPuntos);
        }




        protected void btnGraficar_Click(object sender, EventArgs e)
        {
            if (ddAsignatura.SelectedValue == "0" || ddEvaluacion.SelectedValue == "0" || ddEvaluacion.SelectedValue == "")
            {
                Response.Write("<script>alert('Seleccione una Asignatura y Evaluación para poder graficar');</script>");
            }
            else
            {
                this.graficoColumna();
                this.graficoPuntos();
                CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                DataTable dt = cEvaluacion.mostrarResumen(int.Parse(ddEvaluacion.SelectedValue));
                DataTable promedio = cEvaluacion.promedio(dt);
                this.gvResumen.DataSource = promedio;
                CatalogDesempeno cDesempeno = new CatalogDesempeno();
                List<Desempeno> lDesempenos = cDesempeno.listarDesempenosEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
                this.gvDesempenos.DataSource = lDesempenos;
                this.DataBind();
                gvDesempenos.Visible = true;
                gvResumen.Visible = true;
                panelGrafico.Visible = true;
                btnExportar.Visible = true;
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
            List<Resultados> lResultados = cEvaluacion.obtenerResultadosEvaluacionGeneralPorAlumnoGV(int.Parse(ddEvaluacion.SelectedValue));
            List<Desempeno> lDesempenos = cDesempeno.listarDesempenosEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
            List<Resultados> lResultadosGenerales = cEvaluacion.obtenerResultadosEvaluacionGeneralesGV(int.Parse(ddEvaluacion.SelectedValue));
            this.gvResultados.DataSource = lResultados;
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
            dtResumen.TableName = "Resumen Respuestas Alumnos";
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
                wb.Worksheets.Add(dtResumen);

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