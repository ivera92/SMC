using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.CapaDeDatos;
using System.Data;
using System.Data.Common;

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
            bd.createParameter("@id_escuela_asignatura", DbType.Int32, a.Id_escuela_asignatura);
            bd.createParameter("@rut_docente_asignatura", DbType.String, a.Rut_docente_asignatura);
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
            bd.createParameter("@id_escuela_asignatura", DbType.Int32, a.Id_escuela_asignatura);
            bd.createParameter("@rut_docente_asignatura", DbType.String, a.Rut_docente_asignatura);
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
            List<Asignatura> la = new List<Asignatura>();
            DbDataReader result = bd.Query();
            while (result.Read())
            {
                Asignatura a = new Asignatura(result.GetInt32(0), result.GetInt32(1), result.GetString(2), result.GetString(3), result.GetInt32(4), result.GetBoolean(5));
                la.Add(a);
            }
            result.Close();
            bd.Close();
            return la.First();
        }

        public List<Asignatura> mostrarAsignaturas()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarAsignaturas";

            bd.CreateCommandSP(sql);
            List<Asignatura> la = new List<Asignatura>();
            DbDataReader result = bd.Query();

            while (result.Read())
            {
                Asignatura a = new Asignatura(result.GetInt32(0), result.GetInt32(1), result.GetString(2), result.GetString(3), result.GetInt32(4), result.GetBoolean(5));
                la.Add(a);
            }
            result.Close();
            bd.Close();

            return la;
        }
    }
}
