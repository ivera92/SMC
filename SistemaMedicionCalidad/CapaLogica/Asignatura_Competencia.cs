using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Asignatura_Competencia
    {
        int id_ac;
        Asignatura asignatura_ac;
        Competencia competencia_ac;

        public Asignatura_Competencia()
        {
        }

        public Asignatura_Competencia(Asignatura asignatura_ac, Competencia competencia_ac)
        {
            this.Asignatura_ac = asignatura_ac;
            this.Competencia_ac = competencia_ac;
        }
        public int Id_ac
        {
            get { return id_ac; }
            set { id_ac = value; }
        }
        public Asignatura Asignatura_ac
        {
            get { return asignatura_ac; }
            set { asignatura_ac = value; }
        }
        public Competencia Competencia_ac
        {
            get { return competencia_ac; }
            set { competencia_ac = value; }
        }
    }
}
