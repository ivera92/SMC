using System.Data;
using System.Data.Common;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogHPA
    {
        public void agregarHPA(HistoricoPruebaAlumno hpa)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insHPA";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_hpa", DbType.Int32, hpa.Id_hpa);
            bd.createParameter("@id_evaluacion_hpa", DbType.Int32, hpa.Evaluacion_hpa.Id_evaluacion);
            bd.createParameter("@id_respuesta_hpa", DbType.Int32, hpa.Respuesta_hpa.Id_respuesta);
            bd.createParameter("@id_pregunta_hpa", DbType.Int32, hpa.Pregunta_hpa.Id_pregunta);
            bd.createParameter("@rut_alumno_hpa", DbType.String, hpa.Alumno_hpa.Rut_alumno);
            bd.execute();
            bd.Close();
        }

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
    }
}
