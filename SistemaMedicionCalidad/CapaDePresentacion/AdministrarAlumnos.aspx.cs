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
    public partial class AdministrarAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.mostrar();
            }
        }

        public void mostrar()
        {
            this.GridView1.Visible = true;
            CatalogAlumno calumno = new CatalogAlumno();
            List<Alumno> listaAlumnos = new List<Alumno>();
            listaAlumnos = calumno.mostrarAlumnos();
            this.GridView1.DataSource = listaAlumnos;
            this.DataBind();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int selected = this.GridView1.SelectedIndex;
            string rut_alumno = HttpUtility.HtmlDecode((string)this.GridView1.Rows[selected].Cells[1].Text);
            CatalogAlumno calumno = new CatalogAlumno();
            calumno.eliminarAlumnoPA(rut_alumno);

        }

        public void gridData()
        {
            this.GridView1.Visible = true;
            CatalogAlumno calumno = new CatalogAlumno();
            List<Alumno> listAlumno = new List<Alumno>();
            listAlumno = calumno.mostrarAlumnos();
            this.GridView1.DataSource = listAlumno;
            this.DataBind();
        }

        protected void rowDeletingEvent(object sender, GridViewDeleteEventArgs e)
        {
            string rut_alumno = HttpUtility.HtmlDecode((string)this.GridView1.Rows[e.RowIndex].Cells[2].Text);
            CatalogAlumno calumno = new CatalogAlumno();
            calumno.eliminarAlumnoPA(rut_alumno);
        }

        protected void rowEditingEvent(object sender, GridViewEditEventArgs e)
        {

        }

        protected void rowUpdatingEvent(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}