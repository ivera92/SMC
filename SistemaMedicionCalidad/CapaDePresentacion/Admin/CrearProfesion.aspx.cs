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
            CatalogProfesion cProfesion = new CatalogProfesion();
            Profesion p = new Profesion(this.tbxProfesion.Text);

            try
            {
                cProfesion.insertarProfesion(p);
                Response.Write("<script>window.alert('Profesion creada satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Profesion no pudo ser creada');</script>");
            }
            this.tbxProfesion.Text = "";
        }
    }
}