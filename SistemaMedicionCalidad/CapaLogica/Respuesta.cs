using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Respuesta
    {
        int id_respuesta;
        int id_pregunta_respuesta;
        string nombre_respuesta;
        bool correcta_respuesta;

        public Respuesta (int id_pregunta_respuesta, string nombre_respuesta, bool correcta_respuesta)
        {
            this.id_pregunta_respuesta = id_pregunta_respuesta;
            this.nombre_respuesta = nombre_respuesta;
            this.correcta_respuesta = correcta_respuesta;
        }

        public int Id_respuesta
        {
            get { return id_respuesta; }
            set { id_respuesta = value; }
        }

        public int Id_pregunta_respuesta
        {
            get { return id_pregunta_respuesta; }
            set { id_pregunta_respuesta = value; }
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
