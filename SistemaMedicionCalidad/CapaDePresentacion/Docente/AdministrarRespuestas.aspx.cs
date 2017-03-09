using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion
{
    public partial class AdministrarRespuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.mostrar();
            }
        }
        

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id_respuesta = int.Parse(HttpUtility.HtmlDecode((string)(this.gvRespuestas.Rows[e.RowIndex].Cells[1].Text)));
            CatalogRespuesta cr = new CatalogRespuesta();

            try
            {
                cr.eliminarRespuesta(id_respuesta);
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

        }
        public void mostrar()
        {
            this.txtid.Visible = false;
            this.gvRespuestas.Visible = true;
            CatalogRespuesta cr = new CatalogRespuesta();
            List<Respuesta> lr = new List<Respuesta>();
            lr = cr.listarRespuestas();
            this.gvRespuestas.DataSource = lr;
            this.DataBind();
        }
    }
}