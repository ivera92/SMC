using Project.CapaDeDatos;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Project
{
    public class CatalogImparte
    {
        //Asociar una asignatura a un docente
        public void insertarAD(Imparte i)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "insImparte";
            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_docente_imparte", DbType.String, i.Rut_docente_imparte.Rut_persona);
            bd.createParameter("@cod_asignatura_imparte", DbType.String, i.Cod_asignatura_imparte.Cod_asignatura);
            bd.createParameter("@ano_imparte", DbType.String, i.Ano_imparte);
            bd.execute();
            bd.Close();
        }

        //Verifica si ya existe la asignatura inscrita para el docente el mismo año
        public int verificarExistenciaImparte(Imparte i)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "verificarExistenciaImparte";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@rut_docente", DbType.String, i.Rut_docente_imparte.Rut_persona);
            bd.createParameter("@cod_asignatura", DbType.String, i.Cod_asignatura_imparte.Cod_asignatura);
            bd.createParameter("@ano_imparte", DbType.String, i.Ano_imparte);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);

            result.Close();
            bd.Close();
            return existe;
        }

        //Lista todas las asignaturas asociadas existentes en la base de datos
        public List<Imparte> listarAsignaturasAsociadas()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarImparte";
            bd.CreateCommandSP(sqlSearch);
            List<Imparte> lImparte = new List<Imparte>();
            DbDataReader result = bd.Query();//disponible resultado
            CatalogDocente cDocente = new CatalogDocente();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();

            while (result.Read())
            {
                Imparte i = new Imparte(result.GetInt32(0), cDocente.buscarUnDocente(result.GetString(1)), cAsignatura.buscarAsignatura(result.GetString(2)), result.GetString(3));
                lImparte.Add(i);
            }
            result.Close();
            bd.Close();
            return lImparte;
        }

        //Lista todas las asignaturas asociadas despues de una busqueda existentes en la base de datos
        public List<Imparte> listarAsignaturasAsociadasBusqueda(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "mostrarImparteBusqueda";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@buscar", DbType.String, buscar);
            List<Imparte> lImparte = new List<Imparte>();
            DbDataReader result = bd.Query();//disponible resultado
            CatalogDocente cDocente = new CatalogDocente();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();

            while (result.Read())
            {
                Imparte i = new Imparte(result.GetInt32(0), cDocente.buscarUnDocente(result.GetString(1)), cAsignatura.buscarAsignatura(result.GetString(2)), result.GetString(3));
                lImparte.Add(i);
            }
            result.Close();
            bd.Close();
            return lImparte;
        }

        //Devuelve una asociacion entre docente y asignatura acorde a su ID
        public Imparte buscarUnImparte(int id_imparte)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "buscarImparteID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_imparte", DbType.Int32, id_imparte);
            DbDataReader result = bd.Query();
            result.Read();

            CatalogDocente cDocente = new CatalogDocente();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            Imparte i = new Imparte(result.GetInt32(0), cDocente.buscarUnDocente(result.GetString(1)), cAsignatura.buscarAsignatura(result.GetString(2)), result.GetString(3));

            result.Close();
            bd.Close();
            return i;
        }

        //Elimina una asociacion de asignatura existente en la base de datos acorde a su ID
        public void eliminarImparte(int id_imparte)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarImparte";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_imparte", DbType.Int32, id_imparte);
            bd.execute();
            bd.Close();
        }
    }
}
