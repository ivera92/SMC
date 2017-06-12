using System;
using System.Collections.Generic;
using System.Web.UI;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class CrearDocente : System.Web.UI.Page
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
            

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
            }
        }
        public void resetarValores()
        {
            this.txtRut.Text="";
            this.txtNombre.Text="";
            this.txtCorreo.Text = "";
            this.rbDisponibilidad.SelectedIndex = 0;
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogDocente cDocente = new CatalogDocente();
                bool disponibilidad;

                if (this.rbDisponibilidad.Text == "0")
                    disponibilidad = true;
                else
                    disponibilidad = false;

                Docente d = new Docente();
                d.Rut_persona = this.txtRut.Text;
                d.Nombre_persona = this.txtNombre.Text.Trim();
                d.Correo_persona = this.txtCorreo.Text.Trim();
                d.Contrato_docente = disponibilidad;

                cDocente.insertarDocente(d);
                Response.Write("<script>window.alert('Docente creado satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Docente no pudo ser creado o ya existe');</script>");
            }
            this.resetarValores();
        }
    }
}