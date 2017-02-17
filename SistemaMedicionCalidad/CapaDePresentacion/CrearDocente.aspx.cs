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
            CatalogProfesion cprofesion = new CatalogProfesion();
            List<Profesion> profesiones = cprofesion.mostrarProfesiones();

            CatalogPais cpais = new CatalogPais();
            List<Pais> lpais = cpais.mostrarPaises();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.profesion.DataTextField = "Nombre_profesion";
                this.profesion.DataValueField = "Id_profesion";
                this.profesion.DataSource = profesiones;

                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lpais;
                    
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
            CatalogDocente cdocente = new CatalogDocente();
            bool sexo, disponibilidad;
            if (this.sexo.Text == "Masculino")
            {
                sexo = true;
            }
            else
                sexo = false;

            if (this.disponibilidad.Text == "Part-Time")
            {
                disponibilidad = true;
            }
            else
                disponibilidad = true;
        
            Docente d = new Docente();
            Profesion p = new Profesion();
            Pais pa = new Pais();
            d.Profesion_docente = p;
            d.Pais_docente = pa;
            d.Rut_docente = this.rut.Text;
            d.Profesion_docente.Id_profesion = int.Parse(this.profesion.SelectedValue);
            d.Pais_docente.Id_pais = int.Parse(this.ddPais.SelectedValue);
            d.Nombre_docente = this.nombre.Text;
            d.Fecha_nacimiento_docente = DateTime.Parse(this.fechaDeNacimiento.Text);
            d.Direccion_docente = this.direccion.Text;
            d.Telefono_docente = int.Parse(this.telefono.Text);
            d.Sexo_docente = sexo;
            d.Correo_docente = this.correo.Text;
            d.Disponibilidad_docente = disponibilidad;
            try
            {
                cdocente.agregarDocentePA(d);
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