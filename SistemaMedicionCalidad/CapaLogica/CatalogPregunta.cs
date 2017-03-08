using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogPregunta
    {
        public void agregarPregunta(Pregunta p)
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

        public List<Tipo_Pregunta> mostrarTiposPregunta()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select * from tipo_pregunta";
            bd.CreateCommand(sqlSearch);
            List<Tipo_Pregunta> ltp = new List<Tipo_Pregunta>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Tipo_Pregunta tp = new Tipo_Pregunta(result.GetInt32(0), result.GetString(1));
                ltp.Add(tp);
            }
            result.Close();
            bd.Close();
            return ltp;
        }
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

            return p;
        }

        public List<Pregunta> mostrarPreguntas()
        {
            DataBase bd = new DataBase();
            bd.connect(); //método conectar

            string sqlSearch = "select * from pregunta";
            bd.CreateCommand(sqlSearch);
            List<Pregunta> lp = new List<Pregunta>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Pregunta p = new Pregunta();
                Competencia c = new Competencia();
                Tipo_Pregunta tp = new Tipo_Pregunta();
                p.Competencia_pregunta = c;
                p.Tipo_pregunta_pregunta = tp;

                p.Id_pregunta = result.GetInt32(0);
                p.Competencia_pregunta.Id_competencia = result.GetInt32(1);
                p.Tipo_pregunta_pregunta.Id_tipo_pregunta = result.GetInt32(2);
                p.Nombre_pregunta = result.GetString(3);
                lp.Add(p);
            }
            result.Close();
            bd.Close();
            return lp;
        }
    }
}
