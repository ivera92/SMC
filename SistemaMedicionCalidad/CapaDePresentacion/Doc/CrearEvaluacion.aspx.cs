using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Project;
using System.Web;
using System.IO;

namespace CapaDePresentacion.Doc
{
    public partial class CrearEvaluacion : System.Web.UI.Page
    {
        private static string ids_preguntas;
        protected void Page_Load(object sender, EventArgs e)
        {
            string rut = Session["rutDocente"].ToString();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignatura = cAsignatura.listarAsignaturasDocente(rut);
            divGV.Visible = false;
            if (!Page.IsPostBack)
            {
                this.fechaEvaluacion.InnerText = DateTime.Today.ToString("d");
                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Cod_asignatura";
                this.ddAsignatura.DataSource = lAsignatura;
                this.DataBind();//enlaza los datos a un dropdownlist  
            }
        }
        public void pdf()
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            DbDataReader result= cEvaluacion.mostrarPyRA(ddAsignatura.SelectedValue); 

            if (ddTipoEvaluacion.SelectedValue == "1")
            {
                result = cEvaluacion.mostrarPyRA(ddAsignatura.SelectedValue);
            }
            else if (ddTipoEvaluacion.SelectedValue == "2")
            {
                result = cEvaluacion.generarPruebaAleatoria(ddAsignatura.SelectedValue);
            }
            else if (ddTipoEvaluacion.SelectedValue == "4")
            {
                result = cEvaluacion.mostrarPyRSeleccionadas(ids_preguntas); //Trae las Preguntas y respuestas asociadas a la lista de preguntas enviadas  
            } 
                  
            string s = "";

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=Evaluacion.pdf");
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
            Paragraph p = new Paragraph(this.nombreAlumno.InnerText + "\n");
            p.Add(this.rut.InnerText + "\n");
            p.Add(this.fecha.InnerText + "\n");
            pdfDoc.Add(p);

            int numPregunta = 1;
            while (result.Read())
            {
                Paragraph pp = new Paragraph();
                Label l = new Label();
                l.Text = result.GetString(2);       
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
                        if (result.GetString(3) != null && result.GetString(3) != "ImagenesPreguntas/")
                        {
                            //OBtiene la ruta del dominio y la base de la ubicacion del archivo                            
                            string ruta2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ImagenesPreguntas\" + result.GetString(3));
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
                    catch{}
                    numPregunta = numPregunta + 1;
                }
                //Dependiendo del tipo de pregunta agrega
                if (result.GetString(0) == "Seleccion multiple")
                {
                    PdfPCell pc2 = new PdfPCell(new Paragraph("O " + result.GetString(1)));
                    pc2.BorderColor = BaseColor.WHITE;
                    tabla.AddCell(pc2);
                }

                else if (result.GetString(0) == "Casillas de verificacion")
                {
                    PdfPCell pc2 = new PdfPCell(new Paragraph("[] " + result.GetString(1) + "\n"));
                    pc2.BorderColor = BaseColor.WHITE;
                    tabla.AddCell(pc2);
                }
                else if (result.GetString(0) == "Verdadero o falso")
                {
                    PdfPCell pc2 = new PdfPCell(new Paragraph("O " + result.GetString(1)));
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
            CatalogEvaluacion ce = new CatalogEvaluacion();
            Evaluacion ev = new Evaluacion();
            Asignatura a = new Asignatura();
            ev.Asignatura_evaluacion = a;

            ev.Fecha_evaluacion = DateTime.Parse(this.fechaEvaluacion.InnerText);
            ev.Asignatura_evaluacion.Cod_asignatura = this.ddAsignatura.SelectedValue;
            ev.Nombre_evaluacion = this.txtNombre.Text;

            
                if (ce.verificarExistencia(ddAsignatura.SelectedValue) > 0)
                {
                    Response.Write("<script>window.alert('La evaluacion asociada a esta asignatura ya fue creada anteriormente');</script>");
                    this.pdf();
                }
                else
                {
                    ce.insertarEvaluacion(ev);
                    Response.Write("<script>window.alert('Evaluacion creada satisfactoriamente');</script>");
                    this.pdf();
                }
            ids_preguntas = "";
        }

        public string lSeleccionadas()
        {
            foreach (GridViewRow row in gvPreguntas.Rows)
            {
                CheckBox check = row.FindControl("cbSeleccionado") as CheckBox;

                if (check.Checked)
                {
                    ids_preguntas += row.Cells[1].Text + " , ";
                }
            }            
            return ids_preguntas;
        }        

        protected void ddTipoEvaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddTipoEvaluacion.SelectedValue == "3")
            {

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