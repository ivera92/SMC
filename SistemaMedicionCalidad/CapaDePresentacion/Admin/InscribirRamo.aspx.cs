using System;
using System.Collections.Generic;
using System.Web.UI;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion.Admin
{
    public partial class InscribirRamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutAdmin"].ToString();
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                List<Asignatura> lAsignatura = cAsignatura.listarAsignaturas();

                if (!Page.IsPostBack) //para ver si cargo por primera vez
                {

                    this.ddAsignatura.DataTextField = "Nombre_asignatura";
                    this.ddAsignatura.DataValueField = "Cod_asignatura";
                    this.ddAsignatura.DataSource = lAsignatura;

                    this.DataBind();//enlaza los datos a un dropdownlist                
                }
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }

        protected void btnInscribir_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogCursa cCursa = new CatalogCursa();
                CatalogAlumno cAlumno = new CatalogAlumno();
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                DateTime fechaHoy = DateTime.Now;
                Cursa c = new Cursa();

                c.Rut_alumno_aa = cAlumno.buscarAlumnoPorRut(txtRut.Text);
                c.Cod_asignatura_aa = cAsignatura.buscarAsignatura(ddAsignatura.SelectedValue);
                c.Ano_asignatura = fechaHoy.Year + "";

                if (cCursa.verificarExistenciaCursa(c)==0)
                {
                    cCursa.inscribirAsignatura(c);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Asignatura inscrita correctamente');window.location='InscribirRamo.aspx';</script>'");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Asignatura ya existe inscrita para el alumno');window.location='InscribirRamo.aspx';</script>'");
                }
            }
            catch
            {
                Response.Write("<script>window.alert('Seleccione alguna asignatura');</script>");
            }
        }
    }
}