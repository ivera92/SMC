using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;
using Project.CapaDeDatos;
using Project.CapaDeNegocios;

namespace Project
{
    public class CatalogDocente
    {
        //Inserta un docente a la base de datos
        public void insertarDocente(Docente d)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insDocentes";
            string contrasenaEn = encriptar(d.Rut_persona);
            bd.CreateCommandSP(sql);
            bd.createParameter("@contraseña_usuario", DbType.String, contrasenaEn);
            bd.createParameter("@rut_docente", DbType.String, d.Rut_persona);
            bd.createParameter("@id_profesion_docente", DbType.Int32, d.Profesion_docente.Id_profesion);
            bd.createParameter("@nombre_docente", DbType.String, d.Nombre_persona);
            bd.createParameter("@fecha_nacimiento_docente", DbType.Date, d.Fecha_nacimiento_persona);
            bd.createParameter("@direccion_docente", DbType.String, d.Direccion_persona);
            bd.createParameter("@telefono_docente", DbType.Int32, d.Telefono_persona);
            bd.createParameter("@id_pais_docente", DbType.Int32, d.Pais_persona.Id_pais);
            bd.createParameter("@sexo_docente", DbType.Boolean, d.Sexo_persona);
            bd.createParameter("@correo_docente", DbType.String, d.Correo_persona);
            bd.createParameter("@disponibilidad_docente", DbType.Boolean, d.Disponibilidad_docente);
            bd.execute();
            bd.Close();
        }

        //Devuelve un docente acorde al RUT
        public Docente buscarUnDocente(string rut)
        {
            DataBase bd = new DataBase();
            bd.connect();

            if (rut == null)
                rut = "";

            string sql = "select * from docente where rut_docente='" + rut + "'";
            bd.CreateCommand(sql);
            bd.createParameter("@rut", DbType.String, rut);

            Profesion p = new Profesion();
            Pais pa = new Pais();
            DbDataReader result = bd.Query();
            result.Read();

            Docente d = new Docente();
            d.Profesion_docente = p;
            d.Pais_persona = pa;
            d.Rut_persona = result.GetString(0);
            d.Profesion_docente.Id_profesion = result.GetInt32(1);
            d.Pais_persona.Id_pais = result.GetInt32(2);
            d.Nombre_persona = result.GetString(3);
            d.Fecha_nacimiento_persona = result.GetDateTime(4);
            d.Direccion_persona = result.GetString(5);
            d.Telefono_persona = result.GetInt32(6);
            d.Sexo_persona = result.GetBoolean(7);
            d.Correo_persona = result.GetString(8);
            d.Disponibilidad_docente = result.GetBoolean(9);

            result.Close();
            bd.Close();
            return d;
        }

        //Lista todos los docentes existentes en la base de datos
        public List<Docente> listarDocentes()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sql = "mostrarDocentes";
            bd.CreateCommandSP(sql);

            List<Docente> lDocentes = new List<Docente>();
            DbDataReader result = bd.Query();
            CatalogProfesion cProfesion = new CatalogProfesion();
            Profesion p = new Profesion();
            
            while (result.Read())
            {
                Docente d = new Docente();
                d.Profesion_docente = p;
                p =cProfesion.buscarUnaProfesion(result.GetInt32(2));
                d.Nombre_persona = result.GetString(0);
                d.Rut_persona = result.GetString(1);
                d.Profesion_docente.Nombre_profesion = p.Nombre_profesion;
                lDocentes.Add(d);
            }
            result.Close();
            bd.Close();
            return lDocentes;
        }

        //Elimina un docente existente en la base de datos
        public void eliminarDocente(string rut_docente)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarDocente";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_docente", DbType.String, rut_docente);
            bd.execute();
            bd.Close();
        }

        //Actualiza un docente existente en la base de datos
        public void actualizarDocente(Docente d)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarDocente";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_docente", DbType.String, d.Rut_persona);
            bd.createParameter("@id_profesion_docente", DbType.Int32, d.Profesion_docente.Id_profesion);
            bd.createParameter("@nombre_docente", DbType.String, d.Nombre_persona);
            bd.createParameter("@fecha_nacimiento_docente", DbType.Date, d.Fecha_nacimiento_persona);
            bd.createParameter("@direccion_docente", DbType.String, d.Direccion_persona);
            bd.createParameter("@telefono_docente", DbType.Int32, d.Telefono_persona);
            bd.createParameter("@id_pais_docente", DbType.Int32, d.Pais_persona.Id_pais);
            bd.createParameter("@sexo_docente", DbType.Boolean, d.Sexo_persona);
            bd.createParameter("@correo_docente", DbType.String, d.Correo_persona);
            bd.createParameter("@disponibilidad_docente", DbType.Boolean, d.Disponibilidad_docente);
            bd.execute();
            bd.Close();
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
    }
}
