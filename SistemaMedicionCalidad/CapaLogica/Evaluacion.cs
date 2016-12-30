using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Evaluacion
    {
        int id_evaluacion;
        int id_asignatura_evaluacion;
        string nombre_evaluacion;
        DateTime fecha_evaluacion;

        public Evaluacion(int id_asignatura_evaluacion, string nombre_evaluacion, DateTime fecha_evaluacion)
        {
            this.id_asignatura_evaluacion = id_asignatura_evaluacion;
            this.nombre_evaluacion = nombre_evaluacion;
            this.fecha_evaluacion = fecha_evaluacion;
        }

        public Evaluacion(int id_evaluacion, int id_asignatura_evaluacion, string nombre_evaluacion, DateTime fecha_evaluacion)
        {
            this.id_evaluacion = id_evaluacion;
            this.id_asignatura_evaluacion = id_asignatura_evaluacion;
            this.nombre_evaluacion = nombre_evaluacion;
            this.fecha_evaluacion = fecha_evaluacion;
        }

        public int Id_evaluacion
        {
            get { return id_evaluacion; }
            set { id_evaluacion = value; }
        }

        public int Id_asignatura_evaluacion
        {
            get { return id_asignatura_evaluacion; }
            set { id_asignatura_evaluacion = value; }
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
