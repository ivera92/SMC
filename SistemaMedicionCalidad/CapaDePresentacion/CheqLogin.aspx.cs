using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion
{
    public partial class CheqLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogTipoUsuario ctu = new CatalogTipoUsuario();
            List<Tipo_Usuario> ltp = ctu.listarTiposUsuario();
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
            Session.Clear();
            int tipoUsuario = ddTipoUsuario.SelectedIndex + 1;
            //try
            //{
            if (CatalogUsuario.Autenticar(rut.Text, txtclave.Text, tipoUsuario))
            {
                FormsAuthentication.RedirectFromLoginPage(rut.Text, true);
                if (tipoUsuario == 1)
                {
                    Session["rutAlumno"] = rut.Text;
                    Response.Redirect("~/Alum/Principal.aspx");
                }
                else if (tipoUsuario == 2)
                {
                    Session["rutDocente"] = rut.Text;
                    Response.Redirect("~/Doc/CrearAlumnos.aspx");
                }
                else
                {
                    Session["rutAdmin"] = rut.Text;
                    Response.Redirect("~/Admin/AdministrarAsignaturas.aspx");
                }
            }
            else
            {
                Response.Write("<script>window.alert('Error al Ingresar los datos');</script>");
                //}
            }
        }
        //catch
        //{

        //}
    }
}