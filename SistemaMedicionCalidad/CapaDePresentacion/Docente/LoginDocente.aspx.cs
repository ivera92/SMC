using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion
{
    public partial class LoginDocente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (CatalogUsuario.Autenticar(rut.Text, txtclave.Text, 2))
            {
                FormsAuthentication.RedirectFromLoginPage(rut.Text, true);
                Response.Redirect("~/Docente/InicioDocente.aspx");

                //Response.Write("Bienvenido");
            }
            else
                Response.Write("<script>window.alert('Error al Ingresar los datos');</script>");
        }
    }
}