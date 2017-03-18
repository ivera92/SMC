namespace Project.CapaDeNegocios
{
    public class Profesion
    {
        private int id_profesion;
        private string nombre_profesion;

        //Constructor predeterminado
        public Profesion()
        {
        }
        public Profesion(string nombre_profesion)
        {
            this.nombre_profesion = nombre_profesion;
        }

        public Profesion(int id_profesion, string nombre_profesion)
        {
            this.id_profesion = id_profesion;
            this.nombre_profesion = nombre_profesion;
        }

        public int Id_profesion
        {
            get { return id_profesion; }
            set { id_profesion = value; }
        }

        public string Nombre_profesion
        {
            get { return nombre_profesion; }
            set { nombre_profesion = value; }
        }
    }
}
