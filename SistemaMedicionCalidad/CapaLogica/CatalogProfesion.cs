using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Project.CapaDeDatos;

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

        public void agregarProfesionPA(Profesion p)
        {
            DataBase bd= new DataBase();
            bd.connect();

            string sql = "insProfesion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@nombre_profesion", DbType.String, p.Nombre_profesion);
            bd.execute();
            bd.Close();
        }
    }
}
