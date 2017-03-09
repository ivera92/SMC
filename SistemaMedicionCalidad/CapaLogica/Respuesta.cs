namespace Project
{
    public class Respuesta
    {
        private int id_respuesta;
        private Pregunta pregunta_respuesta;
        private string nombre_respuesta;
        private bool correcta_respuesta;

        public Respuesta()
        {
        }

        public Respuesta (Pregunta pregunta_respuesta, string nombre_respuesta, bool correcta_respuesta)
        {
            this.pregunta_respuesta = pregunta_respuesta;
            this.nombre_respuesta = nombre_respuesta;
            this.correcta_respuesta = correcta_respuesta;
        }

        public int Id_respuesta
        {
            get { return id_respuesta; }
            set { id_respuesta = value; }
        }

        public Pregunta Pregunta_respuesta
        {
            get { return pregunta_respuesta; }
            set { pregunta_respuesta = value; }
        }

        public string Nombre_respuesta
        {
            get { return nombre_respuesta; }
            set { nombre_respuesta = value; }
        }

        public bool Correcta_respuesta
        {
            get { return correcta_respuesta; }
            set { correcta_respuesta = value; }
        }
    }
}
