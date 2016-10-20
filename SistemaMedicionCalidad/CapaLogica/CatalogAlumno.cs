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
            CapaDeDatos.DataBase bd = new DataBase();
            bd.connect();

            string sql = "insAlumnos";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, a.Rut_alumno);
            bd.createParameter("@id_escuela", DbType.Int32, a.Id_escuela);
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

        public void eliminarAlumnoPA(string rut_alumno)
        {
            CapaDeDatos.DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarAlumno";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);
            bd.execute();
            bd.Close();
        }


        /*public List<Alumno> buscarAlumno(string nombreAlumno)
        {
            CapaDeDatos.DataBase bd = new DataBase();
            bd.connect(); //método conectar

            if (nombreAlumno == null)
                nombreAlumno = "";

            string sqlSearch = "select rut_alumno, id_escuela, nombre_alumno, fecha_nacimiento_alumno, sexo_alumno, promocion_alumno, beneficio_alumno from alumno where nombre_alumno like '%" + nombreAlumno + "%'";
            bd.CreateCommand(sqlSearch);
            List<Alumno> lalumno = new List<Alumno>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Alumno a = new Alumno(result.GetString(0), result.GetInt32(1), result.GetString(2), result.GetDateTime(3), result.GetBoolean(4), result.GetInt32(5), result.GetBoolean(6));     
                lalumno.Add(a);
            }
            result.Close();
            bd.Close();
            return lalumno;
        }*/

        
        public List<Alumno> mostrarAlumnos()
        {
            CapaDeDatos.DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select nombre_alumno, rut_alumno, id_escuela, promocion_alumno from alumno";
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
    }
}
