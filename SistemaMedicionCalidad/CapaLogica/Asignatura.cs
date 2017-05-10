using Project.CapaDeNegocios;

namespace Project
{
    public class Asignatura
    {
        private char cod_asignatura;
        private Escuela escuela_asignatura;
        private Docente docente_asignatura;
        private string nombre_asignatura;
        private int ano_asignatura;
        private bool duracion_asignatura;

        //Constructor predeterminado
        public Asignatura()
        {
        }

        public Asignatura(char cod_asignatura, string nombre_asignatura)
        {
            this.cod_asignatura = cod_asignatura;
            this.nombre_asignatura = nombre_asignatura;
        }
        public Asignatura(Escuela escuela_asignatura, Docente docente_asignatura, string nombre_asignatura, int ano_asignatura, bool duracion_asignatura)
        {
            this.escuela_asignatura = escuela_asignatura;
            this.docente_asignatura = docente_asignatura;
            this.nombre_asignatura = nombre_asignatura;
            this.ano_asignatura = ano_asignatura;
            this.duracion_asignatura = duracion_asignatura;
        }

        public Asignatura(char cod_asignatura, Escuela escuela_asignatura, Docente docente_asignatura, string nombre_asignatura, int ano_asignatura, bool duracion_asignatura)
        {
            this.cod_asignatura = cod_asignatura;
            this.escuela_asignatura = escuela_asignatura;
            this.docente_asignatura = docente_asignatura;
            this.nombre_asignatura = nombre_asignatura;
            this.ano_asignatura = ano_asignatura;
            this.duracion_asignatura = duracion_asignatura;
        }

        public char Cod_asignatura
        {
            get { return cod_asignatura; }
            set { cod_asignatura = value; }
        }

        public string Nombre_asignatura
        {
            get { return nombre_asignatura; }
            set { nombre_asignatura = value; }
        }

        public int Ano_asignatura
        {
            get { return ano_asignatura; }
            set { ano_asignatura = value; }
        }

        public bool Duracion_asignatura
        {
            get { return duracion_asignatura; }
            set { duracion_asignatura = value; }
        }

        public Escuela Escuela_asignatura
        {
            get { return escuela_asignatura; }
            set { escuela_asignatura = value; }
        }

        public Docente Docente_asignatura
        {
            get { return docente_asignatura; }
            set { docente_asignatura = value; }
        }
    }
}
