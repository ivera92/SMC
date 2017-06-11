using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Imparte
    {
        private int id_imparte;
        private Docente rut_docente_imparte;
        private Asignatura cod_asignatura_imparte;

        public Imparte() { }

        public Imparte(Docente rut_docente_imparte, Asignatura cod_asignatura_imparte)
        {
            this.rut_docente_imparte = rut_docente_imparte;
            this.cod_asignatura_imparte = cod_asignatura_imparte;
        }

        public Imparte(int id_imparte, Docente rut_docente_imparte, Asignatura cod_asignatura_imparte)
        {
            this.id_imparte = id_imparte;
            this.rut_docente_imparte = rut_docente_imparte;
            this.cod_asignatura_imparte = cod_asignatura_imparte;
        }

        public int Id_imparte
        {
            get { return id_imparte; }
            set { id_imparte = value; }
        }

        public Docente Rut_docente_imparte
        {
            get { return rut_docente_imparte; }
            set { rut_docente_imparte = value; }
        }

        public Asignatura Cod_asignatura_imparte
        {
            get { return cod_asignatura_imparte; }
            set { cod_asignatura_imparte = value; }
        }
    }
}
