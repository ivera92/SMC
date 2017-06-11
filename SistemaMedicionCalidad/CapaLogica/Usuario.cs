namespace Project
{
    public class Usuario
    {
        private string nombre_usuario;
        private Tipo_Usuario tipo_usuario_usuario;        
        private string contrasena_usuario;
        private string correo_usuario;

        //Constructor predeterminado
        public Usuario()
        {
        }
        public Usuario(string nombre_usuario, Tipo_Usuario tipo_usuario_usuario, string contrasena_usuario, string correo_usuario)
        {
            this.nombre_usuario = nombre_usuario;
            this.tipo_usuario_usuario = tipo_usuario_usuario;            
            this.contrasena_usuario = contrasena_usuario;
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
    }
}