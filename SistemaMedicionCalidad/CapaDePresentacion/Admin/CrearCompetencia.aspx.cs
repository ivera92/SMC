using System;
using Project;
using System.Collections.Generic;

namespace CapaDePresentacion
{
    public partial class CrearCompetencia : System.Web.UI.Page
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
            CatalogTipoCompetencia cTipoCompetencia = new CatalogTipoCompetencia();
            List<Tipo_Competencia> lTiposCompetencia = cTipoCompetencia.listarTipoCompetencias();
            CatalogAmbito cAmbito = new CatalogAmbito();
            List<Ambito> lAmbitos = cAmbito.listarAmbitos();
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddTipoCompetencia.DataTextField = "Nombre_tipo_competencia";
                this.ddTipoCompetencia.DataValueField = "Id_tipo_competencia";
                this.ddTipoCompetencia.DataSource = lTiposCompetencia;

                this.ddAmbito.DataTextField = "Nombre_ambito";
                this.ddAmbito.DataValueField = "Id_ambito";
                this.ddAmbito.DataSource = lAmbitos;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }
        public void resetearValores()
        {
            this.ddTipoCompetencia.SelectedIndex = 0;
            this.ddAmbito.SelectedIndex = 0;
            this.txtNombre.InnerText = "";
        }
        protected void brnCrear_Click(object sender, EventArgs e)
        {
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            CatalogTipoCompetencia cTipoCompetencia = new CatalogTipoCompetencia();
            Tipo_Competencia tp = cTipoCompetencia.buscarUnTipoCompetencia(int.Parse(ddTipoCompetencia.SelectedValue));
            CatalogAmbito cAmbito = new CatalogAmbito();
            Ambito a = cAmbito.buscarUnAmbito(int.Parse(ddAmbito.SelectedValue));
            Competencia c = new Competencia(a, tp , txtNombre.InnerText);
            try
            {
                cCompetencia.insertarCompetencia(c);
                Response.Write("<script>window.alert('Competencia creada satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Competencia no a podido se registrada');</script>");
            }
            this.resetearValores();
        }
    }
}