using System;
using System.Collections.Generic;
using System.Web.UI;
using Project;
using System.Web.Security;

namespace CapaDePresentacion
{
    public partial class LoginAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogTipoUsuario ctu = new CatalogTipoUsuario();
            List<Tipo_Usuario> ltp = ctu.mostrarTiposU();
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddTipoUsuario.DataTextField = "Nombre_tipo_usuario";
                this.ddTipoUsuario.DataValueField = "Id_tipo_usuario";
                this.ddTipoUsuario.DataSource = ltp;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (CatalogUsuario.Autenticar(txtRut.Text, txtclave.Text, (this.ddTipoUsuario.SelectedIndex)+1))
            {
                FormsAuthentication.RedirectFromLoginPage(txtRut.Text, true);
                Response.Redirect("Administrador.aspx");
                //Response.Write("Bienvenido");
            }
            else
                Response.Write("<script>window.alert('Error al Ingresar los datos');</script>");
        }
    }
}