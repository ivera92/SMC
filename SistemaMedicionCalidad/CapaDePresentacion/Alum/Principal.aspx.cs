using System;
using Project;
using Project.CapaDeNegocios;
using System.Collections.Generic;

namespace CapaDePresentacion.Alum
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogPais cPais = new CatalogPais();
            List<Pais> lPaises = cPais.listarPaises();

            this.ocultarActualizacion();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {

                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lPaises;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }

            try
            {
                string rut = Session["rutAlumno"].ToString();
                this.cargarDatosAlumno(rut);
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }            
        }
        public void ocultarActualizacion()
        {
            txtFechaDeNacimiento.Visible = false;
            txtDireccion.Visible = false;
            txtPromocion.Visible = false;
            txtTelefono.Visible = false;
            ddPais.Visible = false;
            divSexo.Visible = false;
            btnGuardar.Visible = false;
            divBeneficio.Visible = false;
        }
        public void mostrarActualizacion()
        {
            txtFechaDeNacimiento.Visible = true;
            txtDireccion.Visible = true;
            txtPromocion.Visible = true;
            txtTelefono.Visible = true;
            ddPais.Visible = true;
            divSexo.Visible = true;
            btnActualizar.Visible = false;
            btnGuardar.Visible = true;
            divBeneficio.Visible = true;
        }
        //Carga los datos del docente
        public void cargarDatosAlumno(string rut)
        {
            CatalogAlumno cAlumno = new CatalogAlumno();
            Alumno a = cAlumno.buscarAlumnoPorRut(rut);
            CatalogEscuela cEscuela = new CatalogEscuela();
            Escuela es = cEscuela.buscarUnaEscuela(a.Escuela_alumno.Id_escuela);
            CatalogPais cPais = new CatalogPais();            

            nombreAlumno.InnerText = a.Nombre_persona;
            correo.InnerText = a.Correo_persona;
            nombreEscuela.InnerText = es.Nombre_escuela;

            try
            {
                Pais p = cPais.buscarUnPais(a.Pais_persona.Id_pais);
                nacionalidad.InnerText = p.Nombre_pais;
                fechaNacimiento.InnerText = a.Fecha_nacimiento_persona.Date.ToString("dd/M/yyyy");
                direccion.InnerText = a.Direccion_persona;
                telefono.InnerText = a.Telefono_persona + "";
                promocion.InnerText = a.Promocion_alumno + "";
            }
            catch {
                nacionalidad.InnerText = "";
                fechaNacimiento.InnerText = "";
                direccion.InnerText = "";
                telefono.InnerText = "";
                promocion.InnerText = "";
            }
        }
        public void cargarActualizacion()
        {
            string rut = Session["rutAlumno"].ToString();
            CatalogAlumno cAlumno = new CatalogAlumno();
            Alumno a = cAlumno.buscarAlumnoPorRut(rut);
            CatalogPais cPais = new CatalogPais();
            Pais p = cPais.buscarUnPais(a.Pais_persona.Id_pais);
            ddPais.SelectedValue = p.Id_pais + "";
            txtFechaDeNacimiento.Text = a.Fecha_nacimiento_persona.Date.ToString("dd/M/yyyy");
            txtDireccion.Text = a.Direccion_persona;
            txtTelefono.Text = a.Telefono_persona + "";
            txtPromocion.Text = a.Promocion_alumno + "";
            if (a.Beneficio_alumno == true)
            {
                rbBeneficio.SelectedValue = "1";
            }else
            {
                rbBeneficio.SelectedValue = "0";
            }
            if (a.Sexo_persona == true)
            {
                rbBeneficio.SelectedValue = "1";
            }
            else
            {
                rbBeneficio.SelectedValue = "0";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                
                this.cargarActualizacion();
                nacionalidad.Visible = false;
                fechaNacimiento.Visible = false;
                direccion.Visible = false;
                telefono.Visible = false;
                promocion.Visible = false;
            }
            catch
            {
                nacionalidad.InnerText = "";
                fechaNacimiento.InnerText = "";
                direccion.InnerText = "";
                telefono.InnerText = "";
                promocion.InnerText = "";
            }
            this.mostrarActualizacion();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string rut = Session["rutAlumno"].ToString();
            CatalogAlumno cAlumno = new CatalogAlumno();
            bool sexo, beneficio;

            if (this.rbSexo.SelectedValue == "0")
                sexo = true;
            else
                sexo = false;

            if (this.rbBeneficio.SelectedValue == "0")
                beneficio = true;
            else
                beneficio = false;

            Alumno a = new Alumno();
            Pais p = new Pais();
            a.Pais_persona = p;

            try
            {
                a.Rut_persona = rut;
                a.Pais_persona.Id_pais = int.Parse(this.ddPais.SelectedValue);
                a.Fecha_nacimiento_persona = DateTime.Parse(this.txtFechaDeNacimiento.Text);
                a.Direccion_persona = this.txtDireccion.Text;
                a.Telefono_persona = int.Parse(this.txtTelefono.Text);
                a.Sexo_persona = sexo;
                a.Promocion_alumno = int.Parse(this.txtPromocion.Text);
                a.Beneficio_alumno = beneficio;
            }
            catch
            { }
            try
            {
                cAlumno.actualizarAlumnoEnAlumno(a);
                Response.Redirect("Principal.aspx");
            }
            catch
            {
                Response.Write("<script>window.alert('No fue posible guardar los cambios');</script>");
            }
        }
    }
}