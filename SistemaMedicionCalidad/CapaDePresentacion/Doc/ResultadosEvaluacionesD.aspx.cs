﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Project;
using Project.CapaDeNegocios;
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
            divPais.Visible = false;
            divPromocion.Visible = false;
            divRut.Visible = false;
            divSexo.Visible = false;
            divAsignatura.Visible = false;
            divEvaluacion.Visible = false;
            divCompetencia.Visible = false;
            btnGraficar.Visible = false;
        }

        public void limpiarDD()
        {
            ddPais.SelectedIndex = 0;
            ddPromocion.SelectedIndex = 0;
            ddSexo.SelectedIndex = 0;
            ddAsignatura.SelectedIndex = 0;
            ddEvaluacion.SelectedIndex = 0;
            ddCompetencia.SelectedIndex = 0;
            txtRut.Text = "";
        }
        public void ocultarFitros()
        {
            divPais.Visible = false;
            divPromocion.Visible = false;
            divRut.Visible = false;
            divSexo.Visible = false;
        }
        protected void ddAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ocultarFitros();
            if (ddAlumno.SelectedValue == "0")
            {
                divAsignatura.Visible = false;
                divEvaluacion.Visible = false;
                divCompetencia.Visible = false;
            }
            else if (ddAlumno.SelectedValue == "1")
            {
                divAsignatura.Visible = true;
                listarAsignaturas();
            }
            else if (ddAlumno.SelectedValue == "2")
            {
                CatalogPais cPais = new CatalogPais();
                List<Pais> lPaises = cPais.listarPaises();
                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lPaises;
                this.DataBind();//enlaza los datos a un dropdownlist     

                divPais.Visible = true;
            }
            else if (ddAlumno.SelectedValue == "3")
            {
                CatalogAlumno cAlumno = new CatalogAlumno();
                List<int> lPromociones = cAlumno.listarPromociones();
                foreach (int item in lPromociones)
                {
                    this.ddPromocion.Items.Add(new ListItem(item + ""));
                }
                divPromocion.Visible = true;
            }
            else if (ddAlumno.SelectedValue == "4")
            {
                divRut.Visible = true;
                listarAsignaturas();
                
                divAsignatura.Visible = true;
            }
            else if (ddAlumno.SelectedValue == "5")
            {
                divSexo.Visible = true;
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

        protected void ddDisponibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarAsignaturas();
        }

        protected void ddSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarAsignaturas();
        }
        protected void ddPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarAsignaturas();
        }
        protected void ddPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarAsignaturas();
        }      

        public void graficoColumna()
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            panelGrafico.Visible = true;
            List<string> result = cEvaluacion.obtenerResultadosEvaluacionGeneral(int.Parse(ddPais.SelectedValue), int.Parse(ddPromocion.SelectedValue), txtRut.Text, int.Parse(ddSexo.SelectedValue), 0, int.Parse(ddEvaluacion.SelectedValue), int.Parse(ddCompetencia.SelectedValue));

            int i = 0;
            while (i < result.Count)
            {
                string nombreCompetencia = result[i + 2];
                if (Boolean.Parse(result[i]) == false)
                {
                    this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                    i = i + 3;
                    try
                    {
                        if (Boolean.Parse(result[i]) == false)
                        {
                            this.chartColumna.Series["Correctas"].Points.AddXY(nombreCompetencia, 0);
                        }
                        else
                        {
                            this.chartColumna.Series["Correctas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                            i = i + 3;
                        }
                    }
                    catch { }
                }
                else if (Boolean.Parse(result[i]) == true)
                {
                    this.chartColumna.Series["Correctas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                    i = i + 3;
                    try
                    {
                        if (Boolean.Parse(result[i]) == true)
                        {
                            this.chartColumna.Series["Inorrectas"].Points.AddXY(nombreCompetencia, 0);
                        }
                        else
                        {
                            this.chartColumna.Series["Inorrectas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                            i = i + 3;
                        }
                    }
                    catch { }
                }
            }
            chartColumna.Titles.Add(ddEvaluacion.SelectedItem.Text);

            // Create a new legend called "Legend2".
            chartColumna.Legends.Add(new Legend("Incorrectas"));
            chartColumna.Legends.Add(new Legend("Correctas"));

            // Assign the legend to Series1.
            chartColumna.Series["Incorrectas"].Legend = "Incorrectas";
            chartColumna.Series["Incorrectas"].IsVisibleInLegend = true;

            chartColumna.Series["Correctas"].Legend = "Correctas";
            chartColumna.Series["Correctas"].IsVisibleInLegend = true;
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
            List<Resultados> lResultados= cEvaluacion.obtenerResultadosEvaluacionGeneralGV(int.Parse(ddPais.SelectedValue), int.Parse(ddPromocion.SelectedValue), txtRut.Text, int.Parse(ddSexo.SelectedValue), 0, int.Parse(ddEvaluacion.SelectedValue), int.Parse(ddCompetencia.SelectedValue));
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
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencia = cCompetencia.listarCompetenciasAsignatura(ddAsignatura.SelectedValue);

            this.ddCompetencia.Items.Clear();

            if (lCompetencia.Count > 0)
                this.ddCompetencia.Items.Add(new ListItem("Todas las Competencias", "0"));

            this.ddCompetencia.DataTextField = "Nombre_competencia";
            this.ddCompetencia.DataValueField = "Id_competencia";
            this.ddCompetencia.DataSource = lCompetencia;
            this.DataBind();//enlaza los datos a un dropdownlist  

            divCompetencia.Visible = true;
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