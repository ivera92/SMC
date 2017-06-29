using System;
using System.Drawing;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using System.Data;

namespace CapaDePresentacion.Alum
{
    public partial class EvaluacionA : System.Web.UI.Page
    {
        private static List<RadioButtonList> lRbl;      //Para poder revisar los checked
        private static List<RadioButtonList> lRblVF;
        private static List<CheckBoxList> lCbl;
        private static RadioButtonList rbl;             //Para crear los controles dinamicamente
        private static RadioButtonList rblVF;
        private static CheckBoxList cbxl;
        private static List<int> lIdsCV;                //Para guardar el ID de la Pregunta y Respuesta
        private static List<int> lIdsSM;
        private static List<int> lIdsVF;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string rut = Session["rutAlumno"].ToString();
                CatalogAsignatura cAsignatura = new CatalogAsignatura();
                List<Asignatura> lAsignaturas = cAsignatura.listarAsignaturasAlumno(rut);
                btnGuardar.Visible = false;
                divPreguntas.Visible = false;
                if (!Page.IsPostBack) //para ver si cargo por primera vez
                {
                    this.ddAsignatura.DataTextField = "Nombre_asignatura";
                    this.ddAsignatura.DataValueField = "Cod_asignatura";
                    this.ddAsignatura.DataSource = lAsignaturas;

                    this.DataBind();//enlaza los datos a un dropdownlist                
                }
            }
            catch
            {
                Response.Redirect("../CheqLogin.aspx");
            }

