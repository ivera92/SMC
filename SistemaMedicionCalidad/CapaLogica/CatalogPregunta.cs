﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogPregunta
    {
        public void agregarPregunta(Pregunta p)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insPregunta";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_competencia_pregunta", DbType.Int32, p.Id_competencia_pregunta);
            bd.createParameter("@id_tipo_pregunta_pregunta", DbType.Int32, p.Id_tipo_pregunta_pregunta);
            bd.createParameter("@nombre_pregunta", DbType.String, p.Nombre_pregunta);

            bd.execute();
            bd.Close();
        }

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

        public List<Tipo_Pregunta> mostrarTiposPregunta()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select * from tipo_pregunta";
            bd.CreateCommand(sqlSearch);
            List<Tipo_Pregunta> ltp = new List<Tipo_Pregunta>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Tipo_Pregunta tp = new Tipo_Pregunta(result.GetInt32(0), result.GetString(1));
                ltp.Add(tp);
            }
            result.Close();
            bd.Close();
            return ltp;
        }

        public Pregunta buscarUnaPregunta(int id_pregunta)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "select * from pregunta where id_pregunta='" + id_pregunta + "'";
            bd.CreateCommand(sql);

            List<Pregunta> lp = new List<Pregunta>();
            DbDataReader result = bd.Query();
            while(result.Read())
            {
                Pregunta p = new Pregunta(result.GetInt32(0), result.GetInt32(1), result.GetInt32(2), result.GetString(3));
                lp.Add(p);
            }
            return lp.First();
        }

        public List<Pregunta> mostrarPreguntas()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select * from pregunta";
            bd.CreateCommand(sqlSearch);
            List<Pregunta> lp = new List<Pregunta>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Pregunta p = new Pregunta(result.GetInt32(0), result.GetInt32(1), result.GetInt32(2), result.GetString(3));
                lp.Add(p);
            }
            result.Close();
            bd.Close();
            return lp;
        }
    }
}
