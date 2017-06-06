using System.Data;
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
            bd.createParameter("@cod_asignatura_aa", DbType.String, c.Cod_asignatura_aa.Cod_asignatura);
            bd.execute();
            bd.Close();
        }
    }
}
