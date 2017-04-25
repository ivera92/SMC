using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Project;
using Project.CapaDeDatos;

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

        public void graficarColumna()
        {
            string rut = Session["rutAlumno"].ToString();
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "SELECT CORRECTA_RESPUESTA, count(id_competencia) as cantidad, NOMBRE_COMPETENCIA FROM COMPETENCIA INNER JOIN PREGUNTA ON ID_COMPETENCIA = ID_COMPETENCIA_PREGUNTA INNER JOIN HISTORICO_PRUEBA_ALUMNO ON ID_PREGUNTA = ID_PREGUNTA_HPA INNER JOIN RESPUESTA ON ID_PREGUNTA = ID_PREGUNTA_RESPUESTA AND ID_RESPUESTA_HPA = ID_RESPUESTA where rut_alumno_hpa='" + rut + "' group by id_competencia, correcta_respuesta, nombre_competencia"; 
            bd.CreateCommand(sqlSearch);
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                if (result.GetBoolean(0) == false)
                {
                    this.chartColumna.Series["Incorrectas"].Points.AddXY(result.GetString(2), result.GetInt32(1));
                }
                else if (result.GetBoolean(0) == true)
                {
                    this.chartColumna.Series["Correctas"].Points.AddXY(result.GetString(2), result.GetInt32(1));
                }
            }
            
            // Create a new legend called "Legend2".
            chartColumna.Legends.Add(new Legend("Incorrectas"));
            chartColumna.Legends.Add(new Legend("Correctas"));

            // Assign the legend to Series1.
            chartColumna.Series["Incorrectas"].Legend = "Incorrectas";
            chartColumna.Series["Incorrectas"].IsVisibleInLegend = true;

            chartColumna.Series["Correctas"].Legend = "Correctas";
            chartColumna.Series["Correctas"].IsVisibleInLegend = true;
            result.Close();
            bd.Close();
        }

        protected void btnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddCompetencia.SelectedValue == "0")
                {
                    this.graficar();
                    this.graficarColumna();
                }
                else
                {
                    this.graficar();
                }
            }catch
            {
            }
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