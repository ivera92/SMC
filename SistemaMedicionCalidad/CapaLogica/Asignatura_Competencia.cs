namespace Project
{
    public class Asignatura_Competencia
    {
        private int id_ac;
        private Asignatura asignatura_ac;
        private Competencia competencia_ac;

        //Constructor predeterminado
        public Asignatura_Competencia()
        {
        }

        public Asignatura_Competencia(Asignatura asignatura_ac, Competencia competencia_ac)
        {
            this.asignatura_ac = asignatura_ac;
            this.competencia_ac = competencia_ac;
        }

        public int Id_ac
        {
            get { return id_ac; }
            set { id_ac = value; }
        }

        public Asignatura Asignatura_ac
        {
            get { return asignatura_ac; }
            set { asignatura_ac = value; }
        }

        public Competencia Competencia_ac
        {
            get { return competencia_ac; }
            set { competencia_ac = value; }
        }
    }
}
