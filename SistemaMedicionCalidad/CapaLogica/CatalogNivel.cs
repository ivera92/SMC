using Project.CapaDeDatos;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Project
{
    public class CatalogNivel
    {
        //Inserta un nivel a la base de datos
        public void insertarNivel(Nivel n)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insNivel";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_desempeno", DbType.Int32, n.Id_desempeño.Id_desempeno);
            bd.createParameter("@numero_nivel", DbType.Int32, n.Numero_nivel);
            bd.createParameter("nombre_nivel", DbType.String, n.Nombre_nivel);
            bd.createParameter("descripcion_nivel", DbType.String, n.Descripcion_nivel);
            bd.execute();
            bd.Close();
        }

        //Actualiza un nivel a la base de datos
        public void actualizarNivel(Nivel n)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarNivel";

            bd.CreateCommandSP(sql);
            bd.createParameter("id_nivel", DbType.Int32, n.Id_nivel);
            bd.createParameter("@id_desempeno", DbType.Int32, n.Id_desempeño.Id_desempeno);
            bd.createParameter("@numero_nivel", DbType.Int32, n.Numero_nivel);
            bd.createParameter("nombre_nivel", DbType.String, n.Nombre_nivel);
            bd.createParameter("descripcion_nivel", DbType.String, n.Descripcion_nivel);
            bd.execute();
            bd.Close();
        }

        //Elimina un nivel existente en la base de datos
        public void eliminarNivel(int id_nivel)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarNivel";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_nivel", DbType.Int32, id_nivel);
            bd.execute();
            bd.Close();
        }

        //Lista todas los niveles existentes en la base de datos
        public List<Nivel> listarNiveles()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarNiveles";

            bd.CreateCommandSP(sql);
            List<Nivel> lNiveles = new List<Nivel>();
            DbDataReader result = bd.Query();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();

            while (result.Read())
            {
                Nivel n = new Nivel(result.GetInt32(0), cDesempeno.buscarUnDesempeno(result.GetInt32(1)), result.GetInt32(2), result.GetString(3), result.GetString(4));
                lNiveles.Add(n);
            }
            result.Close();
            bd.Close();

            return lNiveles;
        }

        //Lista todas los niveles de un indicador de desempeño existentes en la base de datos
        public List<Nivel> listarNivelesDesempeno(int id_desempeno)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarNivelesDesempeno";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_desempeno", DbType.Int32, id_desempeno);
            List<Nivel> lNiveles = new List<Nivel>();
            DbDataReader result = bd.Query();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();

            while (result.Read())
            {
                Nivel n = new Nivel(result.GetInt32(0), cDesempeno.buscarUnDesempeno(result.GetInt32(1)), result.GetInt32(2), result.GetString(3), result.GetString(4));
                lNiveles.Add(n);
            }
            result.Close();
            bd.Close();

            return lNiveles;
        }

        //Elimina los niveles asociados a un indicador de desempeño existentes en la base de datos
        public void eliminarNivelesDesempeno(int id_desempeno)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarNivelesDesempeno";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_desempeno", DbType.Int32, id_desempeno);
            bd.execute();
            bd.Close();
        }

        //Verifica si ya existe en la base de datos un nivel con la misma descripcion
        public int verificarExistenciaNivel(string descripcion_nivel)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "verificarExistenciaNivel";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@descripcion_nivel", DbType.String, descripcion_nivel);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);

            result.Close();
            bd.Close();
            return existe;
        }

        //Devuelve un nivel acorde a su ID
        public Nivel buscarNivel(int id_nivel)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "buscarNivelID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_nivel", DbType.Int32, id_nivel);
            DbDataReader result = bd.Query();
            result.Read();

            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            Nivel n = new Nivel(result.GetInt32(0), cDesempeno.buscarUnDesempeno(result.GetInt32(1)), result.GetInt32(2), result.GetString(3), result.GetString(4));
            result.Close();
            bd.Close();
            return n;
        }
    }
}
