using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Doc
{
    public partial class AdministrarEvaluaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutDocente"].ToString();
                this.mostrar();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }            
        }
        public void mostrar()
        {
            string rut = Session["rutDocente"].ToString();
            this.gvEvaluaciones.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<Evaluacion> lEvaluacion = cEvaluacion.listarEvaluacionesDocente(rut);
            this.gvEvaluaciones.DataSource = lEvaluacion;
            this.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvEvaluaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEvaluaciones.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
            }
            else
            {
                this.mostrar();
            }
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            
                //
                // Se obtiene indice de la row seleccionada
                //
                //int index = Convert.ToInt32(e.CommandArgument);

                //
                // Obtengo el id de la entidad que se esta editando
                // en este caso de la entidad Person
                //
                //int id = Convert.ToInt32(gvEvaluaciones.DataKeys[index].Value);

            
        }
    }
}