using System.Collections.Generic;
using System.Data.Common;
using Project.CapaDeDatos;
using System.Data;

namespace Project
{
    public class CatalogTipoUsuario
    {
        //Lista los tipos de usuario existentes en la base de datos
        public List<Tipo_Usuario> listarTiposUsuario()
        {
            DataBase db = new DataBase();
            db.connect();

            string sql = "mostrarTipoUsuarios";
            db.CreateCommandSP(sql);

            DbDataReader result = db.Query();
            List<Tipo_Usuario> lTiposUsuario = new List<Tipo_Usuario>();
            while(result.Read())
            {
                Tipo_Usuario tp = new Tipo_Usuario(result.GetInt32(0), result.GetString(1));
                lTiposUsuario.Add(tp);
                
            }
            return lTiposUsuario;
        }

        //Devuelve un tipo de usuario acorde a su ID
        public Tipo_Usuario buscarUnTipoUsuario(int id_tipo_usuario)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "buscarTipoUsuarioID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_tipo_usuario", DbType.Int32, id_tipo_usuario);
            DbDataReader result = bd.Query();
            result.Read();

            Tipo_Usuario tu = new Tipo_Usuario(result.GetInt32(0), result.GetString(1));

            result.Close();
            bd.Close();
            return tu;
        }
    }
}
