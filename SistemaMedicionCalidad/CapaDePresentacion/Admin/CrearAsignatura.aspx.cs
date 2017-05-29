using System;
using System.Collections.Generic;
using System.Web.UI;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class CrearAsignatura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogEscuela cEscuela = new CatalogEscuela();
            List<Escuela> lEscuelas = cEscuela.listarEscuelas();
            CatalogDocente cDocente = new CatalogDocente();
            List<Docente> lDocentes = cDocente.listarDocentes();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddEscuela.DataTextField = "Nombre_escuela";
                this.ddEscuela.DataValueField = "Id_escuela";
                this.ddEscuela.DataSource = lEscuelas;

                this.ddDocente.DataTextField = "Nombre_persona";
                this.ddDocente.DataValueField = "Rut_persona";
                this.ddDocente.DataSource = lDocentes;

                this.DataBind();//enlaza los datos a un dropdownlist   
            }
        }
        public void resetearValores()
        {
            this.ddEscuela.SelectedIndex = 0;
            this.ddDocente.SelectedIndex = 0;
            this.txtNombre.Text = "";
            this.txtAno.Text = "";
            this.txtCodigo.Text = "";
            rbDuracion.SelectedIndex = 0;
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            bool duracion;
            if (this.rbDuracion.Text == "Semestral")
                duracion = true;
            else
                duracion = false;

            Asignatura a = new Asignatura();
            Escuela es = new Escuela();
            Docente d = new Docente();
            a.Escuela_asignatura = es;
            a.Docente_asignatura = d;

            a.Escuela_asignatura.Id_escuela = int.Parse(this.ddEscuela.SelectedValue);
            a.Docente_asignatura.Rut_persona = this.ddDocente.SelectedValue;
            a.Nombre_asignatura = this.txtNombre.Text;
            a.Ano_asignatura = int.Parse(this.txtAno.Text);
            a.Cod_asignatura = this.txtCodigo.Text.ToUpper();
            a.Duracion_asignatura = duracion;
            try
            {
                cAsignatura.insertarAsignatura(a);
                Response.Write("<script>window.alert('Asignatura creada satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Codigo de asignatura ya existe');</script>");
            }
            this.resetearValores();
        }
    }
}