using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Project;
using System.Web;
using System.IO;
using System.Data;

namespace CapaDePresentacion.Admin
{
    public partial class CrearEvaluacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutAdmin"].ToString();
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                List<Asignatura> lAsignatura = cAsignatura.listarAsignaturas();

                if (!Page.IsPostBack)
                {
                    divGV.Visible = false;
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
        public void pdf(string ids_preguntas)
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            DataTable dt = cEvaluacion.mostrarPyRSeleccionadas(ids_preguntas);
            string s = "";

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=" + txtNombre.Text + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            // Creamos el documento con el tamaño de página tradicional
            Document pdfDoc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            // Creamos la imagen y le ajustamos el tamaño (Logo de la universidad)
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"imagenes\logo.jpg");
            ruta = Path.GetFullPath(ruta);
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(ruta);
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            float percentage = 0.0f;
            percentage = 100 / imagen.Width;
            imagen.ScalePercent(percentage * 75);

            // Insertamos la imagen en el documento
            pdfDoc.Add(imagen);

            Paragraph p2 = new Paragraph(this.txtNombre.Text + " - " + this.ddAsignatura.SelectedItem.Text + "\n");     //Agrega el nombre de la prueba y el de la asignatura
            p2.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(p2);
            Paragraph p = new Paragraph("Nombre Alumno:  " + "\n");
            p.Add("Rut Alumno: " + "\n");
            p.Add("Fecha de Evaluación" + "\n");
            PdfPTable ptabla = new PdfPTable(1);
            PdfPCell pcell = new PdfPCell(p);
            ptabla.AddCell(p);
            pdfDoc.Add(ptabla); 

