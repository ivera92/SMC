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
            CatalogProfesion cProfesion = new CatalogProfesion();
            List<Profesion> lProfesiones = cProfesion.listarProfesiones();

            CatalogPais cPais = new CatalogPais();
            List<Pais> lPaises = cPais.listarPaises();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddProfesion.DataTextField = "Nombre_profesion";
                this.ddProfesion.DataValueField = "Id_profesion";
                this.ddProfesion.DataSource = lProfesiones;

                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lPaises;
                    
                this.DataBind();
            }
        }
        public void resetarValores()
        {
            this.txtRut.Text="";
            this.ddProfesion.SelectedIndex = 0;
            this.ddPais.SelectedIndex = 0;
            this.txtNombre.Text="";
            this.txtFechaDeNacimiento.Text = "";
            this.txtDireccion.Text = "";
            this.txtTelefono.Text = "";
            rbSexo.SelectedIndex = 0;
            this.txtCorreo.Text = "";
            rbDisponibilidad.SelectedIndex = 0;
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogDocente cDocente = new CatalogDocente();
                bool sexo, disponibilidad;
                if (this.rbSexo.Text == "Masculino")
                    sexo = true;
                else
                    sexo = false;

                if (this.rbDisponibilidad.Text == "Part-Time")
                    disponibilidad = true;
                else
                    disponibilidad = false;

                Docente d = new Docente();
                Profesion p = new Profesion();
                Pais pa = new Pais();
                d.Profesion_docente = p;
                d.Pais_persona = pa;
                d.Rut_persona = this.txtRut.Text.Trim();
                d.Profesion_docente.Id_profesion = int.Parse(this.ddProfesion.SelectedValue);
                d.Pais_persona.Id_pais = int.Parse(this.ddPais.SelectedValue);
                d.Nombre_persona = this.txtNombre.Text;
                d.Fecha_nacimiento_persona = DateTime.Parse(this.txtFechaDeNacimiento.Text);
                d.Direccion_persona = this.txtDireccion.Text;
                d.Telefono_persona = int.Parse(this.txtTelefono.Text);
                d.Sexo_persona = sexo;
                d.Correo_persona = this.txtCorreo.Text.Trim();
                d.Disponibilidad_docente = disponibilidad;

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