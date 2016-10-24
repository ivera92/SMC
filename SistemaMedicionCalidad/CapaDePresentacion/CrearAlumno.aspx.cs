using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.CapaDeNegocios;
using Project;

namespace CapaDePresentacion
{
    public partial class CrearAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogEscuela cescuela = new CatalogEscuela();
            List<Project.CapaDeNegocios.Escuela> escuelas = cescuela.getEscuela();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.escuela.DataTextField = "Nombre_escuela";
                this.escuela.DataValueField = "Id_escuela";
                this.escuela.DataSource = escuelas;

                this.DataBind();                
            }
        }

        

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogAlumno alumno = new CatalogAlumno();
            bool sexo, beneficio;
            Project.CapaDeNegocios.Escuela es = new Project.CapaDeNegocios.Escuela(int.Parse(this.escuela.SelectedValue),this.escuela.Items[this.escuela.SelectedIndex].Text);
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

            Alumno a = new Alumno(this.rut.Text, es.Id_escuela, this.nombre.Text, DateTime.Parse(this.fechaDeNacimiento.Text),this.direccion.Text,int.Parse(this.telefono.Text),this.nacionalidad.Text, sexo, this.correo.Text, int.Parse(this.promocion.Text), beneficio);
            alumno.agregarAlumnoPA(a);
        }
    }
}