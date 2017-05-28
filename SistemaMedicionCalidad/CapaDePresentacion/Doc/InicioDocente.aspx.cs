using Project;
using Project.CapaDeNegocios;
using System;

namespace CapaDePresentacion.Doc
{
    public partial class InicioDocente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutDocente"].ToString();                
                this.cargarDatosDocente(rut);
            }
            catch { }
        }
        //Carga los datos en la ventana inicial despues de digitar el rut de usuario y contraseña en el login
        public void cargarDatosDocente(string rut)
        {
            CatalogDocente cDocente = new CatalogDocente();
            Docente d = cDocente.buscarUnDocente(rut);
            CatalogProfesion cProfesion = new CatalogProfesion();
            Profesion pro = cProfesion.buscarUnaProfesion(d.Profesion_docente.Id_profesion);
            CatalogPais cPais = new CatalogPais();
            Pais p = cPais.buscarUnPais(d.Pais_persona.Id_pais);

            nombreDocente.InnerText = d.Nombre_persona;
            profesionDocente.InnerText = pro.Nombre_profesion;
            correo.InnerText = d.Correo_persona;

            try
            {
                nacionalidad.InnerText = p.Nombre_pais;
                fechaNacimiento.InnerText = d.Fecha_nacimiento_persona.Date.ToString("dd/M/yyyy");
                direccion.InnerText = d.Direccion_persona;
                telefono.InnerText = d.Telefono_persona + "";
            }
            catch
            {
                nacionalidad.InnerText = "";
                fechaNacimiento.InnerText = "";
                direccion.InnerText = "";
                telefono.InnerText = "";
            }
        }
    }
}