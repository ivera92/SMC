using System.Collections.Generic;
using System.Data.Common;
using Project.CapaDeDatos;
using System.Data;

namespace Project.CapaDeNegocios
{
    public class CatalogEscuela
    { 
        //Lista las escuelas existentes en la base de datos que cumplan el criterio de busqueda
        public List<Escuela> buscarEscuela(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            if (buscar == null)
                buscar = "";

            string sqlSearch = "select * from escuela where nombre_escuela like '" + buscar + "%' or id_escuela like '" + buscar + "%'";
            bd.CreateCommand(sqlSearch);
            List<Escuela> lEscuelas = new List<Escuela>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Escuela e = new Escuela(result.GetInt32(0), result.GetString(1));
                lEscuelas.Add(e);
            }
            result.Close();
            bd.Close();
            return lEscuelas;
        }
        //Lista todas las escuelas existentes en la base de datos
        public List<Escuela> listarEscuelas()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select id_escuela, nombre_escuela from escuela";
            bd.CreateCommand(sqlSearch);
            List<Escuela> lEscuelas = new List<Escuela>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Escuela es = new Escuela(result.GetInt32(0),result.GetString(1));
                lEscuelas.Add(es);
            }
            result.Close();
            bd.Close();
            return lEscuelas;
        }

        //Devuelve una esculela acorde a su ID
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

        //Elimina una Escuela existente en la base de datos acorde a su ID
        public void eliminarEscuela(int id_escuela)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarEscuela";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_escuela", DbType.Int32, id_escuela);
            bd.execute();
            bd.Close();
        }

        //Inserta una escuela en la base de datos
        public void insertarEscuela(Escuela e)
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

        //Actualiza una escuela existente en la base de datos
        public void actualizarEscuela(Escuela e)
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
