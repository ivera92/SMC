using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.CapaDeNegocios;
using Project;
using System.Threading;

namespace CapaDePresentacion
{
    public partial class AdministrarAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogEscuela cescuela = new CatalogEscuela();
            List<Escuela> escuelas = cescuela.listarEscuelas();
            CatalogPais cpais = new CatalogPais();
            List<Pais> lpais = cpais.listarPaises();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.escuela.DataTextField = "Nombre_escuela";
                this.escuela.DataValueField = "Id_escuela";
                this.escuela.DataSource = escuelas;

                this.pais.DataTextField = "Nombre_pais";
                this.pais.DataValueField = "Id_pais";
                this.pais.DataSource = lpais;

                this.divEditar.Visible = false;
                this.mostrar();
            }
        }

        public void mostrar()
        {
            this.GridView1.Visible = true;
            CatalogAlumno calumno = new CatalogAlumno();
            List<Alumno> listaAlumnos = new List<Alumno>();
            listaAlumnos = calumno.listarAlumnos();
            this.GridView1.DataSource = listaAlumnos;
            this.DataBind();
        }

        protected void rowDeletingEvent(object sender, GridViewDeleteEventArgs e)
        {
            string rut_alumno = HttpUtility.HtmlDecode((string)this.GridView1.Rows[e.RowIndex].Cells[2].Text);
            CatalogAlumno calumno = new CatalogAlumno();
            try
            {
                calumno.eliminarAlumno(rut_alumno);
                Response.Write("<script>window.alert('Registro eliminado satisfactoriamente');</script>");
                Thread.Sleep(1500);
                this.mostrar();
            }
            catch
            {
                Response.Write("<script>window.alert('Registro no a podido ser eliminado');</script>");
            }
            
        }

        protected void rowEditingEvent(object sender, GridViewEditEventArgs e)
        {
            this.divMostrar.Visible = false;
            string rut_alumno = HttpUtility.HtmlDecode((string)this.GridView1.Rows[e.NewEditIndex].Cells[2].Text);
            CatalogAlumno ca = new CatalogAlumno();
            Alumno a = ca.buscarAlumnoPorRut(rut_alumno);
            this.escuela.SelectedIndex = a.Escuela_alumno.Id_escuela;
            this.nombre.Text = a.Nombre_persona;
            this.rut.Text = a.Rut_persona;
            this.fechaDeNacimiento.Text = a.Fecha_nacimiento_persona.ToString("d");
            this.direccion.Text = a.Direccion_persona;
            this.telefono.Text = a.Telefono_persona+"";
            this.pais.SelectedIndex = a.Pais_persona.Id_pais;
            this.correo.Text = a.Correo_persona;
            this.promocion.Text = a.Promocion_alumno + "";
            if (a.Beneficio_alumno == true)
            {
                this.beneficio.SelectedIndex = 0;
            }
            else
                this.beneficio.SelectedIndex = 1;
            if (a.Sexo_persona == true)
            {
                this.sexo.SelectedIndex = 0;
            }
            else
                this.sexo.SelectedIndex = 1;
            this.divEditar.Visible = true;
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            this.GridView1.Visible = true;
            CatalogAlumno alumno = new CatalogAlumno();
            List<Alumno> listAlumno = new List<Alumno>();
            listAlumno = alumno.buscarAlumno(this.tbxbuscar.Text);

            this.GridView1.DataSource = listAlumno;
            this.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogAlumno calumno = new CatalogAlumno();
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

            Alumno a = new Alumno();
            Escuela es = new Escuela();
            Pais p = new Pais();
            a.Escuela_alumno = es;
            a.Pais_persona = p;

            a.Rut_persona = this.rut.Text;
            a.Escuela_alumno.Id_escuela = this.escuela.SelectedIndex;
            a.Pais_persona.Id_pais = this.pais.SelectedIndex;
            a.Nombre_persona = this.nombre.Text;
            a.Fecha_nacimiento_persona = DateTime.Parse(this.fechaDeNacimiento.Text);
            a.Direccion_persona = this.direccion.Text;
            a.Telefono_persona = int.Parse(this.telefono.Text);
            a.Sexo_persona = sexo;
            a.Correo_persona = this.correo.Text;
            a.Promocion_alumno = int.Parse(this.promocion.Text);
            a.Beneficio_alumno = beneficio;
            try
            {
                calumno.actualizarAlumno(a);
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