namespace Project
{
    public class Asignatura_Competencia
    {
        private int id_ac;
        private Asignatura cod_asignatura_ac;
        private Competencia id_competencia_ac;
        private string nivel_dominio_ac;

        //Constructor predeterminado
        public Asignatura_Competencia()
        {
        }
        //Constructor usado para insertar registro en Asignatura_Competencia
        public Asignatura_Competencia(Asignatura cod_asignatura_ac, Competencia id_competencia_ac, string nivel_dominio_ac)
        {
            this.cod_asignatura_ac = cod_asignatura_ac;
            this.id_competencia_ac = id_competencia_ac;
            this.nivel_dominio_ac = nivel_dominio_ac;
        }
        //Constructor usado para actualizar registro en Asignatura_Competencia
        public Asignatura_Competencia(int id_ac, Asignatura cod_asignatura_ac, Competencia id_competencia_ac, string nivel_dominio_ac)
        {
            this.id_ac = id_ac;
            this.cod_asignatura_ac = cod_asignatura_ac;
            this.id_competencia_ac = id_competencia_ac;
            this.nivel_dominio_ac = nivel_dominio_ac;
        }
        public int Id_ac
        {
            get { return id_ac; }
            set { id_ac = value; }
        }

        public Asignatura Cod_Asignatura_ac
        {
            get { return cod_asignatura_ac; }
            set { cod_asignatura_ac = value; }
        }

        public Competencia Id_Competencia_ac
        {
            get { return id_competencia_ac; }
            set { id_competencia_ac = value; }
        }

        public string Nivel_dominio_ac
        {
            get { return nivel_dominio_ac; }
            set { nivel_dominio_ac = value; }
        }
    }
}
