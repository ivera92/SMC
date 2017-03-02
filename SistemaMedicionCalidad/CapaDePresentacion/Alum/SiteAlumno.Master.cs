using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Alum
{
    public partial class SiteAlumno : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string alumno, docente, admin;
            try
            {
                admin = Session["rutAdmin"].ToString();
            }
            catch
            {
                admin = "";
            }
            try
            {
                alumno = Session["rutAlumno"].ToString();
            }
            catch
            {
                alumno = "";
            }
            try
            {
                docente = Session["rutDocente"].ToString();
            }
            catch
            {
                docente = "";
            }
            
            if(admin!="" || docente!="")
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("../CheqLogin.aspx");
        }
    }
}