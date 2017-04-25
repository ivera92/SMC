using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace CapaDePresentacion
{
    public partial class CheqLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.divRut.Visible = false;
            this.divCorreo.Visible = false;
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
            CatalogUsuario cUsuario = new CatalogUsuario();
            Session.Clear();
            int tipoUsuario = int.Parse(ddTipoUsuario.SelectedValue);
            string s = cUsuario.encriptar(txtclave.Text);
            if (CatalogUsuario.Autenticar(rut.Text, s, tipoUsuario))
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
                    Response.Redirect("~/Doc/CrearEvaluacion.aspx");
                }
                else
                {
                    Session["rutAdmin"] = rut.Text;
                    Response.Redirect("~/Admin/InicioAdmin.aspx");
                }
            }
            else
            {
                Response.Write("<script>window.alert('Error al Ingresar los datos');</script>");
            }
        }

        public void recuperarContrasena()
        {
            Random r = new Random();
            int pwTemp=r.Next(1000, 9999);
            CatalogUsuario cUsuario = new CatalogUsuario();
            string pwTempS = cUsuario.encriptar(pwTemp + "");
            cUsuario.recuperarClave(this.rutRC.Text, pwTempS);
            MailMessage msg = new MailMessage();
            msg.To.Add(lblCorreo.InnerText);
            msg.From = new MailAddress("soporte.smcfe@gmail.com", "Administrador", Encoding.UTF8);
            msg.Subject = "Recuperar contraseña";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Su contraseña actual es: "+ pwTemp;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            //Aquí es donde se hace lo especial
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("soporte.smcfe@gmail.com", "soporte_smcfe");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
            client.Send(msg);
        }

        protected void recuperar_Click(object sender, EventArgs e)
        {
            this.divLogin.Visible = false;
            this.divRut.Visible = true;
        }

        protected void btnVerificarRut_Click(object sender, EventArgs e)
        {
            CatalogUsuario cUsuario = new CatalogUsuario();
            string correo = cUsuario.verificarRut(this.rutRC.Text);
            this.lblCorreo.InnerText = correo;
            this.divRut.Visible = false;
            this.divCorreo.Visible = true;
        }

        protected void btnEnviarC_Click(object sender, EventArgs e)
        {
            try
            {
                this.recuperarContrasena();
                Response.Write("<script>window.alert('Correo enviado correctamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('No se pudo recuperar la contraseña');</script>");
            }
        }

        protected void btnNoEnviar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheqLogin.aspx");
        }
    }
}