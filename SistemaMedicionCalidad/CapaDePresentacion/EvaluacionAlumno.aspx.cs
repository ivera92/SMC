using System;
using System.Data;
using System.Data.Common;
using Project.CapaDeDatos;

namespace CapaDePresentacion
{
    public partial class EvaluacionAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}