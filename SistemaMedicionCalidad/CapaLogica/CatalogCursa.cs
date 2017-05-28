using Project.CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project
{
    public class CatalogCursa
    {
        //Inscribe una asignatura a un alumno
        public void inscribirAsignatura(Cursa c)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "insInscribirRamo";
            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura_aa", DbType.String, c.Cod_asignatura_aa.Cod_asignatura);
            bd.createParameter("@rut_alumno_aa", DbType.String, c.Rut_alumno_aa.Rut_persona);
            bd.execute();
            bd.Close();
        }
    }
}
