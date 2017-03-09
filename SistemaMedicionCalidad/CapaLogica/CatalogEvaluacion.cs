﻿using System.Collections.Generic;
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
    }
}
