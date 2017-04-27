﻿using System;
using Project;

namespace CapaDePresentacion
{
    public partial class CrearCompetencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void resetearValores()
        {
            this.txtNombreCompetencia.Text = "";
            this.rbTipoCompetencia.SelectedIndex = 0;
            this.txtADescripcion.InnerText = "";
        }
        protected void brnCrear_Click(object sender, EventArgs e)
        {
            CatalogCompetencia cCompetencia = new CatalogCompetencia();

            Competencia c = new Competencia(this.txtNombreCompetencia.Text, int.Parse(rbTipoCompetencia.SelectedValue), this.txtADescripcion.InnerText);
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