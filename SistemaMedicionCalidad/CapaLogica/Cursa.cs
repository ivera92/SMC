using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Cursa
    {
        private int id_aa;
        private Alumno rut_alumno_aa;
        private Asignatura id_asignatura_aa;

        public Cursa() { }

        public Cursa(Alumno rut_alumno_aa, Asignatura id_asignatura_aa)
        {
            this.rut_alumno_aa = rut_alumno_aa;
            this.id_asignatura_aa = id_asignatura_aa;
        }
        public Alumno Rut_alumno_aa
        {
            get
            {
                return rut_alumno_aa;
            }

            set
            {
                rut_alumno_aa = value;
            }
        }

        public Asignatura Id_asignatura_aa
        {
            get
            {
                return id_asignatura_aa;
            }

            set
            {
                id_asignatura_aa = value;
            }
        }

        public int Id_aa
        {
            get
            {
                return id_aa;
            }

            set
            {
                id_aa = value;
            }
        }
    }
}
