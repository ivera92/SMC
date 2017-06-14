using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Project.CapaDeDatos;
using Project.CapaDeNegocios;
using System;

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
            bd.createParameter("@cod_asignatura_evaluacion", DbType.String, e.Asignatura_evaluacion.Cod_asignatura);
            bd.createParameter("@nombre_evaluacion", DbType.String, e.Nombre_evaluacion);
            bd.createParameter("@fecha_evaluacion", DbType.Date, e.Fecha_evaluacion);
            bd.createParameter("@preguntas_evaluacion", DbType.String, e.Preguntas_evaluacion);
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
        public List<Evaluacion> listarEvaluacionesAsignatura(string cod_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();
            
            string sql = "mostrarEvaluacionesAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura", DbType.String, cod_asignatura);
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

        //Lista las evaluaciones propias de un docente en la base de datos
        public List<Evaluacion> listarEvaluacionesDocente(string rut_docente)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarEvaluacionesDocente";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_docente", DbType.String, rut_docente);
            List<Evaluacion> lEvaluaciones = new List<Evaluacion>();
            DbDataReader result = bd.Query();
            CatalogEvaluacion cEvaluaciones = new CatalogEvaluacion();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();

            while (result.Read())
            {
                Evaluacion e = new Evaluacion(cAsignatura.buscarAsignatura(result.GetString(0)), result.GetString(1), result.GetDateTime(2), result.GetString(3));
                lEvaluaciones.Add(e);
            }
            result.Close();
            bd.Close();

            return lEvaluaciones;
        }

        //Verifica si existe un evaluacion con el mismo nombre en una misma asignatura
        public int verificarExistencia(string cod_asignatura, string nombre_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "verificarExistenciaEvaluacion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura_evaluacion", DbType.String, cod_asignatura);
            bd.createParameter("@nombre_evaluacion", DbType.String, nombre_evaluacion);
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

        //obtiene  resultados de  una evaluacion 
        public List<string> obtenerResultadosEvaluacionGeneral(string rut, int id_evaluacion, int id_competencia)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResultadosGenerales";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@rut", DbType.String, rut);
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

        //Lista los IDs de las preguntas asociadas a una evaluacion
        public string listarPreguntasEvaluacion(int id_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "mostrarIDsPE";
            bd.CreateCommandSP(sql);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            DbDataReader result = bd.Query();
            result.Read();
            string ids_preguntas = result.GetString(0);

            result.Close();
            bd.Close();

            return ids_preguntas;
        }

        //obtiene  resultados de  una evaluacion 
        public List<Resultados> obtenerResultadosEvaluacionGeneralGV(string rut, int id_evaluacion, int id_competencia)
        {

            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResultadosGeneralesGV";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@rut", DbType.String, rut);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            bd.createParameter("@id_competencia", DbType.Int32, id_competencia);

            DbDataReader result = bd.Query();//disponible resultado
            
            CatalogDocente cDocente = new CatalogDocente();
            CatalogAlumno cAlumno = new CatalogAlumno();
            CatalogEvaluacion cEvaluacion = new CatalogEvaluacion();
            
            List<Resultados> lResultados = new List<Resultados>();
            
            while (result.Read())
            {
                Competencia c = new Competencia();
                Respuesta res = new Respuesta();
                Resultados r = new Resultados();
                r.Correcta_respuesta = res;
                r.Nombre_competencia = c;

                if (result.GetBoolean(0)==false)
                {
                    r.Estado_respuesta = "Incorrecta";
                }
                else
                {
                    r.Estado_respuesta = "Correcta";
                }

                r.Cantidad =result.GetInt32(1);
                r.Nombre_competencia.Nombre_competencia = result.GetString(2);
                r.Rut_docente = cDocente.buscarUnDocente(result.GetString(3));
                r.Rut_alumno = cAlumno.buscarAlumnoPorRut(result.GetString(4));
                r.Id_evaluacion_hpa = cEvaluacion.buscarUnaEvaluacion(result.GetInt32(5));
                lResultados.Add(r);
            }
            result.Close();
            bd.Close();
            return lResultados;
        }

        //Lista las preguntas asociadas a una asignatura
        public List<Pregunta> listarPA(string cod_asignatura_ac)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarPA";

            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura_ac", DbType.String, cod_asignatura_ac);
            List<Pregunta> lPreguntas = new List<Pregunta>();
            DbDataReader result = bd.Query();
            CatalogEvaluacion cEvaluaciones = new CatalogEvaluacion();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            CatalogTipoPregunta cTP = new CatalogTipoPregunta();

            while (result.Read())
            {
                Pregunta p = new Pregunta();
                p.Id_pregunta = result.GetInt32(0);
                p.Id_desempeno = cDesempeno.buscarUnDesempeno(result.GetInt32(1));
                p.Tipo_pregunta_pregunta = cTP.buscarUnTipoPregunta(result.GetInt32(2));
                p.Enunciado_pregunta = result.GetString(3);
                p.Nivel_pregunta = result.GetInt32(4);
                lPreguntas.Add(p);
            }
            result.Close();
            bd.Close();

            return lPreguntas;
        }
        //Genera una prueba aleatoria de 15 preguntas
        public string generarPruebaAleatoria(string cod_asignatura)
        {
            List<int> lIDS = new List<int>();
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarIDsPA";
            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura_evaluacion", DbType.String, cod_asignatura);
            DbDataReader result = bd.Query();
            while (result.Read())
            {
                lIDS.Add(result.GetInt32(0));
            }
            result.Close();
            Random r = new Random();
            int numero = 0;
            string ids_preguntas = "";
            int i = 0;
            while (i < 15)
            {
                numero = r.Next(0, lIDS.Count-1);
                ids_preguntas += lIDS[numero] + ",";
                lIDS.RemoveAt(numero);
                i += 1;
            }
            return ids_preguntas;
        }
        public DataTable mostrarPyRSeleccionadas(string ids_preguntas)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "mostrarPYRSeleccionadas";
            bd.CreateCommandSP(sql);
            bd.createParameter("@ids_preguntas", DbType.String, ids_preguntas);
            DbDataReader result = bd.Query();
            DataTable dt = new DataTable();
            dt.Load(result);

            result.Close();
            bd.Close();
            return dt;
        }

        //Muestra los id_preguntas asociadas a una asignatura
        public string mostrarIDsPA(string cod_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarIDsPA";
            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura_evaluacion", DbType.String, cod_asignatura);
            DbDataReader result = bd.Query();
            string ids_preguntas = "";
            while (result.Read())
            {
                ids_preguntas += result.GetInt32(0) + ",";
            }
            result.Close();
            bd.Close();
            return ids_preguntas;
        }

        //Devuelve una evaluacion acorde a su ID existente en la base de datos
        public Evaluacion buscarUnaEvaluacion(int id_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "buscarEvaluacionID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            DbDataReader result = bd.Query();//disponible resultado
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            result.Read();
            Evaluacion e = new Evaluacion(result.GetInt32(0), cAsignatura.buscarAsignatura(result.GetString(2)), result.GetString(1), result.GetDateTime(3), result.GetString(4));
           
            result.Close();
            bd.Close();
            return e;
        }

        //Verifica si existe una evaliacion de una asignatura en los registros
        public int verificarExistenciaEvaluacionAsignatura(string cod_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "verificarExistenciaEvaluacionAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura", DbType.String, cod_asignatura);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);
            bd.Close();
            result.Close();
            return existe;
        }

        //Verifica si un alumno fue evaluado en una asignatura en los registros
        public int verificarAlumnoEvaluado(string rut_alumno)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "verificarAlumnoEvaluado";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);
            bd.Close();
            result.Close();
            return existe;
        }

        //Verifica si existe una evaluacion asociada a un docente en los registros
        public int verificarDocenteEvaluacion(string rut_docente)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "verificarDocenteEvaluacion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_docente", DbType.String, rut_docente);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);
            bd.Close();
            result.Close();
            return existe;
        }
    }
}

