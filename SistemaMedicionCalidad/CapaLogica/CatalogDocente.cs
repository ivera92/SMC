using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Project.CapaDeDatos;
using Project.CapaDeNegocios;

namespace Project
{
    public class CatalogDocente
    {
        public void agregarDocentePA(Docente d)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insDocentes";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_docente", DbType.String, d.Rut_docente);
            bd.createParameter("@id_profesion_docente", DbType.Int32, d.Profesion_docente.Id_profesion);
            bd.createParameter("@nombre_docente", DbType.String, d.Nombre_docente);
            bd.createParameter("@fecha_nacimiento_docente", DbType.Date, d.Fecha_nacimiento_docente);
            bd.createParameter("@direccion_docente", DbType.String, d.Direccion_docente);
            bd.createParameter("@telefono_docente", DbType.Int32, d.Telefono_docente);
            bd.createParameter("@id_pais_docente", DbType.Int32, d.Pais_docente.Id_pais);
            bd.createParameter("@sexo_docente", DbType.Boolean, d.Sexo_docente);
            bd.createParameter("@correo_docente", DbType.String, d.Correo_docente);
            bd.createParameter("@disponibilidad_docente", DbType.Boolean, d.Disponibilidad_docente);
            bd.execute();
            bd.Close();
        }

        public List<Docente> buscarDocentePA(string rut)
        {
            DataBase bd = new DataBase();
            bd.connect();

            if (rut == null)
                rut = "";

            string sql = "select * from docente where rut_docente='" + rut + "'";
            bd.CreateCommand(sql);
            bd.createParameter("@rut", DbType.String, rut);
            
            List<Docente> ldocente = new List<Docente>();
            Profesion p = new Profesion();
            Pais pa = new Pais();
            DbDataReader result = bd.Query();
            while (result.Read())
            {

                Docente d = new Docente();
                d.Profesion_docente = p;
                d.Pais_docente = pa;
                d.Rut_docente = result.GetString(0);
                d.Profesion_docente.Id_profesion = result.GetInt32(1);
                d.Pais_docente.Id_pais = result.GetInt32(2);
                d.Nombre_docente = result.GetString(3);
                d.Fecha_nacimiento_docente = result.GetDateTime(4);
                d.Direccion_docente= result.GetString(5);
                d.Telefono_docente = result.GetInt32(6);
                d.Sexo_docente = result.GetBoolean(7);
                d.Correo_docente = result.GetString(8);
                d.Disponibilidad_docente= result.GetBoolean(9);
                ldocente.Add(d);
            }
            result.Close();
            bd.Close();
            return ldocente;
        }

        public List<Docente> mostrarDocentesPA()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sql = "mostrarDocentes";
            bd.CreateCommandSP(sql);

            List<Docente> ldocente = new List<Docente>();
            DbDataReader result = bd.Query();
            CatalogProfesion cp = new CatalogProfesion();
            Profesion p = new Profesion();
            
            while (result.Read())
            {
                Docente d = new Docente();
                d.Profesion_docente = p;
                p =cp.buscarUnaProfesion(result.GetInt32(2));
                d.Nombre_docente = result.GetString(0);
                d.Rut_docente = result.GetString(1);
                d.Profesion_docente.Nombre_profesion = p.Nombre_profesion;
                ldocente.Add(d);
            }
            result.Close();
            bd.Close();
            return ldocente;
        }

        public void eliminarDocentePA(string rut_docente)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarDocente";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_docente", DbType.String, rut_docente);
            bd.execute();
            bd.Close();
        }

        public void editarDocentePA(Docente d)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarDocente";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_docente", DbType.String, d.Rut_docente);
            bd.createParameter("@id_profesion_docente", DbType.Int32, d.Profesion_docente.Id_profesion);
            bd.createParameter("@nombre_docente", DbType.String, d.Nombre_docente);
            bd.createParameter("@fecha_nacimiento_docente", DbType.Date, d.Fecha_nacimiento_docente);
            bd.createParameter("@direccion_docente", DbType.String, d.Direccion_docente);
            bd.createParameter("@telefono_docente", DbType.Int32, d.Telefono_docente);
            bd.createParameter("@id_pais_docente", DbType.Int32, d.Pais_docente.Id_pais);
            bd.createParameter("@sexo_docente", DbType.Boolean, d.Sexo_docente);
            bd.createParameter("@correo_docente", DbType.String, d.Correo_docente);
            bd.createParameter("@disponibilidad_docente", DbType.Boolean, d.Disponibilidad_docente);
            bd.execute();
            bd.Close();
        }
    }
}
