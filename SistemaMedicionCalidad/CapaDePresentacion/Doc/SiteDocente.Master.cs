﻿using System;
using System.Web.Security;

namespace CapaDePresentacion
{
    public partial class SiteDocente : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verifica que la persona que ingreso corresponde a un docente
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                string alumno, docente, admin;
                try
                {
                    admin = Session["rutAdmin"].ToString();
                }
                catch
                {
                    admin = "";
                }
                try
                {
                    alumno = Session["rutAlumno"].ToString();
                }
                catch
                {
                    alumno = "";
                }
                try
                {
                    docente = Session["rutDocente"].ToString();
                }
                catch
                {
                    docente = "";
                }

                if (alumno != "" || admin != "")
                {
                    Response.Redirect("../CheqLogin.aspx");
                }
            }
        }
    }
}