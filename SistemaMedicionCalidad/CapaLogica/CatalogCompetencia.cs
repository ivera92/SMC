﻿using System.Collections.Generic;
using Project.CapaDeDatos;
using System.Data;
using System.Data.Common;

namespace Project
{
    public class CatalogCompetencia
    {
        //Inserta una competencia en la base de datos
        public void insertarCompetencia(Competencia c)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql="insCompetencia";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_ambito", DbType.Int32, c.Id_ambito.Id_ambito);
            bd.createParameter("@id_tipo_competencia", DbType.Int32, c.Id_tipo_competencia.Id_tipo_competencia);
            bd.createParameter("@nombre_competencia", DbType.String, c.Nombre_competencia);
            bd.execute();
            bd.Close();
        }

        //Elimina una competencia existente en la base de datos acorde a su ID
        public void eliminarCompetencia(int id_competencia)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "eliminarCompetencia";
            bd.CreateCommandSP(sql);

            bd.createParameter("@id_competencia", DbType.Int32, id_competencia);
            bd.execute();
            bd.Close();
        }

        //Actualiza una competencia existente en la base de datos
        public void actualizarCompetencia(Competencia c)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarCompetencia";

            bd.CreateCommandSP(sql);
            
            bd.createParameter("@id_competencia", DbType.Int32, c.Id_competencia);
            bd.createParameter("@id_ambito", DbType.Int32, c.Id_ambito.Id_ambito);
            bd.createParameter("@id_tipo_competencia", DbType.Int32, c.Id_tipo_competencia.Id_tipo_competencia);
            bd.createParameter("@nombre_competencia", DbType.String, c.Nombre_competencia);
            bd.execute();
            bd.Close();
        }

        //Lista todas las competencias existentes en la base de datos
        public List<Competencia> listarCompetencias()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarCompetencias";

            bd.CreateCommandSP(sql);
            List<Competencia> lcompetencia = new List<Competencia>();
            DbDataReader result = bd.Query();
            CatalogAmbito cAmbito = new CatalogAmbito();
            CatalogTipoCompetencia cTipoCompetencia = new CatalogTipoCompetencia();
            while (result.Read())
            {
                Ambito a = cAmbito.buscarUnAmbito(result.GetInt32(1));
                Tipo_Competencia tc = cTipoCompetencia.buscarUnTipoCompetencia(result.GetInt32(2));
                
                Competencia c = new Competencia(result.GetInt32(0), a, tc, result.GetString(3));
                lcompetencia.Add(c);
            }
            result.Close();
            bd.Close();

            return lcompetencia;
        }

        //Lista todas las competencias existentes buscadas en la base de datos
        public List<Competencia> listarCompetenciasBusqueda(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarCompetenciasBusqueda";

            bd.CreateCommandSP(sql);
            bd.createParameter("@buscar", DbType.String, buscar);
            List<Competencia> lcompetencia = new List<Competencia>();
            DbDataReader result = bd.Query();
            CatalogAmbito cAmbito = new CatalogAmbito();
            CatalogTipoCompetencia cTipoCompetencia = new CatalogTipoCompetencia();
            while (result.Read())
            {
                Ambito a = cAmbito.buscarUnAmbito(result.GetInt32(1));
                Tipo_Competencia tc = cTipoCompetencia.buscarUnTipoCompetencia(result.GetInt32(2));

                Competencia c = new Competencia(result.GetInt32(0), a, tc, result.GetString(3));
                lcompetencia.Add(c);
            }
            result.Close();
            bd.Close();

            return lcompetencia;
        }

        //Lista las competencias asociadas a una asignatura existentes en la base de datos
        public List<Competencia> listarCompetenciasAsignatura(string cod_asignatura_ac)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarCompetenciasAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura", DbType.String, cod_asignatura_ac);
            List<Competencia> lCompetencias = new List<Competencia>();
            CatalogAmbito cAmbito = new CatalogAmbito();
            CatalogTipoCompetencia cTipoCompetencia = new CatalogTipoCompetencia();
            DbDataReader result = bd.Query();

            while (result.Read())
            {
                Ambito a = cAmbito.buscarUnAmbito(result.GetInt32(1));
                Tipo_Competencia tc = cTipoCompetencia.buscarUnTipoCompetencia(result.GetInt32(2));

                Competencia c = new Competencia(result.GetInt32(0), a, tc, result.GetString(3));
                lCompetencias.Add(c);
            }
            result.Close();
            bd.Close();

            return lCompetencias;
        }

        //Devuelve una competencia acorde a su ID
        public Competencia buscarUnaCompetencia(int id_competencia)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "buscarCompetenciaID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_competencia", DbType.Int32, id_competencia);
            DbDataReader result = bd.Query();
            result.Read();
            CatalogAmbito cAmbito = new CatalogAmbito();
            CatalogTipoCompetencia cTipoCompetencia = new CatalogTipoCompetencia();
            Ambito a = cAmbito.buscarUnAmbito(result.GetInt32(1));
            Tipo_Competencia tc = cTipoCompetencia.buscarUnTipoCompetencia(result.GetInt32(2));

            Competencia c = new Competencia(result.GetInt32(0), a, tc, result.GetString(3));

            result.Close();
            bd.Close();
            return c;
        }

        //Devuelve una competencia acorde a su nombre
        public Competencia buscarUnaCompetenciaNombre(string nombre_competencia)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "buscarCompetenciaNombre";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@nombre_competencia", DbType.String, nombre_competencia);
            DbDataReader result = bd.Query();
            result.Read();
            CatalogAmbito cAmbito = new CatalogAmbito();
            CatalogTipoCompetencia cTipoCompetencia = new CatalogTipoCompetencia();
            Ambito a = cAmbito.buscarUnAmbito(result.GetInt32(1));
            Tipo_Competencia tc = cTipoCompetencia.buscarUnTipoCompetencia(result.GetInt32(2));

            Competencia c = new Competencia(result.GetInt32(0), a, tc, result.GetString(3));

            result.Close();
            bd.Close();
            return c;
        }
        //Verifica si ya existe en la base de datos una competencia con el mismo nombre
        public int verificarExistenciaCompetencia(string nombre_competencia)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "verificarExistenciaCompetencia";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@nombre_competencia", DbType.String, nombre_competencia);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);

            result.Close();
            bd.Close();
            return existe;
        }

        //Obtiene las competencias y las correctas e incorrectas de una asignatura
        public DataTable mostrarResumenCompetenciasAsignatura(string cod_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResumenCompetenciasAsignatura";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@cod_asignatura", DbType.String, cod_asignatura);

            DbDataReader result = bd.Query();
            DataTable dt = new DataTable();
            dt.Load(result);

            result.Close();
            bd.Close();
            return dt;
        }

        //Obtiene las competencias y las correctas e incorrectas de una escuela
        public DataTable mostrarResumenCompetenciasEscuela(int id_escuela)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResumenCompetenciasEscuela";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_escuela", DbType.Int32, id_escuela);

            DbDataReader result = bd.Query();
            DataTable dt = new DataTable();
            dt.Load(result);

            result.Close();
            bd.Close();
            return dt;
        }

        //Obtiene las competencias y las correctas e incorrectas de una evaluacion
        public DataTable mostrarResumenCompetenciasEvaluacion(int id_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarResumenCompetenciasEvaluacion";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_evaluacion", DbType.Int32, id_evaluacion);

            DbDataReader result = bd.Query();
            DataTable dt = new DataTable();
            dt.Load(result);

            result.Close();
            bd.Close();
            return dt;
        }

        //Lista todos las competencias de una evaluacion
        public DataTable mostrarCompetenciasEvaluacion(int id_evaluacion)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarCompetenciasEvaluacion";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("id_evaluacion", DbType.Int32, id_evaluacion);
            List<Desempeno> lDesempenos = new List<Desempeno>();
            DbDataReader result = bd.Query();
            DataTable dt = new DataTable();
            dt.Load(result);

            result.Close();
            bd.Close();
            return dt;
        }

        //Lista todos las competencias de una evaluacion
        public DataTable mostrarCompetenciasAsignatura(string cod_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarCompetenciasDeAsignatura";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("cod_asignatura", DbType.String, cod_asignatura);
            List<Desempeno> lDesempenos = new List<Desempeno>();
            DbDataReader result = bd.Query();
            DataTable dt = new DataTable();
            dt.Load(result);

            result.Close();
            bd.Close();
            return dt;
        }
    }
}