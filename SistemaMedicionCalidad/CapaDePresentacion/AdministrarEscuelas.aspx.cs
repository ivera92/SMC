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
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.tablaEditar.Visible = false;
                this.mostrar();
            }
        }

        public void mostrar()
        {
            this.txtid.Visible = false;
            this.GridView1.Visible = true;
            CatalogEscuela cescuela = new CatalogEscuela();
            List<Escuela> listaEscuelas = new List<Escuela>();
            listaEscuelas = cescuela.mostrarEscuelas();
            this.GridView1.DataSource = listaEscuelas;
            this.DataBind();
        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id_escuela = int.Parse(HttpUtility.HtmlDecode((string)(this.GridView1.Rows[e.RowIndex].Cells[2].Text)));
            CatalogEscuela cescuela = new CatalogEscuela();

            try
            {
                cescuela.eliminarEscuelaPA(id_escuela);
                Response.Write("<script>window.alert('Registro eliminado satisfactoriamente');</script>");
                Thread.Sleep(1500);
                this.mostrar();
            }
            catch
            {
                Response.Write("<script>window.alert('Registro no se a podido eliminar');</script>");
            }
        }
        
        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            string id_escuela = HttpUtility.HtmlDecode((string)this.GridView1.Rows[e.NewEditIndex].Cells[2].Text);
            CatalogEscuela cescuela= new CatalogEscuela();
            Escuela escuela = cescuela.buscarUnaEscuela(int.Parse(id_escuela));
            this.tbxEscuela.Text = escuela.Nombre_escuela;
            this.txtid.Text = escuela.Id_escuela+"";
            this.tablaAdministrar.Visible = false;
            this.tablaEditar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogEscuela cescuela = new CatalogEscuela();
            Escuela es = new Escuela(int.Parse(this.txtid.Text), this.tbxEscuela.Text);
            try
            {
                cescuela.editarEscuelaPA(es);
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