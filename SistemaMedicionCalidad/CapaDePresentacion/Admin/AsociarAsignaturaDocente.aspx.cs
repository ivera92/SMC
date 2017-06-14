using Project;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace CapaDePresentacion.Admin
{
    public partial class AsociarAsignaturaDocente : System.Web.UI.Page
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

        protected void btnAsociar_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogImparte cImparte = new CatalogImparte();
                CatalogDocente cDocente = new CatalogDocente();
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                DateTime fechaHoy = DateTime.Now;
                Imparte i = new Imparte();

                i.Rut_docente_imparte = cDocente.buscarUnDocente(txtRut.Text);
                i.Cod_asignatura_imparte = cAsignatura.buscarAsignatura(ddAsignatura.SelectedValue);
                i.Ano_imparte = fechaHoy.Year + "";

                if (cImparte.verificarExistenciaImparte(i) == 0)
                {
                    cImparte.insertarAD(i);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Asignatura asociada correctamente');window.location='InscribirRamo.aspx';</script>'");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Asignatura ya esta asociada para el docente');window.location='InscribirRamo.aspx';</script>'");
                }
            }
            catch
            {
                Response.Write("<script>window.alert('Seleccione alguna asignatura');</script>");
            }
        }
    }
}