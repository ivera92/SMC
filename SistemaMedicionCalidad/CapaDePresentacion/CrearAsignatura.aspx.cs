using System;
using System.Collections.Generic;
using System.Web.UI;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class CrearAsignatura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogEscuela cescuela = new CatalogEscuela();
            List<Escuela> escuelas = cescuela.mostrarEscuelas();
            CatalogDocente cdocente = new CatalogDocente();
            List<Docente> ldocentes = cdocente.mostrarDocentesPA();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddEscuela.DataTextField = "Nombre_escuela";
                this.ddEscuela.DataValueField = "Id_escuela";
                this.ddEscuela.DataSource = escuelas;

                this.ddDocente.DataTextField = "Nombre_docente";
                this.ddDocente.DataValueField = "Rut_Docente";
                this.ddDocente.DataSource = ldocentes;

                this.DataBind();//enlaza los datos a un dropdownlist   
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogAsignatura ca = new CatalogAsignatura();
            bool duracion;
            if (this.duracion.Text == "Semestral")
            {
                duracion = true;
            }
            else
                duracion = false;

            Asignatura a = new Asignatura(int.Parse(this.ddEscuela.SelectedValue), this.ddDocente.SelectedValue, this.txtNombre.Text, int.Parse(this.txtAno.Text), duracion);
            ca.agregarAsignaturaPA(a);
            Response.Write("<script>window.alert('Asignatura creada satisfactoriamente');</script>");
        }
    }
}