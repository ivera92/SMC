using Project.CapaDeDatos;
using System.Data;
using System.Data.Common;

namespace Project
{
    public class CatalogUsuario
    {
        //Verifica la existencia del usuario, su contraseña, y si coincide con el tipo de usuario seleccionado
        //1 en caso de coincidir los datos, 0 caso contrario
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
        //Cambia la clave de un usuario (actualiza la columna contraseña)
        public int actualizarClave(string rut, string clave, string claveNueva)
        {
            int filasAfectadas = 0;
            //consulta a la base de datos
            string sql = "editarClaveUsuario";

            //cadena conexion
            DataBase bd = new DataBase();
            bd.connect();

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_usuario", DbType.String, rut);
            bd.createParameter("@contrasena_actual", DbType.String, clave);
            bd.createParameter("@contrasena_nueva", DbType.String, claveNueva);
            DbDataReader result = bd.Query();//disponible resultado
            
            result.Read();
            filasAfectadas = result.GetInt32(0);
            result.Close();
            bd.Close();
            return filasAfectadas;
        }
    }
}
