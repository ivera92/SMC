namespace Project
{
    public class Competencia
    {
        private int id_competencia;
        private string nombre_competencia;
        private Tipo_Competencia id_tipo_competencia;
        private string descripcion_competencia;

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
        //Constructor usado para listar las competencias en el administrador de competencias
        public Competencia(string nombre_competencia, Tipo_Competencia id_tipo_competencia, int id_competencia)
        {
            this.nombre_competencia = nombre_competencia;
            this.id_tipo_competencia = id_tipo_competencia;
            this.id_competencia = id_competencia;
        }
        //Constructor usado para listar las competencias en dropdownlist
        public Competencia(string nombre_competencia, string descripcion_competencia, int id_competencia)
        {
            this.nombre_competencia = nombre_competencia;
            this.descripcion_competencia = descripcion_competencia;
            this.id_competencia = id_competencia;
        }
        //Constructor usado para crear competencia
        public Competencia(string nombre_competencia, Tipo_Competencia id_tipo_competencia, string descripcion_competencia)
        {
            this.nombre_competencia = nombre_competencia;
            this.id_tipo_competencia = id_tipo_competencia;
            this.descripcion_competencia = descripcion_competencia;
        }
        //Constructor usado para actualizar competencia
        public Competencia(int id_competencia, string nombre_competencia, Tipo_Competencia id_tipo_competencia, string descripcion_competencia)
        {
            this.id_competencia = id_competencia;
            this.nombre_competencia = nombre_competencia;
            this.id_tipo_competencia = id_tipo_competencia;
            this.descripcion_competencia = descripcion_competencia;
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

        public string Descripcion_competencia
        {
            get { return descripcion_competencia; }
            set { descripcion_competencia = value; }
        }
    }
}