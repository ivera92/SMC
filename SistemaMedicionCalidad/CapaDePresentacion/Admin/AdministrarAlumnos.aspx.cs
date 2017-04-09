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
            CatalogEscuela cEscuela = new CatalogEscuela();
            List<Escuela> lEscuelas = cEscuela.listarEscuelas();
            CatalogPais cPais = new CatalogPais();
            List<Pais> lPaises = cPais.listarPaises();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddEscuela.DataTextField = "Nombre_escuela";
                this.ddEscuela.DataValueField = "Id_escuela";
                this.ddEscuela.DataSource = lEscuelas;

                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lPaises;

                this.divEditar.Visible = false;
                this.mostrar();
            }
        }

        public void mostrar()
        {
            this.gvAlumnos.Visible = true;
            CatalogAlumno cAlumno = new CatalogAlumno();
            List<Alumno> lAlumno = cAlumno.listarAlumnos();
            this.gvAlumnos.DataSource = lAlumno;
            this.DataBind();
        }

        protected void rowDeletingEvent(object sender, GridViewDeleteEventArgs e)
        {
            string rut_alumno = HttpUtility.HtmlDecode((string)this.gvAlumnos.Rows[e.RowIndex].Cells[2].Text);
            CatalogAlumno cAlumno = new CatalogAlumno();
            try
            {
                cAlumno.eliminarAlumno(rut_alumno);
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
            string rut_alumno = HttpUtility.HtmlDecode((string)this.gvAlumnos.Rows[e.NewEditIndex].Cells[2].Text);
            CatalogAlumno cAlumno = new CatalogAlumno();
            Alumno a = cAlumno.buscarAlumnoPorRut(rut_alumno);
            this.ddEscuela.SelectedValue = a.Escuela_alumno.Id_escuela+"";
            this.txtNombre.Text = a.Nombre_persona;
            this.txtRut.Text = a.Rut_persona;
            this.txtFechaDeNacimiento.Text = a.Fecha_nacimiento_persona.ToString("d");
            this.txtDireccion.Text = a.Direccion_persona;
            this.txtTelefono.Text = a.Telefono_persona+"";
            this.ddPais.SelectedValue = a.Pais_persona.Id_pais+"";
            this.txtCorreo.Text = a.Correo_persona;
            this.txtPromocion.Text = a.Promocion_alumno + "";

            if (a.Beneficio_alumno == true)
                this.rbBeneficio.SelectedIndex = 0;
            else
                this.rbBeneficio.SelectedIndex = 1;

            if (a.Sexo_persona == true)
                this.rbSexo.SelectedIndex = 0;
            else
                this.rbSexo.SelectedIndex = 1;

            this.divEditar.Visible = true;
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            this.gvAlumnos.Visible = true;
            CatalogAlumno cAlumno = new CatalogAlumno();
            List<Alumno> lAlumno = cAlumno.buscarAlumno(this.tbxbuscar.Text);

            this.gvAlumnos.DataSource = lAlumno;
            this.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogAlumno cAlumno = new CatalogAlumno();
            bool sexo, beneficio;

            if (this.rbSexo.Text == "Masculino")
                sexo = true;
            else
                sexo = false;

            if (this.rbBeneficio.Text == "Si")
                beneficio = true;
            else
                beneficio = false;

            Alumno a = new Alumno();
            Escuela es = new Escuela();
            Pais p = new Pais();
            a.Escuela_alumno = es;
            a.Pais_persona = p;

            a.Rut_persona = this.txtRut.Text;
            a.Escuela_alumno.Id_escuela = int.Parse(this.ddEscuela.SelectedValue);
            a.Pais_persona.Id_pais = int.Parse(this.ddPais.SelectedValue);
            a.Nombre_persona = this.txtNombre.Text;
            a.Fecha_nacimiento_persona = DateTime.Parse(this.txtFechaDeNacimiento.Text);
            a.Direccion_persona = this.txtDireccion.Text;
            a.Telefono_persona = int.Parse(this.txtTelefono.Text);
            a.Sexo_persona = sexo;
            a.Correo_persona = this.txtCorreo.Text;
            a.Promocion_alumno = int.Parse(this.txtPromocion.Text);
            a.Beneficio_alumno = beneficio;
            try
            {
                cAlumno.actualizarAlumno(a);
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