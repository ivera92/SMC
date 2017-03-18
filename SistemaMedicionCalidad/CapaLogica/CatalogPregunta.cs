using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogPregunta
    {
        //Inserta una pregunta en la base de datos
        public void insertarPregunta(Pregunta p)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insPregunta";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_competencia_pregunta", DbType.Int32, p.Competencia_pregunta.Id_competencia);
            bd.createParameter("@id_tipo_pregunta_pregunta", DbType.Int32, p.Tipo_pregunta_pregunta.Id_tipo_pregunta);
            bd.createParameter("@nombre_pregunta", DbType.String, p.Nombre_pregunta);
            bd.createParameter("@imagen_pregunta", DbType.String, p.Imagen_pregunta);

            bd.execute();
            bd.Close();
        }

        //Elimina una pregunta existete en la base de datos acorde a su ID
        public void eliminarPregunta(int id_pregunta)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarPregunta";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_pregunta", DbType.Int32, id_pregunta);
            bd.execute();
            bd.Close();
        }

        //Lista los Tipos de Preguntas
        public List<Tipo_Pregunta> listarTiposPregunta()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select * from tipo_pregunta";
            bd.CreateCommand(sqlSearch);
            List<Tipo_Pregunta> lTiposPregunta = new List<Tipo_Pregunta>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Tipo_Pregunta tp = new Tipo_Pregunta(result.GetInt32(0), result.GetString(1));
                lTiposPregunta.Add(tp);
            }
            result.Close();
            bd.Close();
            return lTiposPregunta;
        }
        //Devuelve la ultima pregunta ingresada en la base de datos
        public int ultimaPregunta()
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "SELECT TOP 1 * FROM pregunta ORDER BY id_pregunta DESC ";
            bd.CreateCommand(sql);
            DbDataReader result = bd.Query();
            result.Read();
            int id = result.GetInt32(0);
            result.Close();
            bd.Close();
            return id;
        }

        //Devuelve una pregunta acorde a su ID
        public Pregunta buscarUnaPregunta(int id_pregunta)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "select * from pregunta where id_pregunta='" + id_pregunta + "'";
            bd.CreateCommand(sql);

            DbDataReader result = bd.Query();
            result.Read();
            Pregunta p = new Pregunta();
            Competencia c = new Competencia();
            Tipo_Pregunta tp = new Tipo_Pregunta();
            p.Competencia_pregunta = c;
            p.Tipo_pregunta_pregunta = tp;

            p.Id_pregunta = result.GetInt32(0);
            p.Competencia_pregunta.Id_competencia = result.GetInt32(1);
            p.Tipo_pregunta_pregunta.Id_tipo_pregunta = result.GetInt32(2);
            p.Nombre_pregunta = result.GetString(3);
            try
            {
                p.Imagen_pregunta = result.GetString(4);
            }
            catch
            {
                p.Imagen_pregunta = "";
            }
            return p;
        }

        //Lista todas las preguntas existentes en la base de datos
        public List<Pregunta> listarPreguntas()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select * from pregunta";
            bd.CreateCommand(sqlSearch);
            List<Pregunta> lPreguntas = new List<Pregunta>();
            CatalogCompetencia cCompetencia = new CatalogCompetencia();
            CatalogPregunta cPregunta = new CatalogPregunta();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Pregunta p = new Pregunta();
                Competencia c = new Competencia();
                Tipo_Pregunta tp = new Tipo_Pregunta();
                p.Competencia_pregunta = c;
                p.Tipo_pregunta_pregunta = tp;
                c = cCompetencia.buscarUnaCompetencia(result.GetInt32(1));

                p.Id_pregunta = result.GetInt32(0);
                p.Competencia_pregunta.Nombre_competencia = c.Nombre_competencia;
                p.Tipo_pregunta_pregunta.Id_tipo_pregunta = result.GetInt32(2);
                p.Nombre_pregunta = result.GetString(3);
                lPreguntas.Add(p);
            }
            result.Close();
            bd.Close();
            return lPreguntas;
        }
        //Actualiza una pregunta existente en la base de datos
        public void actualizarPregunta(Pregunta p)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "actualizarPregunta";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_pregunta", DbType.Int32, p.Id_pregunta);
            bd.createParameter("@id_competencia_pregunta", DbType.Int32, p.Competencia_pregunta.Id_competencia+1);
            bd.createParameter("@id_tipo_pregunta_pregunta", DbType.Int32, p.Tipo_pregunta_pregunta.Id_tipo_pregunta+1);
            bd.createParameter("@nombre_pregunta", DbType.String, p.Nombre_pregunta);
            bd.execute();
            bd.Close();
        }
    }
}
