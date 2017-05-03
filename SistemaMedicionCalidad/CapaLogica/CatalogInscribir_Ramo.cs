using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogInscribir_Ramo
    {
        //Inscribe una asignatura a un alumno
        public void insertarAA(Cursa c)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "insInscribirRamo";
            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno_aa", DbType.String, c.Rut_alumno_aa.Rut_persona);
            bd.createParameter("@id_asignatura_aa", DbType.Int32, c.Id_asignatura_aa.Id_asignatura);
            bd.execute();
            bd.Close();
        }
    }
}
