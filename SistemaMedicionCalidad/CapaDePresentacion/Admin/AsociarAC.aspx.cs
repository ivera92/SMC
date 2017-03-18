using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion.Admin
{
    public partial class AsociarAC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencias = cCompetencia.listarCompetencias();

            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignatura = cAsignatura.listarAsignaturas();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {

                this.ddCompetencia.DataTextField = "Nombre_competencia";
                this.ddCompetencia.DataValueField = "Id_competencia";
                this.ddCompetencia.DataSource = lCompetencias;

                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Id_asignatura";
                this.ddAsignatura.DataSource = lAsignatura;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }

        protected void btnAsociar_Click(object sender, EventArgs e)
        {

        }
    }
}