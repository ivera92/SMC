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
            bd.createParameter("@id_asignatura", DbType.Int32, a.Id_asignatura);
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
            bd.createParameter("@id_asignatura", DbType.Int32, a.Id_asignatura);
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
                Escuela es = new Escuela();
                Docente d = new Docente();
                a.Escuela_asignatura = es;
                a.Docente_asignatura = d;
                es = cEscuela.buscarUnaEscuela(result.GetInt32(1));
                d = cDocente.buscarUnDocente(result.GetString(2));

                a.Id_asignatura = result.GetInt32(0);
                a.Escuela_asignatura.Nombre_escuela = es.Nombre_escuela;
                a.Docente_asignatura.Nombre_persona = d.Nombre_persona;
                a.Nombre_asignatura = result.GetString(3);
                a.Ano_asignatura = result.GetInt32(4);
                a.Duracion_asignatura = result.GetBoolean(5);
                lAsignaturas.Add(a);
            }
            result.Close();
            bd.Close();

            return lAsignaturas;
        }

        //Elimina una asignatura existente en la base de datos
        public void eliminarAsignatura(int id_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_asignatura", DbType.Int32, id_asignatura);
            bd.execute();
            bd.Close();
        }

        //Devuelve una asignatura acorde a su ID
        public Asignatura buscarAsignatura(int id_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "select * from asignatura where id_asignatura='" + id_asignatura + "'";
            bd.CreateCommand(sql);
            DbDataReader result = bd.Query();
            result.Read();

            Asignatura a = new Asignatura();
            Escuela es = new Escuela();
            Docente d = new Docente();
            a.Escuela_asignatura = es;
            a.Docente_asignatura = d;

            a.Id_asignatura = result.GetInt32(0);
            a.Escuela_asignatura.Id_escuela = result.GetInt32(1);
            a.Docente_asignatura.Rut_persona = result.GetString(2);
            a.Nombre_asignatura = result.GetString(3);
            a.Ano_asignatura = result.GetInt32(4);
            a.Duracion_asignatura = result.GetBoolean(5);
            result.Close();
            bd.Close();
            return a;
        }
    }
}
