using System.Collections.Generic;
using System.Data.Common;
using Project.CapaDeDatos;
using System.Data;

namespace Project
{
    public class CatalogPais
    {
        //Lista los paises existentes en la base de datos
        public List<Pais> listarPaises()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar
            List<Pais> lPaises = new List<Pais>();
            string sql = "select * from pais"; //comando sql
            bd.CreateCommand(sql);

            DbDataReader result = bd.Query(); //disponible resultado

            while (result.Read())
            {
                Pais p = new Pais(result.GetInt32(0), result.GetString(1));
                lPaises.Add(p);
            }
            result.Close();
            bd.Close();

            return lPaises;
        }

        //Devuelve un pais acorde a su ID
        public Pais buscarUnPais(int id_pais)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "buscarPaisID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_pais", DbType.Int32, id_pais);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            Pais p = new Pais(result.GetInt32(0),result.GetString(1));

            result.Close();
            bd.Close();
            return p;
        }
    }
}