using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Project.CapaDeDatos;
using System.Data;

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

        public List<Escuela> buscarEscuela(string buscar)
        {
            CapaDeDatos.DataBase bd = new DataBase();
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
            CapaDeDatos.DataBase bd = new DataBase();
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
            CapaDeDatos.DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select * from escuela where id_escuela='" + id_escuela + "'";
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
            return lescuela.First();
        }

        public void eliminarEscuelaPA(int id_escuela)
        {
            CapaDeDatos.DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarEscuela";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_escuela", DbType.Int32, id_escuela);
            bd.execute();
            bd.Close();
        }

        public void agregarEscuelaPA(Escuela e)
        {
            CapaDeDatos.DataBase bd = new DataBase();
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
            CapaDeDatos.DataBase bd = new DataBase();
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
