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
            string alumno, docente, admin, evaluador;
            try
            {
                admin = Session["rutAdmin"].ToString();
                Label1.Text = "Usuario: "+ admin+"";
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
            try
            {
                evaluador = Session["rutEvaluador"].ToString();
            }
            catch
            {
                evaluador = "";
            }

            if (alumno != "" || docente != "" || evaluador != "")
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }
    }
}