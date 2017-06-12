using Project;
using Project.CapaDeNegocios;
using System;

namespace CapaDePresentacion.Doc
{
    public partial class InicioDocente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verifica que un docente haya iniciado sesion y carga sus datos, de lo contrario lo redirige 
            try
            {
                string rut = Session["rutDocente"].ToString();                
                this.cargarDatosDocente(rut);
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }
        //Carga los datos en la ventana inicial despues de digitar el rut de usuario y contraseña en el login
        public void cargarDatosDocente(string rut)
        {
            CatalogDocente cDocente = new CatalogDocente();
            Docente d = cDocente.buscarUnDocente(rut);

            nombreDocente.InnerText = d.Nombre_persona;
            correo.InnerText = d.Correo_persona;
            
        }
    }
}