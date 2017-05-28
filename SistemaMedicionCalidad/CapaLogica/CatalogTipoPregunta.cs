using Project.CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Project
{
    public class CatalogTipoPregunta
    {
        //Lista los tipos de pregunta existentes en la base de datos
        public List<Tipo_Pregunta> listarTipoPreguntas()
        {
            DataBase db = new DataBase();
            db.connect();

            string sql = "mostrarTipoPreguntas";
            db.CreateCommandSP(sql);

            DbDataReader result = db.Query();
            List<Tipo_Pregunta> lTipoPreguntas = new List<Tipo_Pregunta>();
            while (result.Read())
            {
                Tipo_Pregunta tp = new Tipo_Pregunta(result.GetInt32(0), result.GetString(1));
                lTipoPreguntas.Add(tp);

            }
            return lTipoPreguntas;
        }

        //Devuelve un tipo de pregunta acorde a su ID
        public Tipo_Pregunta buscarUnTipoPregunta(int id_tipo_pregunta)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "buscarTipoPreguntaID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_tipo_pregunta", DbType.Int32, id_tipo_pregunta);
            DbDataReader result = bd.Query();
            result.Read();

            Tipo_Pregunta tp = new Tipo_Pregunta(result.GetInt32(0), result.GetString(1));

            result.Close();
            bd.Close();
            return tp;
        }
    }
}
