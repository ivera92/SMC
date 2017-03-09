using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogAsignaturaCompetencia
    {
        //Asocia una Competencia con una Asignatura, ambas previamente creadas
        public void insertarAC(Asignatura_Competencia ac)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "insAC";
            bd.CreateCommandSP(sql);
            bd.createParameter("@id_asignatura_ac", DbType.Int32, ac.Asignatura_ac.Id_asignatura);
            bd.createParameter("@id_competencia_ac", DbType.Int32, ac.Competencia_ac.Id_competencia);
            bd.execute();
            bd.Close();
        }
    }
}
