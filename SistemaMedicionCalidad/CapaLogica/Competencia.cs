namespace Project
{
    public class Competencia
    {
        private int id_competencia;
        private string nombre_competencia;
        private int tipo_competencia;
        private string descripcion_competencia;

        //Constructor predeterminado
        public Competencia()
        {
        }
        
        public Competencia(int id_competencia, string nombre_competencia)
        {
            this.id_competencia = id_competencia;
            this.nombre_competencia = nombre_competencia;
        }
        public Competencia(string nombre_competencia, int tipo_competencia, int id_competencia)
        {
            this.nombre_competencia = nombre_competencia;
            this.tipo_competencia = tipo_competencia;
            this.id_competencia = id_competencia;
        }

        public Competencia(string nombre_competencia, string descripcion_competencia, int id_competencia)
        {
            this.nombre_competencia = nombre_competencia;
            this.descripcion_competencia = descripcion_competencia;
            this.id_competencia = id_competencia;
        }

        public Competencia(string nombre_competencia, int tipo_competencia, string descripcion_competencia)
        {
            this.nombre_competencia = nombre_competencia;
            this.tipo_competencia = tipo_competencia;
            this.descripcion_competencia = descripcion_competencia;
        }

        public Competencia(int id_competencia, string nombre_competencia, int tipo_competencia, string descripcion_competencia)
        {
            this.id_competencia = id_competencia;
            this.nombre_competencia = nombre_competencia;
            this.tipo_competencia = tipo_competencia;
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

        public int Tipo_competencia
        {
            get { return tipo_competencia; }
            set { tipo_competencia = value; }
        }

        public string Descripcion_competencia
        {
            get { return descripcion_competencia; }
            set { descripcion_competencia = value; }
        }
    }
}