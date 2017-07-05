using Project;
using System;
using System.Collections.Generic;

namespace CapaDePresentacion.Doc
{
    public partial class ResultadosEspecificos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutDocente"].ToString();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignaturas = cAsignatura.listarAsignaturas();
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                gvDesempenos.Visible = false;
                divAlumno.Visible = false;
                divPregunta.Visible = false;
                divRut.Visible = false;
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
                chartColumna.Visible = true;
                lblCorrectas.InnerText = lResultados[2];
                gvDesempenos.Visible = true;
            }
            else if (ddOpcion.SelectedValue == "2")
            {
                List<string> lResultados = cEvaluacion.resultadosEspecificos(int.Parse(ddEvaluacion.SelectedValue), 2);
                lblNombreAlumno.InnerText = lResultados[1];
                this.graficoColumna(lResultados[0]);
                divPregunta.Visible = false;
                divAlumno.Visible = true;
                chartColumna.Visible = true;
                lblCorrectas.InnerText = lResultados[2];
                gvDesempenos.Visible = true;          
            }
            else if (ddOpcion.SelectedValue == "3")
            {
                List<string> lResultados = cEvaluacion.resultadosEspecificos(int.Parse(ddEvaluacion.SelectedValue), 3);
                txtAPregunta.InnerText = lResultados[1];
                lblCorrectasP.InnerText = lResultados[2];
                divAlumno.Visible = false;
                divPregunta.Visible = true;                
            }
            else if (ddOpcion.SelectedValue == "4")
            {
                List<string> lResultados = cEvaluacion.resultadosEspecificos(int.Parse(ddEvaluacion.SelectedValue), 4);
                txtAPregunta.InnerText = lResultados[1];
                lblCorrectasP.InnerText = lResultados[2];
                divAlumno.Visible = false;
                divPregunta.Visible = true;
            }
            else if (ddOpcion.SelectedValue == "5")
            {
                graficoColumna(txtRut.Text);
                divAlumno.Visible = true;
                lblCorrectas.Visible = false;
                lblNombreAlumno.Visible = false;
                nombre.Visible = false;
                respuestas.Visible = false;
                divPregunta.Visible = false;
                gvDesempenos.Visible = true;
            }
        }

        public void graficoColumna(string rut_alumno)
        {
            this.mostrar();
            panelGraficoColumna.Visible = true;
            chartColumna.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<string> result = cEvaluacion.obtenerResultadosEvaluacionGeneralAlumno(int.Parse(ddEvaluacion.SelectedValue), rut_alumno);

            int i = 0;
            bool primera_vez = true;
            while (i < result.Count)
            {

                if (Boolean.Parse(result[i]) == true && primera_vez)
                {
                    this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i + 2], 0);
                    this.chartColumna.Series["Correctas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                    i = i + 3;
                    primera_vez = false;
                }

                else if (Boolean.Parse(result[i]) == false)
                {
                    string x = result[i + 2];
                    this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                    i = i + 3;
                    try
                    {
                        if (Boolean.Parse(result[i]) == false)
                        {
                            this.chartColumna.Series["Correctas"].Points.AddXY(x, 0);
                        }
                        else
                        {
                            this.chartColumna.Series["Correctas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                            i = i + 3;
                        }
                    }
                    catch
                    {
                        this.chartColumna.Series["Correctas"].Points.AddXY(x, 0);
                    }
                }
                else if (Boolean.Parse(result[i]) == true)
                {
                    this.chartColumna.Series["Incorrectas"].Points.AddXY(result[i + 2], 0);
                    this.chartColumna.Series["Correctas"].Points.AddXY(result[i + 2], int.Parse(result[i + 1]));
                    i = i + 3;
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

        protected void ddOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartColumna.Visible = false;
            divAlumno.Visible = false;
            gvDesempenos.Visible = false;
            divPregunta.Visible = false;
            if (ddOpcion.SelectedValue == "5")
            {
                txtRut.Text = "";
                divRut.Visible = true;
            }
            else
            {
                divRut.Visible = false;
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
    }
}