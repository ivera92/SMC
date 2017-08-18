using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Admin
{
    public partial class AdministrarAmbitos : System.Web.UI.Page
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
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.tablaEditar.Visible = false;
                this.mostrar();
            }
        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            string id_ambito = HttpUtility.HtmlDecode((string)this.gvAmbitos.Rows[e.NewEditIndex].Cells[2].Text);
            CatalogAmbito cAmbito = new CatalogAmbito();
            Ambito a = cAmbito.buscarUnAmbito(int.Parse(id_ambito));
            this.tbxAmbito.Text = a.Nombre_ambito;
            this.txtid.Text = a.Id_ambito + "";
            this.tablaAdministrar.Visible = false;
            this.tablaEditar.Visible = true;
        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id_ambito = int.Parse(HttpUtility.HtmlDecode((string)(this.gvAmbitos.Rows[e.RowIndex].Cells[2].Text)));
            CatalogAmbito cAmbito = new CatalogAmbito();

            try
            {
                cAmbito.eliminarAmbito(id_ambito);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Registro eliminado satisfactoriamente');window.location='AdministrarAmbitos.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Registro no a podido ser eliminado');window.location='AdministrarAmbitos.aspx';</script>'");
            }
        }

        //Lista las esculeas existentes
        public void mostrar()
        {
            this.txtid.Visible = false;
            this.gvAmbitos.Visible = true;
            CatalogAmbito cAmbito = new CatalogAmbito();
            List<Ambito> lAmbitos = cAmbito.listarAmbitos();
            this.gvAmbitos.DataSource = lAmbitos;
            this.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogAmbito cAmbito = new CatalogAmbito();
            Ambito a = new Ambito(int.Parse(txtid.Text), tbxAmbito.Text.Trim());
            try
            {
                cAmbito.actualizarAmbito(a);
                this.tablaEditar.Visible = false;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Cambios guardados satisfactoriamente');window.location='AdministrarAmbitos.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No fue posible guardar los cambios');window.location='AdministrarAmbitos.aspx';</script>'");
            }
        }
    }
}