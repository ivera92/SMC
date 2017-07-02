using Project;
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
            string alumno, docente, admin, evaluador;
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
                evaluador = Session["rutEvaluador"].ToString();
            }
            catch
            {
                evaluador = "";
            }
            try
            {
                alumno = Session["rutAlumno"].ToString();
                CatalogAlumno cAlumno = new CatalogAlumno();                
                Label1.Text = "Usuario: " + cAlumno.buscarAlumnoPorRut(alumno).Nombre_persona;
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

            if (admin != "" || docente != "" || evaluador != "")
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }
    }
}