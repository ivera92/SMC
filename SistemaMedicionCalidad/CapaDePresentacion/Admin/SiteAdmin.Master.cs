using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Admin
{
    public partial class SiteAdmin : System.Web.UI.MasterPage
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

            if (alumno != "" || docente != "")
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }
    }
}