
namespace Project
{
    public class Desempeno
    {
        private int id_desempeno;
        private string indicador_desempeno;

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
    }
}
