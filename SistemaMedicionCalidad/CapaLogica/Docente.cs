using System;
using Project.CapaDeNegocios;

namespace Project
{
    public class Docente
    {
        string rut_docente;
        Profesion profesion_docente;
        string nombre_docente;
        DateTime fecha_nacimiento_docente;
        string direccion_docente;
        int telefono_docente;
        Pais pais_docente;
        bool sexo_docente;
        string correo_docente;
        bool disponibilidad_docente;

        public Docente()
        {

        }
        public Docente(string nombre_docente, string rut_docente, Profesion profesion_docente)
        {
            this.nombre_docente = nombre_docente;
            this.rut_docente = rut_docente;
            this.profesion_docente = profesion_docente;
        }

        public Docente(string rut_docente, Profesion profesion_docente, Pais pais_docente, string nombre_docente, DateTime fecha_nacimiento_docente, string direccion_docente, int telefono_docente, bool sexo_docente, string correo_docente, bool disponibilidad_docente)
        {
            this.rut_docente = rut_docente;
            this.profesion_docente = profesion_docente;
            this.nombre_docente = nombre_docente;
            this.fecha_nacimiento_docente = fecha_nacimiento_docente;
            this.direccion_docente = direccion_docente;
            this.telefono_docente = telefono_docente;
            this.pais_docente = pais_docente;
            this.sexo_docente = sexo_docente;
            this.correo_docente = correo_docente;
            this.disponibilidad_docente = disponibilidad_docente;
        }

        public string Rut_docente
        {
            get { return rut_docente; }
            set { rut_docente = value; }
        }
        
        
        public string Nombre_docente
        {
            get { return nombre_docente; }
            set { nombre_docente = value; }
        }

        public DateTime Fecha_nacimiento_docente
        {
            get { return fecha_nacimiento_docente; }
            set { fecha_nacimiento_docente = value; }
        }
        
        public string Direccion_docente
        {
            get { return direccion_docente; }
            set { direccion_docente = value; }
        }

        public int Telefono_docente
        {
            get { return telefono_docente; }
            set { telefono_docente = value; }
        }

        public bool Sexo_docente
        {
            get { return sexo_docente; }
            set { sexo_docente = value; }
        }

        public string Correo_docente
        {
            get { return correo_docente; }
            set { correo_docente = value; }
        }

        public bool Disponibilidad_docente
        {
            get { return disponibilidad_docente; }
            set { disponibilidad_docente = value; }
        }

        public Pais Pais_docente
        {
            get { return pais_docente; }
            set { pais_docente = value; }
        }

        public Profesion Profesion_docente
        {
            get { return profesion_docente; }
            set { profesion_docente = value; }
        }
    }
}
