namespace Project
{
    public class Competencia
    {
        private int id_competencia;
        private Ambito id_ambito;        
        private Tipo_Competencia id_tipo_competencia;
        private string nombre_competencia;

        //Constructor predeterminado
        public Competencia()
        {
        }
        //Constructor usado para listar las competencias asociadas a una asignatura en dropdownlist
        public Competencia(int id_competencia, string nombre_competencia)
        {
            this.id_competencia = id_competencia;
            this.nombre_competencia = nombre_competencia;
        }
        //Constructor usado para crear competencia
        public Competencia(Ambito id_ambito, Tipo_Competencia id_tipo_competencia, string nombre_competencia)
        {
            this.Id_ambito = id_ambito;
            this.id_tipo_competencia = id_tipo_competencia;
            this.nombre_competencia = nombre_competencia;
        }
        //Constructor usado para actualizar competencia
        public Competencia(int id_competencia, Ambito id_ambito, Tipo_Competencia id_tipo_competencia, string nombre_competencia)
        {
            this.id_competencia = id_competencia;
            this.Id_ambito = id_ambito;
            this.id_tipo_competencia = id_tipo_competencia;
            this.nombre_competencia = nombre_competencia;
        }

        public int Id_competencia
        {
            get { return id_competencia; }
            set { id_competencia = value; }
        }

        public string Nombre_competencia
        {
            get { return nombre_competencia; }
            set { nombre_competencia = value; }
        }

        public Tipo_Competencia Id_tipo_competencia
        {
            get { return id_tipo_competencia; }
            set { id_tipo_competencia = value; }
        }

        public Ambito Id_ambito
        {
            get { return id_ambito; }
            set { id_ambito = value; }
        }
    }
}