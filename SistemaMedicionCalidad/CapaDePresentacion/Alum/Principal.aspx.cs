using System;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion.Alum
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rut = Session["rutAlumno"].ToString();
            this.cargarDatosAlumno(rut);
            
        }
        public void cargarDatosAlumno(string rut)
        {
            CatalogAlumno cAlumno = new CatalogAlumno();
            Alumno a = cAlumno.buscarAlumnoPorRut(rut);
            CatalogEscuela cEscuela = new CatalogEscuela();
            Escuela es = cEscuela.buscarUnaEscuela((a.Escuela_alumno.Id_escuela) + 1);
            CatalogPais cPais = new CatalogPais();
            Pais p = cPais.buscarUnPais(a.Pais_persona.Id_pais + 1);

            nombreAlumno.InnerText = a.Nombre_persona;
            nombreEscuela.InnerText = es.Nombre_escuela;
            nacionalidad.InnerText = p.Nombre_pais;
            fechaNacimiento.InnerText = a.Fecha_nacimiento_persona.Date.ToString("dd/M/yyyy");
            direccion.InnerText = a.Direccion_persona;
            telefono.InnerText = a.Telefono_persona + "";
            correo.InnerText = a.Correo_persona;
            promocion.InnerText = a.Promocion_alumno + "";
        }
    }
}