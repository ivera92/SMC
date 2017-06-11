using System;
using Project.CapaDeNegocios;

namespace Project
{
    //Clase con Herencia
    public class Alumno:Persona
    {
        private int promocion_alumno;

        //Constructor predeterminado
        public Alumno()
        {
        }
        //Constructor que recibe los datos mediante Excel (importados)
        public Alumno(string rut_alumno, string nombre_alumno, string correo_alumno)
        {
            this.Rut_persona = rut_alumno;
            this.Nombre_persona = nombre_alumno;
            this.Correo_persona = correo_alumno;
        }
        //Constructor usado para la creacion de alumnos mediante el sistema web
        public Alumno(string rut_alumno, string nombre_alumno, string correo_alumno, int promocion_alumno)
        {
            //Atributos heredados
            this.Rut_persona = rut_alumno;
            this.Nombre_persona = nombre_alumno;
            this.Correo_persona = correo_alumno;

            //Atributos propios
            this.promocion_alumno = promocion_alumno;
        }

        public int Promocion_alumno
        {
            get { return promocion_alumno; }
            set { promocion_alumno = value; }
        }
    }
}