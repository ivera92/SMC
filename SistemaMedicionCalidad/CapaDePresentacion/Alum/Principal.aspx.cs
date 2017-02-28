using System;
using System.Reflection.Emit;
using System.Web.UI.WebControls;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion.Alum
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rut = Session["rutAlumno"].ToString();
            CatalogAlumno ca = new CatalogAlumno();
            Alumno a = ca.buscarAlumnoPorRut(rut);
            CatalogEscuela ce = new CatalogEscuela();
            Escuela es = ce.buscarUnaEscuela((a.Escuela_alumno.Id_escuela)+1);
            CatalogPais cp = new CatalogPais();
            Pais p = cp.buscarUnPais(a.Pais_alumno.Id_pais + 1);
            
            nombreAlumno.InnerText = a.Nombre_alumno;
            nombreEscuela.InnerText = es.Nombre_escuela;
            nacionalidad.InnerText = p.Nombre_pais;
            fechaNacimiento.InnerText = a.Fecha_nacimiento_alumno.Date.ToString("dd/M/yyyy");
            direccion.InnerText = a.Direccion_alumno;
            telefono.InnerText = a.Telefono_alumno+"";
            correo.InnerText = a.Correo_alumno;
            promocion.InnerText = a.Promocion_alumno+"";

            
        }
    }
}