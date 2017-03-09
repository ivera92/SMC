using System;
using System.Collections.Generic;
using System.Threading;
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
            lcompetencias =ccompentecia.listarCompetencias();
            this.gvCompetencias.DataSource = lcompetencias;
            this.DataBind();
        }
        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id_competencia = HttpUtility.HtmlDecode((string)this.gvCompetencias.Rows[e.RowIndex].Cells[3].Text);
            CatalogCompetencia cc = new CatalogCompetencia();
            try
            {
                cc.eliminarCompetencia(int.Parse(id_competencia));
                Response.Write("<script>window.alert('Registro eliminado satisfactoriamente');</script>");
                Thread.Sleep(1500);
                this.mostrar();
            }
            catch
            {
                Response.Write("<script>window.alert('Registro no se a podido eliminar');</script>");
            }
        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            this.divMostrar.Visible = false;
            string idCompetencia = HttpUtility.HtmlDecode((string)this.gvCompetencias.Rows[e.NewEditIndex].Cells[3].Text);
            CatalogCompetencia cc = new CatalogCompetencia();
            Competencia c = cc.buscarUnaCompetencia(int.Parse(idCompetencia));
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
            try
            {
                cc.actualizarCompetencia(c);
                this.editar.Visible = false;
                Response.Write("<script>window.alert('Cambios guardados satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('No fue posible guardar los cambios');</script>");
            }
        }
    }
}