using System.Collections.Generic;
using System.Data.Common;
using Project.CapaDeDatos;

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
    }
}
