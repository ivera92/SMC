using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion.Admin
{
    public partial class AdministrarAsignaturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogEscuela cEscuela = new CatalogEscuela();
            List<Escuela> lEscuelas = cEscuela.listarEscuelas();//lista escuelas existentes
            CatalogDocente cDocente = new CatalogDocente();
            List<Docente> lDocentes = cDocente.listarDocentes();//lista docentes existentes

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddEscuela.DataTextField = "Nombre_escuela";
                this.ddEscuela.DataValueField = "Id_escuela";
                this.ddEscuela.DataSource = lEscuelas;

                this.ddDocente.DataTextField = "Nombre_Persona";
                this.ddDocente.DataValueField = "Rut_Persona";
                this.ddDocente.DataSource = lDocentes;

                this.divEditar.Visible = false;
                this.txtID.Visible = false;
                this.mostrar();
            }
        }
        //Elimina fila seleccionada
        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CatalogAsignatura ca = new CatalogAsignatura();
            try
            {
                string id_asignatura = HttpUtility.HtmlDecode((string)this.gvAsignatura.Rows[e.RowIndex].Cells[1].Text);
                ca.eliminarAsignatura(int.Parse(id_asignatura));
                Response.Write("<script>window.alert('Registro eliminado satisfactoriamente');</script>");
                Thread.Sleep(1500);
                this.mostrar();
            }
            catch
            {
                Response.Write("<script>window.alert('Registro no se a podido eliminar');</script>");
            }
        }
        //Carga los valores de la fila seleccionada para posteriormente actualizarlos
        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            this.divAdministrar.Visible = false;
            string id_asignatura = HttpUtility.HtmlDecode((string)this.gvAsignatura.Rows[e.NewEditIndex].Cells[1].Text);
            this.txtID.Text = id_asignatura;
            this.divEditar.Visible = true;
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            Asignatura a = cAsignatura.buscarAsignatura(int.Parse(id_asignatura));
            this.ddEscuela.SelectedValue = a.Escuela_asignatura.Id_escuela + "";
            this.ddDocente.SelectedValue = a.Docente_asignatura.Rut_persona;
            this.txtNombre.Text = a.Nombre_asignatura;
            this.txtAno.Text = a.Ano_asignatura + "";
            if (a.Duracion_asignatura == true)
                this.rbDuracion.SelectedIndex = 0;
            else
                this.rbDuracion.SelectedIndex = 1;
        }
        //Lista todas las asignaturas existentes en la base de datos
        public void mostrar()
        {
            this.gvAsignatura.Visible = true;
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignaturas = cAsignatura.listarAsignaturas();
            this.gvAsignatura.DataSource = lAsignaturas;
            this.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            bool duracion;
            if (this.rbDuracion.Text == "Semestral")
                duracion = true;
            else
                duracion = false;

            Asignatura a = new Asignatura();
            Escuela es = new Escuela();
            Docente d = new Docente();
            a.Escuela_asignatura = es;
            a.Docente_asignatura = d;

            a.Escuela_asignatura.Id_escuela = int.Parse(this.ddEscuela.SelectedValue);
            a.Docente_asignatura.Rut_persona = this.ddDocente.SelectedValue;
            a.Nombre_asignatura = this.txtNombre.Text;
            a.Ano_asignatura = int.Parse(this.txtAno.Text);
            a.Duracion_asignatura = duracion;
            a.Cod_asignatura = char.Parse(txtID.Text);
            try
            {
                cAsignatura.actualizarAsignatura(a);
                this.divEditar.Visible = false;
                Response.Write("<script>window.alert('Cambios guardados satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('No fue posible guardar los cambios');</script>");
            }     
        }
    }
}