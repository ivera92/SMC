using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using Project.CapaDeDatos;

namespace Project.CapaDeNegocios
{
    public class CatalogProfesion
    {
        //Lista las profesiones existentes en la base de datos
        public List<Profesion> listarProfesiones()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar
            List<Profesion> lProfesiones = new List<Profesion>();
            string sql = "mostrarProfesiones"; //comando sql
            bd.CreateCommandSP(sql);

            DbDataReader result = bd.Query(); //disponible resultado

            while (result.Read())
            {
                Profesion p = new Profesion(result.GetInt32(0), result.GetString(1));
                lProfesiones.Add(p);
            }
            result.Close();
            bd.Close();

            return lProfesiones;
        }

        //Inserta una profesion en la base de datos
        public void insertarProfesion(Profesion p)
        {
            DataBase bd= new DataBase();
            bd.connect();

            string sql = "insProfesion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@nombre_profesion", DbType.String, p.Nombre_profesion);
            bd.execute();
            bd.Close();
        }

        //Elimina una profesion existente en la base de datos acorde a su ID
        public void eliminarProfesion(int id_profesion)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarProfesion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_profesion", DbType.Int32, id_profesion);
            bd.execute();
            bd.Close();
        }
        //Devuelve una profesion acorde a su ID existente en la base de datos
        public Profesion buscarUnaProfesion(int id_profesion)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "buscarProfesionID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_profesion", DbType.Int32, id_profesion);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            Profesion p = new Profesion(result.GetInt32(0), result.GetString(1));
            result.Close();
            bd.Close();
            return p;
        }

        //Actualiza una profesion existente en la base de datos
        public void actualizarProfesion(Profesion p)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarProfesion";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_profesion", DbType.Int32, p.Id_profesion);
            bd.createParameter("@nombre_profesion", DbType.String, p.Nombre_profesion);
            bd.execute();
            bd.Close();
        }
    }
}
