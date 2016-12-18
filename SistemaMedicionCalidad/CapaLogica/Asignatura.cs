using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Asignatura
    {
        int id_asignatura;
        int id_escuela_asignatura;
        string rut_docente_asignatura;
        string nombre_asignatura;
        int ano_asignatura;
        bool duracion_asignatura;


        public Asignatura(int id_escuela_asignatura, string rut_docente_asignatura, string nombre_asignatura, int ano_asignatura, bool duracion_asignatura)
        {
            this.id_escuela_asignatura = id_escuela_asignatura;
            this.rut_docente_asignatura = rut_docente_asignatura;
            this.nombre_asignatura = nombre_asignatura;
            this.ano_asignatura = ano_asignatura;
            this.duracion_asignatura = duracion_asignatura;
        }

        public Asignatura(int id_asignatura, int id_escuela_asignatura, string rut_docente_asignatura, string nombre_asignatura, int ano_asignatura, bool duracion_asignatura)
        {
            this.id_asignatura = id_asignatura;
            this.id_escuela_asignatura = id_escuela_asignatura;
            this.rut_docente_asignatura = rut_docente_asignatura;
            this.nombre_asignatura = nombre_asignatura;
            this.ano_asignatura = ano_asignatura;
            this.duracion_asignatura = duracion_asignatura;
        }

        public int Id_asignatura
        {
            get { return id_asignatura; }
            set { id_asignatura = value; }
        }
        
        public int Id_escuela_asignatura
        {
            get { return id_escuela_asignatura; }
            set { id_escuela_asignatura = value; }
        }

        public string Rut_docente_asignatura
        {
            get { return rut_docente_asignatura; }
            set { rut_docente_asignatura = value; }
        }

        public string Nombre_asignatura
        {
            get { return nombre_asignatura; }
            set { nombre_asignatura = value; }
        }

        public int Ano_asignatura
        {
            get { return ano_asignatura; }
            set { ano_asignatura = value; }
        }

        public bool Duracion_asignatura
        {
            get { return duracion_asignatura; }
            set { duracion_asignatura = value; }
        }
    }
}
