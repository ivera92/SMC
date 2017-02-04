using System;
using System.Collections.Generic;
using System.Web.UI;
using Project.CapaDeNegocios;
using Project;
using System.Threading;

namespace CapaDePresentacion
{
    public partial class CrearAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogEscuela cescuela = new CatalogEscuela();
            List<Escuela> escuelas = cescuela.mostrarEscuelas();
            CatalogPais cpais = new CatalogPais();
            List<Pais> lpais = cpais.mostrarPaises();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.escuela.DataTextField = "Nombre_escuela";
                this.escuela.DataValueField = "Id_escuela";
                this.escuela.DataSource = escuelas;

                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lpais;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogAlumno alumno = new CatalogAlumno();
            bool sexo, beneficio;
            if (this.sexo.Text == "Masculino")
            {
                sexo = true;
            }
            else
                sexo = false;

            if (this.beneficio.Text == "Si")
            {
                beneficio = true;
            }
            else
                beneficio = false;

            Alumno a = new Alumno(this.rut.Text, int.Parse(this.escuela.SelectedValue), int.Parse(this.ddPais.SelectedValue), this.nombre.Text, DateTime.Parse(this.fechaDeNacimiento.Text),this.direccion.Text,int.Parse(this.telefono.Text), sexo, this.correo.Text, int.Parse(this.promocion.Text), beneficio);
            try
            {
                alumno.agregarAlumno(a);
                Response.Write("<script>window.alert('Alumno creado satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Ya existe registro asociado al Rut');</script>");
            }
        }
    }
}