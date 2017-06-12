﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;

namespace CapaDePresentacion.Admin
{
    public partial class InscribirRamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutAdmin"].ToString();
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                List<Asignatura> lAsignatura = cAsignatura.listarAsignaturas();

                if (!Page.IsPostBack) //para ver si cargo por primera vez
                {

                    this.ddAsignatura.DataTextField = "Nombre_asignatura";
                    this.ddAsignatura.DataValueField = "Cod_asignatura";
                    this.ddAsignatura.DataSource = lAsignatura;

                    this.DataBind();//enlaza los datos a un dropdownlist                
                }
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }

        protected void btnInscribir_Click(object sender, EventArgs e)
        {
            CatalogCursa cCursa = new CatalogCursa();
            Cursa c= new Cursa();
            Asignatura a = new Asignatura();
            Alumno al = new Alumno();
            c.Rut_alumno_aa = al;
            c.Cod_asignatura_aa = a;

            c.Rut_alumno_aa.Rut_persona = txtRut.Text;
            c.Cod_asignatura_aa.Cod_asignatura = ddAsignatura.SelectedValue;
            try
            {
                cCursa.inscribirAsignatura(c);
                Response.Write("<script>window.alert('Asignatura inscrita correctamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Asignatura no pudo ser inscrita, o ya se encuentra inscrita');</script>");
            }
        }
    }
}