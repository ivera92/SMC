using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Project.CapaDeNegocios
{
    public class CatalogProfesion
    {
        public List<Profesion> getProfesion()
        {
            CapaDeDatos.DataBase bd = new CapaDeDatos.DataBase();
            bd.connect(); //método conectar
            List<Profesion> profesiones = new List<Profesion>();
            string sql = "select * from Profesion"; //comando sql
            bd.CreateCommand(sql);

            DbDataReader result = bd.Query(); //disponible resultado

            while (result.Read())
            {
                Profesion p = new Profesion(result.GetInt32(0), result.GetString(1));
                profesiones.Add(p);
            }
            result.Close();
            bd.Close();

            return profesiones;
        }
    }
}
