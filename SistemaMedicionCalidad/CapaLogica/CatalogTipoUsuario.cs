using System.Collections.Generic;
using System.Data.Common;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogTipoUsuario
    {
        public List<Tipo_Usuario> mostrarTiposU()
        {
            DataBase db = new DataBase();
            db.connect();

            string sql = "select * from tipo_usuario";
            db.CreateCommand(sql);

            DbDataReader result = db.Query();
            List<Tipo_Usuario> ltp = new List<Tipo_Usuario>();
            while(result.Read())
            {
                Tipo_Usuario tp = new Tipo_Usuario(result.GetInt32(0), result.GetString(1));
                ltp.Add(tp);
                
            }
            return ltp;
        }
    }
}
