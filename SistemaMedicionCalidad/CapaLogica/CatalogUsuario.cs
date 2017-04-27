using Project.CapaDeDatos;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Net.Mail;

namespace Project
{
    
    public class CatalogUsuario
    {
        //Verifica la existencia del usuario, su contraseña, y si coincide con el tipo de usuario seleccionado
        //1 en caso de coincidir los datos, 0 caso contrario
        public static bool Autenticar(string rut_usuario, string contrasena, int id_tipo_usuario)
        {
            
            //consulta a la base de datos
            string sql = "autentificarUsuario";
            //cadena conexion

            DataBase bd = new DataBase();
            bd.connect();
            string s = encriptar(contrasena);

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_tipo_usuario_usuario", DbType.Int32, id_tipo_usuario);
            bd.createParameter("@rut_usuario", DbType.String, rut_usuario);
            bd.createParameter("@contraseña_usuario", DbType.String, s);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            int count = result.GetInt32(0);

            if (count == 0)
                return false;
            else
                return true;
        }

        public string verificarRut(string rut_usuario)
        {
            string s = "";
            string sql = "buscarCorreoRut";
            //cadena conexion

            DataBase bd = new DataBase();
            bd.connect();

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_usuario", DbType.String, rut_usuario);
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

        //Obtiene la clave asociada a un rut
        public int reestablecerClave(string rut)
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
            bd.createParameter("@rut_usuario", DbType.String, rut);
            bd.createParameter("@contrasena_nueva", DbType.String, pwTempS);
            DbDataReader result = bd.Query();//disponible resultado

            result.Read();
            filasAfectadas = result.GetInt32(0);
            result.Close();
            bd.Close();
            return pwTemp;
        }

        public void  recuperarContrasena(string rut, string correo)
        {
            CatalogUsuario cUsuario = new CatalogUsuario();
            int pw = cUsuario.reestablecerClave(rut);
            MailMessage msg = new MailMessage();
            msg.To.Add(correo);
            msg.From = new MailAddress("soporte.smcfe@gmail.com", "Administrador", Encoding.UTF8);
            msg.Subject = "Recuperar contraseña";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = "Su contraseña actual es: " + pw;
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
    }
}
