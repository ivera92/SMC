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
        public void resetearValores()
        {
            this.ddEscuela.SelectedIndex = 0;
            this.ddDocente.SelectedIndex = 0;
            this.txtNombre.Text = "";
            this.txtAno.Text = "";
            duracion.SelectedIndex = 0;
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

            Asignatura a = new Asignatura();
            Escuela es = new Escuela();
            Docente d = new Docente();
            a.Escuela_asignatura = es;
            a.Docente_asignatura = d;

            a.Escuela_asignatura.Id_escuela = int.Parse(this.ddEscuela.SelectedValue);
            a.Docente_asignatura.Rut_docente = this.ddDocente.SelectedValue;
            a.Nombre_asignatura = this.txtNombre.Text;
            a.Ano_asignatura = int.Parse(this.txtAno.Text);
            a.Duracion_asignatura = duracion;
            try
            {
                ca.agregarAsignaturaPA(a);
                Response.Write("<script>window.alert('Asignatura creada satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Asignatura no pudo ser creada');</script>");
            }
            this.resetearValores();
        }
    }
}