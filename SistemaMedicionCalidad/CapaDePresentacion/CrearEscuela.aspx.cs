using System;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class CrearEscuela : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btbCrear_Click(object sender, EventArgs e)
        {
            CatalogEscuela cescuela = new CatalogEscuela();
            Escuela es= new Escuela (this.tbxEscuela.Text);
            cescuela.agregarEscuelaPA(es);
            Response.Write("<script>window.alert('Escuela creada satisfactoriamente');</script>");
        }
    }
}