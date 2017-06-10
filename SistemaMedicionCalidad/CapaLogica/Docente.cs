using System;
using Project.CapaDeNegocios;

namespace Project
{
    //Clase con Herencia
    public class Docente:Persona
    {
        private bool contrato_docente;

        //Constructor predeterminado
        public Docente()
        {
        }

        public Docente(string rut_docente, string nombre_docente, string correo_docente, bool contrato_docente)
        {
            this.Rut_persona = rut_docente;
            this.Nombre_persona = nombre_docente;
            this.Correo_persona = correo_docente;
            this.contrato_docente = contrato_docente;
        }

        public bool Contrato_docente
        {
            get { return contrato_docente; }
            set { contrato_docente = value; }
        }
    }
}
