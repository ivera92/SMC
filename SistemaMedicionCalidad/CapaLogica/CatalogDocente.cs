using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogDocente
    {
        public void agregarDocentePA(Docente d)
        {
            CapaDeDatos.DataBase bd = new CapaDeDatos.DataBase();
            bd.connect();

            string sql = "insDocentes";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_docente", DbType.String, d.Rut_docente);
            bd.createParameter("@id_profesion_docente", DbType.Int32, d.Id_profesion_docente);
            bd.createParameter("@nombre_docente", DbType.String, d.Nombre_docente);
            bd.createParameter("@fecha_nacimiento_docente", DbType.Date, d.Fecha_nacimiento_docente);
            bd.createParameter("@direccion_docente", DbType.String, d.Direccion_docente);
            bd.createParameter("@telefono_docente", DbType.Int32, d.Telefono_docente);
            bd.createParameter("@nacionalidad_docente", DbType.String, d.Nacionalidad_docente);
            bd.createParameter("@sexo_docente", DbType.Boolean, d.Sexo_docente);
            bd.createParameter("@correo_docente", DbType.String, d.Correo_docente);
            bd.createParameter("@disponibilidad_docente", DbType.Boolean, d.Disponibilidad_docente);
            bd.execute();
            bd.Close();
        }

        public List<Docente> buscarDocentePA(string buscar)
        {
            CapaDeDatos.DataBase bd = new CapaDeDatos.DataBase();
            bd.connect();

            if (buscar == null)
                buscar = "";

            string sql = "buscarDocente";
            bd.CreateCommandSP(sql);
            bd.createParameter("@buscar", DbType.String, buscar);
            
            List<Docente> ldocente = new List<Docente>();
            DbDataReader result = bd.Query();
            while (result.Read())
            {
                Docente d= new Docente(result.GetString(0),result.GetInt32(1),result.GetString(2),result.GetDateTime(3),result.GetString(4),result.GetInt32(5),result.GetString(6),result.GetBoolean(7),result.GetString(8),result.GetBoolean(9));
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

            while (result.Read())
            {
                Docente d = new Docente(result.GetString(0), result.GetString(1), result.GetInt32(2));
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
            bd.createParameter("@id_profesion_docente", DbType.Int32, d.Id_profesion_docente);
            bd.createParameter("@nombre_docente", DbType.String, d.Nombre_docente);
            bd.createParameter("@fecha_nacimiento_docente", DbType.Date, d.Fecha_nacimiento_docente);
            bd.createParameter("@direccion_docente", DbType.String, d.Direccion_docente);
            bd.createParameter("@telefono_docente", DbType.Int32, d.Telefono_docente);
            bd.createParameter("@nacionalidad_docente", DbType.String, d.Nacionalidad_docente);
            bd.createParameter("@sexo_docente", DbType.Boolean, d.Sexo_docente);
            bd.createParameter("@correo_docente", DbType.String, d.Correo_docente);
            bd.createParameter("@disponibilidad_docente", DbType.Boolean, d.Disponibilidad_docente);
            bd.execute();
            bd.Close();
        }
    }
}
