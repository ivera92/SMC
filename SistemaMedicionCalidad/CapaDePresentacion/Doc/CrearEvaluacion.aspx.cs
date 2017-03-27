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

namespace CapaDePresentacion.Doc
{
    public partial class CrearEvaluacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignatura = cAsignatura.listarAsignaturas();

            if (!Page.IsPostBack)
            {
                this.fechaEvaluacion.InnerText = DateTime.Today.ToString("d");
                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Id_asignatura";
                this.ddAsignatura.DataSource = lAsignatura;

                this.DataBind();//enlaza los datos a un dropdownlist      
            }
        }
        public void pdf()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "SELECT nombre_tipo_pregunta, NOMBRE_RESPUESTA, nombre_pregunta, imagen_pregunta FROM [ASIGNATURA_COMPETENCIA] inner join asignatura on [asignatura_competencia].id_asignatura_ac = asignatura.id_asignatura inner join competencia on [asignatura_competencia].id_competencia_ac = competencia.id_competencia inner join pregunta on competencia.id_competencia = pregunta.id_competencia_pregunta inner join tipo_pregunta on pregunta.id_tipo_pregunta_pregunta = tipo_pregunta.id_tipo_pregunta inner join respuesta on id_pregunta_respuesta=id_pregunta where asignatura.id_asignatura ='" + this.ddAsignatura.SelectedValue + "' order by nombre_tipo_pregunta";

            bd.CreateCommand(sql);
            DbDataReader result = bd.Query();
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

                //Si cambio la pregunta
                if (s != l.Text)
                {
                    pp.Add(new Paragraph(" "));
                    pp.Add(numPregunta + " ");
                    pp.Add(l.Text+"\n");
                    pp.Add(new Paragraph(" "));

                    try
                    {
                        string ss = result.GetString(3);
                        if (result.GetString(3) != null && result.GetString(3) != "")
                        {
                            // Creamos la imagen y le ajustamos el tamaño
                            iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance(result.GetString(3));
                            imagen2.BorderWidth = 0;
                            imagen2.Alignment = Element.ALIGN_CENTER;
                            float percentage2 = 0.0f;
                            percentage2 = 100 / imagen2.Width;
                            imagen2.ScalePercent(percentage2 * 75);

                            // Insertamos la imagen en el documento
                            pdfDoc.Add(imagen2);
                        }
                    }
                    catch
                    {

                    }
                    numPregunta = numPregunta + 1;
                }
                if (result.GetString(0) == "Seleccion multiple")
                {
                    pp.Add("O " + result.GetString(1));
                }

                else if (result.GetString(0) == "Casillas de verificacion")
                {
                    pp.Add("[] " + result.GetString(1) + "\n");

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
            CatalogEvaluacion ce = new CatalogEvaluacion();
            Evaluacion ev = new Evaluacion();
            Asignatura a = new Asignatura();
            ev.Asignatura_evaluacion = a;

            ev.Fecha_evaluacion = DateTime.Parse(this.fechaEvaluacion.InnerText);
            ev.Asignatura_evaluacion.Id_asignatura = int.Parse(this.ddAsignatura.SelectedValue);
            ev.Nombre_evaluacion = this.txtNombre.Text;

            try
            {
                if (ce.verificarExistencia(int.Parse(ddAsignatura.SelectedValue)) > 0)
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
            }
            catch
            {
            }
        }

        public void crearControles()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "SELECT nombre_tipo_pregunta, NOMBRE_RESPUESTA, nombre_pregunta FROM [ASIGNATURA_COMPETENCIA] inner join asignatura on [asignatura_competencia].id_asignatura_ac = asignatura.id_asignatura inner join competencia on [asignatura_competencia].id_competencia_ac = competencia.id_competencia inner join pregunta on competencia.id_competencia = pregunta.id_competencia_pregunta inner join tipo_pregunta on pregunta.id_tipo_pregunta_pregunta = tipo_pregunta.id_tipo_pregunta inner join respuesta on id_pregunta_respuesta=id_pregunta where asignatura.id_asignatura ='" + this.ddAsignatura.SelectedValue + "' order by nombre_tipo_pregunta";

            bd.CreateCommand(sql);
            DbDataReader result = bd.Query();
            string s = "";

            string[] letras = { "A) ", "B) ", "C) ", "D) ", "F) " };
            int numPregunta = 1;
            int i = 0;

            RadioButtonList rbl = new RadioButtonList();
            RadioButtonList rblVF = new RadioButtonList();
            CheckBoxList cbxl = new CheckBoxList();

            while (result.Read())
            {
                Label pregunta = new Label();
                pregunta.Text = result.GetString(2);
                
                if (s != pregunta.Text)
                {
                    Label l2 = new Label();
                    l2.Text = numPregunta + ") " + result.GetString(2);

                    if (result.GetString(0) == "Seleccion multiple")
                    {
                        rbl = new RadioButtonList();
                    }
                    else if (result.GetString(0) == "Casillas de verificacion")
                    {
                        cbxl = new CheckBoxList();
                    }
                    else if (result.GetString(0) == "Verdadero o falso")
                    {
                        rblVF = new RadioButtonList();
                    }

                    i = 0;
                    this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                    this.Panel1.Controls.Add(l2);
                    this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                    numPregunta = numPregunta + 1;
                    s = pregunta.Text;
                }
                if (result.GetString(0) == "Seleccion multiple" && s == pregunta.Text)
                {
                    rbl.Items.Add(letras[i] + " " + result.GetString(1));
                    this.Panel1.Controls.Add(rbl);
                }

                else if (result.GetString(0) == "Casillas de verificacion" && s == pregunta.Text)
                {
                    cbxl.Items.Add(letras[i] + " " + result.GetString(1));
                    this.Panel1.Controls.Add(cbxl);
                }
                else if (result.GetString(0) == "Verdadero o falso" && s == pregunta.Text)
                {
                    rblVF.Items.Add(letras[i] + " " + result.GetString(1));
                    this.Panel1.Controls.Add(rblVF);
                }
                s = result.GetString(2);
                i = i + 1;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.crearControles();
        }
    }
}