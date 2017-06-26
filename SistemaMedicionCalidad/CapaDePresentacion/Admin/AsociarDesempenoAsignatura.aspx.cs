using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Admin
{
    public partial class AsociarDesempenoAsignatura : System.Web.UI.Page
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
            try
            {
                string rut = Session["rutAdmin"].ToString();
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                List<Asignatura> lAsignatura = cAsignatura.listarAsignaturas();
                CatalogDesempeno cDesempeno = new CatalogDesempeno();
                List<Desempeno> lDesempeno = cDesempeno.listarDesempenosAjustado();

                if (!Page.IsPostBack) //para ver si cargo por primera vez
                {

                    this.ddAsignatura.DataTextField = "Nombre_asignatura";
                    this.ddAsignatura.DataValueField = "Cod_asignatura";
                    this.ddAsignatura.DataSource = lAsignatura;

                    this.ddDesempeno.DataTextField = "Indicador_desempeno";
                    this.ddDesempeno.DataValueField = "Id_desempeno";
                    this.ddDesempeno.DataSource = lDesempeno;


                    this.DataBind();//enlaza los datos a un dropdownlist                
                }
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }

        protected void ddDesempeno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddNivel.Items.Clear();            
            CatalogNivel cNivel = new CatalogNivel();
            List<Nivel> lNiveles = cNivel.listarNivelesDesempeno(int.Parse(ddDesempeno.SelectedValue));
            this.ddNivel.DataTextField = "Nombre_nivel";
            this.ddNivel.DataValueField = "Id_nivel";
            this.ddNivel.DataSource = lNiveles;

            this.DataBind();//enlaza los datos a un dropdownlist   
        }

        protected void btnAsociar_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogAsignaturaDesempeno cAD = new CatalogAsignaturaDesempeno();
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                CatalogDesempeno cDesempeno = new CatalogDesempeno();
                CatalogNivel cNivel = new CatalogNivel();
                Asignatura_Desempeno ad = new Asignatura_Desempeno(cAsignatura.buscarAsignatura(ddAsignatura.SelectedValue), cDesempeno.buscarUnDesempeno(int.Parse(ddDesempeno.SelectedValue)), cNivel.buscarNivel(int.Parse(ddNivel.SelectedValue)));
                if (cAD.verificarExistenciaAD(ad) == 0)
                {
                    cAD.insertarAD(ad);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Desempeño asociado correctamente a asignatura');window.location='AsociarDesempenoAsignatura.aspx';</script>'");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Desempeño ya esta asociado con esta asignatura');window.location='AsociarDesempenoAsignatura.aspx';</script>'");
                }
            }
            catch
            {
                Response.Write("<script>window.alert('Debe seleccionar todos los campos');</script>");
            }
        }
    }
}