namespace Project
{
    public class Asignatura_Competencia
    {
        private int id_ac;
        private Asignatura asignatura_ac;
        private Competencia competencia_ac;
        private char nivel_dominio;

        //Constructor predeterminado
        public Asignatura_Competencia()
        {
        }

        public Asignatura_Competencia(Asignatura asignatura_ac, Competencia competencia_ac, char nivel_dominio)
        {
            this.asignatura_ac = asignatura_ac;
            this.competencia_ac = competencia_ac;
            this.nivel_dominio = nivel_dominio;
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

        public char Nivel_dominio
        {
            get { return nivel_dominio; }
            set { nivel_dominio = value; }
        }
    }
}
