using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogEvaluacion
    {
        //Inseta una evaluacion en la base de datos
        public void insertarEvaluacion(Evaluacion e)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insEvaluacion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_evaluacion", DbType.Int32, e.Id_evaluacion);
            bd.createParameter("@id_asignatura_evaluacion", DbType.Int32, e.Asignatura_evaluacion.Id_asignatura);
            bd.createParameter("@nombre_evaluacion", DbType.String, e.Nombre_evaluacion);
            bd.createParameter("@fecha_evaluacion", DbType.Date, e.Fecha_evaluacion);
            bd.execute();
            bd.Close();
        }

        //Lista las evaluaciones existentes en la base de datos
        public List<Evaluacion> listarEvaluaciones()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarEvaluaciones";

            bd.CreateCommandSP(sql);
            List<Evaluacion> lEvaluaciones = new List<Evaluacion>();
            DbDataReader result = bd.Query();
            CatalogEvaluacion cEvaluaciones = new CatalogEvaluacion();

            while (result.Read())
            {
                Evaluacion e = new Evaluacion(result.GetInt32(0), result.GetString(1));
                lEvaluaciones.Add(e);
            }
            result.Close();
            bd.Close();

            return lEvaluaciones;
        }

        //Lista las evaluaciones propias de una asignaturaexistentes en la base de datos
        public List<Evaluacion> listarEvaluacionesAsignatura(int id_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();
            
            string sql = "mostrarEvaluacionesAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_asignatura", DbType.Int32, id_asignatura);
            List<Evaluacion> lEvaluaciones = new List<Evaluacion>();
            DbDataReader result = bd.Query();
            CatalogEvaluacion cEvaluaciones = new CatalogEvaluacion();

            while (result.Read())
            {
                Evaluacion e = new Evaluacion(result.GetInt32(0), result.GetString(1));
                lEvaluaciones.Add(e);
            }
            result.Close();
            bd.Close();

            return lEvaluaciones;
        }

        public int verificarExistencia(int id_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "verificarExistenciaEvaluacion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_asignatura_evaluacion", DbType.Int32, id_asignatura);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);
            bd.Close();
            result.Close();
            return existe;
        }
        
        //obtiene los resultados de un alumno en una evaluacion 
        public List<string> obtenerResultadosEvaluacion(string rut_alumno, int id_evaluacion)
        {

            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResultadosEvaluacion";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            DbDataReader result = bd.Query();//disponible resultado
            List<string> resultados = new List<string>();
            while (result.Read())
            {
                resultados.Add(result.GetBoolean(0) + "");
                resultados.Add(result.GetInt32(1)+"");
                resultados.Add(result.GetString(2));
            }
            result.Close();
            bd.Close();
            return resultados;
        }

        public List<string> resultadosTodosAEvaluacion (int id_evaluacion)
        {

            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResultadosEvaluacionTodosAlumnos";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            DbDataReader result = bd.Query();//disponible resultado
            List<string> resultados = new List<string>();
            while (result.Read())
            {
                resultados.Add(result.GetBoolean(0) + "");
                resultados.Add(result.GetInt32(1) + "");
                resultados.Add(result.GetString(2));
            }
            result.Close();
            bd.Close();
            return resultados;
        }

        //obtiene  resultados de  una evaluacion 
        public List<string> obtenerResultadosEvaluacionGeneral(int id_pais, int promocionA, string rut,  int sexo, int disponibilidadD, int id_evaluacion, int id_competencia)
        {

            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResultadosGenerales";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_pais", DbType.Int32, id_pais);
            bd.createParameter("@promocion", DbType.Int32, promocionA);
            bd.createParameter("@rut", DbType.String, rut);
            bd.createParameter("@sexo", DbType.Int32, sexo);
            bd.createParameter("@disponibilidadD", DbType.Int32, disponibilidadD);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            bd.createParameter("@id_competencia", DbType.Int32, id_competencia);

            DbDataReader result = bd.Query();//disponible resultado
            List<string> resultados = new List<string>();
            while (result.Read())
            {
                resultados.Add(result.GetBoolean(0) + "");
                resultados.Add(result.GetInt32(1) + "");
                resultados.Add(result.GetString(2));
            }
            result.Close();
            bd.Close();
            return resultados;
        }

        //obtiene  resultados de  una evaluacion 
        public List<Resultados> obtenerResultadosEvaluacionGeneralGV(int id_pais, int promocionA, string rut, int sexo, int disponibilidadD, int id_evaluacion, int id_competencia)
        {

            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResultadosGeneralesGV";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_pais", DbType.Int32, id_pais);
            bd.createParameter("@promocion", DbType.Int32, promocionA);
            bd.createParameter("@rut", DbType.String, rut);
            bd.createParameter("@sexo", DbType.Int32, sexo);
            bd.createParameter("@disponibilidadD", DbType.Int32, disponibilidadD);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            bd.createParameter("@id_competencia", DbType.Int32, id_competencia);

            DbDataReader result = bd.Query();//disponible resultado
            Respuesta res = new Respuesta();
            Alumno a = new Alumno();
            Docente d = new Docente();
            HistoricoPruebaAlumno h = new HistoricoPruebaAlumno();
            Competencia c = new Competencia();
            Pais p = new Pais();
            List<Resultados> lResultados = new List<Resultados>();
            Evaluacion e = new Evaluacion();
            while (result.Read())
            {
                Resultados r = new Resultados();
                r.Correcta_respuesta = res;
                r.Nombre_competencia = c;
                r.Rut_docente = d;
                r.Rut_alumno = a;
                r.Id_evaluacion_hpa = h;
                r.Id_evaluacion_hpa.Evaluacion_hpa = e;

                r.Correcta_respuesta.Correcta_respuesta=result.GetBoolean(0);
                r.Cantidad =result.GetInt32(1);
                r.Nombre_competencia.Nombre_competencia = result.GetString(2);
                r.Rut_docente.Rut_persona = result.GetString(3);
                r.Rut_alumno.Rut_persona = result.GetString(4);
                r.Id_evaluacion_hpa.Evaluacion_hpa.Id_evaluacion = result.GetInt32(5);
                lResultados.Add(r);
            }
            result.Close();
            bd.Close();
            return lResultados;
        }
    }
}
