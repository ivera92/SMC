namespace Project
{
    //Clase con Herencia
    public class Alumno:Persona
    {

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
    }
}