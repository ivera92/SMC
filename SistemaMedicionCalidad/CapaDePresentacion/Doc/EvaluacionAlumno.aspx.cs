using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project;
using Project.CapaDeDatos;

namespace CapaDePresentacion.Doc
{
    public partial class EvaluacionAlumno : System.Web.UI.Page
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
            string rut = Session["rutDocente"].ToString();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignaturas = cAsignatura.listarAsignaturasDocente(rut);
            btnSiguiente.Visible = false;
            btnGuardar.Visible = false;
            divPreguntas.Visible = false;
            //Se ocupa en el Page Load para que pueda reconocer los checked de los campos
            try
            {
                this.crearControles();
            }
            catch
            {
                Response.Write("<script>window.alert('No existen preguntas asociadas a la asignatura');</script>");
            }
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Cod_asignatura";
                this.ddAsignatura.DataSource = lAsignaturas;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }

        }
        //Recorre la lista de checked y crea historial por cada pregunta y los inserta en la BD
        public void checkearChecked()
        {
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
                        hpa.Evaluacion_hpa = ev;
                        hpa.Pregunta_hpa = p;
                        hpa.Respuesta_hpa = r;
                        hpa.Alumno_hpa = a;

                        hpa.Evaluacion_hpa.Id_evaluacion = int.Parse(ddEvaluacion.SelectedValue);
                        hpa.Pregunta_hpa.Id_pregunta = lIdsSM[ii];
                        hpa.Respuesta_hpa.Id_respuesta = lIdsSM[ii + 1];
                        hpa.Alumno_hpa.Rut_persona = txtRut.Text;
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
                        hpa.Evaluacion_hpa = ev;
                        hpa.Pregunta_hpa = p;
                        hpa.Respuesta_hpa = r;
                        hpa.Alumno_hpa = a;

                        hpa.Evaluacion_hpa.Id_evaluacion = int.Parse(ddEvaluacion.SelectedValue);
                        hpa.Pregunta_hpa.Id_pregunta = lIdsCV[jj];
                        hpa.Respuesta_hpa.Id_respuesta = lIdsCV[jj + 1];
                        hpa.Alumno_hpa.Rut_persona = txtRut.Text;
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
                        hpa.Evaluacion_hpa = ev;
                        hpa.Pregunta_hpa = p;
                        hpa.Respuesta_hpa = r;
                        hpa.Alumno_hpa = a;

                        hpa.Evaluacion_hpa.Id_evaluacion = int.Parse(ddEvaluacion.SelectedValue);
                        hpa.Pregunta_hpa.Id_pregunta = lIdsVF[kk];
                        hpa.Respuesta_hpa.Id_respuesta = lIdsVF[kk + 1];
                        hpa.Alumno_hpa.Rut_persona = txtRut.Text;
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
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarPreguntasEvaluacionAsignatura";
            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura", DbType.String, this.ddAsignatura.SelectedValue);
            DbDataReader result = bd.Query();
            string s = "";
            int numPregunta = 1;
            int i = 0;

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
            while (result.Read())
            {
                Label pregunta = new Label();
                pregunta.Text = result.GetString(2);

                if (s != pregunta.Text)
                {
                    Label l2 = new Label();
                    l2.Text = numPregunta + ") " + result.GetString(2);

                    if (rbl.Items.Count > 0 && x=="rbl")
                    {
                        lRbl.Add(rbl);
                        this.Panel1.Controls.Add(rbl);
                    }
                    else if (cbxl.Items.Count > 0 && x == "cbxl")
                    {
                        lCbl.Add(cbxl);
                        this.Panel1.Controls.Add(cbxl);
                    }
                    else if (rblVF.Items.Count > 0 && x == "rblVF") 
                    {
                        lRblVF.Add(rblVF);
                        this.Panel1.Controls.Add(rblVF);
                    }

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
                    rbl.Items.Add(result.GetString(1));
                    lIdsSM.Add(result.GetInt32(3));
                    lIdsSM.Add(result.GetInt32(4));
                    x = "rbl";
                }

                else if (result.GetString(0) == "Casillas de verificacion" && s == pregunta.Text)
                {
                    cbxl.Items.Add(result.GetString(1));
                    lIdsCV.Add(result.GetInt32(3));
                    lIdsCV.Add(result.GetInt32(4));
                    x = "cbxl";
                }
                else if (result.GetString(0) == "Verdadero o falso" && s == pregunta.Text)
                {
                    rblVF.Items.Add(result.GetString(1));
                    lIdsVF.Add(result.GetInt32(3));
                    lIdsVF.Add(result.GetInt32(4));
                    x = "rblVF";
                }
                s = result.GetString(2);
                i = i + 1;
            }
            if (rbl.Items.Count > 0 && x == "rbl")
            {
                lRbl.Add(rbl);
                this.Panel1.Controls.Add(rbl);
            }
            else if (cbxl.Items.Count > 0 && x == "cbxl")
            {
                lCbl.Add(cbxl);
                this.Panel1.Controls.Add(cbxl);
            }
            else if (rblVF.Items.Count > 0 && x == "rblVF")
            {
                lRblVF.Add(rblVF);
                this.Panel1.Controls.Add(rblVF);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                divEvaluar.Visible = false;
                this.checkearChecked();
                Response.Write("<script>window.alert('Alumno evaluado correctamente');</script>");
                btnSiguiente.Visible = true;                
            }
            catch
            {
                Response.Write("<script>window.alert('Alumno ya fue evaluado para esta asignatura');</script>");
            }
        }
        //Carga las evaluaciones dependiendo de la asignatura
        protected void ddAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            divPreguntas.Visible = true;
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<Evaluacion> lEvaluaciones = cEvaluacion.listarEvaluacionesAsignatura(ddAsignatura.SelectedValue);
            this.ddEvaluacion.Items.Clear();
            this.ddEvaluacion.DataTextField = "Nombre_evaluacion";
            this.ddEvaluacion.DataValueField = "Id_evaluacion";
            this.ddEvaluacion.DataSource = lEvaluaciones;
            this.DataBind();//enlaza los datos a un dropdownlist    
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            divEvaluar.Visible = true;
            Response.Redirect("EvaluacionAlumno.aspx");
        }
    }
}