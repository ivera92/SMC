using Project.CapaDeNegocios;

namespace Project
{
    public class Asignatura
    {
        private int id_asignatura;
        private Escuela escuela_asignatura;
        private Docente docente_asignatura;
        private string nombre_asignatura;
        private int ano_asignatura;
        private bool duracion_asignatura;

        //Constructor predeterminado
        public Asignatura()
        {
        }

        public Asignatura(Escuela escuela_asignatura, Docente docente_asignatura, string nombre_asignatura, int ano_asignatura, bool duracion_asignatura)
        {
            this.escuela_asignatura = escuela_asignatura;
            this.docente_asignatura = docente_asignatura;
            this.nombre_asignatura = nombre_asignatura;
            this.ano_asignatura = ano_asignatura;
            this.duracion_asignatura = duracion_asignatura;
        }

        public Asignatura(int id_asignatura, Escuela escuela_asignatura, Docente docente_asignatura, string nombre_asignatura, int ano_asignatura, bool duracion_asignatura)
        {
            this.id_asignatura = id_asignatura;
            this.escuela_asignatura = escuela_asignatura;
            this.docente_asignatura = docente_asignatura;
            this.nombre_asignatura = nombre_asignatura;
            this.ano_asignatura = ano_asignatura;
            this.duracion_asignatura = duracion_asignatura;
        }

        public int Id_asignatura
        {
            get { return id_asignatura; }
            set { id_asignatura = value; }
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
