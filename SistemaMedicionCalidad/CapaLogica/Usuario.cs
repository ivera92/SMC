using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Usuario
    {
        string rut_usuario;
        Tipo_Usuario tipo_usuario_usuario;
        string nombre_usuario;
        string contrasena;
        

        public Usuario(string rut_usuario, Tipo_Usuario tipo_usuario_usuario, string nombre_usuario, string contrasena)
        {
            this.rut_usuario = rut_usuario;
            this.tipo_usuario_usuario = tipo_usuario_usuario;
            this.nombre_usuario = nombre_usuario;
            this.contrasena = contrasena;  
        }

        public string Rut_usuario
        {
            get { return rut_usuario; }
            set { rut_usuario = value; }
        }

        public Tipo_Usuario Tipo_usuario_usuario
        {
            get { return tipo_usuario_usuario; }
            set { tipo_usuario_usuario = value; }
        }

        public string Nombre_usuario
        {
            get { return nombre_usuario; }
            set { nombre_usuario = value; }
        }

        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }
    }
}