using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class AdministrarEscuelas : System.Web.UI.Page
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
        //Lista las esculeas existentes
        public void mostrar()
        {
            this.txtid.Visible = false;
            this.gvEscuelas.Visible = true;
            CatalogEscuela cEscuela = new CatalogEscuela();
            List<Escuela> lEscuelas = cEscuela.listarEscuelas();
            this.gvEscuelas.DataSource = lEscuelas;
            this.DataBind();
        }
        //Elimina la fila seleccionada
        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id_escuela = int.Parse(HttpUtility.HtmlDecode((string)(this.gvEscuelas.Rows[e.RowIndex].Cells[2].Text)));
            CatalogEscuela cEscuela = new CatalogEscuela();

            try
            {
                cEscuela.eliminarEscuela(id_escuela);
                Response.Write("<script>window.alert('Registro eliminado satisfactoriamente');</script>");
                Thread.Sleep(1500);
                this.mostrar();
            }
            catch
            {
                Response.Write("<script>window.alert('Registro no se a podido eliminar');</script>");
            }
        }
        //Carga los datos de la fila a actualizar
        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            string id_escuela = HttpUtility.HtmlDecode((string)this.gvEscuelas.Rows[e.NewEditIndex].Cells[2].Text);
            CatalogEscuela cEscuela= new CatalogEscuela();
            Escuela escuela = cEscuela.buscarUnaEscuela(int.Parse(id_escuela));
            this.tbxEscuela.Text = escuela.Nombre_escuela;
            this.txtid.Text = escuela.Id_escuela+"";
            this.tablaAdministrar.Visible = false;
            this.tablaEditar.Visible = true;
        }
        //Guarda los cambios realizados
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogEscuela cEscuela = new CatalogEscuela();
            Escuela es = new Escuela(int.Parse(this.txtid.Text), this.tbxEscuela.Text);
            try
            {
                cEscuela.actualizarEscuela(es);
                this.tablaEditar.Visible = false;
                Response.Write("<script>window.alert('Cambios guardados satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('No fue posible guardar los cambios');</script>");
            }
        }
    }
}