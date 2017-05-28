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
        //Carga los datos del docente
        public void cargarDatosAlumno(string rut)
        {
            CatalogAlumno cAlumno = new CatalogAlumno();
            Alumno a = cAlumno.buscarAlumnoPorRut(rut);
            CatalogEscuela cEscuela = new CatalogEscuela();
            Escuela es = cEscuela.buscarUnaEscuela(a.Escuela_alumno.Id_escuela);
            CatalogPais cPais = new CatalogPais();
            Pais p = cPais.buscarUnPais(a.Pais_persona.Id_pais);

            nombreAlumno.InnerText = a.Nombre_persona;
            correo.InnerText = a.Correo_persona;
            nombreEscuela.InnerText = es.Nombre_escuela;

            try
            {
                nacionalidad.InnerText = p.Nombre_pais;
                fechaNacimiento.InnerText = a.Fecha_nacimiento_persona.Date.ToString("dd/M/yyyy");
                direccion.InnerText = a.Direccion_persona;
                telefono.InnerText = a.Telefono_persona + "";
                promocion.InnerText = a.Promocion_alumno + "";
            }
            catch {
                nacionalidad.InnerText = "";
                fechaNacimiento.InnerText = "";
                direccion.InnerText = "";
                telefono.InnerText = "";
                promocion.InnerText = "";
            }
        }
    }
}