using Project.CapaDeDatos;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Project
{
    public class CatalogCompetenciaDesempeno
    {
        //Asocia un Desempeño con una Competencia, ambas previamente creadas
        public void insertarCD(Competencia_Desempeno cd)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "insCD";
            bd.CreateCommandSP(sql);
            bd.createParameter("@id_desempeno_cd", DbType.Int32, cd.Id_desempeno.Id_desempeno);
            bd.createParameter("@id_competencia_cd", DbType.Int32, cd.Id_competencia.Id_competencia);
            bd.execute();
            bd.Close();
        }

        //Lista todas las sociedades entre competencia y desempeño existentes en la base de datos
        public List<Competencia_Desempeno> listarCD()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarCD";

            bd.CreateCommandSP(sql);
            List<Competencia_Desempeno> lCD = new List<Competencia_Desempeno>();
            DbDataReader result = bd.Query();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            while (result.Read())
            {
                Competencia_Desempeno cd = new Competencia_Desempeno();

                cd.Id_cd = result.GetInt32(0);
                cd.Id_desempeno = cDesempeno.buscarUnDesempeno(result.GetInt32(1));
                cd.Id_competencia = cCompetencia.buscarUnaCompetencia(result.GetInt32(2));

                lCD.Add(cd);
            }
            result.Close();
            bd.Close();

            return lCD;
        }

        //Devuelve la asociacion acorde a su ID
        public Competencia_Desempeno buscarCD(int id_cd)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "buscarCDID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_cd", DbType.Int32, id_cd);
            DbDataReader result = bd.Query();
            result.Read();
            
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            Competencia_Desempeno cd = new Competencia_Desempeno();

            cd.Id_cd = result.GetInt32(0);
            cd.Id_desempeno = cDesempeno.buscarUnDesempeno(result.GetInt32(1));
            cd.Id_competencia = cCompetencia.buscarUnaCompetencia(result.GetInt32(2));

            result.Close();
            bd.Close();
            return cd;
        }

        //Actualiza una asociacion existente en la base de datos
        public void actualizarAsociacion(Competencia_Desempeno cd)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarCD";

            bd.CreateCommandSP(sql);

            bd.createParameter("@id_cd", DbType.Int32, cd.Id_cd);
            bd.createParameter("@id_desempeno_cd", DbType.Int32, cd.Id_desempeno.Id_desempeno);
            bd.createParameter("@id_competencia_cd", DbType.Int32, cd.Id_competencia.Id_competencia);
            bd.execute();
            bd.Close();
        }
    }
}
