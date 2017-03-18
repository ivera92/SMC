namespace Project
{
    public class HistoricoPruebaAlumno
    {
        private int id_hpa;
        private Evaluacion evaluacion_hpa;
        private Respuesta respuesta_hpa;
        private Pregunta pregunta_hpa;
        private Alumno alumno_hpa;

        //Constructor predeterminado
        public HistoricoPruebaAlumno()
        {
        }

        public HistoricoPruebaAlumno(Evaluacion evaluacion_hpa, Respuesta respuesta_hpa, Pregunta pregunta_hpa, Alumno alumno_hpa)
        {
            this.evaluacion_hpa = evaluacion_hpa;
            this.respuesta_hpa = respuesta_hpa;
            this.pregunta_hpa = pregunta_hpa;
            this.alumno_hpa = alumno_hpa;
        }
        public int Id_hpa 
        {
            get { return id_hpa; }
            set { id_hpa = value; }
        }

        public Evaluacion Evaluacion_hpa
        {
            get { return evaluacion_hpa; }
            set { evaluacion_hpa = value; }
        }

        public Respuesta Respuesta_hpa
        {
            get { return respuesta_hpa; }
            set { respuesta_hpa = value; }
        }

        public Pregunta Pregunta_hpa
        {
            get { return pregunta_hpa; }
            set { pregunta_hpa = value; }
        }

        public Alumno Alumno_hpa
        {
            get { return alumno_hpa; }
            set { alumno_hpa = value; }
        }
    }
}
