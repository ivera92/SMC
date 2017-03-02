using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            CatalogCompetencia cc = new CatalogCompetencia();
            List<Competencia> lc = cc.mostrarCompetencias();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddCompetencia.DataTextField = "Nombre_competencia";
                this.ddCompetencia.DataValueField = "Id_competencia";
                this.ddCompetencia.DataSource = lc;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }
        public void graficar()
        {
            string rut = Session["rutAlumno"].ToString();
            string[] series = { "Correctas", "Incorrectas" };
            CatalogHPA chpa = new CatalogHPA();

            
            int[] arrResultados = chpa.resultadoPreguntas(rut, int.Parse(ddCompetencia.SelectedValue));
            List<string> ls = series.ToList();
            List<Int32> li = arrResultados.ToList();
            this.Chart1.Series.Clear();

            // Set palette
            this.Chart1.Palette = ChartColorPalette.EarthTones;

            // Set title
            this.Chart1.Titles.Add(ddCompetencia.Text);

            // Add series.
            /*for (int i = 0; i < series.Length; i++)
            {
                Series Serie2 = this.Chart1.Series.Add(series[i]);
                Serie2.Points.Add(arrResultados[i]);
            }*/
            Chart1.Series[0].Points.DataBindXY(ls, li);
        }

        protected void btnGraficar_Click(object sender, EventArgs e)
        {
            this.chart();
        }
        public void chart()
        {
            string rut = Session["rutAlumno"].ToString();
            string[] series = { "Correctas", "Incorrectas" };
            CatalogHPA chpa = new CatalogHPA();

            int[] arrResultados = chpa.resultadoPreguntas(rut, int.Parse(ddCompetencia.SelectedValue));

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
    }
}