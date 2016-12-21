using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class CrearEscuela : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.creado.Visible = false;
            }
        }

        protected void btbCrear_Click(object sender, EventArgs e)
        {
            CatalogEscuela cescuela = new CatalogEscuela();
            Escuela es= new Escuela (this.tbxEscuela.Text);

            cescuela.agregarEscuelaPA(es);
            this.crear.Visible = false;
            this.creado.Visible = true;
        }
    }
}