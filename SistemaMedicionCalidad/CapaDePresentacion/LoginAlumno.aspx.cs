using System;
using System.Collections.Generic;
using System.Web.UI;
using Project;
using System.Web.Security;

namespace CapaDePresentacion
{
    public partial class LoginAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (CatalogUsuario.Autenticar(rut.Text, txtclave.Text, 1))
            {
                FormsAuthentication.RedirectFromLoginPage(rut.Text, true);
                Response.Redirect("CambiarClave.aspx");
                
                //Response.Write("Bienvenido");
            }
            else
                Response.Write("<script>window.alert('Error al Ingresar los datos');</script>");
        }
    }
}