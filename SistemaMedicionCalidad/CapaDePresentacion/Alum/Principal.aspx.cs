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

            this.ocultarActualizacion();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {           
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

            nombreAlumno.InnerText = a.Nombre_persona;
            correo.InnerText = a.Correo_persona;

            try
            {
                promocion.InnerText = a.Promocion_alumno + "";
            }
            catch
            {
                promocion.InnerText = "";
            }
        }
        public void cargarActualizacion()
        {
            string rut = Session["rutAlumno"].ToString();
            CatalogAlumno cAlumno = new CatalogAlumno();
            Alumno a = cAlumno.buscarAlumnoPorRut(rut);
            txtPromocion.Text = a.Promocion_alumno + "";
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

            Alumno a = new Alumno();

            try
            {
                a.Rut_persona = rut;
                a.Promocion_alumno = int.Parse(this.txtPromocion.Text);
            }
            catch
            { }
            try
            {
                cAlumno.actualizarAlumno(a);
                Response.Redirect("Principal.aspx");
            }
            catch
            {
                Response.Write("<script>window.alert('No fue posible guardar los cambios');</script>");
            }
        }
    }
}