using System;
using System.Web.Security;

namespace CapaDePresentacion.Evaluador
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cierra la sesion
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("../CheqLogin.aspx");
        }
    }
}