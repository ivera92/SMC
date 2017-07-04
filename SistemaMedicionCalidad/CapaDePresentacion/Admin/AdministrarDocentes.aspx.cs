using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion.Doc
{
    public partial class AdministrarDocentes : System.Web.UI.Page
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
                this.tablaEditar.Visible = false;
                this.mostrar();
            }
        }
        //Elimina la fila seleccionada
        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string rut_docente = HttpUtility.HtmlDecode((string)this.gvDocentes.Rows[e.RowIndex].Cells[1].Text);
            CatalogDocente cDocente = new CatalogDocente();
            try
            {
                cDocente.eliminarDocente(rut_docente.Trim().ToUpper());
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Usuario asociado a docente eliminado satisfactoriamente');window.location='AdministrarDocentes.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Registro no a podido ser eliminado');window.location='AdministrarDocentes.aspx';</script>'");
            }

        }
        //Carga los datos de la fila a actualizar
        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            this.tablaAdministrar.Visible = false;
            string rut_docente = HttpUtility.HtmlDecode((string)this.gvDocentes.Rows[e.NewEditIndex].Cells[1].Text);
            CatalogDocente cDocente = new CatalogDocente();
            Docente d = cDocente.buscarUnDocente(rut_docente);
            
            this.txtRut.Text = d.Rut_persona.ToUpper().Trim();
            this.txtNombre.Text = d.Nombre_persona.Trim();
            this.txtCorreo.Text = d.Correo_persona.Trim();  
            if (d.Contrato_docente == true)
            {
                this.rbDisponibilidad.SelectedIndex = 0;
            }
            else
            {
                this.rbDisponibilidad.SelectedIndex = 1;
            }

            this.tablaEditar.Visible = true;
        }
        //Carga los docentes existente en el gridview
        public void mostrar()
        {
            this.gvDocentes.Visible=true;
            CatalogDocente cDocente = new CatalogDocente();
            List<Docente> lDocentes = cDocente.listarDocentes();
            this.gvDocentes.DataSource = lDocentes;
            this.DataBind();
        }
        //Guarda los datos actualizados
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogDocente cDocente = new CatalogDocente();
            Docente d = new Docente();

            d.Rut_persona = this.txtRut.Text.Trim().ToUpper();
            d.Nombre_persona = this.txtNombre.Text.Trim();
            d.Correo_persona = this.txtCorreo.Text.Trim();
            if (this.rbDisponibilidad.SelectedValue == "0")
            {
                d.Contrato_docente = true;
            }
            else
            {
                d.Contrato_docente = false;
            }
            try
            {
                cDocente.actualizarDocente(d);
                this.tablaEditar.Visible = false;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Cambios guardados satisfactoriamente');window.location='AdministrarDocentes.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No fue posible guardar los cambios');window.location='AdministrarDocentes.aspx';</script>'");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvDocentes.Visible = true;
            CatalogDocente cDocente = new CatalogDocente();
            List<Docente> lDocentes = cDocente.listarDocentesBusqueda(txtBuscar.Text.Trim());
            this.gvDocentes.DataSource = lDocentes;
            this.DataBind();
        }

        protected void gvDocentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDocentes.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
                gvDocentes.Visible = true;
                CatalogDocente cDocente = new CatalogDocente();
                List<Docente> lDocentes = cDocente.listarDocentesBusqueda(txtBuscar.Text);
                this.gvDocentes.DataSource = lDocentes;
                this.DataBind();
            }
            else
            {
                this.mostrar();
            }
        }
    }
}