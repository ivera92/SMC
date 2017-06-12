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
            try
            {
                string rut = Session["rutAdmin"].ToString();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
            CatalogEscuela cEscuela = new CatalogEscuela();
            List<Escuela> lEscuelas = cEscuela.listarEscuelas();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddEscuela.DataTextField = "Nombre_escuela";
                this.ddEscuela.DataValueField = "Id_escuela";
                this.ddEscuela.DataSource = lEscuelas;

                this.DataBind();//enlaza los datos a un dropdownlist   
            }
        }
        public void resetearValores()
        {
            this.ddEscuela.SelectedIndex = 0;
            this.txtNombre.Text = "";
            this.txtCodigo.Text = "";
            rbDuracion.SelectedIndex=-1;
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            bool duracion;
            if (this.rbDuracion.SelectedValue == "0")
                duracion = true;
            else
                duracion = false;

            Asignatura a = new Asignatura();
            Escuela es = new Escuela();
            a.Escuela_asignatura = es;

            a.Cod_asignatura = this.txtCodigo.Text.ToUpper().Trim();
            a.Escuela_asignatura.Id_escuela = int.Parse(this.ddEscuela.SelectedValue);
            a.Nombre_asignatura = this.txtNombre.Text.Trim();
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