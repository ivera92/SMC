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
            int tipoUsuario = int.Parse(ddTipoUsuario.SelectedValue);
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
            }
        }

        public void recuperarContrasena()
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add("ivan_cs@live.cl");
            msg.From = new MailAddress("ivera@ic.uach.cl", "Administrador" , System.Text.Encoding.UTF8);
            msg.Subject = "Recuperar contraseña";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Su contraseña actual es: ";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            //Aquí es donde se hace lo especial
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("ivera@ic.uach.cl", "colocolo1");
            client.Port = 465;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
            //try
            //{
                client.Send(msg);
            //}
            //catch
            //{
            //    Response.Write("<script>window.alert('No se pudo recuperar la contraseña');</script>");
            //}
        }

        protected void recuperar_Click(object sender, EventArgs e)
        {
            this.recuperarContrasena();
        }
    }
}