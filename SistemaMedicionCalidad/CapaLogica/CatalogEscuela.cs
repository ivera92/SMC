using System.Collections.Generic;
using System.Data.Common;
using Project.CapaDeDatos;
using System.Data;

namespace Project.CapaDeNegocios
{
    public class CatalogEscuela
    { 
        //Lista todas las escuelas existentes en la base de datos
        public List<Escuela> listarEscuelas()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarEscuelas";
            bd.CreateCommandSP(sqlSearch);
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

        //Devuelve una escuela acorde a su ID
        public Escuela buscarUnaEscuela(int id_escuela)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "buscarEscuelaID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_escuela", DbType.Int32, id_escuela);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            Escuela es = new Escuela(result.GetInt32(0), result.GetString(1));
            result.Close();
            bd.Close();
            return es;
        }

        //Devuelve una escuela acorde al nombre
        //Usado cuando se importan alumnos desde Excel
        public Escuela buscarUnaEscuelaNombre(string nombre_escuela)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "buscarEscuelaNombre";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@nombre_escuela", DbType.String, nombre_escuela);
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
            bd.createParameter("@nombre_escuela", DbType.String, e.Nombre_escuela);
            bd.execute();
            bd.Close();
        }

        //Actualiza una escuela existente en la base de datos
        public void actualizarEscuela(Escuela e)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarEscuela";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_escuela", DbType.Int32, e.Id_escuela);
            bd.createParameter("@nombre_escuela", DbType.String, e.Nombre_escuela);
            bd.execute();
            bd.Close();
        }

        //Verifica si existe una escuela creada con el mismo nombre
        public int verificarExistenciaEscuela(string nombre_escuela)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "verificarExistenciaEscuela";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@nombre_escuela", DbType.String, nombre_escuela);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);

            result.Close();
            bd.Close();
            return existe;
        }
    }
}
