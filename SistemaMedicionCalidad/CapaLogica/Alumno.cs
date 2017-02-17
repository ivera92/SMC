﻿using System;
using Project.CapaDeNegocios;

namespace Project
{
    public class Alumno
    {
        string rut_alumno;
        Escuela escuela_alumno;
        string correo_alumno;
        string nombre_alumno;
        DateTime fecha_nacimiento_alumno;
        string direccion_alumno;
        int telefono_alumno;
        Pais pais_alumno;
        bool sexo_alumno;
        int promocion_alumno;
        bool beneficio_alumno;

        public Alumno()
        {
        }
        public Alumno(string nombre_alumno, string rut_alumno, Escuela escuela_alumno, int promocion_alumno)
        {
            this.rut_alumno = rut_alumno;
            this.escuela_alumno = escuela_alumno;
            this.nombre_alumno = nombre_alumno;
            this.promocion_alumno = promocion_alumno;
        }

        public Alumno(string rut_alumno, Escuela escuela_alumno, Pais pais_alumno, string nombre_alumno, DateTime fecha_nacimiento_alumno, string direccion_alumno, int telefono_alumno, bool sexo_alumno, string correo_alumno, int promocion_alumno, bool beneficio_alumno)
        {
            this.rut_alumno = rut_alumno;
            this.escuela_alumno = escuela_alumno;
            this.nombre_alumno = nombre_alumno;
            this.fecha_nacimiento_alumno = fecha_nacimiento_alumno;
            this.direccion_alumno = direccion_alumno;
            this.telefono_alumno = telefono_alumno;
            this.pais_alumno = pais_alumno;
            this.sexo_alumno = sexo_alumno;
            this.correo_alumno = correo_alumno;
            this.promocion_alumno = promocion_alumno;
            this.beneficio_alumno = beneficio_alumno;
        }

        public string Rut_alumno
        {
            get { return rut_alumno; }
            set { rut_alumno = value; }
        }
        
        public string Nombre_alumno
        {
            get { return nombre_alumno; }
            set { nombre_alumno = value; }
        }
        
        public DateTime Fecha_nacimiento_alumno
        {
            get { return fecha_nacimiento_alumno; }
            set { fecha_nacimiento_alumno = value; }
        }
        
        public string Direccion_alumno
        {
            get { return direccion_alumno; }
            set { direccion_alumno = value; }
        }
        
        public int Telefono_alumno
        {
            get { return telefono_alumno; }
            set { telefono_alumno = value; }
        }
        public bool Sexo_alumno
        {
            get { return sexo_alumno; }
            set { sexo_alumno = value; }
        }

        public string Correo_alumno
        {
            get { return correo_alumno; }
            set { correo_alumno = value; }
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

        public Pais Pais_alumno
        {
            get { return pais_alumno; }
            set { pais_alumno = value; }
        }
    }
}
