﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class AdministrarAsignaturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogEscuela cescuela = new CatalogEscuela();
            List<Escuela> escuelas = cescuela.mostrarEscuelas();
            CatalogDocente cdocente = new CatalogDocente();
            List<Docente> ldocentes = cdocente.mostrarDocentesPA();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddEscuela.DataTextField = "Nombre_escuela";
                this.ddEscuela.DataValueField = "Id_escuela";
                this.ddEscuela.DataSource = escuelas;

                this.ddDocente.DataTextField = "Nombre_docente";
                this.ddDocente.DataValueField = "Rut_Docente";
                this.ddDocente.DataSource = ldocentes;

                this.editar.Visible = false;
                this.txtID.Visible = false;
                this.mostrar();
            }
        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id_asignatura = HttpUtility.HtmlDecode((string)this.gvAsignatura.Rows[e.RowIndex].Cells[1].Text);
            CatalogAsignatura ca = new CatalogAsignatura();
            try
            {
                ca.eliminarAsignatura(int.Parse(id_asignatura));
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
            this.administrar.Visible = false;
            string id_asignatura = HttpUtility.HtmlDecode((string)this.gvAsignatura.Rows[e.NewEditIndex].Cells[1].Text);
            this.txtID.Text = id_asignatura;
            this.editar.Visible = true;
            CatalogAsignatura ca = new CatalogAsignatura();
            Asignatura a= ca.buscarAsignatura(int.Parse(id_asignatura));
            this.ddEscuela.SelectedIndex = a.Escuela_asignatura.Id_escuela-1;
            this.ddDocente.SelectedValue = a.Docente_asignatura.Rut_docente;
            this.txtNombre.Text = a.Nombre_asignatura;
            this.txtAno.Text = a.Ano_asignatura +"";
            if (a.Duracion_asignatura == true)
            {
                this.duracion.SelectedIndex = 0;
            }
            else
            {
                this.duracion.SelectedIndex = 1;
            }
        }

        public void mostrar()
        {
            this.gvAsignatura.Visible = true;
            CatalogAsignatura ca = new CatalogAsignatura();
            List<Asignatura> la = new List<Asignatura>();
            la= ca.mostrarAsignaturas();
            this.gvAsignatura.DataSource = la;
            this.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CatalogAsignatura ca = new CatalogAsignatura();
            bool duracion;
            if (this.duracion.Text == "Semestral")
            {
                duracion = true;
            }
            else
                duracion = false;

            Asignatura a = new Asignatura();
            Escuela es = new Escuela();
            Docente d = new Docente();
            a.Escuela_asignatura = es;
            a.Docente_asignatura = d;

            a.Escuela_asignatura.Id_escuela = int.Parse(this.ddEscuela.SelectedValue);
            a.Docente_asignatura.Rut_docente = this.ddDocente.SelectedValue;
            a.Nombre_asignatura = this.txtNombre.Text;
            a.Ano_asignatura = int.Parse(this.txtAno.Text);
            a.Duracion_asignatura = duracion;
            a.Id_asignatura = int.Parse(txtID.Text);
            try
            {
                ca.editarAsignaturaPA(a);
                this.editar.Visible = false;
                Response.Write("<script>window.alert('Cambios guardados satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('No fue posible guardar los cambios');</script>");
            }     
        }
    }
}