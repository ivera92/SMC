using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion
{
    public partial class AdministrarCursa : System.Web.UI.Page
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
                txtId.Visible = false;
                this.mostrar();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void gvCursa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        public void mostrar()
        {
            this.txtId.Visible = false;
            this.gvCursa.Visible = true;
            CatalogCursa cCursa = new CatalogCursa();
            List<Cursa> lCursa = cCursa.listarAsignaturasInscritas();
            this.gvCursa.DataSource = lCursa;
            this.DataBind();
        }
    }
}