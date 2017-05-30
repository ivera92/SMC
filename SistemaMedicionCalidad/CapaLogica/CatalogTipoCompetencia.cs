using Project.CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Project
{
    public class CatalogTipoCompetencia
    {
        //Lista los tipos de competencias existentes en la base de datos
        public List<Tipo_Competencia> listarTipoCompetencias()
        {
            DataBase db = new DataBase();
            db.connect();

            string sql = "mostrarTipoCompetencias";
            db.CreateCommandSP(sql);

            DbDataReader result = db.Query();
            List<Tipo_Competencia> lTipoCompetencias = new List<Tipo_Competencia>();
            while (result.Read())
            {
                Tipo_Competencia tc = new Tipo_Competencia(result.GetInt32(0), result.GetString(1));
                lTipoCompetencias.Add(tc);

            }
            return lTipoCompetencias;
        }

        //Devuelve un tipo de competencia acorde a su ID
        public Tipo_Competencia buscarUnTipoCompetencia(int id_tipo_competencia)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "buscarTipoCompetenciaID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_tipo_competencia", DbType.Int32, id_tipo_competencia);
            DbDataReader result = bd.Query();
            result.Read();

            Tipo_Competencia tc = new Tipo_Competencia(result.GetInt32(0), result.GetString(1));

            result.Close();
            bd.Close();
            return tc;
        }
    }
}
