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
                this.ddAsignatura.DataValueField = "Cod_asignatura";
                this.ddAsignatura.DataSource = lAsignatura;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }
        public void resetearValores()
        {
            ddAsignatura.SelectedIndex = 0;
            ddCompetencia.SelectedIndex = 0;
            txtNivelDominio.Text = "";
        }

        protected void btnAsociar_Click(object sender, EventArgs e)
        {
            CatalogAsignaturaCompetencia cAC = new CatalogAsignaturaCompetencia();
            Asignatura_Competencia aC = new Asignatura_Competencia();
            Asignatura a = new Asignatura();
            Competencia c = new Competencia();
            aC.Cod_Asignatura_ac = a;
            aC.Id_Competencia_ac = c;


            aC.Cod_Asignatura_ac.Cod_asignatura = ddAsignatura.SelectedValue;
            aC.Id_Competencia_ac.Id_competencia = int.Parse(ddCompetencia.SelectedValue);
            aC.Nivel_dominio_ac = txtNivelDominio.Text.ToUpper();
            try
            {
                cAC.insertarAC(aC);
                Response.Write("<script>window.alert('Competencia fue correctamente asociada a asignatura');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Componentes no pudieron ser asociados');</script>");
            }
            this.resetearValores();
        }
    }
}