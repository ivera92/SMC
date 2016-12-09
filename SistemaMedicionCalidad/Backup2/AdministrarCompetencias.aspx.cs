using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion
{
    public partial class AdministrarCompetencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.mostrar();
            }            
        }
        public void mostrar()
        {
            this.gvCompetencias.Visible = true;
            CatalogCompetencia ccompentecia = new CatalogCompetencia();
            List<Competencia> lcompetencias = new List<Competencia>();
            lcompetencias =ccompentecia.mostrarCompetencias();
            this.gvCompetencias.DataSource = lcompetencias;
            this.DataBind();
        }
        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id_competencia = HttpUtility.HtmlDecode((string)this.gvCompetencias.Rows[e.RowIndex].Cells[3].Text);
            CatalogCompetencia cc = new CatalogCompetencia();
            cc.eliminarCompetencia(int.Parse(id_competencia));
        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}