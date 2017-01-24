﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Project;
using Project.CapaDeDatos;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using System.Web;
using iTextSharp.text.html.simpleparser;

namespace CapaDePresentacion
{
    public partial class Evaluacion : System.Web.UI.Page
    {
        private List<string> llabel, ltextbox;
        protected void Page_Load(object sender, EventArgs e)
        {
            llabel = new List<string>();
            ltextbox = new List<string>();

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
            Paragraph p = new Paragraph(this.txtNombre.Text);
            pdfDoc.Add(Chunk.NEWLINE);
            p.Add(this.ddAsignatura.SelectedValue);
            p.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(Chunk.NEWLINE);
            pdfDoc.Add(p);
            pdfDoc.Add(Chunk.NEWLINE);
            pdfDoc.Add(new Paragraph(this.nombreAlumno.InnerText));
            pdfDoc.Add(Chunk.NEWLINE);
            Paragraph p2 = new Paragraph(this.fecha.InnerText + "");
            p2.Alignment = Element.ALIGN_RIGHT;
            pdfDoc.Add(p2);

            int numPregunta = 1;
            while (result.Read())
            {
                Paragraph pp = new Paragraph();
                Label l = new Label();
                l.Text = result.GetString(2);
                //Si es la primera pregunta
                if (pVez == 0)
                {
                    pVez++;
                    pp.Add(numPregunta+"");
                    pp.Add(l.Text);
                    pdfDoc.Add(Chunk.NEWLINE);
                }
                //Si cambio la pregunta
                if (s != l.Text)
                {
                    l.Text = result.GetString(2);
                    pp.Add(numPregunta + "");
                    pp.Add(l.Text);
                    pdfDoc.Add(Chunk.NEWLINE);
                }
                if (result.GetString(0) == "Seleccion multiple")
                {
                    pp.Add(result.GetString(1));
                }

                else if (result.GetString(0) == "Casillas de verificacion")
                {
                    pp.Add(result.GetString(1));
                    pdfDoc.Add(Chunk.NEWLINE);
                    while (result.GetString(0) == "Casillas de verificacion" && result.Read())
                    {
                        pp.Add(result.GetString(1));
                        pdfDoc.Add(Chunk.NEWLINE);
                    }
                }
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(pp);
                s = l.Text;
                numPregunta=numPregunta+1;

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