﻿using System;
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
                this.divEditar.Visible = false;
                this.mostrar();
            }            
        }
        //Carga los datos en el Gridview
        public void mostrar()
        {
            this.txtCompetencia.Visible = false;
            this.gvCompetencias.Visible = true;
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencias = cCompetencia.listarCompetencias();
            this.gvCompetencias.DataSource = lCompetencias;
            this.DataBind();
        }
        //Elimina una competencia por su ID
        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            try
            {
                string id_competencia = HttpUtility.HtmlDecode((string)this.gvCompetencias.Rows[e.RowIndex].Cells[3].Text);
                cCompetencia.eliminarCompetencia(int.Parse(id_competencia));
                Response.Write("<script>window.alert('Registro eliminado satisfactoriamente');</script>");
                Thread.Sleep(1500);
                this.mostrar();
            }
            catch
            {
                Response.Write("<script>window.alert('Registro no se a podido eliminar');</script>");
            }
        }
        //Carga los valores de la competencia a editar
        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            this.divMostrar.Visible = false;
            string idCompetencia = HttpUtility.HtmlDecode((string)this.gvCompetencias.Rows[e.NewEditIndex].Cells[3].Text);
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            Competencia c = cCompetencia.buscarUnaCompetencia(int.Parse(idCompetencia));
            this.txtCompetencia.Text = c.Id_competencia + "";
            this.txtNombreCompetencia.Text = c.Nombre_competencia;
            this.txtADescripcion.InnerText = c.Descripcion_competencia;

            if(int.Parse(rbTipoCompetencia.SelectedValue)==1)
                this.rbTipoCompetencia.SelectedIndex = 1;
            else if(int.Parse(rbTipoCompetencia.SelectedValue)==2)
                this.rbTipoCompetencia.SelectedIndex = 2;
            else
                this.rbTipoCompetencia.SelectedIndex = 3;

            this.divEditar.Visible = true;
        }
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogCompetencia cCompetencia = new CatalogCompetencia();

            Competencia c = new Competencia(int.Parse(this.txtCompetencia.Text), this.txtNombreCompetencia.Text, int.Parse(rbTipoCompetencia.SelectedValue), this.txtADescripcion.InnerText);
            try
            {
                cCompetencia.actualizarCompetencia(c);
                this.divEditar.Visible = false;
                Response.Write("<script>window.alert('Cambios guardados satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('No fue posible guardar los cambios');</script>");
            }
        }
    }
}