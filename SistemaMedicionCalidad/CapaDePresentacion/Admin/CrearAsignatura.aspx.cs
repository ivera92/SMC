using System;
using System.Collections.Generic;
using System.Web.UI;
using Project;
using Project.CapaDeNegocios;

namespace CapaDePresentacion
{
    public partial class CrearAsignatura : System.Web.UI.Page
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
            CatalogEscuela cEscuela = new CatalogEscuela();
            List<Escuela> lEscuelas = cEscuela.listarEscuelas();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddEscuela.DataTextField = "Nombre_escuela";
                this.ddEscuela.DataValueField = "Id_escuela";
                this.ddEscuela.DataSource = lEscuelas;

                this.DataBind();//enlaza los datos a un dropdownlist   
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (ddEscuela.SelectedValue != "0")
            {
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                CatalogEscuela cEscuela = new CatalogEscuela();
                bool duracion;
                if (this.rbDuracion.SelectedValue == "0")
                    duracion = true;
                else
                    duracion = false;

                Asignatura a = new Asignatura();

                a.Cod_asignatura = this.txtCodigo.Text.ToUpper().Trim();
                a.Escuela_asignatura = cEscuela.buscarUnaEscuela(int.Parse(this.ddEscuela.SelectedValue));
                a.Nombre_asignatura = this.txtNombre.Text.Trim();
                a.Duracion_asignatura = duracion;
                try
                {
                    cAsignatura.insertarAsignatura(a);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Asignatura creada satisfactoriamente');window.location='CrearAsignatura.aspx';</script>'");
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Codigo de asignatura ya existe en los registros, verifique en administrar asignaturas');window.location='AdministrarAsignaturas.aspx';</script>'");
                }
            }
            else
            {
                Response.Write("<script>alert('Seleccione una Escuela');</script>");
            }
        }
    }
}