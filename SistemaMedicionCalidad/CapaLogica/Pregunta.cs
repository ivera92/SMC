namespace Project
{
    public class Pregunta
    {
        private int id_pregunta;
        private Competencia competencia_pregunta;
        private Tipo_Pregunta tipo_pregunta_pregunta;
        private string enunciado_pregunta;
        private string imagen_pregunta;
        private char nivel_pregunta; 

        //Constructor predeterminado
        public Pregunta()
        {
        }

        public Pregunta(Competencia competencia_pregunta, Tipo_Pregunta tipo_pregunta_pregunta, string enunciado_pregunta, string imagen_pregunta)
        {
            this.competencia_pregunta = competencia_pregunta;
            this.tipo_pregunta_pregunta = tipo_pregunta_pregunta;
            this.enunciado_pregunta = enunciado_pregunta;
            this.imagen_pregunta = imagen_pregunta;
        }

        public Pregunta(int id_pregunta, Competencia competencia_pregunta, Tipo_Pregunta tipo_pregunta_pregunta, string enunciado_pregunta)
        {
            this.id_pregunta = id_pregunta;
            this.competencia_pregunta = competencia_pregunta;
            this.tipo_pregunta_pregunta = tipo_pregunta_pregunta;
            this.enunciado_pregunta = enunciado_pregunta;
        }
        public Pregunta(Competencia competencia_pregunta, Tipo_Pregunta tipo_pregunta_pregunta, string enunciado_pregunta, string imagen_pregunta, char nivel_pregunta)
        {
            this.competencia_pregunta = competencia_pregunta;
            this.tipo_pregunta_pregunta = tipo_pregunta_pregunta;
            this.enunciado_pregunta = enunciado_pregunta;
            this.imagen_pregunta = imagen_pregunta;
            this.nivel_pregunta = nivel_pregunta;
        }

        public int Id_pregunta
        {
            get{ return id_pregunta; }
            set{ id_pregunta = value; }
        }

        public Competencia Competencia_pregunta
        {
            get { return competencia_pregunta; }
            set { competencia_pregunta = value; }
        }

        public Tipo_Pregunta Tipo_pregunta_pregunta
        {
            get { return tipo_pregunta_pregunta; }
            set { tipo_pregunta_pregunta = value; }
        }

        public string Enunciado_pregunta
        {
            get { return enunciado_pregunta; }
            set { enunciado_pregunta = value; }
        }

        public string Imagen_pregunta
        {
            get { return imagen_pregunta; }
            set { imagen_pregunta = value; }
        }

        public char Nivel_pregunta
        {
            get { return nivel_pregunta; }
            set { nivel_pregunta = value; }
        }
    }
}
