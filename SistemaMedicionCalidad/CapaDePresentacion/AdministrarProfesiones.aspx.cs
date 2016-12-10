using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class AdministrarProfesiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.editar.Visible = false;
                this.mostrar();
            }
        }
        public void mostrar()
        {
            this.txtid.Visible = false;
            this.GridView1.Visible = true;
            CatalogProfesion cp = new CatalogProfesion();
            List<Profesion> lp = new List<Profesion>();
            lp = cp.mostrarProfesiones();
            this.GridView1.DataSource = lp;
            this.DataBind();
        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id_profesion = int.Parse(HttpUtility.HtmlDecode((string)(this.GridView1.Rows[e.RowIndex].Cells[2].Text)));
            CatalogProfesion cp = new CatalogProfesion();
            cp.eliminarProfesionPA(id_profesion);
        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            int id_profesion = int.Parse(HttpUtility.HtmlDecode((string)(this.GridView1.Rows[e.NewEditIndex].Cells[2].Text)));
            CatalogProfesion cp = new CatalogProfesion();
            Profesion p = cp.buscarUnaProfesion(id_profesion);
            this.tbxProfesion.Text = p.Nombre_profesion;
            this.txtid.Text = p.Id_profesion + "";
            this.editar.Visible = true;
            this.administrar.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogProfesion cp = new CatalogProfesion();
            Profesion p = new Profesion(int.Parse(this.txtid.Text) ,this.tbxProfesion.Text);
            cp.editarProfesion(p);
        }
    }
}