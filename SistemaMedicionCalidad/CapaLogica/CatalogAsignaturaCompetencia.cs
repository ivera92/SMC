using System.Data;
using Project.CapaDeDatos;
using System.Collections.Generic;
using System.Data.Common;

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
            bd.createParameter("@cod_asignatura_ac", DbType.String, ac.Cod_Asignatura_ac.Cod_asignatura);
            bd.createParameter("@id_competencia_ac", DbType.Int32, ac.Id_Competencia_ac.Id_competencia);
            bd.createParameter("@nivel_dominio_ac", DbType.String, ac.Nivel_dominio_ac);
            bd.execute();
            bd.Close();
        }

        //Lista todas las sociedades entre asignaturas y competencias existentes en la base de datos
        public List<Asignatura_Competencia> listarAC()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarAC";

            bd.CreateCommandSP(sql);
            List<Asignatura_Competencia> lAC = new List<Asignatura_Competencia>();
            DbDataReader result = bd.Query();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            while (result.Read())
            {
                Asignatura_Competencia ac = new Asignatura_Competencia();

                ac.Id_ac = result.GetInt32(0);
                ac.Cod_Asignatura_ac = cAsignatura.buscarAsignatura(result.GetString(1));
                ac.Id_Competencia_ac = cCompetencia.buscarUnaCompetencia(result.GetInt32(2));
                ac.Nivel_dominio_ac = result.GetString(3);

                lAC.Add(ac);
            }
            result.Close();
            bd.Close();

            return lAC;
        }

        //Devuelve la asociacion acorde a su ID
        public Asignatura_Competencia buscarAsociacion(int id_ac)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "buscarACID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_ac", DbType.Int32, id_ac);
            DbDataReader result = bd.Query();
            result.Read();

            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            Asignatura_Competencia ac = new Asignatura_Competencia();

            ac.Id_ac = result.GetInt32(0);
            ac.Cod_Asignatura_ac = cAsignatura.buscarAsignatura(result.GetString(1));
            ac.Id_Competencia_ac = cCompetencia.buscarUnaCompetencia(result.GetInt32(2));
            ac.Nivel_dominio_ac = result.GetString(3);

            result.Close();
            bd.Close();
            return ac;
        }

        //Actualiza una asociacion existente en la base de datos
        public void actualizarAsociacion(Asignatura_Competencia ac)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarAC";

            bd.CreateCommandSP(sql);

            bd.createParameter("@id_ac", DbType.Int32, ac.Id_ac);
            bd.createParameter("@cod_asignatura_ac", DbType.String, ac.Cod_Asignatura_ac.Cod_asignatura);
            bd.createParameter("@id_competencia_ac", DbType.Int32, ac.Id_Competencia_ac.Id_competencia);
            bd.createParameter("@nivel_dominio_ac", DbType.String, ac.Nivel_dominio_ac);
            bd.execute();
            bd.Close();
        }
    }
}
