﻿using Project.CapaDeDatos;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Project
{
    public class CatalogDesempeno
    {
        //Lista todos los desempeños existentes en la base de datos
        public List<Desempeno> listarDesempenos()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarDesempenos";
            bd.CreateCommandSP(sqlSearch);
            List<Desempeno> lDesempenos = new List<Desempeno>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Desempeno d = new Desempeno(result.GetInt32(0), result.GetString(1));
                lDesempenos.Add(d);
            }
            result.Close();
            bd.Close();
            return lDesempenos;
        }

        //Lista todos los desempeños de una asignatura existentes en la base de datos
        public List<Desempeno> listarDesempenosAsignatura(string cod_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarDesempenosAsignatura";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("cod_asignatura", DbType.String, cod_asignatura);
            List<Desempeno> lDesempenos = new List<Desempeno>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Desempeno d = new Desempeno(result.GetInt32(0), result.GetString(1));
                lDesempenos.Add(d);
            }
            result.Close();
            bd.Close();
            return lDesempenos;
        }

        //Lista los desempeños acorde a una busqueda existentes en la base de datos
        public List<Desempeno> listarDesempenosBusqueda(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarDesempenosBusqueda";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@buscar", DbType.String, buscar);
            List<Desempeno> lDesempenos = new List<Desempeno>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Desempeno d = new Desempeno(result.GetInt32(0), result.GetString(1));
                lDesempenos.Add(d);
            }
            result.Close();
            bd.Close();
            return lDesempenos;
        }

        //Devuelve un desempeno acorde a su ID
        public Desempeno buscarUnDesempeno(int id_desempeno)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "buscarDesempenoID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_desempeno", DbType.Int32, id_desempeno);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            Desempeno d = new Desempeno(result.GetInt32(0), result.GetString(1));
            result.Close();
            bd.Close();
            return d;
        }

        //Devuelve un desempeno acorde a su indicador
        public Desempeno buscarUnDesempenoIndicador(string indicador_desempeno)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "buscarDesempenoIndicador";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@indicador_desempeno", DbType.String, indicador_desempeno);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            Desempeno d = new Desempeno(result.GetInt32(0), result.GetString(1));
            result.Close();
            bd.Close();
            return d;
        }

        //Elimina un Desempeño existente en la base de datos acorde a su ID
        public void eliminarDesempeno(int id_desempeno)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarDesempeno";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_desempeno", DbType.Int32, id_desempeno);
            bd.execute();
            bd.Close();
        }

        //Inserta un desempeno en la base de datos
        public void insertarDesempeno(Desempeno d)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insDesempeno";

            bd.CreateCommandSP(sql);
            bd.createParameter("@indicador_desempeno", DbType.String, d.Indicador_desempeno);
            bd.execute();
            bd.Close();
        }

        //Actualiza una desempeno existente en la base de datos
        public void actualizarDesempeno(Desempeno d)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarDesempeno";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_desempeno", DbType.Int32, d.Id_desempeno);
            bd.createParameter("@indicador_desempeno", DbType.String, d.Indicador_desempeno);
            bd.execute();
            bd.Close();
        }

        //Verifica si ya existe en la base de datos un desempeño con el mismo nombre
        public int verificarExistenciaIDesempeno(string indicador_desempeno)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "verificarExistenciaIDesempeno";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@indicador_desempeno", DbType.String, indicador_desempeno);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);

            result.Close();
            bd.Close();
            return existe;
        }
    }
}
