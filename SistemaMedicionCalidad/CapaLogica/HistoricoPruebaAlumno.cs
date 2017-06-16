namespace Project
{
    public class HistoricoPruebaAlumno
    {
        private int id_hpa;
        private Evaluacion id_evaluacion_hpa;
        private Respuesta respuesta_hpa;
        private Pregunta pregunta_hpa;
        private Alumno alumno_hpa;

        //Constructor predeterminado
        public HistoricoPruebaAlumno()
        {
        }

        public HistoricoPruebaAlumno(Alumno alumno_hpa, Evaluacion id_evaluacion_hpa, Pregunta pregunta_hpa, Respuesta respuesta_hpa)
        {
            this.alumno_hpa = alumno_hpa;
            this.Id_evaluacion_hpa = id_evaluacion_hpa;
            this.pregunta_hpa = pregunta_hpa;
            this.respuesta_hpa = respuesta_hpa;            
        }

        public HistoricoPruebaAlumno(int id_hpa, Alumno alumno_hpa, Evaluacion id_evaluacion_hpa, Pregunta pregunta_hpa, Respuesta respuesta_hpa)
        {
            this.id_hpa = id_hpa;
            this.alumno_hpa = alumno_hpa;
            this.Id_evaluacion_hpa = id_evaluacion_hpa;
            this.pregunta_hpa = pregunta_hpa;
            this.respuesta_hpa = respuesta_hpa;
        }
        public int Id_hpa 
        {
            get { return id_hpa; }
            set { id_hpa = value; }
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

        public Evaluacion Id_evaluacion_hpa
        {
            get { return id_evaluacion_hpa; }
            set { id_evaluacion_hpa = value; }
        }
    }
}
