﻿using System;
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
    public partial class CrearAlumnoD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutDocente"].ToString();
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                List<Asignatura> lAsignatura = cAsignatura.listarAsignaturasDocente(rut);
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
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }  

            divCrearManual.Visible = false;
            divCrearExcel.Visible = false;

            
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Alumno creado satisfactoriamente');window.location='CrearAlumnoD.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Ya existe registro asociado al rut');window.location='CrearAlumnoD.aspx';</script>'");
            }
        }
        protected void ImportExcel()
        {
            //Save the uploaded Excel file.
            string filePath = Server.MapPath("~/Excel/") + Path.GetFileName(FileUpload1.PostedFile.FileName);


            //Save the uploaded Excel file.
            string path = Server.MapPath("~/Excel/");
            FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);

            string extension = Path.GetExtension(FileUpload1.FileName).ToLower();


            //Open the Excel file using ClosedXML.
            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Create a new DataTable.
                DataTable dt = new DataTable();

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {

                    //Use the first row to add columns to DataTable.
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
                        //Add rows to DataTable.
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
                        rut = HttpUtility.HtmlDecode(row.Cells[0].Text).ToUpper().TrimStart('0');
                        nombre = HttpUtility.HtmlDecode(row.Cells[1].Text);
                        email = HttpUtility.HtmlDecode(row.Cells[2].Text);
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Lista de alumnos exportada correctamente');window.location='AdministrarAsignaturasInscritas.aspx';</script>'");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Lista de alumnos exportada con problemas, verifique en administrar alumnos');window.location='AdministrarAsignaturasInscritas.aspx';</script>'");
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
            Response.TransmitFile(Server.MapPath("/Doc/ImagenesDoc/Formato.xlsx"));
            Response.End();
        }
    }
}