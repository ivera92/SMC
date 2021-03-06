﻿namespace Project
{
    public class Tipo_Usuario
    {
        private int id_tipo_usuario;
        private string nombre_tipo_usuario;

        //Constructor predeterminado
        public Tipo_Usuario()
        {
        }
        public Tipo_Usuario(int id_tipo_usuario, string nombre_tipo_usuario)
        {
            this.id_tipo_usuario = id_tipo_usuario;
            this.nombre_tipo_usuario = nombre_tipo_usuario;
        }

        public int Id_tipo_usuario
        {
            get { return id_tipo_usuario; }
            set { id_tipo_usuario = value; }
        }

        public string Nombre_tipo_usuario
        {
            get { return nombre_tipo_usuario; }
            set { nombre_tipo_usuario = value; }
        }
    }
}