            //Se ocupa en el Page Load para que pueda reconocer los checked de los campos
            try
            {
                this.crearControles();
            }
            catch
            { }
        }
        //Recorre la lista de checked y crea historial por cada pregunta y los inserta en la BD
        public void checkearChecked()
        {
            string rut = Session["rutAlumno"].ToString();
            Evaluacion ev = new Evaluacion();
            Pregunta p = new Pregunta();
            Respuesta r = new Respuesta();
            Alumno a = new Alumno();

            CatalogHPA cHPA = new CatalogHPA();
            int ii = 0;
            int jj = 0;
            int kk = 0;
            foreach (RadioButtonList item in lRbl)
            {
                for (int i = 0; i < item.Items.Count; i++)
                {
                    string text = item.Text;
                    bool selected = item.Items[i].Selected;

                    if (selected == true)
                    {
                        HistoricoPruebaAlumno hpa = new HistoricoPruebaAlumno();
                        hpa.Id_evaluacion_hpa = ev;
                        hpa.Pregunta_hpa = p;
                        hpa.Respuesta_hpa = r;
                        hpa.Alumno_hpa = a;

                        hpa.Id_evaluacion_hpa.Id_evaluacion = int.Parse(ddEvaluacion.SelectedValue);
                        hpa.Pregunta_hpa.Id_pregunta = lIdsSM[ii];
                        hpa.Respuesta_hpa.Id_respuesta = lIdsSM[ii + 1];
                        hpa.Alumno_hpa.Rut_persona = rut;
                        cHPA.insertarHPA(hpa);
                    }
                    ii = ii + 2;
                }
            }

            foreach (CheckBoxList item in lCbl)
            {
                for (int j = 0; j < item.Items.Count; j++)
                {
                    string text = item.Text;
                    bool selected = item.Items[j].Selected;

                    if (selected)
                    {
                        HistoricoPruebaAlumno hpa = new HistoricoPruebaAlumno();
                        hpa.Id_evaluacion_hpa = ev;
                        hpa.Pregunta_hpa = p;
                        hpa.Respuesta_hpa = r;
                        hpa.Alumno_hpa = a;

                        hpa.Id_evaluacion_hpa.Id_evaluacion = int.Parse(ddEvaluacion.SelectedValue);
                        hpa.Pregunta_hpa.Id_pregunta = lIdsCV[jj];
                        hpa.Respuesta_hpa.Id_respuesta = lIdsCV[jj + 1];
                        hpa.Alumno_hpa.Rut_persona = rut;
                        cHPA.insertarHPA(hpa);
                    }
                    jj = jj + 2;
                }
            }
            foreach (RadioButtonList item in lRblVF)
            {
                for (int k = 0; k < item.Items.Count; k++)
                {
                    string text = item.Text;
                    bool selected = item.Items[k].Selected;

                    if (selected)
                    {
                        HistoricoPruebaAlumno hpa = new HistoricoPruebaAlumno();
                        hpa.Id_evaluacion_hpa = ev;
                        hpa.Pregunta_hpa = p;
                        hpa.Respuesta_hpa = r;
                        hpa.Alumno_hpa = a;

                        hpa.Id_evaluacion_hpa.Id_evaluacion = int.Parse(ddEvaluacion.SelectedValue);
                        hpa.Pregunta_hpa.Id_pregunta = lIdsVF[kk];
                        hpa.Respuesta_hpa.Id_respuesta = lIdsVF[kk + 1];
                        hpa.Alumno_hpa.Rut_persona = rut;
                        cHPA.insertarHPA(hpa);
                    }
                    kk = kk + 2;
                }
            }
        }
        //Se crean los controles dependiendo del tipo, se agregan al panel para que sean visibles en la interfaz grafica, y a la vez 
        //se crean listas estaticas para que se pueda acceder a los atributos checked posteriormente 
        public void crearControles()
        {
            string ids_preguntas = "";
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            ids_preguntas = cEvaluacion.listarPreguntasEvaluacion(int.Parse(ddEvaluacion.SelectedValue));

            DataTable dt = cEvaluacion.mostrarPyRSeleccionadas(ids_preguntas);
            string s = "";
            int numPregunta = 1;

            lRbl = new List<RadioButtonList>();
            lRblVF = new List<RadioButtonList>();
            lCbl = new List<CheckBoxList>();

            rbl = new RadioButtonList();
            rblVF = new RadioButtonList();
            cbxl = new CheckBoxList();

            lIdsCV = new List<int>();
            lIdsVF = new List<int>();
            lIdsSM = new List<int>();
            string x = "";
            foreach (DataRow result in dt.Rows)
            {
                Label pregunta = new Label();
                pregunta.Text = result[2].ToString();

                if (s != pregunta.Text)
                {
                    Label l2 = new Label();
                    l2.Text = numPregunta + ") " + result[2].ToString();

                    if (rbl.Items.Count > 0 && x == "rbl")
                    {
                        rbl.ID = "rbl" + lRbl.Count;
                        RequiredFieldValidator rqdVal = new RequiredFieldValidator();
                        rqdVal.ID = "rqdVal" + rbl.ID;
                        rqdVal.ControlToValidate = rbl.ID;
                        rqdVal.ErrorMessage = "Por favor seleccione al menos una respuesta en todas las preguntas";
                        rqdVal.ForeColor = Color.Red;
                        rqdVal.Display = ValidatorDisplay.Dynamic;
                        lRbl.Add(rbl);
                        this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                        this.Panel1.Controls.Add(rqdVal);
                        this.Panel1.Controls.Add(rbl);
                    }
                    else if (cbxl.Items.Count > 0 && x == "cbxl")
                    {
                        cbxl.ID = "cbxl" + lCbl.Count;
                        lCbl.Add(cbxl);
                        this.Panel1.Controls.Add(cbxl);
                    }
                    else if (rblVF.Items.Count > 0 && x == "rblVF")
                    {
                        rblVF.ID = "rblVF" + lRblVF.Count;
                        RequiredFieldValidator rqdVal = new RequiredFieldValidator();
                        rqdVal.ID = "rqdVal" + rblVF.ID;
                        rqdVal.ControlToValidate = rblVF.ID;
                        rqdVal.ErrorMessage = "Por favor seleccione al menos una respuesta en todas las preguntas";
                        rqdVal.ForeColor = Color.Red;
                        rqdVal.Display = ValidatorDisplay.Dynamic;
                        lRblVF.Add(rblVF);
                        this.Panel1.Controls.Add(rblVF);
                        this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                        this.Panel1.Controls.Add(rqdVal);
                    }

                    if (result[0].ToString() == "Seleccion multiple")
                    {
                        rbl = new RadioButtonList();
                    }
                    else if (result[0].ToString() == "Casillas de verificacion")
                    {
                        cbxl = new CheckBoxList();
                    }
                    else if (result[0].ToString() == "Verdadero o falso")
                    {
                        rblVF = new RadioButtonList();
                    }

                    this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                    this.Panel1.Controls.Add(l2);
                    this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                    if (result[3].ToString() != "" && result[3].ToString() != null)
                    {
                        System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                        //string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ImagenesPreguntas\" + result.GetString(5));
                        //ruta = Path.GetFullPath(ruta);
                        img.ImageUrl = "../ImagenesPreguntas/" + result[3].ToString();
                        Panel1.Controls.Add(img);
                    }
                    numPregunta = numPregunta + 1;
                    s = pregunta.Text;
                }
                if (result[0].ToString() == "Seleccion multiple" && s == pregunta.Text)
                {
                    rbl.Items.Add(result[1].ToString());
                    lIdsSM.Add(int.Parse(result[4].ToString() + ""));
                    lIdsSM.Add(int.Parse(result[5].ToString() + ""));
                    x = "rbl";
                }

                else if (result[0].ToString() == "Casillas de verificacion" && s == pregunta.Text)
                {
                    cbxl.Items.Add(result[1].ToString());
                    lIdsCV.Add(int.Parse(result[4].ToString() + ""));
                    lIdsCV.Add(int.Parse(result[5].ToString() + ""));
                    x = "cbxl";
                }
                else if (result[0].ToString() == "Verdadero o falso" && s == pregunta.Text)
                {
                    rblVF.Items.Add(result[1].ToString());
                    lIdsVF.Add(int.Parse(result[4].ToString() + ""));
                    lIdsVF.Add(int.Parse(result[5].ToString() + ""));
                    x = "rblVF";
                }
                s = result[2].ToString();
            }
            if (rbl.Items.Count > 0 && x == "rbl")
            {
                rbl.ID = "rbl" + lRbl.Count;
                RequiredFieldValidator rqdVal = new RequiredFieldValidator();
                rqdVal.ID = "rqdVal" + rbl.ID;
                rqdVal.ControlToValidate = rbl.ID;
                rqdVal.ErrorMessage = "Por favor seleccione al menos una respuesta en todas las preguntas";
                rqdVal.ForeColor = Color.Red;
                rqdVal.Display = ValidatorDisplay.Dynamic;
                lRbl.Add(rbl);
                this.Panel1.Controls.Add(rbl);
                this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                this.Panel1.Controls.Add(rqdVal);
            }
            else if (cbxl.Items.Count > 0 && x == "cbxl")
            {
                cbxl.ID = "cbxl" + lCbl.Count;
                lCbl.Add(cbxl);
                this.Panel1.Controls.Add(cbxl);
            }
            else if (rblVF.Items.Count > 0 && x == "rblVF")
            {
                rblVF.ID = "rblVF" + lRblVF.Count;
                RequiredFieldValidator rqdVal = new RequiredFieldValidator();
                rqdVal.ID = "rqdVal" + rblVF.ID;
                rqdVal.ControlToValidate = rblVF.ID;
                rqdVal.ErrorMessage = "Por favor seleccione al menos una respuesta en todas las preguntas";
                rqdVal.ForeColor = Color.Red;
                rqdVal.Display = ValidatorDisplay.Dynamic;
                lRblVF.Add(rblVF);
                this.Panel1.Controls.Add(rblVF);
                this.Panel1.Controls.Add(new LiteralControl("<br/>"));
                this.Panel1.Controls.Add(rqdVal);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                divEvaluar.Visible = false;
                this.checkearChecked();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Respuestas guardadas satisfactoriamente, revise sus resultados');window.location='Resultados.aspx';</script>'");
            }
            catch
            {
                Response.Write("<script>window.alert('Alumno no pudo ser evaluado para esta asignatura');</script>");
            }
        }
        //Carga las evaluaciones dependiendo de la asignatura
        protected void ddAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rut = Session["rutAlumno"].ToString();
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<Evaluacion> lEvaluaciones = cEvaluacion.listarEvaluacionesPendientes(rut, ddAsignatura.SelectedValue);
            this.ddEvaluacion.Items.Clear();
            this.ddEvaluacion.Items.Add(new ListItem("<--Seleccione una evaluacion-->", "0"));
            this.ddEvaluacion.DataTextField = "Nombre_evaluacion";
            this.ddEvaluacion.DataValueField = "Id_evaluacion";
            this.ddEvaluacion.DataSource = lEvaluaciones;
            this.DataBind();//enlaza los datos a un dropdownlist    
        }

        protected void ddEvaluacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            divPreguntas.Visible = true;
        }
    }
}