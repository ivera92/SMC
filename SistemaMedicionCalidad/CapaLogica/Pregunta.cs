﻿namespace Project
{
    public class Pregunta
    {
        private int id_pregunta;
        private Desempeno id_desempeno;
        private Tipo_Pregunta tipo_pregunta_pregunta;
        private string enunciado_pregunta;
        private string imagen_pregunta;
        private Nivel nivel_pregunta;

        private string estado;

        //Constructor predeterminado
        public Pregunta()
        {
        }

        public Pregunta(Desempeno id_desempeno, Tipo_Pregunta tipo_pregunta_pregunta, string enunciado_pregunta, string imagen_pregunta, Nivel nivel_pregunta)
        {
            this.Id_desempeno = id_desempeno;
            this.tipo_pregunta_pregunta = tipo_pregunta_pregunta;
            this.enunciado_pregunta = enunciado_pregunta;
            this.imagen_pregunta = imagen_pregunta;
            this.nivel_pregunta = nivel_pregunta;
        }

        public Pregunta(int id_pregunta, Desempeno id_desempeno, Tipo_Pregunta tipo_pregunta_pregunta, string enunciado_pregunta, string imagen_pregunta, Nivel nivel_pregunta, string estado)
        {
            this.id_pregunta = id_pregunta;
            this.id_desempeno = id_desempeno;
            this.tipo_pregunta_pregunta = tipo_pregunta_pregunta;
            this.enunciado_pregunta = enunciado_pregunta;
            this.imagen_pregunta = imagen_pregunta;
            this.nivel_pregunta = nivel_pregunta;
            this.estado = estado;
        }

        public int Id_pregunta
        {
            get{ return id_pregunta; }
            set{ id_pregunta = value; }
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

        public Desempeno Id_desempeno
        {
            get { return id_desempeno; }
            set { id_desempeno = value; }
        }

        public Nivel Nivel_pregunta
        {
            get { return nivel_pregunta; }
            set { nivel_pregunta = value; }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
    }
}
