using System;
using System.Collections.Generic;
using System.Web.UI;
using Project;
using System.IO;
using System.Data;
using ClosedXML.Excel;
using System.Web.UI.WebControls;
using System.Web;

namespace CapaDePresentacion.Doc
{
    public partial class CrearAlumno : System.Web.UI.Page
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

            divCrearManual.Visible = false;
            divCrearExcel.Visible = false;

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Cod_asignatura";
                this.ddAsignatura.DataSource = lAsignatura;
                this.ddAsignaturaC.DataTextField = "Nombre_asignatura";
                this.ddAsignaturaC.DataValueField = "Cod_asignatura";
                this.ddAsignaturaC.DataSource = lAsignatura;
                this.DataBind();//enlaza los datos a un dropdownlist  
            }
        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogAlumno cAlumno = new CatalogAlumno();
            CatalogCursa cCursa = new CatalogCursa();

            Alumno a = new Alumno(this.txtRut.Text.Trim().ToUpper(), this.txtNombre.Text.Trim(), this.txtCorreo.Text.Trim());
            try
            {
                cAlumno.insertarAlumno(a);
                if (ddAsignatura.SelectedValue != "0")
                {
                    DateTime fechaHoy = DateTime.Now;
                    CatalogAsignatura cAsignatura = new CatalogAsignatura();
                    Cursa c = new Cursa(a, cAsignatura.buscarAsignatura(ddAsignatura.SelectedValue), fechaHoy.Year + "");
                    if (cCursa.verificarExistenciaCursa(c) == 0)
                    {
                        cCursa.inscribirAsignatura(c);
                    }
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Alumno creado satisfactoriamente');window.location='CrearAlumno.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Ya existe registro asociado al rut');window.location='CrearAlumno.aspx';</script>'");
            }
        }
        protected void ImportExcel()
        {
            //Se guarda la ruta y el nombre del arcivo.
            string filePath = Server.MapPath("~/Excel/") + Path.GetFileName(FileUpload1.PostedFile.FileName);


            //Se guarda la carpeta en donde se guardara y se guarda el Excel.
            string path = Server.MapPath("~/Excel/");
            FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);

            string extension = Path.GetExtension(FileUpload1.FileName).ToLower();


            //Se abre el archivo Excel.
            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                //Se lee la primera hoja del archivo Excel.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Se crea un DataTable.
                DataTable dt = new DataTable();

                //Se recorren las filas de la hoja de calculo
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Al ser la primera fila se asume que seran los titulos de las columnas, por tanto se agregan al DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Se agregan las filas al DataTable.
                        dt.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                    gvAlumnos.DataSource = dt;
                    gvAlumnos.DataBind();
                }
            }
        }
        protected void btnMostrar_Click1(object sender, EventArgs e)
        {
            divCrearExcel.Visible = true;
            btnImportar.Visible = true;
            try
            {
                this.ImportExcel();
            }
            catch
            {
                Response.Write("<script>alert('Formato de archivo no coincide, o plantilla no tiene las columnas solicitadas');</script>");
            }
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            DateTime fechaHoy = DateTime.Now;
            CatalogAlumno cAlumno = new CatalogAlumno();
            CatalogCursa cCursa = new CatalogCursa();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            try
            {
                foreach (GridViewRow row in gvAlumnos.Rows)
                {
                    string rut = "";
                    string nombre = "";
                    string email = "";
                    Alumno a = new Alumno();
                    Cursa c = new Cursa();
                    try
                    {
                        //HttpUtility.HtmlDecode Convierte una cadena que ha sido codificada en HTML para la transmisión HTTP en una cadena decodificada.
                        //TrimStart('0') elimina los 0 al inicio del rut, puesto que los rut vienen del sistema con 0's al principio
                        rut = HttpUtility.HtmlDecode(row.Cells[0].Text).ToUpper().TrimStart('0');
                        nombre = HttpUtility.HtmlDecode(row.Cells[1].Text.Trim());
                        email = HttpUtility.HtmlDecode(row.Cells[2].Text.Trim());
                        a.Rut_persona = rut;
                        a.Nombre_persona = nombre;
                        a.Correo_persona = email;
                    }
                    catch { }

                    try
                    {
                        cAlumno.insertarAlumno(a);
                    }
                    catch { }

                    try
                    {
                        c.Rut_alumno_aa = cAlumno.buscarAlumnoPorRut(rut);
                        c.Cod_asignatura_aa = cAsignatura.buscarAsignatura(ddAsignaturaC.SelectedValue);
                        c.Ano_asignatura = fechaHoy.Year + "";
                        if (cCursa.verificarExistenciaCursa(c) == 0)
                        {
                            cCursa.inscribirAsignatura(c);
                        }
                    }

                    catch { }
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Lista de alumnos exportada correctamente');window.location='AdministrarAlumnos.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Lista de alumnos exportada con problemas, verifique en administrar alumnos');window.location='AdministrarAlumnos.aspx';</script>'");
            }
        }

        protected void btnManual_Click(object sender, EventArgs e)
        {
            divOpcion.Visible = false;
            divCrearManual.Visible = true;
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            divOpcion.Visible = false;
            divCrearExcel.Visible = true;
            btnImportar.Visible = false;
        }

        protected void imgExcelBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Formato.xlsx");
            Response.TransmitFile(Server.MapPath("/Admin/ImagenesAdmin/Formato.xlsx"));
            Response.End();
        }
    }
}