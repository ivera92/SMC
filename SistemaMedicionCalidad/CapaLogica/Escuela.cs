using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.CapaDeNegocios
{
    public class Escuela
    {
        int id_escuela;
        string nombre_escuela;

        public Escuela()
        {
        }
        public Escuela(string nombre_escuela)
        {
            this.nombre_escuela = nombre_escuela;
        }

        public Escuela(int id_escuela, string nombre_escuela)
        {
            this.id_escuela = id_escuela;
            this.nombre_escuela = nombre_escuela;
        }

        public int Id_escuela
        {
            get { return id_escuela; }
            set { id_escuela = value; }
        }

        public string Nombre_escuela
        {
            get { return nombre_escuela; }
            set { nombre_escuela = value; }
        }
    }
}
