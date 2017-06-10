using Project.CapaDeNegocios;

namespace Project
{
    public class Asignatura
    {
        private string cod_asignatura;
        private Escuela escuela_asignatura;
        private string nombre_asignatura;
        private bool duracion_asignatura;

        //Constructor predeterminado
        public Asignatura()
        {
        }
        //Constructor listar asignaturas en dropdownlist
        public Asignatura(string cod_asignatura, string nombre_asignatura)
        {
            this.cod_asignatura = cod_asignatura;
            this.nombre_asignatura = nombre_asignatura;
        }
        //Constructor usado para crear asignaturas mediante el sistema web
        public Asignatura(string cod_asignatura, Escuela escuela_asignatura, string nombre_asignatura, bool duracion_asignatura)
        {
            this.cod_asignatura = cod_asignatura;
            this.escuela_asignatura = escuela_asignatura;
            this.nombre_asignatura = nombre_asignatura;
            this.duracion_asignatura = duracion_asignatura;
        }
        public string Cod_asignatura
        {
            get { return cod_asignatura; }
            set { cod_asignatura = value; }
        }

        public string Nombre_asignatura
        {
            get { return nombre_asignatura; }
            set { nombre_asignatura = value; }
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
    }
}
