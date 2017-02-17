using System.Collections.Generic;
using Project.CapaDeDatos;
using System.Data.Common;
using System.Data;

namespace Project.CapaDeNegocios
{
    public class CatalogAlumno
    {
        public void agregarAlumno(Alumno a)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insAlumnos";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, a.Rut_alumno);
            bd.createParameter("@id_escuela_alumno", DbType.Int32, a.Escuela_alumno.Id_escuela);
            bd.createParameter("@id_pais_alumno", DbType.Int32, a.Pais_alumno.Id_pais);
            bd.createParameter("@nombre_alumno", DbType.String, a.Nombre_alumno);
            bd.createParameter("@fecha_nacimiento_alumno", DbType.Date, a.Fecha_nacimiento_alumno);
            bd.createParameter("@direccion_alumno", DbType.String, a.Direccion_alumno);
            bd.createParameter("@telefono_alumno", DbType.Int32, a.Telefono_alumno);
            bd.createParameter("@sexo_alumno", DbType.Boolean, a.Sexo_alumno);
            bd.createParameter("@correo_alumno", DbType.String, a.Correo_alumno);
            bd.createParameter("@promocion_alumno", DbType.Int32, a.Promocion_alumno);
            bd.createParameter("@beneficio_alumno", DbType.Boolean, a.Beneficio_alumno);
            bd.execute();
            bd.Close();
        }

        public void editarAlumnoPA(Alumno a)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarAlumnos";
            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, a.Rut_alumno);
            bd.createParameter("@id_escuela_alumno", DbType.Int32, a.Escuela_alumno.Id_escuela);
            bd.createParameter("@nombre_alumno", DbType.String, a.Nombre_alumno);
            bd.createParameter("@fecha_nacimiento_alumno", DbType.Date, a.Fecha_nacimiento_alumno);
            bd.createParameter("@direccion_alumno", DbType.String, a.Direccion_alumno);
            bd.createParameter("@telefono_alumno", DbType.Int32, a.Telefono_alumno);
            bd.createParameter("@id_pais_alumno", DbType.Int32, a.Pais_alumno.Id_pais);
            bd.createParameter("@sexo_alumno", DbType.Boolean, a.Sexo_alumno);
            bd.createParameter("@correo_alumno", DbType.String, a.Correo_alumno);
            bd.createParameter("@promocion_alumno", DbType.Int32, a.Promocion_alumno);
            bd.createParameter("@beneficio_alumno", DbType.Boolean, a.Beneficio_alumno);
            bd.execute();
            bd.Close();
        }

        public void eliminarAlumnoPA(string rut_alumno)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarAlumno";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);
            bd.execute();
            bd.Close();
        }
        
        public List<Alumno> mostrarAlumnos()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarAlumnos";
            bd.CreateCommandSP(sqlSearch);
            List<Alumno> lalumno = new List<Alumno>();
            DbDataReader result = bd.Query();//disponible resultado
            CatalogEscuela ce = new CatalogEscuela();
            Escuela es = new Escuela();
            while (result.Read())
            {
                Alumno a = new Alumno();
                a.Escuela_alumno = es;
                es = ce.buscarUnaEscuela(result.GetInt32(2)+1);
                              
                a.Nombre_alumno = result.GetString(0);
                a.Rut_alumno = result.GetString(1);
                a.Escuela_alumno.Nombre_escuela = es.Nombre_escuela;
                a.Promocion_alumno = result.GetInt32(3);
                lalumno.Add(a);
            }
            result.Close();
            bd.Close();
            return lalumno;
        }

        public List<Alumno> buscarAlumno(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            if (buscar == null)
                buscar = "";

            string sqlSearch = "mostrarAlumnosBusqueda";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@buscar", DbType.String, buscar);
            List<Alumno> alumno = new List<Alumno>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Alumno a = new Alumno();
                Pais p = new Pais();
                Escuela es = new Escuela();
                a.Pais_alumno = p;
                a.Escuela_alumno = es;

                a.Rut_alumno = result.GetString(0);
                a.Escuela_alumno.Id_escuela = result.GetInt32(1);
                a.Pais_alumno.Id_pais = result.GetInt32(2);
                a.Nombre_alumno = result.GetString(3);
                a.Fecha_nacimiento_alumno = result.GetDateTime(4);
                a.Direccion_alumno = result.GetString(5);
                a.Telefono_alumno = result.GetInt32(6);
                a.Sexo_alumno = result.GetBoolean(7);
                a.Correo_alumno = result.GetString(8);
                a.Promocion_alumno = result.GetInt32(9);
                a.Beneficio_alumno = result.GetBoolean(10);
                alumno.Add(a);
            }
            result.Close();
            bd.Close();
            return alumno;
        }

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
            a.Pais_alumno = p;
            a.Escuela_alumno = es;

            a.Rut_alumno = result.GetString(0);
            a.Escuela_alumno.Id_escuela = result.GetInt32(1);
            a.Pais_alumno.Id_pais = result.GetInt32(2);
            a.Nombre_alumno = result.GetString(3);
            a.Fecha_nacimiento_alumno = result.GetDateTime(4);
            a.Direccion_alumno = result.GetString(5);
            a.Telefono_alumno = result.GetInt32(6);
            a.Sexo_alumno = result.GetBoolean(7);
            a.Correo_alumno = result.GetString(8);
            a.Promocion_alumno = result.GetInt32(9);
            a.Beneficio_alumno = result.GetBoolean(10);
            result.Close();
            bd.Close();
            return a;
        }
    }
}
