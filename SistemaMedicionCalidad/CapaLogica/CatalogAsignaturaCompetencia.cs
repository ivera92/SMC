using System.Data;
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
            bd.createParameter("@cod_asignatura_ac", DbType.String, ac.Asignatura_ac.Cod_asignatura);
            bd.createParameter("@id_competencia_ac", DbType.Int32, ac.Competencia_ac.Id_competencia);
            bd.createParameter("@nivel_dominio_ac", DbType.String, ac.Nivel_dominio);
            bd.execute();
            bd.Close();
        }
    }
}
