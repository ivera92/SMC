namespace Project
{
    public class Ambito
    {
        private int id_ambito;
        private string nombre_ambito;

        public Ambito() { }

        public Ambito(string nombre_ambito)
        {
            this.nombre_ambito = nombre_ambito;
        }

        public Ambito(int id_ambito, string nombre_ambito)
        {
            this.id_ambito = id_ambito;
            this.nombre_ambito = nombre_ambito;
        }

        public int Id_ambito
        {
            get { return id_ambito; }
            set { id_ambito = value; }
        }

        public string Nombre_ambito
        {
            get { return nombre_ambito; }
            set { nombre_ambito = value; }
        }
    }
}
