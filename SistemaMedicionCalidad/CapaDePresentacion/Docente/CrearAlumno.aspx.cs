using System;
using System.Collections.Generic;
using System.Web.UI;
using Project.CapaDeNegocios;
using Project;

namespace CapaDePresentacion
{
    public partial class CrearAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogEscuela cescuela = new CatalogEscuela();
            List<Escuela> escuelas = cescuela.listarEscuelas();

            CatalogPais cpais = new CatalogPais();
            List<Pais> lpais = cpais.listarPaises();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.escuela.DataTextField = "Nombre_escuela";
                this.escuela.DataValueField = "Id_escuela";
                this.escuela.DataSource = escuelas;

                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lpais;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }
        }
        public void resetearValores()
        {
            this.rut.Text="";
            this.escuela.SelectedIndex=0;
            this.ddPais.SelectedIndex=0;
            this.nombre.Text="";
            this.fechaDeNacimiento.Text="";
            this.direccion.Text="";
            this.telefono.Text="";
            sexo.SelectedIndex=0;
            this.correo.Text="";
            this.promocion.Text="";
            beneficio.SelectedIndex=0;
        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogAlumno alumno = new CatalogAlumno();
            bool sexo, beneficio;
            if (this.sexo.Text == "Masculino")
            {
                sexo = true;
            }
            else
                sexo = false;

            if (this.beneficio.Text == "Si")
            {
                beneficio = true;
            }
            else
                beneficio = false;

            Alumno a = new Alumno();
            Pais p = new Pais();
            Escuela es = new Escuela();
            a.Pais_persona = p;
            a.Escuela_alumno = es;

            a.Rut_persona = this.rut.Text;
            a.Escuela_alumno.Id_escuela = this.escuela.SelectedIndex;
            a.Pais_persona.Id_pais = this.ddPais.SelectedIndex;
            a.Nombre_persona = this.nombre.Text;
            a.Fecha_nacimiento_persona = DateTime.Parse(this.fechaDeNacimiento.Text);
            a.Direccion_persona = this.direccion.Text;
            a.Telefono_persona = int.Parse(this.telefono.Text);
            a.Sexo_persona = sexo;
            a.Correo_persona = this.correo.Text;
            a.Promocion_alumno = int.Parse(this.promocion.Text);
            a.Beneficio_alumno = beneficio;
            try
            {
                alumno.insertarAlumno(a);
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