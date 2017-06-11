﻿using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogPregunta
    {
        //Inserta una pregunta en la base de datos
        public void insertarPregunta(Pregunta p)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insPregunta";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_desempeno", DbType.Int32, p.Id_desempeno.Id_desempeno);
            bd.createParameter("@id_tipo_pregunta_pregunta", DbType.Int32, p.Tipo_pregunta_pregunta.Id_tipo_pregunta);
            bd.createParameter("@enunciado_pregunta", DbType.String, p.Enunciado_pregunta);
            bd.createParameter("@imagen_pregunta", DbType.String, p.Imagen_pregunta);
            bd.createParameter("@nivel_pregunta", DbType.Int32, p.Nivel_pregunta);
            bd.execute();
            bd.Close();
        }

        //Elimina una pregunta existete en la base de datos acorde a su ID
        public void eliminarPregunta(int id_pregunta)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarPregunta";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_pregunta", DbType.Int32, id_pregunta);
            bd.execute();
            bd.Close();
        }
        //Devuelve la ultima pregunta ingresada en la base de datos
        public int ultimaPregunta()
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "ultimaPregunta";
            bd.CreateCommand(sql);
            DbDataReader result = bd.Query();
            result.Read();
            int id = result.GetInt32(0);
            result.Close();
            bd.Close();
            return id;
        }

        //Devuelve una pregunta acorde a su ID
        public Pregunta buscarUnaPregunta(int id_pregunta)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "buscarPreguntaID";
            bd.CreateCommandSP(sql);
            bd.createParameter("@id_pregunta", DbType.Int32, id_pregunta);

            DbDataReader result = bd.Query();
            result.Read();
            Pregunta p = new Pregunta();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            CatalogTipoPregunta cTipoPregunta = new CatalogTipoPregunta();

            p.Id_pregunta = result.GetInt32(0);
            p.Id_desempeno = cDesempeno.buscarUnDesempeno(result.GetInt32(1));
            p.Tipo_pregunta_pregunta = cTipoPregunta.buscarUnTipoPregunta(result.GetInt32(2));
            p.Enunciado_pregunta = result.GetString(3);
            try
            {
                p.Imagen_pregunta = result.GetString(4);
            }
            catch
            {
                p.Imagen_pregunta = "";
            }
            p.Nivel_pregunta = result.GetInt32(5);
            
            result.Close();
            bd.Close();

            return p;
        }

        //Lista todas las preguntas existentes en la base de datos
        public List<Pregunta> listarPreguntas()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarPreguntas";
            bd.CreateCommandSP(sqlSearch);
            List<Pregunta> lPreguntas = new List<Pregunta>();

            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            CatalogTipoPregunta cTipoPregunta = new CatalogTipoPregunta();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Pregunta p = new Pregunta();

                p.Id_pregunta = result.GetInt32(0);
                p.Id_desempeno = cDesempeno.buscarUnDesempeno(result.GetInt32(1));
                p.Tipo_pregunta_pregunta = cTipoPregunta.buscarUnTipoPregunta(result.GetInt32(2));
                p.Enunciado_pregunta = result.GetString(3);
                try
                {
                    p.Imagen_pregunta = result.GetString(4);
                }
                catch
                {
                    p.Imagen_pregunta = "";
                }
                p.Nivel_pregunta = result.GetInt32(5);
                lPreguntas.Add(p);
            }
            result.Close();
            bd.Close();
            return lPreguntas;
        }

        //Lista todas las preguntas acorde a un criterio de busqueda existentes en la base de datos
        public List<Pregunta> listarPreguntasBusqueda(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarPreguntasBusqueda";
            bd.CreateCommandSP(sqlSearch);
            List<Pregunta> lPreguntas = new List<Pregunta>();

            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            CatalogTipoPregunta cTipoPregunta = new CatalogTipoPregunta();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Pregunta p = new Pregunta();

                p.Id_pregunta = result.GetInt32(0);
                p.Id_desempeno = cDesempeno.buscarUnDesempeno(result.GetInt32(1));
                p.Tipo_pregunta_pregunta = cTipoPregunta.buscarUnTipoPregunta(result.GetInt32(2));
                p.Enunciado_pregunta = result.GetString(3);
                try
                {
                    p.Imagen_pregunta = result.GetString(4);
                }
                catch
                {
                    p.Imagen_pregunta = "";
                }
                p.Nivel_pregunta = result.GetInt32(5);
                lPreguntas.Add(p);
            }
            result.Close();
            bd.Close();
            return lPreguntas;
        }
        //Actualiza una pregunta existente en la base de datos
        public void actualizarPregunta(Pregunta p)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarPregunta";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_pregunta", DbType.Int32, p.Id_pregunta);
            bd.createParameter("@id_desempeno_pregunta", DbType.Int32, p.Id_desempeno.Id_desempeno);
            bd.createParameter("@id_tipo_pregunta_pregunta", DbType.Int32, p.Tipo_pregunta_pregunta.Id_tipo_pregunta+1);
            bd.createParameter("@enunciado_pregunta", DbType.String, p.Enunciado_pregunta);
            bd.createParameter("@nivel_pregunta", DbType.Int32, p.Nivel_pregunta);
            bd.execute();
            bd.Close();
        }
    }
}
