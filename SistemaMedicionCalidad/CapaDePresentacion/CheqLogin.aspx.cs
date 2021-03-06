﻿using System;
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
                if (!Page.IsPostBack) //para ver si cargo por primera vez
                {              
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

            try
            {
                string[] autentificacion = cUsuario.Autenticar(rut.Text.ToUpper(), txtclave.Text.ToUpper());


                //Se verifica si existe el usuario y es valido, despues de eso se ven los roles 
                if (int.Parse(autentificacion[0]) > 0 && bool.Parse(autentificacion[2])==true)
                {
                    //Redirige al usuario autenticado a la dirección URL solicitada originalmente o la dirección URL predeterminada
                    //Para crear una cookie duradera (aquella que se guarda en las sesiones del explorador); de lo contrario, false.
                    FormsAuthentication.RedirectFromLoginPage(rut.Text, true);

                    if (int.Parse(autentificacion[1]) == 1)
                    {
                        Session["rutAlumno"] = rut.Text.ToUpper();
                        Response.Redirect("~/Alum/Inicio.aspx");
                    }
                    else if (int.Parse(autentificacion[1]) == 2)
                    {
                        Session["rutDocente"] = rut.Text.ToUpper();
                        Response.Redirect("~/Doc/Inicio.aspx");
                    }
                    else if (int.Parse(autentificacion[1]) == 3)
                    {
                        Session["rutAdmin"] = rut.Text.ToUpper();
                        Response.Redirect("~/Admin/InicioAdmin.aspx");
                    }
                    else 
                    {
                        Session["rutEvaluador"] = rut.Text.ToUpper();
                        Response.Redirect("~/Evaluador/Inicio.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('El usuario con el que intenta ingresar se encuentra inactivo');</script>");
                }
            }
            catch
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
                string correo = cUsuario.verificarRut(this.rutRC.Text.Trim());
                this.lblCorreo.InnerText = correo;
                this.divRut.Visible = false;
                this.divCorreo.Visible = true;
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Rut no existe en los registros');window.location='CheqLogin.aspx';</script>'");
            }
        }
        //Se envia un correo al email asociado al rut
        protected void btnEnviarC_Click(object sender, EventArgs e)
        {
            CatalogUsuario cUsuario = new CatalogUsuario();
            try
            {
                cUsuario.recuperarContrasena(rutRC.Text, lblCorreo.InnerText);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Correo enviado satisfactoriamente');window.location='CheqLogin.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No se pudo recuperar la contraseña');window.location='CheqLogin.aspx';</script>'");
            }
        }
        //En caso de cancelar el envio de correo, redirecciona a la ventana de registro
        protected void btnNoEnviar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheqLogin.aspx");
        }
    }
}