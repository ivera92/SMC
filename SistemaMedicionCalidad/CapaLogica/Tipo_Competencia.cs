namespace Project
{
    public class Tipo_Competencia
    {
        private int id_tipo_competencia;
        private string nombre_tipo_competencia;

        public Tipo_Competencia() { }

        public Tipo_Competencia(string nombre_tipo_competencia)
        {
            this.nombre_tipo_competencia = nombre_tipo_competencia;
        }

        public Tipo_Competencia(int id_tipo_competencia, string nombre_tipo_competencia)
        {
            this.id_tipo_competencia = id_tipo_competencia;
            this.nombre_tipo_competencia = nombre_tipo_competencia;
        }
        public int Id_tipo_competencia
        {
            get { return id_tipo_competencia; }
            set { id_tipo_competencia = value; }
        }

        public string Nombre_tipo_competencia
        {
            get { return nombre_tipo_competencia; }
            set { nombre_tipo_competencia = value; }
        }
    }
}
