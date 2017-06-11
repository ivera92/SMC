using Project.CapaDeDatos;
using System.Data;

namespace Project
{
    public class CatalogImparte
    {
        //Asociar una asignatura a un docente
        public void insertarAD(Imparte i)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "insImparte";
            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_docente_imparte", DbType.String, i.Rut_docente_imparte.Rut_persona);
            bd.createParameter("@cod_asignatura_imparte", DbType.String, i.Cod_asignatura_imparte.Cod_asignatura);
            bd.execute();
            bd.Close();
        }
    }
}
