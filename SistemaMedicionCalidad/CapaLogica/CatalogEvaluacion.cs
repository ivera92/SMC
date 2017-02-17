using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogEvaluacion
    {
        public void crearEvaluacion(Evaluacion e)
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
    }
}
