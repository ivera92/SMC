using Project;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Admin
{
    public partial class AdministrarUsuarios : System.Web.UI.Page
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
                this.mostrar();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.gvUsuarios.Visible = true;
            CatalogUsuario cUsuario = new CatalogUsuario();
            List<Usuario> lUsuarios = cUsuario.listarUsuariosBusqueda(txtBuscar.Text);
            this.gvUsuarios.DataSource = lUsuarios;
            this.DataBind();
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "activo")
            {
                // Recupera el índice de fila almacenado en el
                // CommandArgument propiedad.
                int index = Convert.ToInt32(e.CommandArgument);

                // Recuperar la fila que contiene el botón
                // de la Filas.
                GridViewRow row = gvUsuarios.Rows[index];
                string nombre_usuario = HttpUtility.HtmlDecode(row.Cells[1].Text);
                string estado = HttpUtility.HtmlDecode(row.Cells[4].Text);
                bool estado_nuevo;
                if (estado == "Activo")
                {
                    estado_nuevo = false;
                }
                else
                {
                    estado_nuevo = true;
                }
                CatalogUsuario cUsuario = new CatalogUsuario();
                cUsuario.actualizarEstado(nombre_usuario, estado_nuevo);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Estado de usuario cambiado satisfactoriamente');window.location='AdministrarUsuarios.aspx';</script>'");

            }
        }

        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
                this.gvUsuarios.Visible = true;
                CatalogUsuario cUsuario = new CatalogUsuario();
                List<Usuario> lUsuarios = cUsuario.listarUsuariosBusqueda(txtBuscar.Text);
                this.gvUsuarios.DataSource = lUsuarios;
                this.DataBind();
            }
            else
            {
                this.mostrar();
            }
        }
        public void mostrar()
        {
            this.gvUsuarios.Visible = true;
            CatalogUsuario cUsuario = new CatalogUsuario();
            List<Usuario> lUsuarios = cUsuario.listarUsuarios();
            this.gvUsuarios.DataSource = lUsuarios;
            this.DataBind();
        }
    }
}