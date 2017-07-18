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
            bd.createParameter("@cod_asignatura_evaluacion", DbType.String, e.Asignatura_evaluacion.Cod_asignatura);
            bd.createParameter("@nombre_evaluacion", DbType.String, e.Nombre_evaluacion);
            bd.createParameter("@fecha_evaluacion", DbType.Date, e.Fecha_evaluacion);
            bd.createParameter("@preguntas_evaluacion", DbType.String, e.Preguntas_evaluacion);
            bd.createParameter("@porcentaje_exigencia_evaluacion", DbType.Int32, e.Porcentaje_exigencia_evaluacion);
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
            CatalogAsignatura cAsignatura = new CatalogAsignatura();

            while (result.Read())
            {
                string activo_evaluacion = "";
                if (result.GetBoolean(5) == true)
                {
                    activo_evaluacion = "Habilitada";
                }
                else
                {
                    activo_evaluacion = "Deshabilitada";
                }
                Evaluacion e = new Evaluacion(result.GetInt32(0), cAsignatura.buscarAsignatura(result.GetString(1)), result.GetString(2), result.GetDateTime(3), result.GetString(4), activo_evaluacion, result.GetInt32(6));
                lEvaluaciones.Add(e);
            }
            result.Close();
            bd.Close();

            return lEvaluaciones;
        }


        //Lista las evaluaciones despues de una busqueda existentes en la base de datos
        public List<Evaluacion> listarEvaluacionesBusqueda(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarEvaluacionesBusqueda";

            bd.CreateCommandSP(sql);
            bd.createParameter("@buscar", DbType.String, buscar);
            List<Evaluacion> lEvaluaciones = new List<Evaluacion>();
            DbDataReader result = bd.Query();
            CatalogEvaluacion cEvaluaciones = new CatalogEvaluacion();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();

            while (result.Read())
            {
                string activo_evaluacion = "";
                if (result.GetBoolean(5) == true)
                {
                    activo_evaluacion = "Habilitada";
                }
                else
                {
                    activo_evaluacion = "Deshabilitada";
                }

                Evaluacion e = new Evaluacion(result.GetInt32(0), cAsignatura.buscarAsignatura(result.GetString(1)), result.GetString(2), result.GetDateTime(3), result.GetString(4), activo_evaluacion, result.GetInt32(6));
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
                string activo_evaluacion = "";
                if (result.GetBoolean(4) == true)
                {
                    activo_evaluacion = "Habilitada";
                }
                else
                {
                    activo_evaluacion = "Deshabilitada";
                }
                Evaluacion e = new Evaluacion(cAsignatura.buscarAsignatura(result.GetString(0)), result.GetString(1), result.GetDateTime(2), result.GetString(3), activo_evaluacion, result.GetInt32(5));
                lEvaluaciones.Add(e);
            }
            result.Close();
            bd.Close();

            return lEvaluaciones;
        }

        //Verifica si existe un evaluacion con el mismo nombre en una misma asignatura en el año
        public int verificarExistencia(string cod_asignatura, string nombre_evaluacion, DateTime fecha_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "verificarExistenciaEvaluacion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura_evaluacion", DbType.String, cod_asignatura);
            bd.createParameter("@nombre_evaluacion", DbType.String, nombre_evaluacion);
            bd.createParameter("@fecha_evaluacion", DbType.DateTime, fecha_evaluacion);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);
            bd.Close();
            result.Close();
            return existe;
        }

        //Verifica si existe un un registro en el historico de pruebas relacionado con la evaluacion
        public int verificarExistenciaEvaluacionHPA(string nombre_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "verificarExistenciaEvaluacionHPA";

            bd.CreateCommandSP(sql);
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
                resultados.Add(result.GetInt32(1) + "");
                resultados.Add(result.GetString(2));
            }
            result.Close();
            bd.Close();
            return resultados;
        }

        //obtiene  resultados de  una evaluacion 
        public List<string> obtenerResultadosEvaluacionGeneral(int id_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResultadosGenerales";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);

            DbDataReader result = bd.Query();//disponible resultado
            List<string> resultados = new List<string>();
            int i = 1;
            while (result.Read())
            {
                resultados.Add("D" + i);
                resultados.Add(result.GetInt32(1) + "");
                resultados.Add(result.GetInt32(2) + "");
                i += 1;
            }
            result.Close();
            bd.Close();
            return resultados;
        }

        //obtiene  resultados de  una evaluacion de un alumno
        public List<string> obtenerResultadosEvaluacionGeneralAlumno(int id_evaluacion, string rut_alumno)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResultadosGeneralesAlumno";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);

            DbDataReader result = bd.Query();//disponible resultado
            List<string> resultados = new List<string>();
            int i = 1;
            while (result.Read())
            {
                resultados.Add("D" + i);
                resultados.Add(result.GetInt32(1) + "");
                resultados.Add(result.GetInt32(2) + "");
                i += 1;
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

        //Lista los IDs de las preguntas asociadas a una evaluacion por su nombre
        public string listarPreguntasEvaluacionNombre(string nombre_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "mostrarIDsPENombre";
            bd.CreateCommandSP(sql);
            bd.createParameter("@nombre_evaluacion", DbType.String, nombre_evaluacion);
            DbDataReader result = bd.Query();
            result.Read();
            string ids_preguntas = result.GetString(0);

            result.Close();
            bd.Close();

            return ids_preguntas;
        }

        //obtiene  resultados de  una evaluacion 
        public DataTable obtenerResultadosEvaluacionGeneralPorAlumnoGV(int id_evaluacion)
        {

            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResultadosGeneralesPorAlumnoGV";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            
            DbDataReader result = bd.Query();
            DataTable dt = new DataTable();
            dt.Load(result);

            result.Close();
            bd.Close();
            return dt;
        }

        //obtiene  resultados de  una evaluacion 
        public List<Resultados> obtenerResultadosEvaluacionGeneralesGV(int id_evaluacion)
        {

            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResultadosGeneralesGV";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);

            DbDataReader result = bd.Query();//disponible resultado
            CatalogDesempeno cDesempeno = new CatalogDesempeno();

            List<Resultados> lResultados = new List<Resultados>();
            int i = 1;
            string indicador_desempeño = "";
            bool primera_vez = false;
            string s = "";
            while (result.Read())
            {
                Desempeno d = new Desempeno();
                Respuesta res = new Respuesta();
                Resultados r = new Resultados();
                r.Correcta_respuesta = res;

                if (result.GetBoolean(0) == false)
                {
                    r.Estado_respuesta = "Incorrecta";
                }
                else
                {
                    r.Estado_respuesta = "Correcta";
                }

                r.Cantidad = result.GetInt32(1);
                r.Indicador_desempeno = cDesempeno.buscarUnDesempenoIndicador(result.GetString(2));

                if (primera_vez == false)
                {
                    primera_vez = true;
                    r.Indicador_desempeno.Nombre_desempeno = "Desempeño " + i;
                    i += 1;
                }
                else if (result.GetString(2) != indicador_desempeño)
                {
                    r.Indicador_desempeno.Nombre_desempeno = "Desempeño " + i;
                    i = i + 1;
                }
                else
                {
                    r.Indicador_desempeno.Nombre_desempeno = "Desempeño " + (i - 1);
                }
                indicador_desempeño = result.GetString(2);

                lResultados.Add(r);
                s = result.GetString(2);
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
            CatalogNivel cNivel = new CatalogNivel();

            while (result.Read())
            {
                Pregunta p = new Pregunta();
                p.Id_pregunta = result.GetInt32(0);
                p.Id_desempeno = cDesempeno.buscarUnDesempeno(result.GetInt32(1));
                p.Tipo_pregunta_pregunta = cTP.buscarUnTipoPregunta(result.GetInt32(2));
                p.Enunciado_pregunta = result.GetString(3);
                p.Nivel_pregunta = cNivel.buscarNivel(result.GetInt32(4));
                lPreguntas.Add(p);
            }
            result.Close();
            bd.Close();

            return lPreguntas;
        }
        //Genera una prueba aleatoria de 15 preguntas
        public string generarPruebaAleatoria(string cod_asignatura, int cantidad_preguntas)
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
            while (i < cantidad_preguntas)
            {
                numero = r.Next(0, lIDS.Count - 1);
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
            string activo_evaluacion = "";
            if (result.GetBoolean(5) == true)
            {
                activo_evaluacion = "Habilitada";
            }
            else
            {
                activo_evaluacion = "Deshabilitada";
            }
            Evaluacion e = new Evaluacion(result.GetInt32(0), cAsignatura.buscarAsignatura(result.GetString(1)), result.GetString(2), result.GetDateTime(3), result.GetString(4), activo_evaluacion, result.GetInt32(6));

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

        //Verifica si un alumno fue evaluado en una asignatura en los registros
        public int verificarAlumnoEvaluadoAsignatura(string nombre_alumno, string nombre_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "verificarAlumnoEvaluadoAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@nombre_alumno", DbType.String, nombre_alumno);
            bd.createParameter("@nombre_asignatura", DbType.String, nombre_asignatura);
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

        //Elimina una Evaluacion existente en la base de datos acorde a su ID
        public void eliminarEvaluacion(string nombre_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarEvaluacion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@nombre_evaluacion", DbType.String, nombre_evaluacion);
            bd.execute();
            bd.Close();
        }

        public List<string> resultadosEspecificos(int id_evaluacion, int accion)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarResultadosEspecificos";
            bd.CreateCommandSP(sql);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            bd.createParameter("@accion", DbType.Int32, accion);
            DbDataReader result = bd.Query();
            List<string> lResultados = new List<string>();
            while (result.Read())
            {
                try
                {
                    lResultados.Add(result.GetString(0));
                }
                catch
                {
                    lResultados.Add(result.GetInt32(0) + "");
                }

                try
                {
                    lResultados.Add(result.GetString(1));
                }
                catch
                {
                    lResultados.Add(result.GetInt32(1) + "");
                }
                try
                {
                    lResultados.Add(result.GetString(2));
                }
                catch
                {
                    lResultados.Add(result.GetInt32(2) + "");
                }



            }
            result.Close();
            bd.Close();
            return lResultados;
        }

        //Lista las evaluaciones pendientes de un alumno en una asignatura en la base de datos
        public List<Evaluacion> listarEvaluacionesPendientes(string rut_alumno, string cod_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarEvaluacionesPendientes";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);
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

        //Actualiza el estado de una evaluacion existente en la base de datos
        public void actualizarEstadoEvaluacion(string nombre_evaluacion, bool estado)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarEstadoEvaluacion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@nombre_evaluacion", DbType.String, nombre_evaluacion);
            bd.createParameter("@estado", DbType.Boolean, estado);
            bd.execute();
            bd.Close();
        }

        //Lista las respuestas de un alumno en una evaluacion en la base de datos
        public List<int> listarIDsRA(string rut_alumno, int id_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarRespuestasAlumnoEvaluacion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            DbDataReader result = bd.Query();
            List<int> lIDs = new List<int>();
            while (result.Read())
            {
                lIDs.Add(result.GetInt32(0));
            }
            result.Close();
            bd.Close();

            return lIDs;
        }

        //Lista las respuestas correctas en una evaluacion en la base de datos
        public List<int> listarIDsRC(int id_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarRespuestasCorrectasEvaluacion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            DbDataReader result = bd.Query();
            List<int> lIDs = new List<int>();
            while (result.Read())
            {
                lIDs.Add(result.GetInt32(0));
            }
            result.Close();
            bd.Close();

            return lIDs;
        }

        //Resumen de evaluacion respuestas correctas e incorrectas por rut de alumno
        public DataTable mostrarResumen(int id_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "mostrarResumenEvaluacion";
            bd.CreateCommandSP(sql);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            DbDataReader result = bd.Query();
            DataTable dt = new DataTable();
            dt.Load(result);

            result.Close();
            bd.Close();
            return dt;
        }

        //Devuelve el rut, la cantidad de respuestas correctas e incorrectas de un alumno en una evaluacion
        public List<string> mostrarResumenA(int id_evaluacion, string rut_alumno)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "mostrarResumenEvaluacionA";
            bd.CreateCommandSP(sql);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);
            DbDataReader result = bd.Query();
            result.Read();
            List<string> lResultados = new List<string>();
            lResultados.Add(result.GetString(0));
            lResultados.Add(result.GetInt32(1) + "");
            lResultados.Add(result.GetInt32(2) + "");
            lResultados.Add(result.GetInt32(3) + "");
            result.Close();
            bd.Close();
            return lResultados;
        }

        //Devuelve una tabla resumen con los promedios
        public DataTable promedio(DataTable d)
        {
            string rut, correctas, incorretas;
            int puntaje_ideal;
            double puntaje_exigencia, porcentaje;
            double promedio = 0;
            DataTable d2 = new DataTable();
            d2.Columns.Add("Nombre");
            d2.Columns.Add("Rut");
            d2.Columns.Add("Correo");
            d2.Columns.Add("Correctas");
            d2.Columns.Add("Incorrectas");
            d2.Columns.Add("Nota");
            foreach (DataRow row in d.Rows)
            {
                rut = row[1].ToString();
                correctas = row[3].ToString();
                incorretas = row[4].ToString();
                porcentaje = int.Parse(row[5].ToString()) / 100d;
                puntaje_ideal = int.Parse(correctas) + int.Parse(incorretas);
                puntaje_exigencia = puntaje_ideal * porcentaje;
                double a = puntaje_ideal - puntaje_exigencia;
                double b = int.Parse(correctas) - puntaje_exigencia;

                //MidpointRounding.AwayFromZero si el numero se encunetra en la mitad, es decir .5 aproxima al numero mas alejado del 0
                if (int.Parse(correctas) <= puntaje_exigencia)
                {
                    promedio = Math.Round(3f * (double.Parse(correctas)) / puntaje_exigencia + 1, 1, MidpointRounding.AwayFromZero);
                }
                else
                {
                    promedio = Math.Round(3f * (double.Parse(correctas) - puntaje_exigencia) / (puntaje_ideal - puntaje_exigencia) + 4, 1, MidpointRounding.AwayFromZero);
                }
                DataRow row2 = d2.NewRow();
                row2["Nombre"] = row[0].ToString();
                row2["Rut"] = rut;
                row2["Correo"]= row[2].ToString();
                row2["Correctas"] = correctas;
                row2["Incorrectas"] = incorretas;
                row2["Nota"] = promedio;
                d2.Rows.Add(row2);
            }
            return d2;
        }

        public DataTable mostrarResumenEvaluacionesA(string rut_alumno)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "mostrarResumenEvaluacionesA";
            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);
            DbDataReader result = bd.Query();
            DataTable dt = new DataTable();
            dt.Load(result);


            string rut, correctas, incorretas, evaluacion;
            int puntaje_ideal;
            double puntaje_exigencia, porcentaje;
            double promedio = 0;
            DataTable d2 = new DataTable();
            d2.Columns.Add("Rut");
            d2.Columns.Add("Correctas");
            d2.Columns.Add("Incorrectas");
            d2.Columns.Add("Promedio");
            d2.Columns.Add("Evaluacion");
            foreach (DataRow row in dt.Rows)
            {
                evaluacion = row[3].ToString();
                rut = row[0].ToString();
                correctas = row[1].ToString();
                incorretas = row[2].ToString();
                porcentaje = int.Parse(row[4].ToString()) / 100d;
                puntaje_ideal = int.Parse(correctas) + int.Parse(incorretas);
                puntaje_exigencia = puntaje_ideal * porcentaje;
                double a = puntaje_ideal - puntaje_exigencia;
                double b = int.Parse(correctas) - puntaje_exigencia;

                //MidpointRounding.AwayFromZero si el numero se encunetra en la mitad, es decir .5 aproxima al numero mas alejado del 0
                if (int.Parse(correctas) <= puntaje_exigencia)
                {
                    promedio = Math.Round(3f * (double.Parse(correctas)) / puntaje_exigencia + 1, 1, MidpointRounding.AwayFromZero);
                }
                else
                {
                    promedio = Math.Round(3f * (double.Parse(correctas) - puntaje_exigencia) / (puntaje_ideal - puntaje_exigencia) + 4, 1, MidpointRounding.AwayFromZero);
                }
                DataRow row2 = d2.NewRow();
                row2["Rut"] = rut;
                row2["Correctas"] = correctas;
                row2["Incorrectas"] = incorretas;
                row2["Promedio"] = promedio;
                row2["Evaluacion"] = evaluacion;
                d2.Rows.Add(row2);
            }

            result.Close();
            bd.Close();
            return d2;
        }

        public DataTable mostrarResumenDEvaluacion(int id_evaluacion, int ano_cursa)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "mostrarResumenDEvaluacion";
            bd.CreateCommandSP(sql);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            bd.createParameter("@ano_cursa", DbType.Int32, ano_cursa);
            DbDataReader result = bd.Query();
            DataTable dt = new DataTable();
            dt.Load(result);


            string desempeño, correctas, incorretas;
            int puntaje_ideal;
            double puntaje_exigencia, porcentaje;
            double promedio = 0;
            DataTable d2 = new DataTable();
            d2.Columns.Add("Desempeño");
            d2.Columns.Add("Correctas");
            d2.Columns.Add("Incorrectas");
            d2.Columns.Add("Promedio");
            foreach (DataRow row in dt.Rows)
            {
                desempeño = row[0].ToString();
                correctas = row[1].ToString();
                incorretas = row[2].ToString();
                porcentaje = int.Parse(row[3].ToString()) / 100d;
                puntaje_ideal = int.Parse(correctas) + int.Parse(incorretas);
                puntaje_exigencia = puntaje_ideal * porcentaje;
                double a = puntaje_ideal - puntaje_exigencia;
                double b = int.Parse(correctas) - puntaje_exigencia;

                //MidpointRounding.AwayFromZero si el numero se encunetra en la mitad, es decir .5 aproxima al numero mas alejado del 0
                if (int.Parse(correctas) <= puntaje_exigencia)
                {
                    promedio = Math.Round(3f * (double.Parse(correctas)) / puntaje_exigencia + 1, 1, MidpointRounding.AwayFromZero);
                }
                else
                {
                    promedio = Math.Round(3f * (double.Parse(correctas) - puntaje_exigencia) / (puntaje_ideal - puntaje_exigencia) + 4, 1, MidpointRounding.AwayFromZero);
                }
                DataRow row2 = d2.NewRow();
                row2["Desempeño"] = desempeño;
                row2["Correctas"] = correctas;
                row2["Incorrectas"] = incorretas;
                row2["Promedio"] = promedio;
                d2.Rows.Add(row2);
            }
            result.Close();
            bd.Close();
            return d2;
        }

        public List<Cursa> listarGeneracionesEvaluacion(int id_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarGeneracionesEvaluacion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);
            DbDataReader result = bd.Query();
            List<Cursa> lGeneraciones = new List<Cursa>();
            while (result.Read())
            {
                Cursa c = new Cursa(result.GetString(0));
                lGeneraciones.Add(c);
            }
            result.Close();
            bd.Close();

            return lGeneraciones;
        }
    }
}

