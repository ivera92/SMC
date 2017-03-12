using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion.Doc
{
    public partial class AdministrarDocentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogProfesion cProfesion = new CatalogProfesion();
            List<Profesion> lProfesiones = cProfesion.listarProfesiones();

            CatalogPais cPais = new CatalogPais();
            List<Pais> lPaises = cPais.listarPaises();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddProfesion.DataTextField = "Nombre_profesion";
                this.ddProfesion.DataValueField = "Id_profesion";
                this.ddProfesion.DataSource = lProfesiones;

                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lPaises;

                this.tablaEditar.Visible = false;

                this.mostrar();
                this.DataBind();
            }
        }
        //Elimina la fila seleccionada
        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string rut_docente = HttpUtility.HtmlDecode((string)this.gvDocentes.Rows[e.RowIndex].Cells[2].Text);
            CatalogDocente cDocente = new CatalogDocente();
            try
            {
                cDocente.eliminarDocente(rut_docente);
                Response.Write("<script>window.alert('Registro eliminado satisfactoriamente');</script>");
                Thread.Sleep(1500);
                this.mostrar();
            }
            catch
            {
                Response.Write("<script>window.alert('Registro no se a podido eliminar');</script>");
            }

        }
        //Carga los datos de la fila a actualizar
        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            this.tablaAdministrar.Visible = false;
            string rut_docente = HttpUtility.HtmlDecode((string)this.gvDocentes.Rows[e.NewEditIndex].Cells[2].Text);
            this.ddProfesion.SelectedIndex = 0;
            CatalogDocente cDocente = new CatalogDocente();
            Docente d = cDocente.buscarUnDocente(rut_docente);
            
            this.txtCorreo.Text = d.Correo_persona;
            this.txtDireccion.Text = d.Direccion_persona;

            if (d.Disponibilidad_docente == true)
                this.rbDisponibilidad.SelectedIndex = 0;
            else
                this.rbDisponibilidad.SelectedIndex = 1;

            this.txtFechaDeNacimiento.Text = d.Fecha_nacimiento_persona.ToString("d");
            this.ddPais.SelectedValue = d.Pais_persona.Id_pais+"";
            this.txtNombre.Text = d.Nombre_persona;
            this.ddProfesion.SelectedValue = d.Profesion_docente.Id_profesion+"";
            this.txtRut.Text = d.Rut_persona + "";

            if (d.Sexo_persona == true)
                this.rbSexo.SelectedIndex = 0;
            else
                this.rbSexo.SelectedIndex = 1;

            this.txtTelefono.Text = d.Telefono_persona+"";
            this.tablaEditar.Visible = true;
        }
        //Carga los docentes existente en el gridview
        public void mostrar()
        {
            this.gvDocentes.Visible=true;
            CatalogDocente cDocente = new CatalogDocente();
            List<Docente> lDocentes = cDocente.listarDocentes();
            this.gvDocentes.DataSource = lDocentes;
            this.DataBind();
        }
        //Guarda los datos actualizados
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogDocente cDocente = new CatalogDocente();
            bool sexo, disponibilidad;

            if (this.rbSexo.Text == "Masculino")
                sexo = true;
            else
                sexo = false;

            if (this.rbDisponibilidad.Text == "Part-Time")
                disponibilidad = true;
            else
                disponibilidad = false;

            Docente d = new Docente();
            Profesion p = new Profesion();
            Pais pa = new Pais();
            d.Profesion_docente = p;
            d.Pais_persona = pa;

            d.Rut_persona = this.txtRut.Text;
            d.Profesion_docente.Id_profesion = int.Parse(this.ddProfesion.SelectedValue);
            d.Pais_persona.Id_pais = int.Parse(this.ddPais.SelectedValue);
            d.Nombre_persona = this.txtNombre.Text;
            d.Fecha_nacimiento_persona = DateTime.Parse(this.txtFechaDeNacimiento.Text);
            d.Direccion_persona = this.txtDireccion.Text;
            d.Telefono_persona = int.Parse(this.txtTelefono.Text);
            d.Sexo_persona = sexo;
            d.Correo_persona = this.txtCorreo.Text;
            d.Disponibilidad_docente = disponibilidad;
            try
            {
                cDocente.actualizarDocente(d);
                this.tablaEditar.Visible = false;
                Response.Write("<script>window.alert('Cambios guardados satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Ya existe registro asociado al Rut');</script>");
            }
        }
    }
}