
namespace Project
{
    public class Tipo_Pregunta
    {
        int id_tipo_pregunta;
        string nombre_tipo_pregunta;

        public Tipo_Pregunta()
        {
        }
        public Tipo_Pregunta(string nombre_tipo_pregunta)
        {
            this.Nombre_tipo_pregunta = nombre_tipo_pregunta;
        }

        public Tipo_Pregunta(int id_tipo_pregunta, string nombre_tipo_pregunta)
        {
            this.id_tipo_pregunta = id_tipo_pregunta;
            this.nombre_tipo_pregunta = nombre_tipo_pregunta;
        }

        public int Id_tipo_pregunta
        {
            get { return id_tipo_pregunta; }
            set { id_tipo_pregunta = value; }
        }

        public string Nombre_tipo_pregunta
        {
            get { return nombre_tipo_pregunta; }
            set { nombre_tipo_pregunta = value; }
        }
    }
}
