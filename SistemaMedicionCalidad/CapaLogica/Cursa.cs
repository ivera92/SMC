namespace Project
{
    public class Cursa
    {
        private int id_aa;
        private Alumno rut_alumno_aa;
        private Asignatura cod_asignatura_aa;
        private string ano_asignatura;

        public Cursa() { }

        public Cursa(string ano_asignatura)
        {
            this.ano_asignatura = ano_asignatura;
        }
        public Cursa(Alumno rut_alumno_aa, Asignatura cod_asignatura_aa, string ano_asignatura)
        {
            this.rut_alumno_aa = rut_alumno_aa;
            this.cod_asignatura_aa = cod_asignatura_aa;
            this.ano_asignatura = ano_asignatura;
        }

        public Cursa(int id_aa, Alumno rut_alumno_aa, Asignatura cod_asignatura_aa, string ano_asignatura)
        {
            this.id_aa = id_aa;
            this.rut_alumno_aa = rut_alumno_aa;
            this.cod_asignatura_aa = cod_asignatura_aa;
            this.ano_asignatura = ano_asignatura;
        }
        public Alumno Rut_alumno_aa
        {
            get { return rut_alumno_aa; }
            set { rut_alumno_aa = value; }
        }

        public Asignatura Cod_asignatura_aa
        {
            get { return cod_asignatura_aa; }
            set { cod_asignatura_aa = value; }
        }

        public int Id_aa
        {
            get { return id_aa; }
            set { id_aa = value; }
        }

        public string Ano_asignatura
        {
            get { return ano_asignatura; }
            set { ano_asignatura = value; }
        }
    }
}
