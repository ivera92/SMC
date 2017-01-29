using System;
using Project;

namespace CapaDePresentacion
{
    public partial class CrearCompetencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void brnCrear_Click(object sender, EventArgs e)
        {
            CatalogCompetencia ccompetencia = new CatalogCompetencia();
            bool tipo_competencia;
            if (this.tipoCompetencia.Text == "Generica")
            {
                tipo_competencia = true;
            }
            else
                tipo_competencia = false;
            Competencia c = new Competencia(this.txtNombreCompetencia.Text, tipo_competencia, this.descripcion.InnerText);
            ccompetencia.agregarCompetenciaPA(c);
            Response.Write("<script>window.alert('Competencia creada satisfactoriamente');</script>");
        }
    }
}