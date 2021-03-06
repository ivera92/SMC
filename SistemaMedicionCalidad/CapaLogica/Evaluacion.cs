﻿using System;

namespace Project
{
    public class Evaluacion
    {
        private int id_evaluacion;
        private Asignatura asignatura_evaluacion;
        private string nombre_evaluacion;
        private DateTime fecha_evaluacion;
        private string preguntas_evaluacion;
        private string activo_evaluacion;
        private int porcentaje_exigencia_evaluacion;

        //Constructor predeterminado
        public Evaluacion()
        {
        }

        public Evaluacion(int id_evaluacion, string nombre_evaluacion)
        {
            this.id_evaluacion = id_evaluacion;
            this.nombre_evaluacion = nombre_evaluacion;
        }

        public Evaluacion(Asignatura asignatura_evaluacion, string nombre_evaluacion, DateTime fecha_evaluacion)
        {
            this.asignatura_evaluacion = asignatura_evaluacion;
            this.nombre_evaluacion = nombre_evaluacion;
            this.fecha_evaluacion = fecha_evaluacion;
        }

        public Evaluacion(int id_evaluacion, Asignatura asignatura_evaluacion, string nombre_evaluacion, DateTime fecha_evaluacion, string preguntas_evaluacion, string activo_evaluacion, int porcentaje_exigencia_evaluacion)
        {
            this.id_evaluacion = id_evaluacion;
            this.asignatura_evaluacion = asignatura_evaluacion;
            this.nombre_evaluacion = nombre_evaluacion;
            this.fecha_evaluacion = fecha_evaluacion;
            this.preguntas_evaluacion = preguntas_evaluacion;
            this.activo_evaluacion = activo_evaluacion;
            this.Porcentaje_exigencia_evaluacion = porcentaje_exigencia_evaluacion;
        }


        //Usado para el administrar evaluacion en docente
        public Evaluacion(Asignatura asignatura_evaluacion, string nombre_evaluacion, DateTime fecha_evaluacion, string preguntas_evaluacion, string activo_evaluacion, int porcentaje_exigencia_evaluacion)
        {
            this.asignatura_evaluacion = asignatura_evaluacion;
            this.nombre_evaluacion = nombre_evaluacion;
            this.fecha_evaluacion = fecha_evaluacion;
            this.preguntas_evaluacion = preguntas_evaluacion;
            this.activo_evaluacion = activo_evaluacion;
            this.porcentaje_exigencia_evaluacion = porcentaje_exigencia_evaluacion;
        }

        public int Id_evaluacion
        {
            get { return id_evaluacion; }
            set { id_evaluacion = value; }
        }

        public Asignatura Asignatura_evaluacion
        {
            get { return asignatura_evaluacion; }
            set { asignatura_evaluacion = value; }
        }

        public string Nombre_evaluacion
        {
            get { return nombre_evaluacion; }
            set { nombre_evaluacion = value; }
        }

        public DateTime Fecha_evaluacion
        {
            get { return fecha_evaluacion; }
            set { fecha_evaluacion = value; }
        }

        public string Preguntas_evaluacion
        {
            get { return preguntas_evaluacion; }
            set { preguntas_evaluacion = value; }
        }

        public string Activo_evaluacion
        {
            get
            {
                return activo_evaluacion;
            }

            set
            {
                activo_evaluacion = value;
            }
        }

        public int Porcentaje_exigencia_evaluacion
        {
            get { return porcentaje_exigencia_evaluacion; }
            set { porcentaje_exigencia_evaluacion = value; }
        }
    }
}
