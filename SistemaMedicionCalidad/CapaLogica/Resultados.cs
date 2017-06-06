namespace Project
{
    public class Resultados
    {
        private Respuesta correcta_respuesta;
        private int cantidad;
        private Competencia nombre_competencia;
        private Docente rut_docente;
        private Alumno rut_alumno;
        private Evaluacion id_evaluacion_hpa;

        private string estado_respuesta;
        private string nomnbre_evaluacion;

        public Resultados()
        {

        }
        public Resultados(Respuesta correcta_respuesta, int cantidad, Competencia nombre_competencia, Docente rut_docente, Alumno rut_alumno, Evaluacion id_evaluacion_hpa)
        {
            this.correcta_respuesta = correcta_respuesta;
            this.cantidad = cantidad;
            this.nombre_competencia = nombre_competencia;
            this.rut_docente = rut_docente;
            this.rut_alumno = rut_alumno;
            this.id_evaluacion_hpa = id_evaluacion_hpa;
        }

        //Para exportar en los resultados
        public Resultados(string estado_respuesta, int cantidad, Competencia nombre_competencia, Docente rut_docente, Alumno rut_alumno, string nombre_evaluacion)
        {
            this.estado_respuesta = estado_respuesta;
            this.cantidad = cantidad;
            this.nombre_competencia = nombre_competencia;
            this.rut_docente = rut_docente;
            this.rut_alumno = rut_alumno;
            this.nomnbre_evaluacion = nombre_evaluacion;
        }

        public Respuesta Correcta_respuesta
        {
            get { return correcta_respuesta; }
            set { correcta_respuesta = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public Competencia Nombre_competencia
        {
            get { return nombre_competencia; }
            set { nombre_competencia = value; }
        }

        public Docente Rut_docente
        {
            get { return rut_docente; }
            set { rut_docente = value; }
        }

        public Alumno Rut_alumno
        {
            get { return rut_alumno; }
            set { rut_alumno = value; }
        }

        public Evaluacion Id_evaluacion_hpa
        {
            get { return id_evaluacion_hpa; }
            set { id_evaluacion_hpa = value; }
        }

        public string Estado_respuesta
        {
            get { return estado_respuesta; }
            set { estado_respuesta = value; }
        }

        public string Nomnbre_evaluacion
        {
            get { return nomnbre_evaluacion; }
            set { nomnbre_evaluacion = value; }
        }
    }
}
