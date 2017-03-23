using System;
using System.Collections.Generic;
using System.Web.UI;
using Project.CapaDeNegocios;
using Project;

namespace CapaDePresentacion.Doc
{
    public partial class CrearAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogEscuela cEscuela = new CatalogEscuela();
            List<Escuela> lEscuelas = cEscuela.listarEscuelas();

            CatalogPais cPais = new CatalogPais();
            List<Pais> lPaises = cPais.listarPaises();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddEscuela.DataTextField = "Nombre_escuela";
                this.ddEscuela.DataValueField = "Id_escuela";
                this.ddEscuela.DataSource = lEscuelas;

                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lPaises;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }
        public void resetearValores()
        {
            this.txtRut.Text="";
            this.ddEscuela.SelectedIndex=0;
            this.ddPais.SelectedIndex=0;
            this.txtNombre.Text="";
            this.txtFechaDeNacimiento.Text="";
            this.txtDireccion.Text="";
            this.txtTelefono.Text="";
            rbSexo.SelectedIndex=0;
            this.txtCorreo.Text="";
            this.txtPromocion.Text="";
            rbBeneficio.SelectedIndex=0;
        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogAlumno cAlumno = new CatalogAlumno();
            bool sexo, beneficio;

            if (this.rbSexo.Text == "Masculino")
                sexo = true;
            else
                sexo = false;

            if (this.rbBeneficio.Text == "Si")
                beneficio = true;
            else
                beneficio = false;

            Alumno a = new Alumno();
            Pais p = new Pais();
            Escuela es = new Escuela();
            a.Pais_persona = p;
            a.Escuela_alumno = es;

            a.Rut_persona = this.txtRut.Text;
            a.Escuela_alumno.Id_escuela = int.Parse(this.ddEscuela.SelectedValue);
            a.Pais_persona.Id_pais = int.Parse(this.ddPais.SelectedValue);
            a.Nombre_persona = this.txtNombre.Text;
            a.Fecha_nacimiento_persona = DateTime.Parse(this.txtFechaDeNacimiento.Text);
            a.Direccion_persona = this.txtDireccion.Text;
            a.Telefono_persona = int.Parse(this.txtTelefono.Text);
            a.Sexo_persona = sexo;
            a.Correo_persona = this.txtCorreo.Text;
            a.Promocion_alumno = int.Parse(this.txtPromocion.Text);
            a.Beneficio_alumno = beneficio;
            try
            {
                cAlumno.insertarAlumno(a);
                Response.Write("<script>window.alert('Alumno creado satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Ya existe registro asociado al Rut');</script>");
            }
            this.resetearValores();
        }
    }
}