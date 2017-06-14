using System;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class CrearEscuela : System.Web.UI.Page
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
        }

        protected void btbCrear_Click(object sender, EventArgs e)
        {
            CatalogEscuela cEscuela = new CatalogEscuela();
            Escuela es = new Escuela(this.tbxEscuela.Text);
            if (cEscuela.verificarExistenciaEscuela(this.tbxEscuela.Text) == 0)
            {
                cEscuela.insertarEscuela(es);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Escuela creada satisfactoriamente');window.location='CrearEscuela.aspx';</script>'");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Ya existe una escuela con ese nombre');window.location='CrearEscuela.aspx';</script>'");
            }
        }
    }
}