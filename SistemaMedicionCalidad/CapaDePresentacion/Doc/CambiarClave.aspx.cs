using Project;
using System;

namespace CapaDePresentacion.Doc
{
    public partial class CambiarClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutDocente"].ToString();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string rut = Session["rutDocente"].ToString();
            CatalogUsuario cUsuario = new CatalogUsuario();
            int filasAfectadas = 0;

            if (txtPwNueva1.Text.ToUpper() == txtPwNueva2.Text.ToUpper())
                try
                {
                    filasAfectadas = cUsuario.actualizarClave(rut.ToUpper(), this.txtPwActual.Text.ToUpper(), this.txtPwNueva1.Text.ToUpper());
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