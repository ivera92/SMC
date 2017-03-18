﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.CapaDeNegocios;
using Project;
using System.Threading;

namespace CapaDePresentacion
{
    public partial class AdministrarAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogEscuela cEscuela = new CatalogEscuela();
            List<Escuela> lEscuelas = cEscuela.listarEscuelas();
            CatalogPais cPais = new CatalogPais();
            List<Pais> lPaises = cPais.listarPaises();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.escuela.DataTextField = "Nombre_escuela";
                this.escuela.DataValueField = "Id_escuela";
                this.escuela.DataSource = lEscuelas;

                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lPaises;

                this.divEditar.Visible = false;
                this.mostrar();
            }
        }

        public void mostrar()
        {
            this.GridView1.Visible = true;
            CatalogAlumno cAlumno = new CatalogAlumno();
            List<Alumno> lAlumno = cAlumno.listarAlumnos();
            this.GridView1.DataSource = lAlumno;
            this.DataBind();
        }

        protected void rowDeletingEvent(object sender, GridViewDeleteEventArgs e)
        {
            string rut_alumno = HttpUtility.HtmlDecode((string)this.GridView1.Rows[e.RowIndex].Cells[2].Text);
            CatalogAlumno cAlumno = new CatalogAlumno();
            try
            {
                cAlumno.eliminarAlumno(rut_alumno);
                Response.Write("<script>window.alert('Registro eliminado satisfactoriamente');</script>");
                Thread.Sleep(1500);
                this.mostrar();
            }
            catch
            {
                Response.Write("<script>window.alert('Registro no a podido ser eliminado');</script>");
            }
            
        }

        protected void rowEditingEvent(object sender, GridViewEditEventArgs e)
        {
            this.divMostrar.Visible = false;
            string rut_alumno = HttpUtility.HtmlDecode((string)this.GridView1.Rows[e.NewEditIndex].Cells[2].Text);
            CatalogAlumno cAlumno = new CatalogAlumno();
            Alumno a = cAlumno.buscarAlumnoPorRut(rut_alumno);
            this.escuela.SelectedIndex = a.Escuela_alumno.Id_escuela;
            this.nombre.Text = a.Nombre_persona;
            this.rut.Text = a.Rut_persona;
            this.fechaDeNacimiento.Text = a.Fecha_nacimiento_persona.ToString("d");
            this.direccion.Text = a.Direccion_persona;
            this.telefono.Text = a.Telefono_persona+"";
            this.ddPais.SelectedIndex = a.Pais_persona.Id_pais;
            this.correo.Text = a.Correo_persona;
            this.promocion.Text = a.Promocion_alumno + "";

            if (a.Beneficio_alumno == true)
                this.beneficio.SelectedIndex = 0;
            else
                this.beneficio.SelectedIndex = 1;

            if (a.Sexo_persona == true)
                this.sexo.SelectedIndex = 0;
            else
                this.sexo.SelectedIndex = 1;

            this.divEditar.Visible = true;
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            this.GridView1.Visible = true;
            CatalogAlumno cAlumno = new CatalogAlumno();
            List<Alumno> lAlumno = cAlumno.buscarAlumno(this.tbxbuscar.Text);

            this.GridView1.DataSource = lAlumno;
            this.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogAlumno cAlumno = new CatalogAlumno();
            bool sexo, beneficio;

            if (this.sexo.Text == "Masculino")
                sexo = true;
            else
                sexo = false;

            if (this.beneficio.Text == "Si")
                beneficio = true;
            else
                beneficio = false;

            Alumno a = new Alumno();
            Escuela es = new Escuela();
            Pais p = new Pais();
            a.Escuela_alumno = es;
            a.Pais_persona = p;

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
                cAlumno.actualizarAlumno(a);
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