using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Usuario
    {
        string rut_usuario;
        string contrasena;
        int id_tipo_usuario;

        public Usuario(string rut_usuario, string contrasena, int id_tipo_usuario)
        {
            this.rut_usuario = rut_usuario;
            this.contrasena = contrasena;
            this.id_tipo_usuario = id_tipo_usuario;
        }

        public string Rut_usuario
        {
            get { return rut_usuario; }
            set { rut_usuario = value; }
        }
        
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public int Id_tipo_usuario
        {
            get { return id_tipo_usuario; }
            set { id_tipo_usuario = value; }
        }

    }
}