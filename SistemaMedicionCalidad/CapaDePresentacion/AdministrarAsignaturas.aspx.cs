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
    public partial class AdministrarAsignaturas : System.Web.UI.Page
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

                this.editar.Visible = false;
                this.txtID.Visible = false;
                this.mostrar();
            }
        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id_asignatura = HttpUtility.HtmlDecode((string)this.gvAsignatura.Rows[e.RowIndex].Cells[1].Text);
            CatalogAsignatura ca = new CatalogAsignatura();
            ca.eliminarAsignatura(int.Parse(id_asignatura));
        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            this.administrar.Visible = false;
            string id_asignatura = HttpUtility.HtmlDecode((string)this.gvAsignatura.Rows[e.NewEditIndex].Cells[1].Text);
            this.txtID.Text = id_asignatura;
            this.editar.Visible = true;
            CatalogAsignatura ca = new CatalogAsignatura();
            Asignatura a= ca.buscarAsignatura(int.Parse(id_asignatura));
            this.ddEscuela.SelectedIndex = a.Id_escuela_asignatura-1;
            this.ddDocente.SelectedValue = a.Rut_docente_asignatura;
            this.txtNombre.Text = a.Nombre_asignatura;
            this.txtAno.Text = a.Ano_asignatura +"";
            if (a.Duracion_asignatura == true)
            {
                this.duracion.SelectedIndex = 0;
            }
            else
            {
                this.duracion.SelectedIndex = 1;
            }


        }

        public void mostrar()
        {
            this.gvAsignatura.Visible = true;
            CatalogAsignatura ca = new CatalogAsignatura();
            List<Asignatura> la = new List<Asignatura>();
            la= ca.mostrarAsignaturas();
            this.gvAsignatura.DataSource = la;
            this.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogAsignatura ca = new CatalogAsignatura();
            bool duracion;
            if (this.duracion.Text == "Semestral")
            {
                duracion = true;
            }
            else
                duracion = false;

            Asignatura a = new Asignatura(int.Parse(this.txtID.Text), int.Parse(this.ddEscuela.SelectedValue), this.ddDocente.SelectedValue, this.txtNombre.Text, int.Parse(this.txtAno.Text), duracion);
            ca.editarAsignaturaPA(a);
        }
    }
}