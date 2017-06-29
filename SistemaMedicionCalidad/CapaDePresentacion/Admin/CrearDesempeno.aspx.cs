using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Admin
{
    public partial class CrearDesempeno : System.Web.UI.Page
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
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencias = cCompetencia.listarCompetencias();
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddCompetencia.DataTextField = "Nombre_competencia";
                this.ddCompetencia.DataValueField = "Id_competencia";
                this.ddCompetencia.DataSource = lCompetencias;

                this.DataBind();//enlaza los datos a un dropdownlist 
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogDesempeno cDesempeno = new CatalogDesempeno();
                Desempeno d = new Desempeno(txtIndicador.Text);
                cDesempeno.insertarDesempeno(d);

                CatalogCompetenciaDesempeno cCD = new CatalogCompetenciaDesempeno();
                Desempeno dd = cDesempeno.buscarUnDesempenoIndicador(txtIndicador.Text);

                CatalogCompetencia cCompetencia = new CatalogCompetencia();
                Competencia c = cCompetencia.buscarUnaCompetencia(int.Parse(ddCompetencia.SelectedValue));
                Competencia_Desempeno cd = new Competencia_Desempeno(dd, c);
                cCD.insertarCD(cd);

                CatalogNivel cNivel = new CatalogNivel();
                Nivel nBasico = new Nivel(dd, 1, "Básico", txtNBasico.InnerText);
                Nivel nMedio = new Nivel(dd, 2, "Medio", txtNMedio.InnerText);
                Nivel nSuperior = new Nivel(dd, 3, "Superior", txtNSuperior.InnerText);
                cNivel.insertarNivel(nBasico);
                cNivel.insertarNivel(nMedio);
                cNivel.insertarNivel(nSuperior);

                if (txtNAvanzado.InnerText.Length > 0)
                {
                    Nivel nAvanzado = new Nivel(dd, 4, "Avanzado", txtNAvanzado.InnerText);
                    cNivel.insertarNivel(nAvanzado);
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Desempeño, niveles y asociacion creados satisfactoriamente');window.location='CrearDesempeno.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No fue posible crear desempeño');window.location='CrearDesempeno.aspx';</script>'");
            }
        }
    }
}