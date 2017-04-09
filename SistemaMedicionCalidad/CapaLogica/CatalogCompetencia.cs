using System.Collections.Generic;
using Project.CapaDeDatos;
using System.Data;
using System.Data.Common;

namespace Project
{
    public class CatalogCompetencia
    {
        //Inserta una competencia en la base de datos
        public void insertarCompetencia(Competencia c)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql="insCompetencia";

            bd.CreateCommandSP(sql);
            bd.createParameter("@nombre_competencia", DbType.String, c.Nombre_competencia);
            bd.createParameter("@tipo_competencia", DbType.Boolean, c.Tipo_competencia);
            bd.createParameter("@descripcion_competencia", DbType.String, c.Descripcion_competencia);
            bd.execute();
            bd.Close();
        }

        //Elimina una competencia existente en la base de datos acorde a su ID
        public void eliminarCompetencia(int id_competencia)
        {
            DataBase bd = new DataBase();
            bd.connect();


            string sql = "eliminarCompetencia";

            bd.CreateCommandSP(sql);

            bd.createParameter("@id_competencia", DbType.Int32, id_competencia);
            bd.execute();
            bd.Close();
        }

        //Actualiza una competencia existente en la base de datos
        public void actualizarCompetencia(Competencia c)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarCompetencia";

            bd.CreateCommandSP(sql);
            
            bd.createParameter("@id_competencia", DbType.Int32, c.Id_competencia);
            bd.createParameter("@nombre_competencia", DbType.String, c.Nombre_competencia);
            bd.createParameter("@tipo_competencia", DbType.Boolean, c.Tipo_competencia);
            bd.createParameter("@descripcion_competencia", DbType.String, c.Descripcion_competencia);
            bd.execute();
            bd.Close();
        }

        //Lista todas las competencias existentes en la base de datos
        public List<Competencia> listarCompetencias()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarCompetencias";

            bd.CreateCommandSP(sql);
            List<Competencia> lcompetencia = new List<Competencia>();
            DbDataReader result = bd.Query();

            while (result.Read())
            {
                Competencia c = new Competencia(result.GetString(0), result.GetBoolean(1), result.GetInt32(2));
                lcompetencia.Add(c);
            }
            result.Close();
            bd.Close();

            return lcompetencia;
        }

        //Lista las competencias asociadas a una asignatura existentes en la base de datos
        public List<Competencia> listarCompetenciasAsignatura(int id_asignatura_ac)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarCompetenciasAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_asignatura_ac", DbType.Int32, id_asignatura_ac);
            List<Competencia> lCompetencias = new List<Competencia>();
            DbDataReader result = bd.Query();

            while (result.Read())
            {
                Competencia c = new Competencia(result.GetInt32(0), result.GetString(1));
                lCompetencias.Add(c);
            }
            result.Close();
            bd.Close();

            return lCompetencias;
        }

        //Devuelve una competencia acorde a su ID
        public Competencia buscarUnaCompetencia(int id_competencia)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "select * from competencia where id_competencia='" + id_competencia + "'";
            bd.CreateCommand(sqlSearch);
            DbDataReader result = bd.Query();
            result.Read();

            Competencia c = new Competencia(result.GetInt32(0), result.GetString(1), result.GetBoolean(2), result.GetString(3));

            result.Close();
            bd.Close();
            return c;
        }
    }
}
