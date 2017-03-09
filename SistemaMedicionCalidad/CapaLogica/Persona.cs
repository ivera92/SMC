using System;

namespace Project
{
    public class Persona
    {
        private string rut_persona;
        private Pais pais_persona;
        private string nombre_persona;
        private DateTime fecha_nacimiento_persona;
        private string direccion_persona;
        private int telefono_persona;
        private bool sexo_persona;
        private string correo_persona;

        public Persona()
        {
        }

        public Persona(string rut_persona, Pais pais_persona, string nombre_persona, DateTime fecha_nacimiento_persona, string direccion_persona, int telefono_persona, bool sexo_persona, string correo_persona)
        {
            this.rut_persona = rut_persona;
            this.pais_persona = pais_persona;
            this.nombre_persona = nombre_persona;
            this.fecha_nacimiento_persona = fecha_nacimiento_persona;
            this.direccion_persona = direccion_persona;
            this.telefono_persona = telefono_persona;
            this.sexo_persona = sexo_persona;
            this.correo_persona = correo_persona;
        }

        public string Rut_persona
        {
            get { return rut_persona; }
            set { rut_persona = value; }
        }

        public Pais Pais_persona
        {
            get { return pais_persona; }
            set { pais_persona = value; }
        }

        public string Nombre_persona
        {
            get { return nombre_persona; }
            set { nombre_persona = value; }
        }

        public DateTime Fecha_nacimiento_persona
        {
            get { return fecha_nacimiento_persona; }
            set { fecha_nacimiento_persona = value; }
        }

        public string Direccion_persona
        {
            get { return direccion_persona; }
            set { direccion_persona = value; }
        }

        public int Telefono_persona
        {
            get { return telefono_persona; }
            set { telefono_persona = value; }
        }

        public bool Sexo_persona
        {
            get { return sexo_persona; }
            set { sexo_persona = value; }
        }

        public string Correo_persona
        {
            get { return correo_persona; }
            set { correo_persona = value; }
        }
    }
}
