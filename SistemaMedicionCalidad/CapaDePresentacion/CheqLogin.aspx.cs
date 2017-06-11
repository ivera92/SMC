using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using Project;

namespace CapaDePresentacion
{
    public partial class CheqLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.divRut.Visible = false;
                this.divCorreo.Visible = false;
                CatalogTipoUsuario cTipoUsuario = new CatalogTipoUsuario();
                List<Tipo_Usuario> lTipoUsuarios = cTipoUsuario.listarTiposUsuario();
                if (!Page.IsPostBack) //para ver si cargo por primera vez
                {
                    this.ddTipoUsuario.DataTextField = "Nombre_tipo_usuario";
                    this.ddTipoUsuario.DataValueField = "Id_tipo_usuario";
                    this.ddTipoUsuario.DataSource = lTipoUsuarios;

                    this.DataBind();//enlaza los datos a un dropdownlist                
                }
            }
            catch
            {
                Response.Write("<script>window.alert('No existen tipos de usuario para mostrar, contactese con el administrador');</script>");
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            CatalogUsuario cUsuario = new CatalogUsuario();            
            Session.Clear();

            int[] autentificacion =cUsuario.Autenticar(rut.Text, txtclave.Text);

            //Se verifica si existe el usuario y es valido, despues de eso se ven los roles 
            if (autentificacion[0] > 0)
            {
                //Redirige al usuario autenticado a la dirección URL solicitada originalmente o la dirección URL predeterminada
                //Para crear una cookie duradera (aquella que se guarda en las sesiones del explorador); de lo contrario, false.
                FormsAuthentication.RedirectFromLoginPage(rut.Text, true);

                if (autentificacion[1] == 1)
                {
                    Session["rutAlumno"] = rut.Text;
                    Response.Redirect("~/Alum/Principal.aspx");
                }
                else if (autentificacion[1] == 2)
                {
                    Session["rutDocente"] = rut.Text;
                    Response.Redirect("~/Doc/InicioDocente.aspx");
                }
                else
                {
                    Session["rutAdmin"] = rut.Text;
                    Response.Redirect("~/Admin/InicioAdmin.aspx");
                }
            }
            {
                Response.Write("<script>window.alert('Error al Ingresar los datos');</script>");
            }               
        }
        //Esconde el div de logeo y muestra el de ingresar rut para posteriormente solicitar recuperacion de clave
        protected void recuperar_Click(object sender, EventArgs e)
        {
            this.divLogin.Visible = false;
            this.divRut.Visible = true;
        }
        //Verifica si el rut ingresado existe y registra un email
        protected void btnVerificarRut_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogUsuario cUsuario = new CatalogUsuario();
                string correo = cUsuario.verificarRut(this.rutRC.Text);
                this.lblCorreo.InnerText = correo;
                this.divRut.Visible = false;
                this.divCorreo.Visible = true;
            }
            catch
            {
                Response.Write("<script>window.alert('Rut no existe en los registros');</script>");
            }
        }
        //Se envia un correo al email asociado al rut
        protected void btnEnviarC_Click(object sender, EventArgs e)
        {
            CatalogUsuario cUsuario = new CatalogUsuario();
            try
            {
                cUsuario.recuperarContrasena(rutRC.Text, lblCorreo.InnerText);
                Response.Write("<script>window.alert('Correo enviado correctamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('No se pudo recuperar la contraseña');</script>");
            }
        }
        //En caso de cancelar el envio de correo, redirecciona a la ventana de registro
        protected void btnNoEnviar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheqLogin.aspx");
        }
    }
}