﻿using System;
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
        private static List<RadioButtonList> lRbl;
        private static List<RadioButtonList> lRblVF;
        private static List<CheckBoxList> lCbl;
        private static RadioButtonList rbl;
        private static RadioButtonList rblVF;
        private static CheckBoxList cbxl;

        protected void Page_Load(object sender, EventArgs e)
        {
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            List<Asignatura> lAsignaturas = cAsignatura.listarAsignaturas();
            
            try
            {
                this.crearControles2();
            }
            catch
            {

            }
            if (!Page.IsPostBack) //para ver si cargo por primera vez
            {
                this.ddAsignatura.DataTextField = "Nombre_asignatura";
                this.ddAsignatura.DataValueField = "Id_asignatura";
                this.ddAsignatura.DataSource = lAsignaturas;

                this.DataBind();//enlaza los datos a un dropdownlist                
            }

        }
        public static string verificar(string rut_alumno)
        {
            //consulta a la base de datos
            string s = "";
            string sql = @"SELECT nombre_alumno FROM alumno WHERE rut_alumno = @rut_alumno";
            //cadena conexion

            DataBase bd = new DataBase();
            bd.connect();

            bd.CreateCommand(sql);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);
            DbDataReader result = bd.Query();//disponible resultado
            if (result.Read())
            {
                s = result.GetString(0);
            }
            return s;
        }

        public void checkearChecked()
        {
            Evaluacion ev = new Evaluacion();
            Pregunta p = new Pregunta();
            Respuesta r = new Respuesta();
            Alumno a = new Alumno();

            CatalogHPA cHPA = new CatalogHPA();

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
                        hpa.Pregunta_hpa.Id_pregunta = cHPA.buscarIDPregunta(text);
                        hpa.Respuesta_hpa.Id_respuesta = cHPA.buscarIDRespuesta(text);
                        hpa.Alumno_hpa.Rut_persona = txtRut.Text;
                        cHPA.insertarHPA(hpa);
                    }
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
                        hpa.Pregunta_hpa.Id_pregunta = cHPA.buscarIDPregunta(text);
                        hpa.Respuesta_hpa.Id_respuesta = cHPA.buscarIDRespuesta(text);
                        hpa.Alumno_hpa.Rut_persona = txtRut.Text;
                        cHPA.insertarHPA(hpa);
                    }
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
                        hpa.Pregunta_hpa.Id_pregunta = cHPA.buscarIDPregunta(text);
                        hpa.Respuesta_hpa.Id_respuesta = cHPA.buscarIDRespuesta(text);
                        hpa.Alumno_hpa.Rut_persona = txtRut.Text;
                        cHPA.insertarHPA(hpa);
                    }
                }
            }
        }

        public void crearControles2()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "SELECT nombre_tipo_pregunta, NOMBRE_RESPUESTA, nombre_pregunta, id_pregunta FROM [ASIGNATURA_COMPETENCIA] inner join asignatura on [asignatura_competencia].id_asignatura_ac = asignatura.id_asignatura inner join competencia on [asignatura_competencia].id_competencia_ac = competencia.id_competencia inner join pregunta on competencia.id_competencia = pregunta.id_competencia_pregunta inner join tipo_pregunta on pregunta.id_tipo_pregunta_pregunta = tipo_pregunta.id_tipo_pregunta inner join respuesta on id_pregunta_respuesta=id_pregunta where asignatura.id_asignatura ='" + this.ddAsignatura.SelectedValue + "'";

            bd.CreateCommand(sql);
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
                    x = "rbl";
                }

                else if (result.GetString(0) == "Casillas de verificacion" && s == pregunta.Text)
                {
                    cbxl.Items.Add(result.GetString(1));
                    x = "cbxl";
                }
                else if (result.GetString(0) == "Verdadero o falso" && s == pregunta.Text)
                {
                    rblVF.Items.Add(result.GetString(1));
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
            this.checkearChecked();
            Panel1.Visible = false;
        }

        protected void ddAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            List<Evaluacion> lEvaluaciones = cEvaluacion.listarEvaluacionesAsignatura(int.Parse(ddAsignatura.SelectedValue));
            this.ddEvaluacion.Items.Clear();
            this.ddEvaluacion.DataTextField = "Nombre_evaluacion";
            this.ddEvaluacion.DataValueField = "Id_evaluacion";
            this.ddEvaluacion.DataSource = lEvaluaciones;
            this.DataBind();//enlaza los datos a un dropdownlist    
        }
    }
}