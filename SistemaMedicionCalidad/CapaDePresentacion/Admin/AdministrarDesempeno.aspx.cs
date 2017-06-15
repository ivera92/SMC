using Project;
using System;
using System.Collections.Generic;
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
            CatalogAsignaturaDesempeno cAD = new CatalogAsignaturaDesempeno();
            string id_desempeno = HttpUtility.HtmlDecode((string)this.gvDesempenos.Rows[e.RowIndex].Cells[1].Text);

            if (cAD.verificarExistenciaADIDD(int.Parse(id_desempeno))== 0)
            {
                CatalogDesempeno cDesempeno = new CatalogDesempeno();
                CatalogCompetenciaDesempeno cCD = new CatalogCompetenciaDesempeno();
                CatalogNivel cNivel = new CatalogNivel();
                cNivel.eliminarNivelesDesempeno(int.Parse(id_desempeno));
                cCD.eliminarCDIDDesempeno(int.Parse(id_desempeno));
                cDesempeno.eliminarDesempeno(int.Parse(id_desempeno));
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Indicador de desempeño, niveles y asociacion a competencia eliminados satisfactoriamente');window.location='AdministrarDesempeno.aspx';</script>'");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Indicador no pudo ser eliminado puesto que esta asociado a una asignatura');window.location='AdministrarDesempeno.aspx';</script>'");

            }
        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            string id_desempeno = HttpUtility.HtmlDecode((string)this.gvDesempenos.Rows[e.NewEditIndex].Cells[1].Text);
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            Desempeno d = cDesempeno.buscarUnDesempeno(int.Parse(id_desempeno));
            txtIndicador.Text = d.Indicador_desempeno;
            txtid.Text = id_desempeno;

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
            this.gvDesempenos.Visible = true;
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            List<Desempeno> lDesempenos = cDesempeno.listarDesempenosBusqueda(txtBuscar.Text);
            this.gvDesempenos.DataSource = lDesempenos;
            this.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogDesempeno cDesempeno = new CatalogDesempeno();
                Desempeno dd = new Desempeno(int.Parse(txtid.Text), txtIndicador.Text.Trim());
                cDesempeno.actualizarDesempeno(dd);

                CatalogCompetenciaDesempeno cCD = new CatalogCompetenciaDesempeno();
                Competencia_Desempeno cd = cCD.buscarCDIDDesempeno(int.Parse(txtid.Text));
                CatalogCompetencia cCompetencia = new CatalogCompetencia();
                Competencia c = cCompetencia.buscarUnaCompetencia(int.Parse(ddCompetencia.SelectedValue));
                Competencia_Desempeno cdd = new Competencia_Desempeno(cd.Id_cd, dd, c);
                cCD.actualizarAsociacion(cdd);

                CatalogNivel cNivel = new CatalogNivel();
                List<Nivel> lNiveles = cNivel.listarNivelesDesempeno(int.Parse(txtid.Text));
                Nivel nBasico = lNiveles[0];
                Nivel nMedio = lNiveles[1];
                Nivel nSuperior = lNiveles[2];
                cNivel.actualizarNivel(new Nivel(nBasico.Id_nivel, dd, nBasico.Numero_nivel, nBasico.Nombre_nivel, txtNBasico.InnerText.Trim()));
                cNivel.actualizarNivel(new Nivel(nMedio.Id_nivel, dd, nMedio.Numero_nivel, nMedio.Nombre_nivel, txtNMedio.InnerText.Trim()));
                cNivel.actualizarNivel(new Nivel(nSuperior.Id_nivel, dd, nSuperior.Numero_nivel, nSuperior.Nombre_nivel, txtNSuperior.InnerText.Trim()));

                if (txtNAvanzado.InnerText.Length > 0)
                {
                    Nivel nAvanzado = lNiveles[3];
                    cNivel.actualizarNivel(new Nivel(nAvanzado.Id_nivel, dd, nAvanzado.Numero_nivel, nAvanzado.Nombre_nivel, txtNAvanzado.InnerText.Trim()));
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Desempeño, niveles y asociacion fueron actulizados satisfactoriamente');window.location='AdministrarDesempeno.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No fue posible guardar los cambios');window.location='AdministrarDesempeno.aspx';</script>'");
            }
        }

        protected void gvDesempenos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDesempenos.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
                this.gvDesempenos.Visible = true;
                CatalogDesempeno cDesempeno = new CatalogDesempeno();
                List<Desempeno> lDesempenos = cDesempeno.listarDesempenosBusqueda(txtBuscar.Text);
                this.gvDesempenos.DataSource = lDesempenos;
                this.DataBind();
            }
            else
            {
                this.mostrar();
            }
        }
    }
}