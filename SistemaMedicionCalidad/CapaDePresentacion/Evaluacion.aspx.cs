using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Project;
using Project.CapaDeDatos;
using System.Web;

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
                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Id_asignatura";
                this.ddAsignatura.DataSource = la;

                this.DataBind();//enlaza los datos a un dropdownlist      
            }
        }
        public void pdf2()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "SELECT nombre_tipo_pregunta, NOMBRE_RESPUESTA, nombre_pregunta FROM [ASIGNATURA-COMPETENCIA] inner join asignatura on [asignatura-competencia].id_asignatura = asignatura.id_asignatura inner join competencia on [asignatura-competencia].id_competencia = competencia.id_competencia inner join pregunta on competencia.id_competencia = pregunta.id_competencia_pregunta inner join tipo_pregunta on pregunta.id_tipo_pregunta_pregunta = tipo_pregunta.id_tipo_pregunta inner join respuesta on id_pregunta_respuesta=id_pregunta where asignatura.id_asignatura ='" + this.ddAsignatura.SelectedValue + "'";

            bd.CreateCommand(sql);
            DbDataReader result = bd.Query();
            int pVez = 0;
            string s = "";
            
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=sample.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            
            // Creamos el documento con el tamaño de página tradicional
            Document pdfDoc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            // Creamos la imagen y le ajustamos el tamaño
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance("C:/Users/Iván/Desktop/Tesis/SMC/SistemaMedicionCalidad/CapaDePresentacion/imagenes/logo.jpg");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_CENTER;
            float percentage = 0.0f;
            percentage = 100 / imagen.Width;
            imagen.ScalePercent(percentage*75);

            // Insertamos la imagen en el documento
            pdfDoc.Add(imagen);


            Paragraph p2 = new Paragraph(this.txtNombre.Text+" - "+ this.ddAsignatura.SelectedItem.Text+"\n");
            p2.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(p2);
            Paragraph p = new Paragraph(this.nombreAlumno.InnerText+"\n");
            p.Add(this.rut.InnerText + "\n");
            p.Add(this.fecha.InnerText + "\n");
            pdfDoc.Add(p);


            int numPregunta = 1;
            while (result.Read())
            {
                Paragraph pp = new Paragraph();
                Label l = new Label();
                l.Text = result.GetString(2);
                //Si es la primera pregunta
                if (pVez == 0)
                {
                    pp.Add(new Paragraph(" "));
                    pVez++;
                    pp.Add(numPregunta+" ");
                    pp.Add(l.Text+"\n");
                    s = l.Text;
                    pp.Add(new Paragraph(" "));
                    numPregunta = numPregunta + 1;
                }
                //Si cambio la pregunta
                else if (s != l.Text)
                {
                    pp.Add(new Paragraph(" "));
                    pp.Add(numPregunta + " ");
                    pp.Add(l.Text+"\n");
                    pp.Add(new Paragraph(" "));
                    numPregunta = numPregunta + 1;
                }
                if (result.GetString(0) == "Seleccion multiple")
                {
                    pp.Add("O "+result.GetString(1));
                }

                else if (result.GetString(0) == "Casillas de verificacion")
                {
                    pp.Add("[] "+result.GetString(1)+"\n");
                    while (result.GetString(0) == "Casillas de verificacion" && result.Read())
                    {                    
                        pp.Add("[] "+result.GetString(1)+"\n");
                    }
                }
                pdfDoc.Add(pp);
                s = l.Text;
            }

            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void btnCrear_Click1(object sender, EventArgs e)
        {
            this.pdf2();
        }

        public void crearRadioButtons()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "SELECT nombre_tipo_pregunta, NOMBRE_RESPUESTA, nombre_pregunta FROM [ASIGNATURA-COMPETENCIA] inner join asignatura on [asignatura-competencia].id_asignatura = asignatura.id_asignatura inner join competencia on [asignatura-competencia].id_competencia = competencia.id_competencia inner join pregunta on competencia.id_competencia = pregunta.id_competencia_pregunta inner join tipo_pregunta on pregunta.id_tipo_pregunta_pregunta = tipo_pregunta.id_tipo_pregunta inner join respuesta on id_pregunta_respuesta=id_pregunta where asignatura.id_asignatura ='" + this.ddAsignatura.SelectedValue+"'";
        
            bd.CreateCommand(sql);
            DbDataReader result = bd.Query();
            int pVez = 0;
            string s = "";
            while (result.Read())
            {
                Label l = new Label();
                l.Text = result.GetString(2);
                //Si es la primera pregunta
                if (pVez == 0)
                {
                    pVez++;
                    this.Panel1.Controls.Add(l);
                    this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                    s = l.Text;
                    
                }
                //Si cambio la pregunta
                if (s!= l.Text)
                {
                    l.Text = result.GetString(2);
                    this.Panel1.Controls.Add(l);
                    this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                }
                if (result.GetString(0) == "Seleccion multiple")
                {
                    RadioButton radio = new RadioButton();
                    radio.Text = result.GetString(1);
                    this.Panel1.Controls.Add(radio);

                }

                else if(result.GetString(0) == "Casillas de verificacion")
                {
                    RadioButtonList rbl = new RadioButtonList();
                    rbl.Items.Add(result.GetString(1));
                    this.Panel1.Controls.Add(rbl);
                    while (result.GetString(0) == "Casillas de verificacion" && result.Read())
                    {
                        rbl.Items.Add(result.GetString(1));
                        this.Panel1.Controls.Add(rbl);
                    }
                }
                this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                s = l.Text;

            }
            result.Close();
            bd.Close();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.crearRadioButtons();
        }
    }
}