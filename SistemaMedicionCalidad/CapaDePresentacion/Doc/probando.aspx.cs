using System;
using System.IO;

namespace CapaDePresentacion.Doc
{
    public partial class probando : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (fileImagen.PostedFile.ContentLength > 0)
            {
                string archivo = Server.MapPath(String.Format("/ImagenesPreguntas/{0}",
                    Path.GetFileName(fileImagen.PostedFile.FileName)));
                if (File.Exists(archivo)) File.Delete(archivo);
                fileImagen.PostedFile.SaveAs(archivo);
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje",
                    "alert('La imagen fue grabada en el servidor');", true);
            }
        }
    }
}