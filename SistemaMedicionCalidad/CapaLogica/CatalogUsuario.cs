using Project.CapaDeDatos;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Net.Mail;
using System.Collections.Generic;

namespace Project
{
    
    public class CatalogUsuario
    {
        //Verifica la existencia del usuario, su contraseña, y si coincide con el tipo de usuario seleccionado
        //1 en caso de coincidir los datos, 0 caso contrario
        public string[] Autenticar(string rut_usuario, string contrasena)
        {            
            //consulta a la base de datos
            string sql = "autentificarUsuario";
            //cadena conexion

            DataBase bd = new DataBase();
            bd.connect();
            string s = encriptar(contrasena);

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_usuario", DbType.String, rut_usuario);
            bd.createParameter("@contraseña_usuario", DbType.String, s);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            int numero = result.GetInt32(0);
            int tipo_usuario = result.GetInt32(1);
            bool activo = result.GetBoolean(2);
            string[] autentificacion = { numero+"",  tipo_usuario+"", activo+""};

            return autentificacion;
        }

        public string verificarRut(string usuario)
        {
            string s = "";
            string sql = "buscarCorreo";
            //cadena conexion

            DataBase bd = new DataBase();
            bd.connect();

            bd.CreateCommandSP(sql);
            bd.createParameter("@usuario", DbType.String, usuario);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            s = result.GetString(0);
            return s;
        }

        public static string encriptar(string clave)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //Calcula el hash de los bytes de texto
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(clave));

            //Obtiene el resultado del hash después de calcularlo
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //Cambia en 2 dígitos hexadecimales
                //para cada byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public static string desencriptar(string textoEncriptado)
        {
            try
            {
                string key = "qualityinfosolutions";
                byte[] keyArray;
                byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

                //algoritmo MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

                tdes.Clear();
                textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);

            }
            catch (Exception)
            {

            }
            return textoEncriptado;
        }

        //Cambia la clave de un usuario (actualiza la columna contraseña)
        public int actualizarClave(string usuario, string clave, string claveNueva)
        {
            int filasAfectadas = 0;
            //consulta a la base de datos
            string sql = "editarClaveUsuario";

            //cadena conexion
            DataBase bd = new DataBase();
            bd.connect();
            string cActual = encriptar(clave);
            string cNueva = encriptar(claveNueva);
            bd.CreateCommandSP(sql);
            bd.createParameter("@usuario", DbType.String, usuario);
            bd.createParameter("@contrasena_actual", DbType.String, cActual);
            bd.createParameter("@contrasena_nueva", DbType.String, cNueva);
            DbDataReader result = bd.Query();//disponible resultado
            
            result.Read();
            filasAfectadas = result.GetInt32(0);
            result.Close();
            bd.Close();
            return filasAfectadas;
        }

        //Obtiene la clave asociada a un rut
        public int reestablecerClave(string usuario)
        {
            Random r = new Random();
            int pwTemp = r.Next(100000, 999999);
            string pwTempS = encriptar(pwTemp + "");

            int filasAfectadas = 0;
            //consulta a la base de datos
            string sql = "recuperarClaveUsuario";

            //cadena conexion
            DataBase bd = new DataBase();
            bd.connect();

            bd.CreateCommandSP(sql);
            bd.createParameter("@usuario", DbType.String, usuario);
            bd.createParameter("@contrasena_nueva", DbType.String, pwTempS);
            DbDataReader result = bd.Query();//disponible resultado

            result.Read();
            filasAfectadas = result.GetInt32(0);
            result.Close();
            bd.Close();
            return pwTemp;
        }

        public void  recuperarContrasena(string usuario, string correo)
        {
            CatalogUsuario cUsuario = new CatalogUsuario();
            int pw = cUsuario.reestablecerClave(usuario);
            MailMessage msg = new MailMessage();
            msg.To.Add(correo);
            msg.From = new MailAddress("soporte.smcfe@gmail.com", "Administrador", Encoding.UTF8);
            msg.Subject = "Nuevo Password - Cuenta Sistema-Medicion-Calidad-Formacion-Estudiantes";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Se ha generado un nuevo Password: \n" + pw;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            //Aquí es donde se hace lo especial
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("soporte.smcfe@gmail.com", "soporte_smcfe");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
            client.Send(msg);
        }

        //Inserta un usuario a la base de datos
        public void insertarUsuario(Usuario u)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insUsuario";
            string contraseña = encriptar(u.Nombre_usuario);

            bd.CreateCommandSP(sql);
            bd.createParameter("@nombre_usuario", DbType.String, u.Nombre_usuario);
            bd.createParameter("@id_tipo_usuario_usuario", DbType.Int32, u.Tipo_usuario_usuario.Id_tipo_usuario);
            bd.createParameter("@contrasena_usuario", DbType.String, contraseña);
            bd.createParameter("@correo_usuario", DbType.String, u.Correo_usuario);
            bd.execute();
            bd.Close();
        }

        //Verifica si existe un usuario con el mismo nombre en la base de datos
        public int verificarExistenciaUsuario(string nombre_usuario)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "verificarExistenciaUsuario";

            bd.CreateCommandSP(sql);
            bd.createParameter("@nombre_usuario", DbType.String, nombre_usuario);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);
            bd.Close();
            result.Close();
            return existe;
        }

        //Editar estado de usuario
        public void actualizarEstado(string nombre_usuario, bool estado_usuario) { 

            string sql = "editarEstadoUsuario";

            //cadena conexion
            DataBase bd = new DataBase();
            bd.connect();
            bd.CreateCommandSP(sql);
            bd.createParameter("@nombre_usuario", DbType.String, nombre_usuario);
            bd.createParameter("@estado_usuario", DbType.Boolean, estado_usuario);
            bd.execute();
            bd.Close();
        }

        //Lista los usuarios existentes en la base de datos
        public List<Usuario> listarUsuarios()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarUsuarios";
            bd.CreateCommandSP(sqlSearch);
            List<Usuario> lUsuarios = new List<Usuario>();
            DbDataReader result = bd.Query();//disponible resultado
            CatalogTipoUsuario cTU = new CatalogTipoUsuario();
            while (result.Read())
            {
                string estado = "";
                if (result.GetBoolean(4) == true)
                {
                    estado = "Activo";
                }
                else
                {
                    estado = "Inactivo";
                }
                Usuario u = new Usuario(result.GetString(0), cTU.buscarUnTipoUsuario(result.GetInt32(1)), result.GetString(3), estado);
                lUsuarios.Add(u);
            }
            result.Close();
            bd.Close();
            return lUsuarios;
        }

        //Lista los usuarios existentes en la base de datos despues de una busqueda
        public List<Usuario> listarUsuariosBusqueda(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarUsuariosBusqueda";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@buscar", DbType.String, buscar);
            List<Usuario> lUsuarios = new List<Usuario>();
            DbDataReader result = bd.Query();//disponible resultado
            CatalogTipoUsuario cTU = new CatalogTipoUsuario();
            while (result.Read())
            {
                string estado = "";
                if (result.GetBoolean(4) == true)
                {
                    estado = "Activo";
                }
                else
                {
                    estado = "Inactivo";
                }
                Usuario u = new Usuario(result.GetString(0), cTU.buscarUnTipoUsuario(result.GetInt32(1)), result.GetString(3), estado);
                lUsuarios.Add(u);
            }
            result.Close();
            bd.Close();
            return lUsuarios;
        }
    }
}
