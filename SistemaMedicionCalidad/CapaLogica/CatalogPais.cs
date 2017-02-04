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
    }
}
