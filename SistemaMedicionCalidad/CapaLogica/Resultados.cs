using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Resultados
    {
        private Respuesta correcta_respuesta;
        private int cantidad;
        private Competencia nombre_competencia;
        private Docente rut_docente;
        private Alumno rut_alumno;
        private HistoricoPruebaAlumno id_evaluacion_hpa;

        public Resultados()
        {

        }
        public Resultados(Respuesta correcta_respuesta, int cantidad, Competencia nombre_competencia, Docente rut_docente, Alumno rut_alumno, HistoricoPruebaAlumno id_evaluacion_hpa)
        {
            this.correcta_respuesta = correcta_respuesta;
            this.cantidad = cantidad;
            this.nombre_competencia = nombre_competencia;
            this.rut_docente = rut_docente;
            this.rut_alumno = rut_alumno;
            this.id_evaluacion_hpa = id_evaluacion_hpa;
        }

        public Respuesta Correcta_respuesta
        {
            get
            {
                return correcta_respuesta;
            }

            set
            {
                correcta_respuesta = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public Competencia Nombre_competencia
        {
            get
            {
                return nombre_competencia;
            }

            set
            {
                nombre_competencia = value;
            }
        }

        public Docente Rut_docente
        {
            get
            {
                return rut_docente;
            }

            set
            {
                rut_docente = value;
            }
        }

        public Alumno Rut_alumno
        {
            get
            {
                return rut_alumno;
            }

            set
            {
                rut_alumno = value;
            }
        }

        public HistoricoPruebaAlumno Id_evaluacion_hpa
        {
            get
            {
                return id_evaluacion_hpa;
            }

            set
            {
                id_evaluacion_hpa = value;
            }
        }
    }
}
