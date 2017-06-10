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

            string sql = "insDocente";
            string contrasenaEn = encriptar(d.Rut_persona);
            bd.CreateCommandSP(sql);
            bd.createParameter("@contraseña_usuario", DbType.String, contrasenaEn);
            bd.createParameter("@rut_docente", DbType.String, d.Rut_persona);
            bd.createParameter("@nombre_docente", DbType.String, d.Nombre_persona);
            bd.createParameter("@correo_docente", DbType.String, d.Correo_persona);
            bd.createParameter("@disponibilidad_docente", DbType.Boolean, d.Contrato_docente);
            bd.execute();
            bd.Close();
        }

        //Devuelve un docente acorde al RUT
        public Docente buscarUnDocente(string rut)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "buscarDocentePorRut";
            bd.CreateCommandSP(sql);
            bd.createParameter("@rut", DbType.String, rut);
            
            DbDataReader result = bd.Query();
            result.Read();

            Docente d = new Docente();
            d.Rut_persona = result.GetString(0);
            d.Nombre_persona = result.GetString(1);
            d.Correo_persona = result.GetString(2);
            d.Contrato_docente = result.GetBoolean(3);

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
            
            while (result.Read())
            {
                Docente d = new Docente(result.GetString(0), result.GetString(1), result.GetString(2), result.GetBoolean(3));
                lDocentes.Add(d);
            }
            result.Close();
            bd.Close();
            return lDocentes;
        }

        //Lista todos los docentes existentes con un filtro de busqueda en la base de datos
        public List<Docente> listarDocentesBusqueda(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sql = "mostrarDocentesBusqueda";
            bd.CreateCommandSP(sql);
            bd.createParameter("@buscar", DbType.String, buscar);

            List<Docente> lDocentes = new List<Docente>();
            DbDataReader result = bd.Query();
            CatalogProfesion cProfesion = new CatalogProfesion();

            while (result.Read())
            {
                Docente d = new Docente(result.GetString(0), result.GetString(1), result.GetString(2), result.GetBoolean(3)); ;
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
            bd.createParameter("@nombre_docente", DbType.String, d.Nombre_persona);
            bd.createParameter("@correo_docente", DbType.String, d.Correo_persona);
            bd.createParameter("@disponibilidad_docente", DbType.Boolean, d.Contrato_docente);
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
