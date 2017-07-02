using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Evaluador
{
    public partial class SiteEvaluador : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verifica que la persona que ingreso corresponde a un docente
            if (!Page.IsPostBack) //para ver si cargo por primera vez
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
                    Label1.Text = "Usuario: " + evaluador;
                }
                catch
                {
                    evaluador = "";
                }

                if (alumno != "" || admin != "" || docente != "")
                {
                    Response.Redirect("../CheqLogin.aspx");
                }
            }
        }
    }
}