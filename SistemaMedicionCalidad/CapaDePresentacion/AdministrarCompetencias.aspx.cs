using System;
using System.Collections.Generic;
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
                this.guardado.Visible = false;
                this.txtCompetencia.Visible = false;
                this.editar.Visible = false;
                this.mostrar();
            }            
        }
        public void mostrar()
        {
            this.txtCompetencia.Visible = false;
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
            Response.Redirect("AdministrarAsignaturas.aspx");
        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            this.divMostrar.Visible = false;
            string idCompetencia = HttpUtility.HtmlDecode((string)this.gvCompetencias.Rows[e.NewEditIndex].Cells[3].Text);
            CatalogCompetencia cc = new CatalogCompetencia();
            Competencia c = cc.buscarID(int.Parse(idCompetencia));
            this.txtCompetencia.Text = c.Id_competencia + "";
            this.txtNombreCompetencia.Text = c.Nombre_competencia;
            this.descripcion.InnerText = c.Descripcion_competencia;
            if(c.Tipo_competencia==true)
            {
                this.tipoCompetencia.SelectedIndex = 0;
            }
            else
            {
                this.tipoCompetencia.SelectedIndex = 1;
            }
            this.editar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogCompetencia cc = new CatalogCompetencia();
            bool tipo;
            if (this.tipoCompetencia.Text == "Generica")
            {
                tipo = true;
            }
            else
            {
                tipo = false;
            }
            Competencia c = new Competencia(int.Parse(this.txtCompetencia.Text), this.txtNombreCompetencia.Text, tipo, this.descripcion.InnerText);
            cc.editarCompetencia(c);
            this.editar.Visible = false;
            this.guardado.Visible = true;
        }
    }
}