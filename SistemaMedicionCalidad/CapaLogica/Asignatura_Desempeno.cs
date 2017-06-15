namespace Project
{
    public class Asignatura_Desempeno
    {
        private int id_ad;
        private Asignatura cod_asignatura;
        private Desempeno id_desempeno;
        private Nivel id_nivel;

        public Asignatura_Desempeno() { }

        public Asignatura_Desempeno(Asignatura cod_asignatura, Desempeno id_desempeno, Nivel id_nivel)
        {
            this.cod_asignatura = cod_asignatura;
            this.id_desempeno = id_desempeno;
            this.id_nivel = id_nivel;
        }

        public Asignatura_Desempeno(int id_ad, Asignatura cod_asignatura, Desempeno id_desempeno, Nivel id_nivel)
        {
            this.id_ad = id_ad;
            this.cod_asignatura = cod_asignatura;
            this.id_desempeno = id_desempeno;
            this.id_nivel = id_nivel;
        }

        public int Id_ad
        {
            get { return id_ad; }
            set { id_ad = value; }
        }

        public Asignatura Cod_asignatura
        {
            get { return cod_asignatura; }
            set { cod_asignatura = value; }
        }

        public Desempeno Id_desempeno
        {
            get { return id_desempeno; }
            set { id_desempeno = value; }
        }

        public Nivel Id_nivel
        {
            get { return id_nivel; }
            set { id_nivel = value; }
        }
    }
}
