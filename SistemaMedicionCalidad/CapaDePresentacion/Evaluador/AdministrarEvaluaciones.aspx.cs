using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Project;
using System.Web;
using System.IO;
using System.Data;

namespace CapaDePresentacion.Evaluador
{
    public partial class AdministrarEvaluaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutEvaluador"].ToString();
                this.mostrar();
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }
        }
        public void mostrar()
        {
            this.gvEvaluaciones.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<Evaluacion> lEvaluacion = cEvaluacion.listarEvaluaciones();
            this.gvEvaluaciones.DataSource = lEvaluacion;
            this.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.gvEvaluaciones.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<Evaluacion> lEvaluacion = cEvaluacion.listarEvaluacionesBusqueda(txtBuscar.Text);
            this.gvEvaluaciones.DataSource = lEvaluacion;
            this.DataBind();
        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string nombre_evaluacion = HttpUtility.HtmlDecode((string)(this.gvEvaluaciones.Rows[e.RowIndex].Cells[2].Text));
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            if (cEvaluacion.verificarExistenciaEvaluacionHPA(nombre_evaluacion) == 0)
            {
                try
                {
                    cEvaluacion.eliminarEvaluacion(nombre_evaluacion);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Evaluacion eliminada satisfactoriamente');window.location='AdministrarEvaluaciones.aspx';</script>'");
                }
                catch { }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Evaluacion no pudo ser eliminada puesto que esta en uso');window.location='AdministrarEvaluaciones.aspx';</script>'");
            }
        }

        protected void gvEvaluaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEvaluaciones.PageIndex = e.NewPageIndex;
            if (txtBuscar.Text != "")
            {
                this.gvEvaluaciones.Visible = true;
                CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                List<Evaluacion> lEvaluacion = cEvaluacion.listarEvaluacionesBusqueda(txtBuscar.Text);
                this.gvEvaluaciones.DataSource = lEvaluacion;
                this.DataBind();
            }
            else
            {
                this.mostrar();
            }
        }

        protected void gvEvaluaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "imgBtnPDF")
            {
                // Recupera el índice de fila almacenado en el
                // CommandArgument propiedad.
                int index = Convert.ToInt32(e.CommandArgument);

                // Recuperar la fila que contiene el botón
                // de la Filas.
                GridViewRow row = gvEvaluaciones.Rows[index];
                string nombre_asignatura = HttpUtility.HtmlDecode(row.Cells[3].Text);
                string nombre_evaluacion = HttpUtility.HtmlDecode(row.Cells[2].Text);
                CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                string preguntas = cEvaluacion.listarPreguntasEvaluacionNombre(nombre_evaluacion);
                this.pdf(preguntas, nombre_evaluacion, nombre_asignatura);
            }
            else if (e.CommandName == "activo")
            {
                // Recupera el índice de fila almacenado en el CommandArgument propiedad.
                int index = Convert.ToInt32(e.CommandArgument);

                // Recuperar la fila que contiene el botón de la Filas.
                GridViewRow row = gvEvaluaciones.Rows[index];
                string nombre_evaluacion = HttpUtility.HtmlDecode(row.Cells[2].Text);
                string estado = HttpUtility.HtmlDecode(row.Cells[4].Text);
                bool estado_nuevo;
                if (estado == "Habilitada")
                {
                    estado_nuevo = false;
                }
                else
                {
                    estado_nuevo = true;
                }
                CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
                cEvaluacion.actualizarEstadoEvaluacion(nombre_evaluacion, estado_nuevo);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Estado de Evaluación cambiado satisfactoriamente');window.location='AdministrarEvaluaciones.aspx';</script>'");
            }
        }

        public void pdf(string ids_preguntas, string nombre_evaluacion, string nombre_asignatura)
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            DataTable dt = cEvaluacion.mostrarPyRSeleccionadas(ids_preguntas);
            string s = "";

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=" + nombre_evaluacion + ".pdf");
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

            Paragraph p2 = new Paragraph(nombre_evaluacion + " - " + nombre_asignatura + "\n");     //Agrega el nombre de la prueba y el de la asignatura
            p2.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(p2);
            Paragraph p = new Paragraph("Nombre alumno:\n");
            p.Add("Rut:\n");
            p.Add("Fecha:\n");
            pdfDoc.Add(p);

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
    }
}