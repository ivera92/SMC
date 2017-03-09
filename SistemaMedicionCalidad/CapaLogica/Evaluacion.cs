﻿using System;

namespace Project
{
    public class Evaluacion
    {
        private int id_evaluacion;
        private Asignatura asignatura_evaluacion;
        private string nombre_evaluacion;
        private DateTime fecha_evaluacion;

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

        public Evaluacion(int id_evaluacion, Asignatura asignatura_evaluacion, string nombre_evaluacion, DateTime fecha_evaluacion)
        {
            this.id_evaluacion = id_evaluacion;
            this.asignatura_evaluacion = asignatura_evaluacion;
            this.nombre_evaluacion = nombre_evaluacion;
            this.fecha_evaluacion = fecha_evaluacion;
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
    }
}
