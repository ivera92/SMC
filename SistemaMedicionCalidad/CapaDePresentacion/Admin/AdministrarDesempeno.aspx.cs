using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Admin
{
    public partial class AdministrarDesempeno : System.Web.UI.Page
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
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencias = cCompetencia.listarCompetencias();
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                divEditar.Visible = false;
                this.mostrar();
                this.ddCompetencia.DataTextField = "Nombre_competencia";
                this.ddCompetencia.DataValueField = "Id_competencia";
                this.ddCompetencia.DataSource = lCompetencias;

                this.DataBind();//enlaza los datos a un dropdownlist 
            }
        }
        //Lista los desempeños existentes
        public void mostrar()
        {
            this.txtid.Visible = false;
            this.gvDesempenos.Visible = true;
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            List<Desempeno> lDesempenos = cDesempeno.listarDesempenos();
            this.gvDesempenos.DataSource = lDesempenos;
            this.DataBind();
        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            string id_desempeno = HttpUtility.HtmlDecode((string)this.gvDesempenos.Rows[e.NewEditIndex].Cells[1].Text);
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            Desempeno d = cDesempeno.buscarUnDesempeno(int.Parse(id_desempeno));
            txtIndicador.Text = d.Indicador_desempeno;

            CatalogNivel cNivel = new CatalogNivel();
            List<Nivel> lNiveles = cNivel.listarNivelesDesempeno(int.Parse(id_desempeno));

            Nivel basico = lNiveles[0];
            txtNBasico.InnerText = basico.Descripcion_nivel;
            Nivel medio = lNiveles[1];
            txtNMedio.InnerText = medio.Descripcion_nivel;
            Nivel superior = lNiveles[2];
            txtNSuperior.InnerText = superior.Descripcion_nivel;
            Nivel avanzado;
            try
            {
                avanzado = lNiveles[3];
                txtNAvanzado.InnerText = avanzado.Descripcion_nivel;
            }
            catch { }

            CatalogCompetenciaDesempeno cCD = new CatalogCompetenciaDesempeno();
            Competencia_Desempeno cd = cCD.buscarCDIDDesempeno(int.Parse(id_desempeno));

            ddCompetencia.SelectedValue = cd.Id_competencia.Id_competencia + "";
            
            this.txtid.Text = id_desempeno;
            this.tablaAdministrar.Visible = false;
            this.divEditar.Visible = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}