namespace Project
{
    public class Nivel
    {
        private int id_nivel;
        private Desempeno id_desempeño;
        private int numero_nivel;
        private string nombre_nivel;
        private string descripcion_nivel;

        public Nivel() { }

        public Nivel(Desempeno id_desempeno, int numero_nivel, string nombre_nivel, string descripcion_nivel)
        {
            this.id_desempeño = id_desempeno;
            this.numero_nivel = numero_nivel;
            this.nombre_nivel = nombre_nivel;
            this.descripcion_nivel = descripcion_nivel;
        }

        public Nivel(int id_nivel, Desempeno id_desempeno, int numero_nivel, string nombre_nivel, string descripcion_nivel)
        {
            this.id_nivel = id_nivel;
            this.id_desempeño = id_desempeno;
            this.numero_nivel = numero_nivel;
            this.nombre_nivel = nombre_nivel;
            this.descripcion_nivel = descripcion_nivel;
        }

        public int Id_nivel
        {
            get { return id_nivel; }
            set { id_nivel = value; }
        }

        public Desempeno Id_desempeño
        {
            get { return id_desempeño; }
            set { id_desempeño = value; }
        }

        public int Numero_nivel
        {
            get { return numero_nivel; }
            set { numero_nivel = value; }
        }

        public string Nombre_nivel
        {
            get { return nombre_nivel; }
            set { nombre_nivel = value; }
        }

        public string Descripcion_nivel
        {
            get { return descripcion_nivel; }
            set { descripcion_nivel = value; }
        }
    }
}
