using Project.CapaDeDatos;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Project
{
    public class CatalogAmbito
    {
        //Lista los ambitos existentes en la base de datos
        public List<Ambito> listarAmbitos()
        {
            DataBase db = new DataBase();
            db.connect();

            string sql = "mostrarAmbitos";
            db.CreateCommandSP(sql);

            DbDataReader result = db.Query();
            List<Ambito> lAmbitos = new List<Ambito>();
            while (result.Read())
            {
                Ambito a = new Ambito(result.GetInt32(0), result.GetString(1));
                lAmbitos.Add(a);

            }
            return lAmbitos;
        }

        //Devuelve un ambito acorde a su ID
        public Ambito buscarUnAmbito(int id_ambito)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "buscarAmbitoID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_ambito", DbType.Int32, id_ambito);
            DbDataReader result = bd.Query();
            result.Read();

            Ambito a = new Ambito(result.GetInt32(0), result.GetString(1));

            result.Close();
            bd.Close();
            return a;
        }
    }
}
