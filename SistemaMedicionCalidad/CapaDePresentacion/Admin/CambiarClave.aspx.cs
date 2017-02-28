using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion
{
    public partial class CambiarClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rut = Request.QueryString["Rut"];
            lblRut.InnerText = rut;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
        }
    }
}