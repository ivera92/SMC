using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Project;

namespace CapaDePresentacion
{
    public partial class Evaluacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogAsignatura ca = new CatalogAsignatura();
            List<Asignatura> la = ca.mostrarAsignaturas();
            if (!Page.IsPostBack)
            {
                this.fecha.InnerText = DateTime.Now.ToString("dd/MM/yyyy");
                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Id_asignatura";
                this.ddAsignatura.DataSource = la;

                this.DataBind();//enlaza los datos a un dropdownlist      
            }
        } 

        protected void btnCrear_Click1(object sender, EventArgs e)
        {
            // Creamos el documento con el tamaño de página tradicional
            Document pdfDoc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            // Creamos la imagen y le ajustamos el tamaño
            Image imagen = Image.GetInstance("C:/Users/Iván/Desktop/Tesis/SMC/SistemaMedicionCalidad/CapaDePresentacion/imagenes/logo.jpg");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            float percentage = 0.0f;
            percentage = 100 / imagen.Width;
            imagen.ScalePercent(percentage*75);

            // Insertamos la imagen en el documento
            pdfDoc.Add(imagen);
            Paragraph p = new Paragraph(this.txtNombre.Text);
            p.Add(this.ddAsignatura.SelectedValue);
            p.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(p);
            pdfDoc.Add(Chunk.NEWLINE);
            pdfDoc.Add(new Paragraph(this.nombreAlumno.InnerText));
            pdfDoc.Add(Chunk.NEWLINE);
            Paragraph p2 = new Paragraph(this.fecha.InnerText + "");
            p2.Alignment = Element.ALIGN_RIGHT;
            pdfDoc.Add(p2);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" +
                                           "filename=sample.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}