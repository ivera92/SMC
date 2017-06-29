using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using System.IO;
using ClosedXML.Excel;
using System.Web;

namespace CapaDePresentacion.Doc
{
    public partial class ResultadosEvaluacionesD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutDocente"].ToString();
                btnExportar.Visible = false;
                panelGrafico.Visible = false;
                if (!Page.IsPostBack)
                {
                    this.listarAsignaturas();
                    gvDesempenos.Visible = false;
                }
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }
        public void listarAsignaturas()
        {
            string rut = Session["rutDocente"].ToString();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignaturas = cAsignatura.listarAsignaturasDocente(rut);
            this.ddAsignatura.Items.Clear();
            ddAsignatura.Items.Add(new ListItem("<--Seleccione asignatura-->", "0"));
            this.ddAsignatura.DataTextField = "Nombre_asignatura";
            this.ddAsignatura.DataValueField = "Cod_asignatura";
            this.ddAsignatura.DataSource = lAsignaturas;
            this.ddAsignatura.DataBind();
        }

        public void graficoColumna()
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            panelGrafico.Visible = true;
            List<string> result = cEvaluacion.obtenerResultadosEvaluacionGeneral(int.Parse(ddEvaluacion.SelectedValue));

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
            panelGrafico.Controls.Add(chartColumna);
        }


        protected void btnGraficar_Click(object sender, EventArgs e)
        {
            gvDesempenos.Visible = true;
            this.graficoColumna();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            List<Desempeno> lDesempenos = cDesempeno.listarDesempenosEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
            this.gvDesempenos.DataSource = lDesempenos;
            this.DataBind();
            gvDesempenos.Visible = true;
            panelGrafico.Visible = true;
            btnExportar.Visible = true;
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }
        public void mostrar()
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();            
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            List<Desempeno> lDesempenos = cDesempeno.listarDesempenosEvaluacion(int.Parse(ddEvaluacion.SelectedValue));
            this.gvDesempenos.DataSource = lDesempenos;
            List<Resultados> lResultados= cEvaluacion.obtenerResultadosEvaluacionGeneralGV(int.Parse(ddEvaluacion.SelectedValue));
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
            
            DataTable dt = new DataTable("Resultados");
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
                wb.Worksheets.Add(dt);
                wb.Worksheets.Add(dtDesempenos);
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