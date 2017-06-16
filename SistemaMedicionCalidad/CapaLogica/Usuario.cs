namespace Project
{
    public class Usuario
    {
        private string nombre_usuario;
        private Tipo_Usuario tipo_usuario_usuario;        
        private string contrasena_usuario;
        private string correo_usuario;
        private bool activo_usuario;

        private string estado;

        //Constructor predeterminado
        public Usuario()
        {
        }

        public Usuario(string nombre_usuario, Tipo_Usuario tipo_usuario_usuario, string contrasena_usuario, string correo_usuario, bool activo_usuario)
        {
            this.activo_usuario = activo_usuario;
            this.nombre_usuario = nombre_usuario;
            this.tipo_usuario_usuario = tipo_usuario_usuario;
            this.contrasena_usuario = contrasena_usuario;
            this.correo_usuario = correo_usuario;
        }

        public Usuario(string nombre_usuario, Tipo_Usuario tipo_usuario_usuario, string correo_usuario, bool activo_usuario)
        {
            this.activo_usuario = activo_usuario;
            this.nombre_usuario = nombre_usuario;
            this.tipo_usuario_usuario = tipo_usuario_usuario;
            this.correo_usuario = correo_usuario;
        }

        public Usuario(string nombre_usuario, Tipo_Usuario tipo_usuario_usuario, string correo_usuario, string estado)
        {
            this.estado = estado;
            this.nombre_usuario = nombre_usuario;
            this.tipo_usuario_usuario = tipo_usuario_usuario;
            this.correo_usuario = correo_usuario;
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

        public string Contrasena_usuario
        {
            get { return contrasena_usuario; }
            set { contrasena_usuario = value; }
        }

        public string Correo_usuario
        {
            get { return correo_usuario; }
            set { correo_usuario = value; }
        }

        public bool Activo_usuario
        {
            get { return activo_usuario; }
            set { activo_usuario = value; }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
    }
}