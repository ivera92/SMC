using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.CapaDeNegocios;
using Project;

namespace CapaDePresentacion
{
    public partial class AdministrarAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.mostrar();
            }
        }

        public void mostrar()
        {
            this.GridView1.Visible = true;
            CatalogAlumno calumno = new CatalogAlumno();
            List<Alumno> listaAlumnos = new List<Alumno>();
            listaAlumnos = calumno.mostrarAlumnos();
            this.GridView1.DataSource = listaAlumnos;
            this.DataBind();
        }
    }
}