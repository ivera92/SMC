using System;
using Project;
using Project.CapaDeNegocios;
using System.Collections.Generic;

namespace CapaDePresentacion.Alum
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {           
            }

            try
            {
                string rut = Session["rutAlumno"].ToString();
                this.cargarDatosAlumno(rut);
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }            
        }
        //Carga los datos del docente
        public void cargarDatosAlumno(string rut)
        {
            CatalogAlumno cAlumno = new CatalogAlumno();
            Alumno a = cAlumno.buscarAlumnoPorRut(rut);      

            nombreAlumno.InnerText = a.Nombre_persona;
            correoAlumno.InnerText = a.Correo_persona;

        }
    }
}