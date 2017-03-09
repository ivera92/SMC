namespace Project
{
    public class Pais
    {
        private string nombre_pais;
        private int id_pais;

        public Pais()
        {
        }

        public Pais (string nombre_pais)
        {
            this.nombre_pais = nombre_pais;
        }

        public Pais(int id_pais, string nombre_pais)
        {
            this.nombre_pais = nombre_pais;
            this.id_pais = id_pais;
        }

        public string Nombre_pais
        {
            get { return nombre_pais; }
            set { nombre_pais = value; }
        }

        public int Id_pais
        {
            get { return id_pais; }
            set { id_pais = value; }
        }
    }
}
