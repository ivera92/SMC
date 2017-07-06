namespace Project
{
    public class Desempeno
    {
        private int id_desempeno;
        private string nombre_desempeno;
        private string indicador_desempeno;

        private string nombre_nivel;   //para mostrar en gridview en los resultados dependiendo la evaluacion

        //Contructor predeterminado
        public Desempeno() { }

        //Constructor para crear
        public Desempeno(string indicador_desempeno)
        {
            this.indicador_desempeno = indicador_desempeno;
        }

        //Contructor para mostrar en dropdown
        public Desempeno(int id_desempeno, string indicador_desempeno)
        {
            this.id_desempeno = id_desempeno;
            this.indicador_desempeno = indicador_desempeno;
        }

        //Contructor para mostrar desempeños con niveles dependiendo la evaluacion con sus resultados
        public Desempeno(int id_desempeno, string indicador_desempeno, string nombre_nivel)
        {
            this.id_desempeno = id_desempeno;
            this.indicador_desempeno = indicador_desempeno;
            this.nombre_nivel = nombre_nivel;
        }
        //Contructor para mostrar desempeños con niveles dependiendo la evaluacion con sus resultados
        public Desempeno(string nombre_desempeno, string indicador_desempeno, string nombre_nivel)
        {
            this.nombre_desempeno = nombre_desempeno;
            this.indicador_desempeno = indicador_desempeno;
            this.nombre_nivel = nombre_nivel;
        }

        public int Id_desempeno
        {
            get { return id_desempeno; }
            set { id_desempeno = value; }
        }

        public string Indicador_desempeno
        {
            get { return indicador_desempeno; }
            set { indicador_desempeno = value; }
        }

        public string Nombre_nivel
        {
            get
            {
                return nombre_nivel;
            }

            set
            {
                nombre_nivel = value;
            }
        }

        public string Nombre_desempeno
        {
            get
            {
                return nombre_desempeno;
            }

            set
            {
                nombre_desempeno = value;
            }
        }
    }
}
