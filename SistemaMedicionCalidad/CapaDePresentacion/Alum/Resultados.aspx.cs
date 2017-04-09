using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion.Alum
{
    public partial class Resultados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignatura = cAsignatura.listarAsignaturas();
            

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Id_asignatura";
                this.ddAsignatura.DataSource = lAsignatura;                

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }
        public void graficar()
        {
            string rut = Session["rutAlumno"].ToString();
            string[] series = { "Correctas", "Incorrectas" };
            CatalogHPA cHPA = new CatalogHPA();
            int[] arrResultados = new int[2];
            if (ddCompetencia.SelectedValue == "0")
            {
                arrResultados = cHPA.resultadoPreguntasE(rut, int.Parse(ddEvaluacion.SelectedValue));
            }
            else
            {
                arrResultados = cHPA.resultadoPreguntas(rut, int.Parse(ddCompetencia.SelectedValue));
            }

            chartEvaluacion.Series.Clear();
            chartEvaluacion.Palette = ChartColorPalette.Fire;
            chartEvaluacion.BackColor = Color.LightYellow;
            chartEvaluacion.Titles.Add(ddCompetencia.SelectedItem.ToString());
            chartEvaluacion.ChartAreas[0].BackColor = Color.Transparent;
            Series series1 = new Series
            {
                Name = "series1",
                IsVisibleInLegend = true,
                Color = Color.Green,
                ChartType = SeriesChartType.Pie
            };
            chartEvaluacion.Series.Add(series1);
            series1.Points.Add(arrResultados[0]);
            series1.Points.Add(arrResultados[1]);
            var p1 = series1.Points[0];
            p1.AxisLabel = series[0];
            p1.LegendText = "Hiren Khirsaria";
            var p2 = series1.Points[1];
            p2.AxisLabel = series[1];
            p2.LegendText = "ABC XYZ";
            Panel1.Controls.Add(chartEvaluacion);
        }

        protected void btnGraficar_Click(object sender, EventArgs e)
        {
            this.graficar();
        }
        public void chart()
        {
            string rut = Session["rutAlumno"].ToString();
            string[] series = { "Correctas", "Incorrectas" };
            CatalogHPA cHPA = new CatalogHPA();

            int[] arrResultados = cHPA.resultadoPreguntas(rut, int.Parse(ddCompetencia.SelectedValue));

            Chart pieChart = new Chart();

            ChartArea area = new ChartArea("PierChartArea");
            pieChart.ChartAreas.Add(area);

            pieChart.Series.Clear();
            pieChart.Palette = ChartColorPalette.EarthTones;
            pieChart.BackColor = System.Drawing.Color.LightBlue;
            pieChart.Titles.Add(ddCompetencia.DataTextField);
            pieChart.ChartAreas[0].BackColor = System.Drawing.Color.Transparent;

            Legend l = new Legend()
            {
                BackColor = System.Drawing.Color.Transparent,
                ForeColor = System.Drawing.Color.Black,
                Title = "Resultados"
            };

            pieChart.Legends.Add(l);

            Series s1 = new Series()
            {
                Name = "s1",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Transparent,
                ChartType = SeriesChartType.Pie
            };

            pieChart.Series.Add(s1);

            for (int i = 0; i < arrResultados.Length; i++)
            {
                s1.Points.Add(arrResultados[i]);
            }
            this.Panel1.Controls.Add(pieChart);
        }

        protected void ddAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<Evaluacion> lEvaluaciones = cEvaluacion.listarEvaluacionesAsignatura(int.Parse(ddAsignatura.SelectedValue));

            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencia = cCompetencia.listarCompetenciasAsignatura(int.Parse(ddAsignatura.SelectedValue));

            this.ddEvaluacion.Items.Clear();
            this.ddEvaluacion.DataTextField = "Nombre_evaluacion";
            this.ddEvaluacion.DataValueField = "Id_evaluacion";
            this.ddEvaluacion.DataSource = lEvaluaciones;

            this.ddCompetencia.Items.Clear();

            if (lCompetencia.Count > 0)
                this.ddCompetencia.Items.Add(new ListItem("Todas las Competencias", "0"));

            this.ddCompetencia.DataTextField = "Nombre_competencia";
            this.ddCompetencia.DataValueField = "Id_competencia";
            this.ddCompetencia.DataSource = lCompetencia;
            this.DataBind();//enlaza los datos a un dropdownlist    
        }
    }
}