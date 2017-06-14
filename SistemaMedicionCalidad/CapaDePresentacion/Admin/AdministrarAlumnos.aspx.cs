using System;
using System.Collections.Generic;
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
            try
            {
                string rut = Session["rutAdmin"].ToString();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
            
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {

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
            string rut_alumno = HttpUtility.HtmlDecode((string)this.gvAlumnos.Rows[e.RowIndex].Cells[1].Text);
            CatalogAlumno cAlumno = new CatalogAlumno();
            try
            {
                cAlumno.eliminarAlumno(rut_alumno);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Usuario asociado a alumno eliminado satisfactoriamente');window.location='AdministrarAlumnos.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Registro no pudo ser eliminado');window.location='AdministrarAlumno.aspx';</script>'");
            }
            
        }

        protected void rowEditingEvent(object sender, GridViewEditEventArgs e)
        {
            this.divMostrar.Visible = false;
            string rut_alumno = HttpUtility.HtmlDecode((string)this.gvAlumnos.Rows[e.NewEditIndex].Cells[1].Text);
            CatalogAlumno cAlumno = new CatalogAlumno();
            Alumno a = cAlumno.buscarAlumnoPorRut(rut_alumno);
            this.txtNombre.Text = a.Nombre_persona.Trim();
            this.txtRut.Text = a.Rut_persona;
            this.txtCorreo.Text = a.Correo_persona.Trim();

            this.divEditar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogAlumno cAlumno = new CatalogAlumno();

            Alumno a = new Alumno(txtRut.Text.Trim(), txtNombre.Text.Trim(), txtCorreo.Text.Trim());
            try
            {
                cAlumno.actualizarAlumno(a);
                this.divEditar.Visible = false;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Cambios guardados satisfactoriamente');window.location='AdministrarAlumnos.aspx';</script>'");

            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No fue posible guardar los cambios');window.location='AdministrarAlumnos.aspx';</script>'");
            }
        }

        protected void Grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAlumnos.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
                gvAlumnos.Visible = true;
                CatalogAlumno cAlumno = new CatalogAlumno();
                List<Alumno> lAlumnos = cAlumno.listarAlumnosBusqueda(txtBuscar.Text);
                this.gvAlumnos.DataSource = lAlumnos;
                this.DataBind();
            }
            else
            {
                this.mostrar();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvAlumnos.Visible = true;
            CatalogAlumno cAlumno = new CatalogAlumno();
            List<Alumno> lAlumnos = cAlumno.listarAlumnosBusqueda(txtBuscar.Text.Trim());
            this.gvAlumnos.DataSource = lAlumnos;
            this.DataBind();
        }
    }
}