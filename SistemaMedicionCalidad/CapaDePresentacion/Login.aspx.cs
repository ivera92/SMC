using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAlumno_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginAlumno.aspx");
        }

        protected void btnDocente_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Docente/LoginDocente.aspx");
        }

        protected void btnAdministrador_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/LoginAdministrador.aspx");
        }
    }
}