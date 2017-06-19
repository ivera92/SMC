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
                panelGrafico.Visible = false;
                if (!Page.IsPostBack)
                {
                    this.ocultarDivs();
                }
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }
        public void ocultarDivs()
        {
            divRut.Visible = false;
            divAsignatura.Visible = false;
            divEvaluacion.Visible = false;
            divDesempeno.Visible = false;
            btnGraficar.Visible = false;
        }

        public void limpiarDD()
        {
            ddAsignatura.SelectedIndex = 0;
            ddEvaluacion.SelectedIndex = 0;
            ddDesempeno.SelectedIndex = 0;
            txtRut.Text = "";
        }
        public void ocultarFitros()
        {
            divRut.Visible = false;
        }
        protected void ddAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ocultarFitros();
            divAlumno.Visible = false;
            if (ddAlumno.SelectedValue == "0")
            {
                divAsignatura.Visible = false;
                divEvaluacion.Visible = false;
                divDesempeno.Visible = false;
            }
            else if (ddAlumno.SelectedValue == "1")
            {
                txtRut.Text = "";
                divAsignatura.Visible = true;
                listarAsignaturas();
            }
            else if (ddAlumno.SelectedValue == "2")
            {
                divRut.Visible = true;
                listarAsignaturas();
                
                divAsignatura.Visible = true;
            }
        }
        public void listarAsignaturas()
        {
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignaturas = cAsignatura.listarAsignaturas();
            this.ddAsignatura.Items.Clear();
            ddAsignatura.Items.Add(new ListItem("<--Seleccione asignatura-->", "0"));
            this.ddAsignatura.DataTextField = "Nombre_asignatura";
            this.ddAsignatura.DataValueField = "Cod_asignatura";
            this.ddAsignatura.DataSource = lAsignaturas;
            this.ddAsignatura.DataBind();
        }

        protected void ddDisponibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarAsignaturas();
        }

        public void graficoColumna()
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            panelGrafico.Visible = true;
            List<string> result = cEvaluacion.obtenerResultadosEvaluacionGeneral(txtRut.Text, int.Parse(ddEvaluacion.SelectedValue), int.Parse(ddDesempeno.SelectedValue));

            int i = 0;
            while (i < result.Count)
            {
                string nombreCompetencia = result[i + 2];

                if (Boolean.Parse(result[i]) == true)
                {
                    this.chartColumna.Series["Correctas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                    i = i + 3;
                    try
                    {
                        if (Boolean.Parse(result[i]) == false)
                        {
                            this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i + 2], 0);
                        }
                        else
                        {
                            this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                            i = i + 3;
                        }
                    }
                    catch { }
                }
                else if (Boolean.Parse(result[i]) == false)
                {
                    this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                    i = i + 3;
                    try
                    {
                        if (Boolean.Parse(result[i]) == false)
                        {
                            this.chartColumna.Series["Correctas"].Points.AddXY(result[i + 2], 0);
                        }
                        else
                        {
                            this.chartColumna.Series["Correctas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                            i = i + 3;
                        }
                    }
                    catch { }
                }
            }
            chartColumna.Titles.Add(ddEvaluacion.SelectedItem.Text);

            /*/ Create a new legend called "Legend2".
            chartColumna.Legends.Add(new Legend("Incorrectas"));
            chartColumna.Legends.Add(new Legend("Correctas"));

            // Assign the legend to Series1.
            chartColumna.Series["Incorrectas"].Legend = "Incorrectas";
            chartColumna.Series["Incorrectas"].IsVisibleInLegend = true;

            chartColumna.Series["Correctas"].Legend = "Correctas";
            chartColumna.Series["Correctas"].IsVisibleInLegend = true;*/
            panelGrafico.Controls.Add(chartColumna);
        }


        protected void btnGraficar_Click(object sender, EventArgs e)
        {
            this.graficoColumna();
            panelGrafico.Visible = true;
            btnExportar.Visible = true;
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }
        public void mostrar()
        {
            this.gvResultados.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<Resultados> lResultados= cEvaluacion.obtenerResultadosEvaluacionGeneralGV(txtRut.Text, int.Parse(ddEvaluacion.SelectedValue), int.Parse(ddDesempeno.SelectedValue));
            this.gvResultados.DataSource = lResultados;
            this.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        //Exporta a Excel datos mediante ClosedXml
        protected void ExportExcel()
        {
            this.mostrar();
            
            DataTable dt = new DataTable("GridView_Data");
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

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
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

        protected void ddEvaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            List<Desempeno> lDesempeno = cDesempeno.listarDesempenosAsignatura(ddAsignatura.SelectedValue);

            this.ddDesempeno.Items.Clear();

            if (lDesempeno.Count > 0)
                this.ddDesempeno.Items.Add(new ListItem("Todos los Desempeños", "0"));

            this.ddDesempeno.DataTextField = "Indicador_desempeno";
            this.ddDesempeno.DataValueField = "Id_desempeno";
            this.ddDesempeno.DataSource = lDesempeno;
            this.DataBind();//enlaza los datos a un dropdownlist  

            divDesempeno.Visible = true;
            btnGraficar.Visible = true;
        }

        protected void ddAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            divEvaluacion.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<Evaluacion> lEvaluaciones = cEvaluacion.listarEvaluacionesAsignatura(ddAsignatura.SelectedValue);

            this.ddEvaluacion.Items.Clear();
            if (lEvaluaciones.Count > 0)
                this.ddEvaluacion.Items.Add(new ListItem("<--Seleccione una evaluacion-->", "0"));
            
            this.ddEvaluacion.DataTextField = "Nombre_evaluacion";
            this.ddEvaluacion.DataValueField = "Id_evaluacion";
            this.ddEvaluacion.DataSource = lEvaluaciones;
            this.DataBind();//enlaza los datos a un dropdownlist  
        }
    }
}