using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion.Alum
{
    public partial class CambiarClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string rut = Session["rutAlumno"].ToString();
            CatalogUsuario cu = new CatalogUsuario();
            int filasAfectadas = 0;
            if (pwNueva1.Text == pwNueva2.Text)
            {
                try
                {
                    filasAfectadas = cu.actualizarClave(rut, this.pwActual.Text, this.pwNueva1.Text);
                    if (filasAfectadas == 1)
                    {
                        Response.Write("<script>window.alert('Contraseña cambiada correctamente');</script>");
                    }
                }
                catch
                {
                    Response.Write("<script>window.alert('Ingrese la contraseña actual correctamente');</script>");
                }
            }
            else
            {
                Response.Write("<script>window.alert('Debe repetir 2 veces la nueva contraseña');</script>");
            }
            
        }
    }
}