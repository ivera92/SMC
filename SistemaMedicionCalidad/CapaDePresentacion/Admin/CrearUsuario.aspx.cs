using System;
using Project;

namespace CapaDePresentacion.Admin
{
    public partial class CrearUsuario : System.Web.UI.Page
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

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogUsuario cUsuario = new CatalogUsuario();
            CatalogTipoUsuario cTP = new CatalogTipoUsuario();

            if (cUsuario.verificarExistenciaUsuario(txtNombreUsuario.Text) == 0)
            {
                Usuario u = new Usuario();
                u.Nombre_usuario = txtNombreUsuario.Text;
                u.Tipo_usuario_usuario = cTP.buscarUnTipoUsuario(int.Parse(ddTipoUsuario.SelectedValue));
                u.Correo_usuario = txtCorreo.Text;
                cUsuario.insertarUsuario(u);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Usuario creado satisfactoriamente');window.location='CrearUsuario.aspx';</script>'");
            }
            else
            {
                Response.Write("<script>alert('El nombre de usuario ya esta en los registros');</script>");
            }
        }
    }
}