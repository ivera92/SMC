﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using Project.CapaDeNegocios;
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
            divCrearManual.Visible = false;
            divCrearExcel.Visible = false;
            CatalogEscuela cEscuela = new CatalogEscuela();
            List<Escuela> lEscuelas = cEscuela.listarEscuelas();

            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
            }
        }
        public void resetearValores()
        {
            this.txtRut.Text="";
            this.txtNombre.Text="";
            this.txtCorreo.Text="";
            this.txtPromocion.Text="";
        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            CatalogAlumno cAlumno = new CatalogAlumno();

            Alumno a = new Alumno();

            a.Rut_persona = this.txtRut.Text.Trim();
            a.Nombre_persona = this.txtNombre.Text.Trim();
            a.Correo_persona = this.txtCorreo.Text.Trim();
            a.Promocion_alumno = int.Parse(this.txtPromocion.Text);
            try
            {
                cAlumno.insertarAlumno(a);
                Response.Write("<script>window.alert('Alumno creado satisfactoriamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Ya existe registro asociado al Rut');</script>");
            }
            this.resetearValores();
        }
        protected void ImportExcel()
        {
            //Save the uploaded Excel file.
            string filePath = Server.MapPath("~/Excel") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(filePath);

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

            }
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
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
                    string asignatura = "";
                    Alumno a = new Alumno();
                    Cursa c = new Cursa();
                    try
                    {
                        rut = HttpUtility.HtmlDecode(row.Cells[0].Text).Substring(2, 10);
                        nombre = HttpUtility.HtmlDecode(row.Cells[1].Text);
                        email = HttpUtility.HtmlDecode(row.Cells[2].Text);
                        asignatura = HttpUtility.HtmlDecode(row.Cells[3].Text);
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
                        c.Cod_asignatura_aa = cAsignatura.buscarAsignaturaNombre(asignatura);
                        cCursa.inscribirAsignatura(c);
                    }

                    catch { }
                }
                Response.Write("<script>window.alert('Lista de alumnos exportada correctamente');</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Lista de alumnos exportada correctamente, verifique en administrar alumnos');</script>");
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
    }
}