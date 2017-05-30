using System;
using Project;
using System.Collections.Generic;

namespace CapaDePresentacion
{
    public partial class CrearCompetencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogTipoCompetencia cTipoCompetencia = new CatalogTipoCompetencia();
            List<Tipo_Competencia> lTiposCompetencia = cTipoCompetencia.listarTipoCompetencias();
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddTipoCompetencia.DataTextField = "Nombre_tipo_competencia";
                this.ddTipoCompetencia.DataValueField = "Id_tipo_competencia";
                this.ddTipoCompetencia.DataSource = lTiposCompetencia;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }
        public void resetearValores()
        {
            this.txtNombreCompetencia.Text = "";
            this.ddTipoCompetencia.SelectedIndex = 0;
            this.txtADescripcion.InnerText = "";
        }
        protected void brnCrear_Click(object sender, EventArgs e)
        {
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            CatalogTipoCompetencia cTipoCompetencia = new CatalogTipoCompetencia();
            Tipo_Competencia tp = cTipoCompetencia.buscarUnTipoCompetencia(int.Parse(ddTipoCompetencia.SelectedValue));
            Competencia c = new Competencia(this.txtNombreCompetencia.Text, tp , this.txtADescripcion.InnerText);
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