            int numPregunta = 1;
            foreach (DataRow result in dt.Rows)
            {
                Paragraph pp = new Paragraph();
                Label l = new Label();
                l.Text = result[2].ToString();
                PdfPTable tabla = new PdfPTable(1);

                //Si cambio la pregunta
                if (s != l.Text)
                {
                    PdfPCell pc1 = new PdfPCell(new Paragraph(" "));
                    PdfPCell pc2 = new PdfPCell(new Phrase(numPregunta + ") " + l.Text + "\n"));
                    PdfPCell pc3 = new PdfPCell(new Paragraph(" "));

                    //De dejan los bordes en blanco para que no se vean, la tabla es solo para dar orden
                    pc1.BorderColor = BaseColor.WHITE;
                    pc2.BorderColor = BaseColor.WHITE;
                    pc3.BorderColor = BaseColor.WHITE;
                    tabla.AddCell(pc1);
                    tabla.AddCell(pc2);
                    tabla.AddCell(pc3);

                    try
                    {
                        //Si existe una ruta de imagen
                        if (result[3].ToString() != null && result[3].ToString() != "")
                        {
                            //OBtiene la ruta del dominio y la base de la ubicacion del archivo                            
                            string ruta2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ImagenesPreguntas\" + result[3].ToString());
                            ruta2 = Path.GetFullPath(ruta2);
                            // Creamos la imagen y le ajustamos el tamaño
                            iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance(ruta2);
                            imagen2.ScaleAbsolute(200f, 200f);

                            // Insertamos la imagen en el documento
                            PdfPCell imageCell = new PdfPCell(imagen2);
                            imageCell.BorderColor = BaseColor.WHITE;
                            imageCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            tabla.AddCell(imageCell);
                        }
                    }
                    catch { }
                    numPregunta = numPregunta + 1;
                }
                //Dependiendo del tipo de pregunta agrega
                if (result[0].ToString() == "Seleccion multiple")
                {
                    PdfPCell pc2 = new PdfPCell(new Paragraph("O " + result[1].ToString()));
                    pc2.BorderColor = BaseColor.WHITE;
                    tabla.AddCell(pc2);
                }

                else if (result[0].ToString() == "Casillas de verificacion")
                {
                    PdfPCell pc2 = new PdfPCell(new Paragraph("[] " + result[1].ToString() + "\n"));
                    pc2.BorderColor = BaseColor.WHITE;
                    tabla.AddCell(pc2);
                }
                else if (result[0].ToString() == "Verdadero o falso")
                {
                    PdfPCell pc2 = new PdfPCell(new Paragraph("O " + result[1].ToString()));
                    pc2.BorderColor = BaseColor.WHITE;
                    tabla.AddCell(pc2);
                }
                pp.Add(tabla);
                pdfDoc.Add(pp);
                s = l.Text;
            }
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void btnCrear_Click1(object sender, EventArgs e)
        {
            if (ddAsignatura.SelectedValue != "0" && ddTipoEvaluacion.SelectedValue != "0")
            {
                string ids_preguntas = "";
                CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                int existe = cEvaluacion.verificarExistencia(ddAsignatura.SelectedValue, txtNombre.Text, DateTime.Parse(DateTime.Today.ToString("d")));

                if (existe == 0)
                {
                    try
                    {
                        if (ddTipoEvaluacion.SelectedValue == "1")
                        {
                            ids_preguntas = cEvaluacion.mostrarIDsPA(ddAsignatura.SelectedValue);
                        }
                        else if (ddTipoEvaluacion.SelectedValue == "2")
                        {
                            ids_preguntas = cEvaluacion.generarPruebaAleatoria(ddAsignatura.SelectedValue, 15);
                        }
                        else if (ddTipoEvaluacion.SelectedValue == "3")
                        {
                            ids_preguntas = cEvaluacion.generarPruebaAleatoria(ddAsignatura.SelectedValue, 30);
                        }
                        else if (ddTipoEvaluacion.SelectedValue == "4")
                        {
                            ids_preguntas = this.lSeleccionadas(); //Trae las Preguntas y respuestas asociadas a la lista de preguntas enviadas  
                        }

                        Evaluacion ev = new Evaluacion();
                        CatalogAsignatura cAsignatura = new CatalogAsignatura();
                        Asignatura a = cAsignatura.buscarAsignatura(ddAsignatura.SelectedValue);

                        ev.Asignatura_evaluacion = a;
                        ev.Fecha_evaluacion = DateTime.Parse(DateTime.Today.ToString("d"));
                        ev.Nombre_evaluacion = this.txtNombre.Text.ToUpper();
                        ev.Preguntas_evaluacion = ids_preguntas;
                        ev.Porcentaje_exigencia_evaluacion = int.Parse(ddExigencia.SelectedValue);

                        cEvaluacion.insertarEvaluacion(ev);
                        //this.pdf(ids_preguntas);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Evaluacion creada satisfactoriamente');window.location='CrearEvaluacion.aspx';</script>'");
                    }
                    catch
                    {
                        Response.Write("<script>alert('No existe el minimo de preguntas para crear el tipo de evaluacion');</script>");
                    }
                    ids_preguntas = "";
                }
                else
                {
                    Response.Write("<script>alert('El nombre de la evaluacion ya existe, ingrese otro');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Seleccione Asignatura y Tipo de Evaluación antes de crear la Evaluación');</script>");
            }
        }

        public string lSeleccionadas()
        {
            string ids_preguntas = "";
            foreach (GridViewRow row in gvPreguntas.Rows)
            {
                CheckBox check = row.FindControl("cbSeleccionado") as CheckBox;

                if (check.Checked)
                {
                    ids_preguntas += row.Cells[1].Text + ",";
                }
            }
            return ids_preguntas;
        }

        protected void ddTipoEvaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddTipoEvaluacion.SelectedValue == "0" || ddTipoEvaluacion.SelectedValue == "1" || ddTipoEvaluacion.SelectedValue == "2" || ddTipoEvaluacion.SelectedValue == "3")
            {
                divGV.Visible = false;
            }
            else if (ddTipoEvaluacion.SelectedValue == "4")
            {
                CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                List<Pregunta> lPreguntas = cEvaluacion.listarPA(ddAsignatura.SelectedValue);
                this.gvPreguntas.DataSource = lPreguntas;
                this.DataBind();
                this.divGV.Visible = true;
            }
        }
    }
}