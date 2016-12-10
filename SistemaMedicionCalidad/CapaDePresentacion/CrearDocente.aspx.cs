using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.profesion.DataTextField = "Nombre_profesion";
                this.profesion.DataValueField = "Id_profesion";
                this.profesion.DataSource = profesiones;

                this.DataBind();
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogDocente cdocente = new CatalogDocente();
            bool sexo, disponibilidad;
            Profesion p = new Profesion(int.Parse(this.profesion.SelectedValue), this.profesion.Items[this.profesion.SelectedIndex].Text);
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

            Docente d = new Docente(this.rut.Text, p.Id_profesion, this.nombre.Text, DateTime.Parse(this.fechaDeNacimiento.Text), this.direccion.Text, int.Parse(this.telefono.Text), this.nacionalidad.Text, sexo, this.correo.Text, disponibilidad);
            cdocente.agregarDocentePA(d);
        }

    }
}