namespace Project
{
    public class Competencia_Desempeno
    {
        private int id_cd;
        private Desempeno id_desempeno;
        private Competencia id_competencia;

        public Competencia_Desempeno() { }
        
        public Competencia_Desempeno(Desempeno id_desempeno, Competencia id_competencia)
        {
            this.id_desempeno = id_desempeno;
            this.id_competencia = id_competencia;
        }

        public Competencia_Desempeno(int id_cd, Desempeno id_desempeno, Competencia id_competencia)
        {
            this.id_cd = id_cd;
            this.id_desempeno = id_desempeno;
            this.id_competencia = id_competencia;
        }

        public int Id_cd
        {
            get { return id_cd; }
            set { id_cd = value; }
        }

        public Desempeno Id_desempeno
        {
            get { return id_desempeno; }
            set { id_desempeno = value; }
        }

        public Competencia Id_competencia
        {
            get { return id_competencia; }
            set { id_competencia = value; }
        }               
    }
}
