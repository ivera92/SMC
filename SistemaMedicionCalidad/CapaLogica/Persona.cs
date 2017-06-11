namespace Project
{
    public class Persona
    {
        private string rut_persona;
        private string nombre_persona;
        private string correo_persona;

        //Constructor predeterminado
        public Persona()
        {
        }

        public Persona(string rut_persona, string nombre_persona, string correo_persona)
        {
            this.rut_persona = rut_persona;
            this.nombre_persona = nombre_persona;
            this.correo_persona = correo_persona;
        }

        public string Rut_persona
        {
            get { return rut_persona; }
            set { rut_persona = value; }
        }

        public string Nombre_persona
        {
            get { return nombre_persona; }
            set { nombre_persona = value; }
        }

        public string Correo_persona
        {
            get { return correo_persona; }
            set { correo_persona = value; }
        }
    }
}
