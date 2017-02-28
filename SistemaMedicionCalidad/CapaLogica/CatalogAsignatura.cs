using System.Collections.Generic;
using System.Linq;
using Project.CapaDeDatos;
using System.Data;
using System.Data.Common;
using Project.CapaDeNegocios;

namespace Project
{
    public class CatalogAsignatura
    {
        public void agregarAsignaturaPA(Asignatura a)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_asignatura", DbType.Int32, a.Id_asignatura);
            bd.createParameter("@id_escuela_asignatura", DbType.Int32, a.Escuela_asignatura.Id_escuela);
            bd.createParameter("@rut_docente_asignatura", DbType.String, a.Docente_asignatura.Rut_docente);
            bd.createParameter("@nombre_asignatura", DbType.String, a.Nombre_asignatura);
            bd.createParameter("@ano_asignatura", DbType.Int32, a.Ano_asignatura);
            bd.createParameter("@duracion_asignatura", DbType.Boolean, a.Duracion_asignatura);
            bd.execute();
            bd.Close();
        }

        public void editarAsignaturaPA(Asignatura a)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_asignatura", DbType.Int32, a.Id_asignatura);
            bd.createParameter("@id_escuela_asignatura", DbType.Int32, a.Escuela_asignatura.Id_escuela);
            bd.createParameter("@rut_docente_asignatura", DbType.String, a.Docente_asignatura.Rut_docente);
            bd.createParameter("@nombre_asignatura", DbType.String, a.Nombre_asignatura);
            bd.createParameter("@ano_asignatura", DbType.Int32, a.Ano_asignatura);
            bd.createParameter("@duracion_asignatura", DbType.Boolean, a.Duracion_asignatura);
            bd.execute();
            bd.Close();
        }

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
            a.Docente_asignatura.Rut_docente = result.GetString(2);
            a.Nombre_asignatura = result.GetString(3);
            a.Ano_asignatura = result.GetInt32(4);
            a.Duracion_asignatura = result.GetBoolean(5);
            result.Close();
            bd.Close();
            return a;
        }

        public List<Asignatura> mostrarAsignaturas()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarAsignaturas";

            bd.CreateCommandSP(sql);
            List<Asignatura> la = new List<Asignatura>();
            DbDataReader result = bd.Query();
            CatalogEscuela ce = new CatalogEscuela();
            CatalogDocente cd = new CatalogDocente();

            while (result.Read())
            {
                Asignatura a = new Asignatura();
                Escuela es = new Escuela();
                Docente d = new Docente();
                a.Escuela_asignatura = es;
                a.Docente_asignatura = d;
                es = ce.buscarUnaEscuela(result.GetInt32(1));
                d = cd.buscarDocentePA(result.GetString(2));
                
                a.Id_asignatura = result.GetInt32(0);
                a.Escuela_asignatura.Nombre_escuela = es.Nombre_escuela;
                a.Docente_asignatura.Nombre_docente = d.Nombre_docente;
                a.Nombre_asignatura = result.GetString(3);
                a.Ano_asignatura = result.GetInt32(4);
                a.Duracion_asignatura = result.GetBoolean(5);
                la.Add(a);
            }
            result.Close();
            bd.Close();

            return la;
        }
    }
}
