using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.CapaDeDatos;
using System.Data.Common;
using System.Data;

namespace Project.CapaDeNegocios
{
    public class CatalogAlumno
    {
        public void agregarAlumnoPA(Alumno a)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insAlumnos";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, a.Rut_alumno);
            bd.createParameter("@id_escuela_alumno", DbType.Int32, a.Id_escuela_alumno);
            bd.createParameter("@nombre_alumno", DbType.String, a.Nombre_alumno);
            bd.createParameter("@fecha_nacimiento_alumno", DbType.Date, a.Fecha_nacimiento_alumno);
            bd.createParameter("@direccion_alumno", DbType.String, a.Direccion_alumno);
            bd.createParameter("@telefono_alumno", DbType.Int32, a.Telefono_alumno);
            bd.createParameter("@nacionalidad_alumno", DbType.String, a.Nacionalidad_alumno);
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
            bd.createParameter("@id_escuela_alumno", DbType.Int32, a.Id_escuela_alumno);
            bd.createParameter("@nombre_alumno", DbType.String, a.Nombre_alumno);
            bd.createParameter("@fecha_nacimiento_alumno", DbType.Date, a.Fecha_nacimiento_alumno);
            bd.createParameter("@direccion_alumno", DbType.String, a.Direccion_alumno);
            bd.createParameter("@telefono_alumno", DbType.Int32, a.Telefono_alumno);
            bd.createParameter("@nacionalidad_alumno", DbType.String, a.Nacionalidad_alumno);
            bd.createParameter("@sexo_alumno", DbType.Boolean, a.Sexo_alumno);
            bd.createParameter("@correo_alumno", DbType.String, a.Correo_alumno);
            bd.createParameter("@promocion_alumno", DbType.Int32, a.Promocion_alumno);
            bd.createParameter("@beneficio_alumno", DbType.Boolean, a.Beneficio_alumno);
            bd.execute();
            bd.Close();
        }

        public Escuela buscarEscuela(string rutAlumno)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar
            if (rutAlumno == null)
                rutAlumno = "";

            string sqlBuscar = "select id_escuela, nombre_escuela from escuela inner join alumno on escuela.id_escuela=alumno.id_escuela_alumno where alumno.rut_alumno='" + rutAlumno + "'";
            bd.CreateCommand(sqlBuscar);
            DbDataReader result = bd.Query();//disponible resultado
            result.Read();
            Escuela escuelas = new Escuela(result.GetInt32(0),result.GetString(1));
            result.Close();
            return escuelas;
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
            CapaDeDatos.DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select nombre_alumno, rut_alumno, id_escuela_alumno, promocion_alumno from alumno";
            bd.CreateCommand(sqlSearch);
            List<Alumno> lalumno = new List<Alumno>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Alumno a = new Alumno(result.GetString(0),result.GetString(1),result.GetInt32(2),result.GetInt32(3));
                lalumno.Add(a);
            }
            result.Close();
            bd.Close();
            return lalumno;
        }

        public List<Alumno> buscarAlumno(string buscar)
        {
            CapaDeDatos.DataBase bd = new DataBase();
            bd.connect(); //método conectar

            if (buscar == null)
                buscar = "";

            string sqlSearch = "select * from alumno where nombre_alumno like '" + buscar + "%' or rut_alumno like '"+ buscar + "%' or id_escuela_alumno like '" + buscar +"%' or promocion_alumno like '"+ buscar +"%'or promocion_alumno like '"+ buscar +"%'";
            bd.CreateCommand(sqlSearch);
            List<Alumno> alumno = new List<Alumno>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Alumno a = new Alumno(result.GetString(0), result.GetInt32(1), result.GetString(2), result.GetDateTime(3), result.GetString(4), result.GetInt32(5), result.GetString(6), result.GetBoolean(7), result.GetString(8), result.GetInt32(9), result.GetBoolean(10));
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

            string sqlSearch = "select * from alumno where rut_alumno='"+rut+"'";
            bd.CreateCommand(sqlSearch);
            List<Alumno> lalumno = new List<Alumno>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            { 
                Alumno a = new Alumno(result.GetString(0), result.GetInt32(1), result.GetString(2), result.GetDateTime(3), result.GetString(4), result.GetInt32(5), result.GetString(6), result.GetBoolean(7), result.GetString(8), result.GetInt32(9), result.GetBoolean(10));
                lalumno.Add(a);
            }
            result.Close();
            bd.Close();
            return lalumno.First();
        }
    }
}
