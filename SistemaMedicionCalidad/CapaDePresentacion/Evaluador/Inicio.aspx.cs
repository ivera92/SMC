using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Evaluador
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutEvaluador"].ToString();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }
    }
}