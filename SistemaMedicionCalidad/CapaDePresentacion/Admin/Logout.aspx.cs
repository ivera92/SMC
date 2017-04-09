using System;
using System.Web.Security;

namespace CapaDePresentacion.Admin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("../CheqLogin.aspx");
        }
    }
}