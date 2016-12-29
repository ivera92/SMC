using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Pregunta
    {
        int id_pregunta;
        int id_competencia_pregunta;
        int id_tipo_pregunta_pregunta;
        string nombre_pregunta;

        public Pregunta(int id_competencia_pregunta, int id_tipo_pregunta_pregunta, string nombre_pregunta)
        {
            this.id_competencia_pregunta = id_competencia_pregunta;
            this.id_tipo_pregunta_pregunta = id_tipo_pregunta_pregunta;
            this.nombre_pregunta = nombre_pregunta;
        }

        public int Id_pregunta
        {
            get{ return id_pregunta; }
            set{ id_pregunta = value; }
        }

        public int Id_competencia_pregunta
        {
            get { return id_competencia_pregunta; }
            set { id_competencia_pregunta = value; }
        }

        public int Id_tipo_pregunta_pregunta
        {
            get { return id_tipo_pregunta_pregunta; }
            set { id_tipo_pregunta_pregunta = value; }
        }

        public string Nombre_pregunta
        {
            get { return nombre_pregunta; }
            set { nombre_pregunta = value; }
        }
    }
}
