using System.Collections.Generic;
using Project.CapaDeDatos;
using System.Data.Common;
using System.Data;
using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Project.CapaDeNegocios
{
    public class CatalogAlumno
    {
        //Inserta un alumno a la base de datos
        public void insertarAlumno(Alumno a)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insAlumnos";
            string contraseña = encriptar(a.Rut_persona);

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, a.Rut_persona);
            bd.createParameter("@contraseña_usuario", DbType.String, contraseña);
            bd.createParameter("@id_escuela_alumno", DbType.Int32, a.Escuela_alumno.Id_escuela);
            bd.createParameter("@id_pais_alumno", DbType.Int32, a.Pais_persona.Id_pais);
            bd.createParameter("@nombre_alumno", DbType.String, a.Nombre_persona);
            bd.createParameter("@fecha_nacimiento_alumno", DbType.Date, a.Fecha_nacimiento_persona);
            bd.createParameter("@direccion_alumno", DbType.String, a.Direccion_persona);
            bd.createParameter("@telefono_alumno", DbType.Int32, a.Telefono_persona);
            bd.createParameter("@sexo_alumno", DbType.Boolean, a.Sexo_persona);
            bd.createParameter("@correo_alumno", DbType.String, a.Correo_persona);
            bd.createParameter("@promocion_alumno", DbType.Int32, a.Promocion_alumno);
            bd.createParameter("@beneficio_alumno", DbType.Boolean, a.Beneficio_alumno);
            bd.execute();
            bd.Close();
        }

        //Actualiza un alumno de la base de datos
        public void actualizarAlumno(Alumno a)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarAlumnos";
            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, a.Rut_persona);
            bd.createParameter("@id_escuela_alumno", DbType.Int32, a.Escuela_alumno.Id_escuela);
            bd.createParameter("@nombre_alumno", DbType.String, a.Nombre_persona);
            bd.createParameter("@fecha_nacimiento_alumno", DbType.Date, a.Fecha_nacimiento_persona);
            bd.createParameter("@direccion_alumno", DbType.String, a.Direccion_persona);
            bd.createParameter("@telefono_alumno", DbType.Int32, a.Telefono_persona);
            bd.createParameter("@id_pais_alumno", DbType.Int32, a.Pais_persona.Id_pais);
            bd.createParameter("@sexo_alumno", DbType.Boolean, a.Sexo_persona);
            bd.createParameter("@correo_alumno", DbType.String, a.Correo_persona);
            bd.createParameter("@promocion_alumno", DbType.Int32, a.Promocion_alumno);
            bd.createParameter("@beneficio_alumno", DbType.Boolean, a.Beneficio_alumno);
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
            CatalogEscuela cEscuela = new CatalogEscuela();
            Escuela es = new Escuela();
            while (result.Read())
            {
                Alumno a = new Alumno();
                a.Escuela_alumno = es;
                es = cEscuela.buscarUnaEscuela(result.GetInt32(2));
                              
                a.Nombre_persona = result.GetString(0);
                a.Rut_persona = result.GetString(1);
                a.Escuela_alumno.Nombre_escuela = es.Nombre_escuela;
                a.Promocion_alumno = result.GetInt32(3);
                lAlumnos.Add(a);
            }
            result.Close();
            bd.Close();
            return lAlumnos;
        }

        //Lista alumnos de la base de datos acorde a busqueda
        public List<Alumno> buscarAlumno(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            if (buscar == null)
                buscar = "";

            string sqlSearch = "mostrarAlumnosBusqueda";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@buscar", DbType.String, buscar);
            List<Alumno> lAlumnos = new List<Alumno>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                CatalogEscuela cEscuela = new CatalogEscuela();
                Alumno a = new Alumno();
                Pais p = new Pais();
                Escuela es = new Escuela();

                a.Escuela_alumno = es;
                es = cEscuela.buscarUnaEscuela(result.GetInt32(1));

                a.Nombre_persona = result.GetString(3);
                a.Rut_persona = result.GetString(0);
                a.Escuela_alumno.Nombre_escuela = es.Nombre_escuela;
                a.Promocion_alumno = result.GetInt32(9);
                lAlumnos.Add(a);
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
            Pais p = new Pais();
            Escuela es = new Escuela();
            a.Pais_persona = p;
            a.Escuela_alumno = es;

            a.Rut_persona = result.GetString(0);
            a.Escuela_alumno.Id_escuela = result.GetInt32(1);
            a.Pais_persona.Id_pais = result.GetInt32(2);
            a.Nombre_persona = result.GetString(3);
            a.Fecha_nacimiento_persona = result.GetDateTime(4);
            a.Direccion_persona = result.GetString(5);
            a.Telefono_persona = result.GetInt32(6);
            a.Sexo_persona = result.GetBoolean(7);
            a.Correo_persona = result.GetString(8);
            a.Promocion_alumno = result.GetInt32(9);
            a.Beneficio_alumno = result.GetBoolean(10);
            result.Close();
            bd.Close();
            return a;
        }
        public List<int> listarPromociones()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select distinct promocion_alumno from alumno order by promocion_alumno asc";
            bd.CreateCommand(sqlSearch);
            DbDataReader result = bd.Query();//disponible resultado
            List<int> lPromociones = new List<int>();
            while (result.Read())
            {
                lPromociones.Add(result.GetInt32(0));
            }
            result.Close();
            bd.Close();
            return lPromociones;
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