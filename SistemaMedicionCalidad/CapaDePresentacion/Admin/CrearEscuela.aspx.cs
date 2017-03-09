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
            try
            {
                cescuela.insertarEscuela(es);
                Response.Write("<script>window.alert('Escuela creada satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Escuela no a podido ser registrada');</script>");
            }
            this.tbxEscuela.Text = "";
        }
    }
}