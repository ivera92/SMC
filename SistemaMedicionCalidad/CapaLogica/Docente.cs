using System;
using Project.CapaDeNegocios;

namespace Project
{
    //Clase con Herencia
    public class Docente:Persona
    {
        private Profesion profesion_docente;
        private bool disponibilidad_docente;

        //Constructor predeterminado
        public Docente()
        {
        }

        public Docente(string nombre_docente, string rut_docente, Profesion profesion_docente)
        {
            this.Nombre_persona = nombre_docente;
            this.Rut_persona = rut_docente;
            this.profesion_docente = profesion_docente;
        }

        public Docente(string rut_docente, Profesion profesion_docente, Pais pais_docente, string nombre_docente, DateTime fecha_nacimiento_docente, string direccion_docente, int telefono_docente, bool sexo_docente, string correo_docente, bool disponibilidad_docente)
        {
            this.Rut_persona = rut_docente;
            this.profesion_docente = profesion_docente;
            this.Nombre_persona = nombre_docente;
            this.Fecha_nacimiento_persona = fecha_nacimiento_docente;
            this.Direccion_persona = direccion_docente;
            this.Telefono_persona = telefono_docente;
            this.Pais_persona = pais_docente;
            this.Sexo_persona = sexo_docente;
            this.Correo_persona = correo_docente;
            this.disponibilidad_docente = disponibilidad_docente;
        }

        public bool Disponibilidad_docente
        {
            get { return disponibilidad_docente; }
            set { disponibilidad_docente = value; }
        }

        public Profesion Profesion_docente
        {
            get { return profesion_docente; }
            set { profesion_docente = value; }
        }
    }
}
