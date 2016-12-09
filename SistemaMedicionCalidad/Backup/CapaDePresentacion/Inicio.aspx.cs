using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace CapaDePresentacion
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAlumno_Click(object sender, EventArgs e)
        {
            Server.Transfer("LoginAlumno.aspx");
            //Response.Redirect("LoginAlumno.aspx");
        }
    }
}