using Project.CapaDeDatos;
using Project.CapaDeNegocios;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Project
{
    public class CatalogCursa
    {
        //Inscribe una asignatura a un alumno
        public void inscribirAsignatura(Cursa c)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "insCursa";
            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura_aa", DbType.String, c.Cod_asignatura_aa.Cod_asignatura);
            bd.createParameter("@rut_alumno_aa", DbType.String, c.Rut_alumno_aa.Rut_persona);
            bd.createParameter("@ano_cursa", DbType.String, c.Ano_asignatura);
            bd.execute();
            bd.Close();
        }

        //Verifica si ya existe la asignatura inscrita para el alumno el mismo año
        public int verificarExistenciaCursa(Cursa c)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "verificarExistenciaCursa";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@rut_alumno", DbType.String, c.Rut_alumno_aa.Rut_persona);
            bd.createParameter("@cod_asignatura", DbType.String, c.Cod_asignatura_aa.Cod_asignatura);
            bd.createParameter("@ano_cursa", DbType.String, c.Ano_asignatura);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);

            result.Close();
            bd.Close();
            return existe;
        }

        //Lista todas las asignaturas inscritas existentes en la base de datos
        public List<Cursa> listarAsignaturasInscritas()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarCursa";
            bd.CreateCommandSP(sqlSearch);
            List<Cursa> lCursa = new List<Cursa>();
            DbDataReader result = bd.Query();//disponible resultado
            CatalogAlumno cAlumno = new CatalogAlumno();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();

            while (result.Read())
            {
                Cursa c = new Cursa(result.GetInt32(0), cAlumno.buscarAlumnoPorRut(result.GetString(1)), cAsignatura.buscarAsignatura(result.GetString(2)), result.GetString(3));
                lCursa.Add(c);
            }
            result.Close();
            bd.Close();
            return lCursa;
        }

        //Lista todas las asignaturas inscritas de los estudiantes de los alumnos de un determinado docente existentes en la base de datos
        public List<Cursa> listarCursaDocente(string rut_docente)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarCursaDocente";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@rut_docente", DbType.String, rut_docente);
            List<Cursa> lCursa = new List<Cursa>();
            DbDataReader result = bd.Query();//disponible resultado
            CatalogAlumno cAlumno = new CatalogAlumno();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();

            while (result.Read())
            {
                Cursa c = new Cursa(result.GetInt32(0), cAlumno.buscarAlumnoPorRut(result.GetString(1)), cAsignatura.buscarAsignatura(result.GetString(2)), result.GetString(3));
                lCursa.Add(c);
            }
            result.Close();
            bd.Close();
            return lCursa;
        }

        //Lista todas las asignaturas inscritas de los estudiantes de los alumnos de un determinado docente despues de una busqueda existentes en la base de datos
        public List<Cursa> listarCursaDocenteBusqueda(string rut_docente, string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarCursaDocenteBusqueda";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@rut_docente", DbType.String, rut_docente);
            bd.createParameter("@buscar", DbType.String, buscar);
            List<Cursa> lCursa = new List<Cursa>();
            DbDataReader result = bd.Query();//disponible resultado
            CatalogAlumno cAlumno = new CatalogAlumno();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();

            while (result.Read())
            {
                Cursa c = new Cursa(result.GetInt32(0), cAlumno.buscarAlumnoPorRut(result.GetString(1)), cAsignatura.buscarAsignatura(result.GetString(2)), result.GetString(3));
                lCursa.Add(c);
            }
            result.Close();
            bd.Close();
            return lCursa;
        }

        //Lista todas las asignaturas inscritas despues de una busqueda existentes en la base de datos
        public List<Cursa> listarAsignaturasInscritasBusqueda(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarCursaBusqueda";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@buscar", DbType.String, buscar);
            List<Cursa> lCursa = new List<Cursa>();
            DbDataReader result = bd.Query();//disponible resultado
            CatalogAlumno cAlumno = new CatalogAlumno();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();

            while (result.Read())
            {
                Cursa c = new Cursa(result.GetInt32(0), cAlumno.buscarAlumnoPorRut(result.GetString(1)), cAsignatura.buscarAsignatura(result.GetString(2)), result.GetString(3));
                lCursa.Add(c);
            }
            result.Close();
            bd.Close();
            return lCursa;
        }

        //Elimina una inscripcion de asignatura existente en la base de datos acorde a su ID
        public void eliminarCursa(int id_cursa)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarCursa";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_cursa", DbType.Int32, id_cursa);
            bd.execute();
            bd.Close();
        }

        //Elimina una inscripcion de asignatura existente en la base de datos acorde a su ID
        public void eliminarCursaDocente(string nombre_alumno, string nombre_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarCursaDocente";

            bd.CreateCommandSP(sql);
            bd.createParameter("@nombre_alumno", DbType.String, nombre_alumno);
            bd.createParameter("@nombre_asignatura", DbType.String, nombre_asignatura);
            bd.execute();
            bd.Close();
        }

        //Devuelve una inscripcion de asignatura acorde a su ID
        public Cursa buscarUnCursa(int id_cursa)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "buscarCursaID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_cursa", DbType.Int32, id_cursa);
            DbDataReader result = bd.Query();
            result.Read();

            CatalogAlumno cAlumno = new CatalogAlumno();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            Cursa c = new Cursa(result.GetInt32(0), cAlumno.buscarAlumnoPorRut(result.GetString(1)), cAsignatura.buscarAsignatura(result.GetString(2)), result.GetString(3));

            result.Close();
            bd.Close();
            return c;
        }
    }
}
