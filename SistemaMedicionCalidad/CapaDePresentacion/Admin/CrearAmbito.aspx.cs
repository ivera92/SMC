using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Admin
{
    public partial class CrearAmbito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogAmbito cAmbito = new CatalogAmbito();
            Ambito a = new Ambito(tbxAmbito.Text.Trim());
            try
            {
                cAmbito.insertarAmbito(a);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Ambito creado satisfactoriamente');window.location='CrearAmbito.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Ya existe un ambito con ese nombre');window.location='CrearAmbito.aspx';</script>'");
            }
        }
    }
}