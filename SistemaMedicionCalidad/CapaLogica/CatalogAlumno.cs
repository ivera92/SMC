using System.Collections.Generic;
using Project.CapaDeDatos;
using System.Data.Common;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Project
{
    public class CatalogAlumno
    {
        //Inserta un alumno a la base de datos
        public void insertarAlumno(Alumno a)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insAlumno";
            string contraseña = encriptar(a.Rut_persona);

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, a.Rut_persona);
            bd.createParameter("@contraseña_usuario", DbType.String, contraseña);
            bd.createParameter("@nombre_alumno", DbType.String, a.Nombre_persona);
            bd.createParameter("@correo_alumno", DbType.String, a.Correo_persona);
            bd.execute();
            bd.Close();
        }

        //Actualiza un alumno de la base de datos
        public void actualizarAlumno(Alumno a)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarAlumno";
            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, a.Rut_persona);
            bd.createParameter("@nombre_alumno", DbType.String, a.Nombre_persona);
            bd.createParameter("@correo_alumno", DbType.String, a.Correo_persona);
            bd.execute();
            bd.Close();
        }

        //Elimina un alumno de la base de datos
        public void eliminarAlumno(string rut_alumno)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarAlumno";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);
            bd.execute();
            bd.Close();
        }
        
        //Lista los alumnos existentes en la base de datos
        public List<Alumno> listarAlumnos()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarAlumnos";
            bd.CreateCommandSP(sqlSearch);
            List<Alumno> lAlumnos = new List<Alumno>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Alumno a = new Alumno(result.GetString(0), result.GetString(1), result.GetString(2));
                lAlumnos.Add(a);
            }
            result.Close();
            bd.Close();
            return lAlumnos;
        }

        //Lista alumnos de la base de datos acorde a busqueda ya sea por rut o nombre
        public List<Alumno> listarAlumnosBusqueda(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarAlumnosBusqueda";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@buscar", DbType.String, buscar);
            List<Alumno> lAlumnos = new List<Alumno>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Alumno a = new Alumno(result.GetString(0), result.GetString(1), result.GetString(2));
                lAlumnos.Add(a);
            }
            result.Close();
            bd.Close();
            return lAlumnos;
        }

        //Busca un alumno por su rut
        public Alumno buscarAlumnoPorRut(string rut)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "buscarAlumnoPorRut";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@rut", DbType.String, rut);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            Alumno a = new Alumno();

            a.Rut_persona = result.GetString(0);
            a.Nombre_persona = result.GetString(1);
            a.Correo_persona = result.GetString(2);
            result.Close();
            bd.Close();
            return a;
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