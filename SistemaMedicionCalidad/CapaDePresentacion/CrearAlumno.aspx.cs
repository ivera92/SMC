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
            List<Escuela> escuelas = cescuela.mostrarEscuelas();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.creado.Visible = false;
                this.escuela.DataTextField = "Nombre_escuela";
                this.escuela.DataValueField = "Id_escuela";
                this.escuela.DataSource = escuelas;

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

            Alumno a = new Alumno(this.rut.Text, int.Parse(this.escuela.SelectedValue), this.nombre.Text, DateTime.Parse(this.fechaDeNacimiento.Text),this.direccion.Text,int.Parse(this.telefono.Text),this.nacionalidad.Text, sexo, this.correo.Text, int.Parse(this.promocion.Text), beneficio);
            alumno.agregarAlumnoPA(a);
            this.crear.Visible = false;
            this.creado.Visible = true;
        }
    }
}