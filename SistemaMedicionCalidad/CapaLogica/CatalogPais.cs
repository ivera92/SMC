using System.Collections.Generic;
using System.Data.Common;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogPais
    {
        public List<Pais> mostrarPaises()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar
            List<Pais> lpais = new List<Pais>();
            string sql = "select * from pais"; //comando sql
            bd.CreateCommand(sql);

            DbDataReader result = bd.Query(); //disponible resultado

            while (result.Read())
            {
                Pais p = new Pais(result.GetInt32(0), result.GetString(1));
                lpais.Add(p);
            }
            result.Close();
            bd.Close();

            return lpais;
        }

        public Pais buscarUnPais(int id_pais)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select nombre_pais from pais where id_pais='" + id_pais + "'";
            bd.CreateCommand(sqlSearch);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            Pais p = new Pais(result.GetString(0));

            result.Close();
            bd.Close();
            return p;
        }
    }
}
