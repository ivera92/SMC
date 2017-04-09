using System.Data;
using System.Data.Common;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogHPA
    {
        //Inserta un registo en la tabla Historico Prueba Alumno de la base de datos
        public void insertarHPA(HistoricoPruebaAlumno hpa)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insHPA";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_hpa", DbType.Int32, hpa.Id_hpa);
            bd.createParameter("@id_evaluacion_hpa", DbType.Int32, hpa.Evaluacion_hpa.Id_evaluacion);
            bd.createParameter("@id_respuesta_hpa", DbType.Int32, hpa.Respuesta_hpa.Id_respuesta);
            bd.createParameter("@id_pregunta_hpa", DbType.Int32, hpa.Pregunta_hpa.Id_pregunta);
            bd.createParameter("@rut_alumno_hpa", DbType.String, hpa.Alumno_hpa.Rut_persona);
            bd.execute();
            bd.Close();
        }

        //Devuelve el ID de la pregunta respondida
        public int buscarIDPregunta(string respuesta)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select id_pregunta_respuesta from respuesta where nombre_respuesta='" + respuesta + "'";

            bd.CreateCommand(sqlSearch);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            int id = result.GetInt32(0);
            result.Close();
            bd.Close();
            return id;
        }

        //Devuelve el ID de la respuesta
        public int buscarIDRespuesta(string respuesta)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select id_respuesta from respuesta where nombre_respuesta='" + respuesta + "'";
            bd.CreateCommand(sqlSearch);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            int id = result.GetInt32(0);
            result.Close();
            bd.Close();
            return id;
        }

        //Devuelve un arreglo de tamaño 2 con la cantidad de respuestas correctas e incorrectas de cierta evaluacion 
        //y de determinado alumno
        public int[] resultadoPreguntasE(string rut, int id_evaluacion)
        {
            int[] arrResultados = new int[2];
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarRespuestasEvaluacion";

            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@rut_alumno", DbType.String, rut);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            DbDataReader result = bd.Query();//disponible resultado
            int correctas = 0;
            int incorrectas = 0;
            while (result.Read())
            {
                if (result.GetBoolean(1) == true)
                {
                    correctas = correctas + 1;
                }
                else
                {
                    incorrectas = incorrectas + 1;
                }
            }
            result.Close();
            bd.Close();
            arrResultados[0] = correctas;
            arrResultados[1] = incorrectas;
            return arrResultados;
        }


        //Devuelve un arreglo de tamaño 2 con la cantidad de respuestas correctas e incorrectas de cierta competencia 
        //y de determinado alumno
        public int[] resultadoPreguntas(string rut, int id_competencia)
        {
            int[] arrResultados = new int[2];
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarRespuestasCompetencia";

            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@rut_alumno", DbType.String, rut);
            bd.createParameter("@id_competencia", DbType.Int32, id_competencia);
            DbDataReader result = bd.Query();//disponible resultado
            int correctas = 0;
            int incorrectas = 0;
            while (result.Read())
            {
                if (result.GetBoolean(1) == true)
                {
                    correctas = correctas + 1;
                }
                else
                {
                    incorrectas = incorrectas + 1;
                }
            }
            result.Close();
            bd.Close();
            arrResultados[0] = correctas;
            arrResultados[1] = incorrectas;
            return arrResultados;
        }
    }
}
