using System;
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
            Response.Write("<script>window.alert('Profesion creada satisfactoriamente');</script>");
            this.tbxProfesion.Text = "";
        }
    }
}