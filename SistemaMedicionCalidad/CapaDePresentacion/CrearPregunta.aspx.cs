using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion
{
    public partial class CrearPregunta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogPregunta cp = new CatalogPregunta();
            List<Tipo_Pregunta> ltp = cp.mostrarTiposPregunta();
            CatalogCompetencia cc = new CatalogCompetencia();
            List<Competencia> lc = cc.mostrarCompetencias();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddTipoPregunta.DataTextField = "Nombre_tipo_pregunta";
                this.ddTipoPregunta.DataValueField = "Id_tipo_pregunta";
                this.ddTipoPregunta.DataSource = ltp;

                this.ddCompetencia.DataTextField = "Nombre_competencia";
                this.ddCompetencia.DataValueField = "Id_competencia";
                this.ddCompetencia.DataSource = lc;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogPregunta cp = new CatalogPregunta();
            Pregunta p = new Pregunta(int.Parse(this.ddCompetencia.SelectedValue), int.Parse(this.ddTipoPregunta.SelectedValue), this.txtPregunta.Text);
            cp.agregarPregunta(p);

            Response.Write("<script>window.alert('Pregunta creada satisfactoriamente');</script>");
        }
    }
}