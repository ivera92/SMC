using System.Collections.Generic;
using Project.CapaDeDatos;
using System.Data;
using System.Data.Common;
using Project.CapaDeNegocios;

namespace Project
{
    public class CatalogAsignatura
    {
        //Inserta una asignatura a la base de datos
        public void insertarAsignatura(Asignatura a)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura", DbType.String, a.Cod_asignatura);
            bd.createParameter("@id_escuela_asignatura", DbType.Int32, a.Escuela_asignatura.Id_escuela);
            bd.createParameter("@rut_docente_asignatura", DbType.String, a.Docente_asignatura.Rut_persona);
            bd.createParameter("@nombre_asignatura", DbType.String, a.Nombre_asignatura);
            bd.createParameter("@ano_asignatura", DbType.Int32, a.Ano_asignatura);
            bd.createParameter("@duracion_asignatura", DbType.Boolean, a.Duracion_asignatura);
            bd.execute();
            bd.Close();
        }

        //Actualiza una asignatura existente en la base de datos
        public void actualizarAsignatura(Asignatura a)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura", DbType.String, a.Cod_asignatura);
            bd.createParameter("@id_escuela_asignatura", DbType.Int32, a.Escuela_asignatura.Id_escuela);
            bd.createParameter("@rut_docente_asignatura", DbType.String, a.Docente_asignatura.Rut_persona);
            bd.createParameter("@nombre_asignatura", DbType.String, a.Nombre_asignatura);
            bd.createParameter("@ano_asignatura", DbType.Int32, a.Ano_asignatura);
            bd.createParameter("@duracion_asignatura", DbType.Boolean, a.Duracion_asignatura);
            bd.execute();
            bd.Close();
        }
        //Lista todas las asignaturas existentes en la base de datos
        public List<Asignatura> listarAsignaturas()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarAsignaturas";

            bd.CreateCommandSP(sql);
            List<Asignatura> lAsignaturas = new List<Asignatura>();
            DbDataReader result = bd.Query();
            CatalogEscuela cEscuela = new CatalogEscuela();
            CatalogDocente cDocente = new CatalogDocente();

            while (result.Read())
            {
                Asignatura a = new Asignatura();

                a.Cod_asignatura = result.GetString(0);
                a.Escuela_asignatura = cEscuela.buscarUnaEscuela(result.GetInt32(1));
                a.Docente_asignatura = cDocente.buscarUnDocente(result.GetString(2));
                a.Nombre_asignatura = result.GetString(3);
                a.Ano_asignatura = result.GetInt32(4);
                a.Duracion_asignatura = result.GetBoolean(5);
                lAsignaturas.Add(a);
            }
            result.Close();
            bd.Close();

            return lAsignaturas;
        }

        //Lista todas las asignaturas existentes en la base de datos de determinado docente
        public List<Asignatura> listarAsignaturasDocente(string rut)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarAsignaturasDocente";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_docente_asignatura", DbType.String, rut);
            DbDataReader result = bd.Query();
            List<Asignatura> lAsignaturas = new List<Asignatura>();
            CatalogEscuela cEscuela = new CatalogEscuela();
            CatalogDocente cDocente = new CatalogDocente();

            while (result.Read())
            {
                Asignatura a = new Asignatura();

                a.Cod_asignatura = result.GetString(0);
                a.Escuela_asignatura = cEscuela.buscarUnaEscuela(result.GetInt32(1));
                a.Docente_asignatura = cDocente.buscarUnDocente(result.GetString(2));
                a.Nombre_asignatura = result.GetString(3);
                a.Ano_asignatura = result.GetInt32(4);
                a.Duracion_asignatura = result.GetBoolean(5);
                lAsignaturas.Add(a);
            }
            result.Close();
            bd.Close();

            return lAsignaturas;
        }

        //Lista todas las asignaturas existentes en la base de datos de determinado alumno
        public List<Asignatura> listarAsignaturasAlumno(string rut)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarAsignaturasAlumno";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno_aa", DbType.String, rut);
            DbDataReader result = bd.Query();
            List<Asignatura> lAsignaturas = new List<Asignatura>();
            CatalogEscuela cEscuela = new CatalogEscuela();
            CatalogDocente cDocente = new CatalogDocente();

            while (result.Read())
            {
                Asignatura a = new Asignatura();

                a.Cod_asignatura = result.GetString(0);
                a.Escuela_asignatura = cEscuela.buscarUnaEscuela(result.GetInt32(1));
                a.Docente_asignatura = cDocente.buscarUnDocente(result.GetString(2));
                a.Nombre_asignatura = result.GetString(3);
                a.Ano_asignatura = result.GetInt32(4);
                a.Duracion_asignatura = result.GetBoolean(5);
                lAsignaturas.Add(a);
            }
            result.Close();
            bd.Close();

            return lAsignaturas;
        }


        //Lista todas las asignaturas en las que el alumno a sido evaluado
        public List<Asignatura> listarAsignaturasEvaluadas(string rut_alumno)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarAsignaturasEvaluadasAlumno";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_alumno", DbType.String, rut_alumno);
            List<Asignatura> lAsignaturas = new List<Asignatura>();
            DbDataReader result = bd.Query();

            while (result.Read())
            {
                Asignatura a = new Asignatura(result.GetString(0), result.GetString(1));
                lAsignaturas.Add(a);
            }
            result.Close();
            bd.Close();

            return lAsignaturas;
        }

        //Lista todas las asignaturas pertenecientes a una escuela
        public List<Asignatura> listarAsignaturasDeEscuela(int id_escuela)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarAsignaturasEscuela";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_escuela", DbType.Int32, id_escuela);
            List<Asignatura> lAsignaturas = new List<Asignatura>();
            DbDataReader result = bd.Query();

            while (result.Read())
            {
                Asignatura a = new Asignatura(result.GetString(0), result.GetString(1));
                lAsignaturas.Add(a);
            }
            result.Close();
            bd.Close();

            return lAsignaturas;
        }

        //Elimina una asignatura existente en la base de datos
        public void eliminarAsignatura(string cod_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura", DbType.String, cod_asignatura);
            bd.execute();
            bd.Close();
        }

        //Devuelve una asignatura acorde a su ID
        public Asignatura buscarAsignatura(string cod_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "buscarAsignaturaID";
            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura", DbType.String, cod_asignatura);
            DbDataReader result = bd.Query();
            result.Read();

            Asignatura a = new Asignatura();
            CatalogEscuela cEscuela = new CatalogEscuela();
            CatalogDocente cDocente = new CatalogDocente();

            a.Cod_asignatura = result.GetString(0);
            a.Escuela_asignatura = cEscuela.buscarUnaEscuela(result.GetInt32(1));
            a.Docente_asignatura = cDocente.buscarUnDocente(result.GetString(2));
            a.Nombre_asignatura = result.GetString(3);
            a.Ano_asignatura = result.GetInt32(4);
            a.Duracion_asignatura = result.GetBoolean(5);
            result.Close();
            bd.Close();
            return a;
        }

        //Devuelve una asignatura acorde a su nombre
        public Asignatura buscarAsignaturaNombre(string nombre_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "buscarAsignaturaNombre";
            bd.CreateCommandSP(sql);
            bd.createParameter("@nombre_asignatura", DbType.String, nombre_asignatura);
            DbDataReader result = bd.Query();
            result.Read();

            Asignatura a = new Asignatura();
            CatalogEscuela cEscuela = new CatalogEscuela();
            CatalogDocente cDocente = new CatalogDocente();

            a.Cod_asignatura = result.GetString(0);
            a.Escuela_asignatura = cEscuela.buscarUnaEscuela(result.GetInt32(1));
            a.Docente_asignatura = cDocente.buscarUnDocente(result.GetString(2));
            a.Nombre_asignatura = result.GetString(3);
            a.Ano_asignatura = result.GetInt32(4);
            a.Duracion_asignatura = result.GetBoolean(5);
            result.Close();
            bd.Close();
            return a;
        }
    }
}
