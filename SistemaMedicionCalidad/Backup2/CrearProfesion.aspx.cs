using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class CrearProfesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogProfesion cprofesion = new CatalogProfesion();
            Profesion p = new Profesion(this.tbxProfesion.Text);

            cprofesion.agregarProfesionPA(p);
        }
    }
}