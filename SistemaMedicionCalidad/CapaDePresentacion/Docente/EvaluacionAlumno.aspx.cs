using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using Project.CapaDeDatos;

namespace CapaDePresentacion
{
    public partial class EvaluacionAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogAsignatura ca = new CatalogAsignatura();
            List<Asignatura> la = ca.mostrarAsignaturas();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Id_asignatura";
                this.ddAsignatura.DataSource = la;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }

        }
        public static string verificar(string rut_alumno)
        {
            //consulta a la base de datos
            string s = "";
            string sql = @"SELECT nombre_alumno FROM alumno WHERE rut_alumno = @rut_alumno";
            //cadena conexion

            DataBase bd = new DataBase();
            bd.connect();

            bd.CreateCommand(sql);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);
            DbDataReader result = bd.Query();//disponible resultado
            if (result.Read())
            {
                s = result.GetString(0);
            }
            return s;
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = verificar(txtRut.Text);
            if (verificar(txtRut.Text) != "")
            {
                lblNombreAlumno.Visible = true;
                lblNombreAlumno.InnerText = "Alumno a evaluar: " + nombre;
            }
            else
            {
                lblNombreAlumno.Visible = false;
                Response.Write("<script>window.alert('Alumno no existe');</script>");
            }
        }     

        public void crearControles()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "SELECT nombre_tipo_pregunta, NOMBRE_RESPUESTA, nombre_pregunta, id_pregunta FROM [ASIGNATURA_COMPETENCIA] inner join asignatura on [asignatura_competencia].id_asignatura_ac = asignatura.id_asignatura inner join competencia on [asignatura_competencia].id_competencia_ac = competencia.id_competencia inner join pregunta on competencia.id_competencia = pregunta.id_competencia_pregunta inner join tipo_pregunta on pregunta.id_tipo_pregunta_pregunta = tipo_pregunta.id_tipo_pregunta inner join respuesta on id_pregunta_respuesta=id_pregunta where asignatura.id_asignatura ='" + this.ddAsignatura.SelectedValue + "'";

            bd.CreateCommand(sql);
            DbDataReader result = bd.Query();
            string s = "";
            
            string[] letras = { "A) ", "B) ", "C) ", "D) ", "F) " };
            int numPregunta = 1;
            int i = 0;
            RadioButtonList rbl = new RadioButtonList();

            while (result.Read())
            {
                Label pregunta = new Label();
                pregunta.Text = result.GetString(2);
                Label l2 = new Label();
                l2.Text = numPregunta + ") " + result.GetString(2);

                if (s != pregunta.Text)
                {
                    if (result.GetString(0) == "Seleccion multiple")
                    {
                        rbl = new RadioButtonList();
                    }
                    i = 0;
                    this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                    this.Panel1.Controls.Add(l2);
                    this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                    numPregunta = numPregunta + 1;
                    s = pregunta.Text;
                }
                if (result.GetString(0) == "Seleccion multiple" && s == pregunta.Text)
                {
                    rbl.Items.Add(letras[i] + " " + result.GetString(1));
                    this.Panel1.Controls.Add(rbl);
                    s = result.GetString(2);
                    i = i + 1;
                }

                else if (result.GetString(0) == "Casillas de verificacion" && s == pregunta.Text)
                {
                    CheckBox cbx = new CheckBox();
                    cbx.Text = letras[i] + " " + result.GetString(1);
                    this.Panel1.Controls.Add(cbx);
                    i = i + 1;               
                }
            }
        }
        protected void btnCargarPreguntas_Click(object sender, EventArgs e)
        {
            this.crearControles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}