using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Project.CapaDeNegocios
{
    public class CatalogEscuela
    {
        public List<Escuela> getEscuela()
        {
            CapaDeDatos.DataBase bd = new CapaDeDatos.DataBase();
            bd.connect(); //método conectar
            List<Escuela> escuelas = new List<Escuela>();
            string sql = "select * from Escuela"; //comando sql
            bd.CreateCommand(sql);

            DbDataReader result = bd.Query(); //disponible resultado

            while (result.Read())
            {
                Escuela e = new Escuela(result.GetInt32(0),result.GetString(1));
                escuelas.Add(e);
            }
            result.Close();
            bd.Close();

            return escuelas;
        }
    }
}
