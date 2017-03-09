using System;
using Project.CapaDeNegocios;

namespace Project
{
    //Clase con Herencia
    public class Alumno:Persona
    {
        private Escuela escuela_alumno;
        private int promocion_alumno;
        private bool beneficio_alumno;

        //Constructor predeterminado
        public Alumno()
        {
        }

        public Alumno(string nombre_alumno, string rut_alumno, Escuela escuela_alumno, int promocion_alumno)
        {
            Nombre_persona = nombre_alumno;
            Rut_persona = rut_alumno;
            this.escuela_alumno = escuela_alumno;
            this.promocion_alumno = promocion_alumno;
        }

        public Alumno(string rut_alumno, Escuela escuela_alumno, Pais pais_alumno, string nombre_alumno, DateTime fecha_nacimiento_alumno, string direccion_alumno, int telefono_alumno, bool sexo_alumno, string correo_alumno, int promocion_alumno, bool beneficio_alumno)
        {
            //Atributos heredados
            this.Rut_persona = rut_alumno;
            this.Nombre_persona = nombre_alumno;
            this.Fecha_nacimiento_persona = fecha_nacimiento_alumno;
            this.Direccion_persona = direccion_alumno;
            this.Telefono_persona = telefono_alumno;
            this.Pais_persona = pais_alumno;
            this.Sexo_persona = sexo_alumno;
            this.Correo_persona = correo_alumno;

            //Atributos propios
            this.escuela_alumno = escuela_alumno;
            this.promocion_alumno = promocion_alumno;
            this.beneficio_alumno = beneficio_alumno;
        }

        public int Promocion_alumno
        {
            get { return promocion_alumno; }
            set { promocion_alumno = value; }
        }

        public bool Beneficio_alumno
        {
            get { return beneficio_alumno; }
            set { beneficio_alumno = value; }
        }

        public Escuela Escuela_alumno
        {
            get { return escuela_alumno; }
            set { escuela_alumno = value; }
        }
    }
}