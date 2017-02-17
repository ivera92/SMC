﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class AdministrarDocentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogProfesion cprofesion = new CatalogProfesion();
            List<Profesion> profesiones = cprofesion.mostrarProfesiones();

            CatalogPais cpais = new CatalogPais();
            List<Pais> lpais = cpais.mostrarPaises();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.profesion.DataTextField = "Nombre_profesion";
                this.profesion.DataValueField = "Id_profesion";
                this.profesion.DataSource = profesiones;

                this.ddPais.DataTextField = "Nombre_pais";
                this.ddPais.DataValueField = "Id_pais";
                this.ddPais.DataSource = lpais;

                this.tablaEditar.Visible = false;

                this.mostrar();
                this.DataBind();
            }
        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string rut_docente = HttpUtility.HtmlDecode((string)this.Gridview1.Rows[e.RowIndex].Cells[2].Text);
            CatalogDocente cdocente = new CatalogDocente();
            try
            {
                cdocente.eliminarDocentePA(rut_docente);
                Response.Write("<script>window.alert('Registro eliminado satisfactoriamente');</script>");
                Thread.Sleep(1500);
                this.mostrar();
            }
            catch
            {
                Response.Write("<script>window.alert('Registro no se a podido eliminar');</script>");
            }

        }

        protected void rowEditing(object sender, GridViewEditEventArgs e)
        {
            this.tablaAdministrar.Visible = false;
            string rut_docente = HttpUtility.HtmlDecode((string)this.Gridview1.Rows[e.NewEditIndex].Cells[2].Text);
            this.profesion.SelectedIndex = 0;
            CatalogDocente cdocente = new CatalogDocente();
            Docente d = cdocente.buscarDocentePA(rut_docente).First();
            
            this.correo.Text = d.Correo_docente;
            this.direccion.Text = d.Direccion_docente;
            if (d.Disponibilidad_docente == true)
            {
                this.disponibilidad.SelectedIndex = 0;
            }
            else
                this.disponibilidad.SelectedIndex = 1;
            this.fechaDeNacimiento.Text = d.Fecha_nacimiento_docente.ToString("d");
            this.ddPais.SelectedValue = d.Pais_docente.Id_pais+"";
            this.nombre.Text = d.Nombre_docente;
            this.profesion.SelectedValue = d.Profesion_docente.Id_profesion+"";
            this.rut.Text = d.Rut_docente + "";
            if (d.Sexo_docente == true)
            {
                this.sexo.SelectedIndex = 0;
            }
            else
                this.sexo.SelectedIndex = 1;
            this.telefono.Text = d.Telefono_docente+"";
            this.tablaEditar.Visible = true;
        }
        public void mostrar()
        {
            this.Gridview1.Visible=true;
            CatalogDocente cdocente = new CatalogDocente();
            List<Docente> ldocente = new List<Docente>();
            ldocente = cdocente.mostrarDocentesPA();
            this.Gridview1.DataSource = ldocente;
            this.DataBind();
        }
        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            this.Gridview1.Visible = true;
            CatalogDocente cdocente = new CatalogDocente();
            List<Docente> ldocente = new List<Docente>();
            ldocente = cdocente.buscarDocentePA(this.tbxbuscar.Text);
            this.Gridview1.DataSource = ldocente;
            this.DataBind();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogDocente cdocente = new CatalogDocente();
            bool sexo, disponibilidad;
            if (this.sexo.Text == "Masculino")
            {
                sexo = true;
            }
            else
                sexo = false;

            if (this.disponibilidad.Text == "Part-Time")
            {
                disponibilidad = true;
            }
            else
                disponibilidad = false;

            Docente d = new Docente();
            Profesion p = new Profesion();
            Pais pa = new Pais();
            d.Profesion_docente = p;
            d.Pais_docente = pa;

            d.Rut_docente = this.rut.Text;
            d.Profesion_docente.Id_profesion = int.Parse(this.profesion.SelectedValue);
            d.Pais_docente.Id_pais = int.Parse(this.ddPais.SelectedValue);
            d.Nombre_docente = this.nombre.Text;
            d.Fecha_nacimiento_docente = DateTime.Parse(this.fechaDeNacimiento.Text);
            d.Direccion_docente = this.direccion.Text;
            d.Telefono_docente = int.Parse(this.telefono.Text);
            d.Sexo_docente = sexo;
            d.Correo_docente = this.correo.Text;
            d.Disponibilidad_docente = disponibilidad;
            try
            {
                cdocente.editarDocentePA(d);
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