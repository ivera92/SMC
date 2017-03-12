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
            CatalogProfesion cProfesion = new CatalogProfesion();
            List<Profesion> lProfesiones = cProfesion.listarProfesiones();

            CatalogPais cPais = new CatalogPais();
            List<Pais> lPaises = cPais.listarPaises();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.profesion.DataTextField = "Nombre_profesion";
                this.profesion.DataValueField = "Id_profesion";
                this.profesion.DataSource = lProfesiones;

                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lPaises;
                    
                this.DataBind();
            }
        }
        public void resetarValores()
        {
            this.rut.Text="";
            this.profesion.SelectedIndex = 0;
            this.ddPais.SelectedIndex = 0;
            this.nombre.Text="";
            this.fechaDeNacimiento.Text = "";
            this.direccion.Text = "";
            this.telefono.Text = "";
            sexo.SelectedIndex = 0;
            this.correo.Text = "";
            disponibilidad.SelectedIndex = 0;
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogDocente cDocente = new CatalogDocente();
            bool sexo, disponibilidad;
            if (this.sexo.Text == "Masculino")
                sexo = true;
            else
                sexo = false;

            if (this.disponibilidad.Text == "Part-Time")
                disponibilidad = true;
            else
                disponibilidad = true;
        
            Docente d = new Docente();
            Profesion p = new Profesion();
            Pais pa = new Pais();
            d.Profesion_docente = p;
            d.Pais_persona = pa;
            d.Rut_persona = this.rut.Text;
            d.Profesion_docente.Id_profesion = int.Parse(this.profesion.SelectedValue);
            d.Pais_persona.Id_pais = int.Parse(this.ddPais.SelectedValue);
            d.Nombre_persona = this.nombre.Text;
            d.Fecha_nacimiento_persona = DateTime.Parse(this.fechaDeNacimiento.Text);
            d.Direccion_persona = this.direccion.Text;
            d.Telefono_persona = int.Parse(this.telefono.Text);
            d.Sexo_persona = sexo;
            d.Correo_persona = this.correo.Text;
            d.Disponibilidad_docente = disponibilidad;
            try
            {
                cDocente.insertarDocente(d);
                Response.Write("<script>window.alert('Docente creado satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Ya existe registro asociado al Rut');</script>");
            }
            this.resetarValores();
        }
    }
}