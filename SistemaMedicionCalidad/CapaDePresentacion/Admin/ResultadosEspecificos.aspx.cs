﻿using Project;
using System;
using System.Collections.Generic;

namespace CapaDePresentacion.Admin
{
    public partial class ResultadosEspecificos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignaturas = cAsignatura.listarAsignaturas();
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                divAlumno.Visible = false;
                divPregunta.Visible = false;
                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Cod_asignatura";
                this.ddAsignatura.DataSource = lAsignaturas;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            if (ddOpcion.SelectedValue == "1")
            {
                List<string> lResultados = cEvaluacion.resultadosEspecificos(int.Parse(ddEvaluacion.SelectedValue), 1);
                lblNombreAlumno.InnerText = lResultados[1];
                this.graficoColumna(lResultados[0]);
                divPregunta.Visible = false;
                divAlumno.Visible = true;
                lblCorrectas.InnerText = lResultados[2];
            }
            else if (ddOpcion.SelectedValue == "2")
            {
                List<string> lResultados = cEvaluacion.resultadosEspecificos(int.Parse(ddEvaluacion.SelectedValue), 2);
                lblNombreAlumno.InnerText = lResultados[1];
                this.graficoColumna(lResultados[0]);
                divPregunta.Visible = false;
                divAlumno.Visible = true;
                lblCorrectas.InnerText = lResultados[2];                
            }
            else if (ddOpcion.SelectedValue == "3")
            {
                List<string> lResultados = cEvaluacion.resultadosEspecificos(int.Parse(ddEvaluacion.SelectedValue), 3);
                txtAPregunta.InnerText = lResultados[1];
                lblID.InnerText = lResultados[0];
                lblCorrectasP.InnerText = lResultados[2];
                divAlumno.Visible = false;
                divPregunta.Visible = true;                
            }
            else if (ddOpcion.SelectedValue == "4")
            {
                List<string> lResultados = cEvaluacion.resultadosEspecificos(int.Parse(ddEvaluacion.SelectedValue), 4);
                txtAPregunta.InnerText = lResultados[1];
                lblID.InnerText = lResultados[0];
                lblCorrectasP.InnerText = lResultados[2];
                divAlumno.Visible = false;
                divPregunta.Visible = true;
            }
        }

        public void graficoColumna(string rut_alumno)
        {
            panelGraficoColumna.Visible = true;
            chartColumna.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<string> result = cEvaluacion.obtenerResultadosEvaluacionGeneralAlumno(int.Parse(ddEvaluacion.SelectedValue), rut_alumno);

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
        }
    }
}