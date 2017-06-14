using System;
using System.Collections.Generic;
using System.Web.UI;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class CrearDocente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutAdmin"].ToString();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }

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

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogDocente cDocente = new CatalogDocente();
                bool disponibilidad;

                if (this.rbDisponibilidad.Text == "0")
                    disponibilidad = true;
                else
                    disponibilidad = false;

                Docente d = new Docente();
                d.Rut_persona = this.txtRut.Text;
                d.Nombre_persona = this.txtNombre.Text.Trim();
                d.Correo_persona = this.txtCorreo.Text.Trim();
                d.Contrato_docente = disponibilidad;

                cDocente.insertarDocente(d);
                if (ddAsignatura.SelectedValue != "0")
                {
                    DateTime fechaHoy = DateTime.Now;
                    CatalogImparte cImparte = new CatalogImparte();
                    CatalogAsignatura cAsignatura = new CatalogAsignatura();
                    Imparte i = new Imparte(d, cAsignatura.buscarAsignatura(ddAsignatura.SelectedValue), fechaHoy.Year + "");
                    if (cImparte.verificarExistenciaImparte(i) == 0)
                    {
                        cImparte.insertarAD(i);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Docente creado y asignatura asignada satisfactoriamente');window.location='CrearDocente.aspx';</script>'");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Ya existe registro entre docente y asignatura en este año');window.location='CrearAlumno.aspx';</script>'");
                    }              
                }
                }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Docente ya existe en los registros');window.location='AdministrarDocentes.aspx';</script>'");
            }
        }
    }
}