using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion
{
    public partial class CambiarClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutAdmin"].ToString();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string rut = Session["rutAdmin"].ToString();
            CatalogUsuario cUsuario = new CatalogUsuario();
            int filasAfectadas = 0;

            if (pwNueva1.Text == pwNueva2.Text)
                try
                {
                    filasAfectadas = cUsuario.actualizarClave(rut, this.pwActual.Text, this.pwNueva1.Text);
                    if (filasAfectadas == 1)
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Contraseña cambiada correctamente');window.location='InicioAdmin.aspx';</script>'");
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Ingrese la contraseña actual correctamente');window.location='CambiarClave.aspx';</script>'");
                }

            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Debe repetir 2 veces la nueva contraseña');window.location='CambiarClave.aspx';</script>'");
        }
    }
}