﻿using System;
using System.Web.Security;

namespace CapaDePresentacion
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
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

            if (alumno != "" || docente != "")
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }
    }
}
