using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion.Admin
{
    public partial class ResultadosEvaluaciones : System.Web.UI.Page
    {
        private static string sql;
        protected void Page_Load(object sender, EventArgs e)
        {
            sql = "";
            if (!Page.IsPostBack)
            {
                this.ocultarDivs();
            }
        }
        public void ocultarDivs()
        {
            divAlumno.Visible = false;
            divDocente.Visible = false;
            divEscuela.Visible = false;
            divPais.Visible = false;
            divPromocion.Visible = false;
            divRut.Visible = false;
            divSexo.Visible = false;
        }
        public void ocultarFitros()
        {
            divEscuela.Visible = false;
            divPais.Visible = false;
            divPromocion.Visible = false;
            divRut.Visible = false;
            divSexo.Visible = false;
        }

        protected void ddUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ocultarDivs();
            if (ddUsuario.SelectedValue == "1")
            {
                divAlumno.Visible = true;
            }
            else if(ddUsuario.SelectedValue == "2")
            {
                divDocente.Visible = true;
            }
        }
        protected void ddAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ocultarFitros();
            if (ddAlumno.SelectedValue == "1")
            {

            }
            else if (ddAlumno.SelectedValue == "2")
            {
                CatalogEscuela cEscuela = new CatalogEscuela();
                List<Escuela> lEscuelas = cEscuela.listarEscuelas();
                this.ddEscuela.DataTextField = "Nombre_escuela";
                this.ddEscuela.DataValueField = "Id_escuela";
                this.ddEscuela.DataSource = lEscuelas;
                this.DataBind();//enlaza los datos a un dropdownlist  

                divEscuela.Visible = true;
            }
            else if (ddAlumno.SelectedValue == "3")
            {
                CatalogPais cPais = new CatalogPais();
                List<Pais> lPaises = cPais.listarPaises();
                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lPaises;
                this.DataBind();//enlaza los datos a un dropdownlist     

                divPais.Visible = true;
            }
            else if (ddAlumno.SelectedValue == "4")
            {
                CatalogAlumno cAlumno = new CatalogAlumno();
                List<int> lPromociones = cAlumno.listarPromociones();
                foreach (int item in lPromociones)
                {
                    this.ddPromocion.Items.Add(new ListItem(item + ""));
                }
                divPromocion.Visible = true;
            }
            else if (ddAlumno.SelectedValue == "5")
            {
                divRut.Visible = true;
            }
            else if (ddAlumno.SelectedValue == "6")
            {
                divSexo.Visible = true;
            }
        }
        

        protected void ddEdad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddEscuela_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "SELECT ID_RESPUESTA_HPA, CORRECTA_RESPUESTA, RUT_ALUMNO_HPA, BENEFICIO_ALUMNO FROM ALUMNO INNER JOIN HISTORICO_PRUEBA_ALUMNO ON RUT_ALUMNO = RUT_ALUMNO_HPA INNER JOIN RESPUESTA ON ID_RESPUESTA_HPA = ID_RESPUESTA where escuela_alumno='" + int.Parse(ddEscuela.SelectedValue) + "'";
        }

        protected void ddPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "SELECT ID_RESPUESTA_HPA, CORRECTA_RESPUESTA, RUT_ALUMNO_HPA, BENEFICIO_ALUMNO FROM ALUMNO INNER JOIN HISTORICO_PRUEBA_ALUMNO ON RUT_ALUMNO = RUT_ALUMNO_HPA INNER JOIN RESPUESTA ON ID_RESPUESTA_HPA = ID_RESPUESTA where pais_alumno='" + int.Parse(ddPais.SelectedValue) + "'";
        }

        protected void ddPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "SELECT ID_RESPUESTA_HPA, CORRECTA_RESPUESTA, RUT_ALUMNO_HPA, BENEFICIO_ALUMNO FROM ALUMNO INNER JOIN HISTORICO_PRUEBA_ALUMNO ON RUT_ALUMNO = RUT_ALUMNO_HPA INNER JOIN RESPUESTA ON ID_RESPUESTA_HPA = ID_RESPUESTA where promocion_alumno='" + int.Parse(ddPromocion.Text) + "'";
        }
    }
}