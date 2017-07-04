using System;
using Project;
using System.Collections.Generic;

namespace CapaDePresentacion
{
    public partial class CrearCompetencia : System.Web.UI.Page
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
            CatalogTipoCompetencia cTipoCompetencia = new CatalogTipoCompetencia();
            List<Tipo_Competencia> lTiposCompetencia = cTipoCompetencia.listarTipoCompetencias();
            CatalogAmbito cAmbito = new CatalogAmbito();
            List<Ambito> lAmbitos = cAmbito.listarAmbitos();
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddTipoCompetencia.DataTextField = "Nombre_tipo_competencia";
                this.ddTipoCompetencia.DataValueField = "Id_tipo_competencia";
                this.ddTipoCompetencia.DataSource = lTiposCompetencia;

                this.ddAmbito.DataTextField = "Nombre_ambito";
                this.ddAmbito.DataValueField = "Id_ambito";
                this.ddAmbito.DataSource = lAmbitos;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }
        protected void brnCrear_Click(object sender, EventArgs e)
        {
            if (ddAmbito.SelectedValue != "0" && ddTipoCompetencia.SelectedValue != "0")
            {
                try
                {
                    this.crearCompetencia();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Competencia creada satisfactoriamente');window.location='AdministrarCompetencias.aspx';</script>'");
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Competencia no a podido ser creada');window.location='AdministrarCompetencias.aspx';</script>'");
                }
            }
            else
            {
                Response.Write("<script>window.alert('Debe seleccionar ambito y tipo de competencia');</script>");
            }
        }

        public void limpiarControles()
        {
            this.txtIndicador.InnerText = "";
            this.txtNBasico.InnerText = "";
            this.txtNMedio.InnerText = "";
            this.txtNSuperior.InnerText = "";
            this.txtNAvanzado.InnerText = "";
        }
        protected void btnSeguir_Click(object sender, EventArgs e)
        {
            if (ddAmbito.SelectedValue != "0" && ddTipoCompetencia.SelectedValue != "0")
            {
                try
                {
                    this.crearCompetencia();
                    this.limpiarControles();
                }
                catch { }
            }
            else
            {
                Response.Write("<script>window.alert('Debe seleccionar ambito y tipo de competencia');</script>");
            }
        }

        public void crearCompetencia()
        {

            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            CatalogTipoCompetencia cTipoCompetencia = new CatalogTipoCompetencia();
            CatalogAmbito cAmbito = new CatalogAmbito();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            CatalogCompetenciaDesempeno cCD = new CatalogCompetenciaDesempeno();
            CatalogNivel cNivel = new CatalogNivel();

            //Se verifica si ya existe en los registros un desempeño con el indicador ingresado, o algun nivel con la descripcion
            if (cDesempeno.verificarExistenciaIDesempeno(txtIndicador.InnerText) > 0 || cNivel.verificarExistenciaNivel(txtNBasico.InnerText) > 0 || cNivel.verificarExistenciaNivel(txtNMedio.InnerText) > 0 || cNivel.verificarExistenciaNivel(txtNSuperior.InnerText) > 0 || cNivel.verificarExistenciaNivel(txtNAvanzado.InnerText) > 0)
            {
                Response.Write("<script>window.alert('Indicador de desempeño o niveles ya existen en los registros, verifique');</script>");
            }
            else
            {
                Tipo_Competencia tp = cTipoCompetencia.buscarUnTipoCompetencia(int.Parse(ddTipoCompetencia.SelectedValue));
                Ambito a = cAmbito.buscarUnAmbito(int.Parse(ddAmbito.SelectedValue));
                Competencia c = new Competencia(a, tp, txtNombre.InnerText);
                if (cCompetencia.verificarExistenciaCompetencia(txtNombre.InnerText) == 0)
                {
                    cCompetencia.insertarCompetencia(c);
                }

                Desempeno d = new Desempeno(txtIndicador.InnerText);
                cDesempeno.insertarDesempeno(d);


                Desempeno dd = cDesempeno.buscarUnDesempenoIndicador(txtIndicador.InnerText);
                Competencia cc = cCompetencia.buscarUnaCompetenciaNombre(txtNombre.InnerText);
                Competencia_Desempeno cd = new Competencia_Desempeno(dd, cc);
                cCD.insertarCD(cd);


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
            }
        }
    }
}