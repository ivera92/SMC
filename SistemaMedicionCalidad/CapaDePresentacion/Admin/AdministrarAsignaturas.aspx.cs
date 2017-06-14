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
            try
            {
                string rut = Session["rutAdmin"].ToString();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
            CatalogEscuela cEscuela = new CatalogEscuela();
            List<Escuela> lEscuelas = cEscuela.listarEscuelas();//lista escuelas existentes

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddEscuela.DataTextField = "Nombre_escuela";
                this.ddEscuela.DataValueField = "Id_escuela";
                this.ddEscuela.DataSource = lEscuelas;

                this.divEditar.Visible = false;
                this.mostrar();
            }
        }
        //Elimina fila seleccionada
        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CatalogAsignatura ca = new CatalogAsignatura();
            try
            {
                string cod_asignatura = HttpUtility.HtmlDecode((string)this.gvAsignatura.Rows[e.RowIndex].Cells[1].Text);
                ca.eliminarAsignatura(cod_asignatura);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Registro eliminado satisfactoriamente');window.location='AdministrarAsignaturas.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Registro no a podido ser eliminado');window.location='AdministrarAsignaturas.aspx';</script>'");
            }
        }
        //Carga los valores de la fila seleccionada para posteriormente actualizarlos
        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            this.divAdministrar.Visible = false;
            string cod_asignatura = HttpUtility.HtmlDecode((string)this.gvAsignatura.Rows[e.NewEditIndex].Cells[1].Text);
            this.divEditar.Visible = true;
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            Asignatura a = cAsignatura.buscarAsignatura(cod_asignatura);
            this.txtCodigo.Text = a.Cod_asignatura;
            this.ddEscuela.SelectedValue = a.Escuela_asignatura.Id_escuela + "";
            this.txtNombre.Text = a.Nombre_asignatura;
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
            if (this.rbDuracion.SelectedValue == "0")
                duracion = true;
            else
                duracion = false;

            CatalogEscuela cEscuela = new CatalogEscuela();
            Asignatura a = new Asignatura();

            a.Cod_asignatura = txtCodigo.Text;
            a.Escuela_asignatura = cEscuela.buscarUnaEscuela(int.Parse(this.ddEscuela.SelectedValue));            
            a.Nombre_asignatura = this.txtNombre.Text.Trim();
            a.Duracion_asignatura = duracion;
            
            try
            {
                cAsignatura.actualizarAsignatura(a);
                this.divEditar.Visible = false;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Cambios guardados satisfactoriamente');window.location='AdministrarAsignaturas.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No fue posible guardar los cambios');window.location='AdministrarAsignaturas.aspx';</script>'");
            }     
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvAsignatura.Visible = true;
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignautras = cAsignatura.listarAsignaturasBusqueda(txtBuscar.Text);
            this.gvAsignatura.DataSource = lAsignautras;
            this.DataBind();
        }

        protected void gvAsignatura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAsignatura.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
                gvAsignatura.Visible = true;
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                List<Asignatura> lAsignautras = cAsignatura.listarAsignaturasBusqueda(txtBuscar.Text);
                this.gvAsignatura.DataSource = lAsignautras;
                this.DataBind();
            }
            else
            {
                this.mostrar();
            }
        }
    }
}