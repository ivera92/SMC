using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using System.Web.Security;

namespace CapaDePresentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (CatalogUsuario.Autenticar(txtRut.Text, txtclave.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtRut.Text, true);
                Response.Redirect("Administrador.aspx");
                //Response.Write("Bienvenido");
            }
            else
                Response.Write("<script>window.alert('Error al Ingresar los datos');</script>");
        }
    }
}
