using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion.Doc
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
                Session["rutDocente"] = rut.Text;
                FormsAuthentication.RedirectFromLoginPage(rut.Text, true);
                Response.Redirect("~/Docente/InicioDocente.aspx");
            }
            else
                Response.Write("<script>window.alert('Error al Ingresar los datos');</script>");
        }
    }
}