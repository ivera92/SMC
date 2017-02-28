using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using Project.CapaDeDatos;
using System.Data;

namespace Project.CapaDeNegocios
{
    public class CatalogEscuela
    { 
        public List<Escuela> buscarEscuela(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            if (buscar == null)
                buscar = "";

            string sqlSearch = "select * from escuela where nombre_escuela like '" + buscar + "%' or id_escuela like '" + buscar + "%'";
            bd.CreateCommand(sqlSearch);
            List<Escuela> lescuela = new List<Escuela>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Escuela e = new Escuela(result.GetInt32(0), result.GetString(1));
                lescuela.Add(e);
            }
            result.Close();
            bd.Close();
            return lescuela;
        }
        public List<Escuela> mostrarEscuelas()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select id_escuela, nombre_escuela from escuela";
            bd.CreateCommand(sqlSearch);
            List<Escuela> lescuela = new List<Escuela>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Escuela es = new Escuela(result.GetInt32(0),result.GetString(1));
                lescuela.Add(es);
            }
            result.Close();
            bd.Close();
            return lescuela;
        }

        public Escuela buscarUnaEscuela(int id_escuela)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select * from escuela where id_escuela='" + id_escuela + "'";
            bd.CreateCommand(sqlSearch);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            Escuela es = new Escuela(result.GetInt32(0), result.GetString(1));
            result.Close();
            bd.Close();
            return es;
        }

        public void eliminarEscuelaPA(int id_escuela)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarEscuela";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_escuela", DbType.Int32, id_escuela);
            bd.execute();
            bd.Close();
        }

        public void agregarEscuelaPA(Escuela e)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insEscuela";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_escuela", DbType.Int32, e.Id_escuela);
            bd.createParameter("@nombre_escuela", DbType.String, e.Nombre_escuela);
            bd.execute();
            bd.Close();
        }

        public void editarEscuelaPA(Escuela e)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarEscuelas";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_escuela", DbType.Int32, e.Id_escuela);
            bd.createParameter("@nombre_escuela", DbType.String, e.Nombre_escuela);
            bd.execute();
            bd.Close();
        }
    }
}
