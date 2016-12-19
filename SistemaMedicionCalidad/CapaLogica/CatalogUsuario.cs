using Project.CapaDeDatos;
using System.Data;
using System.Data.Common;

namespace Project
{
    public class CatalogUsuario
    {
        public static bool Autenticar(string rut_usuario, string contrasena, int id_tipo_usuario)
        {
        //consulta a la base de datos
        string sql = @"SELECT COUNT(*) FROM Usuario WHERE rut_usuario = @rut_usuario AND contrasena_usuario = @contrasena_usuario AND id_tipo_usuario_usuario=@id_tipo_usuario";
        //cadena conexion

        DataBase bd=new DataBase();
        bd.connect();

        bd.CreateCommand(sql);
        bd.createParameter("@id_tipo_usuario", DbType.Int32, id_tipo_usuario);
        bd.createParameter("@rut_usuario", DbType.String, rut_usuario);
        bd.createParameter("@contrasena_usuario", DbType.String, contrasena);
        DbDataReader result = bd.Query();//disponible resultado
        result.Read();
        int count = result.GetInt32(0);
     
        if (count == 0)
            return false;
        else
            return true;
        }
    }
}
