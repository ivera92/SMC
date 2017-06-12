using Project.CapaDeDatos;
using System.Data;

namespace Project
{
    public class CatalogCursa
    {
        //Inscribe una asignatura a un alumno
        public void inscribirAsignatura(Cursa c)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "insCursa";
            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura_aa", DbType.String, c.Cod_asignatura_aa.Cod_asignatura);
            bd.createParameter("@rut_alumno_aa", DbType.String, c.Rut_alumno_aa.Rut_persona);
            bd.execute();
            bd.Close();
        }
    }
}
