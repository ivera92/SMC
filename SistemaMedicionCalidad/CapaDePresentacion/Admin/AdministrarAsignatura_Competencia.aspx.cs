using Project;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaDePresentacion.Admin
{
    public partial class AdministrarAsignatura_Competencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            List<Competencia> lCompetencias = cCompetencia.listarCompetencias();

            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignatura = cAsignatura.listarAsignaturas();
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.txtAC.Visible = false;
                this.divEditar.Visible = false;
                this.mostrar();

                this.ddCompetencia.DataTextField = "Nombre_competencia";
                this.ddCompetencia.DataValueField = "Id_competencia";
                this.ddCompetencia.DataSource = lCompetencias;

                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Cod_asignatura";
                this.ddAsignatura.DataSource = lAsignatura;

                this.DataBind();//enlaza los datos a un dropdownlist  
            }
        }

        //Carga los datos en el Gridview
        public void mostrar()
        {
            this.txtAC.Visible = false;
            this.gvAC.Visible = true;
            CatalogAsignaturaCompetencia cAC = new CatalogAsignaturaCompetencia();
            List<Asignatura_Competencia> lAC = cAC.listarAC();
            this.gvAC.DataSource = lAC;
            this.DataBind();
        }
        //Elimina una competencia por su ID
        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            try
            {
                string id_ac = HttpUtility.HtmlDecode((string)this.gvAC.Rows[e.RowIndex].Cells[1].Text);
                cCompetencia.eliminarCompetencia(int.Parse(id_ac));
                Response.Write("<script>window.alert('Registro eliminado satisfactoriamente');</script>");
                Thread.Sleep(1500);
                this.mostrar();
            }
            catch
            {
                Response.Write("<script>window.alert('Registro no se a podido eliminar');</script>");
            }
        }
        //Carga los valores de la competencia a editar
        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            this.divMostrar.Visible = false;
            string id_ac = HttpUtility.HtmlDecode((string)this.gvAC.Rows[e.NewEditIndex].Cells[1].Text);
            CatalogAsignaturaCompetencia cAC = new CatalogAsignaturaCompetencia();
            Asignatura_Competencia ac = cAC.buscarAsociacion(int.Parse(id_ac));
            this.txtAC.Text = ac.Id_ac + "";
            this.txtNivelDominio.Text = ac.Nivel_dominio_ac;
            this.ddAsignatura.SelectedValue = ac.Cod_Asignatura_ac.Cod_asignatura;
            this.ddCompetencia.SelectedValue = ac.Id_Competencia_ac.Id_competencia+"";

            this.divEditar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogAsignaturaCompetencia cAC = new CatalogAsignaturaCompetencia();
            Asignatura_Competencia aC = new Asignatura_Competencia();
            Asignatura a = new Asignatura();
            Competencia c = new Competencia();
            aC.Cod_Asignatura_ac = a;
            aC.Id_Competencia_ac = c;

            aC.Id_ac = int.Parse(txtAC.Text);
            aC.Cod_Asignatura_ac.Cod_asignatura = ddAsignatura.SelectedValue;
            aC.Id_Competencia_ac.Id_competencia = int.Parse(ddCompetencia.SelectedValue);
            aC.Nivel_dominio_ac = txtNivelDominio.Text.ToUpper();
            try
            {
                cAC.actualizarAsociacion(aC);
                this.divEditar.Visible = false;
                Response.Write("<script>window.alert('Cambios guardados satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('No fue posible guardar los cambios');</script>");
            }
        }
    }
}