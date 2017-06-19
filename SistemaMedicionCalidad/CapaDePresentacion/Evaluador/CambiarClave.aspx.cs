using Project;
using System;

namespace CapaDePresentacion.Evaluador
{
    public partial class CambiarClave : System.Web.UI.Page
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string rut = Session["rutEvaluador"].ToString();
            CatalogUsuario cUsuario = new CatalogUsuario();
            int filasAfectadas = 0;

            if (txtPwNueva1.Text == txtPwNueva2.Text)
                try
                {
                    filasAfectadas = cUsuario.actualizarClave(rut, this.txtPwActual.Text, this.txtPwNueva1.Text);
                    if (filasAfectadas == 1)
                        Response.Write("<script>window.alert('Contraseña cambiada correctamente');</script>");
                }
                catch
                {
                    Response.Write("<script>window.alert('Ingrese la contraseña actual correctamente');</script>");
                }

            else
                Response.Write("<script>window.alert('Debe repetir 2 veces la nueva contraseña');</script>");
        }
    }
}