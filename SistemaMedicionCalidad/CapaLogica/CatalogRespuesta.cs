using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogRespuesta
    {
        //Inserta una respuesta a la base de datos
        public void insertarRespuesta(Respuesta r)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "insRespuesta";
            bd.CreateCommandSP(sql);

            bd.createParameter("@id_pregunta_respuesta", DbType.Int32, r.Pregunta_respuesta.Id_pregunta);
            bd.createParameter("@nombre_respuesta", DbType.String, r.Nombre_respuesta);
            bd.createParameter("@correcta_respuesta", DbType.Boolean, r.Correcta_respuesta);
            bd.execute();
            bd.Close();
        }
        //Devuelve las respuestas asociadas a una pregunta mediante su ID
        public List<Respuesta> listarRespuestasPregunta(int id_pregunta)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarRespuestasDePregunta";
            bd.CreateCommandSP(sql);

            bd.createParameter("@id_pregunta_respuesta", DbType.Int32, id_pregunta);
            List<Respuesta> lRespuestasPregunta = new List<Respuesta>();
            CatalogPregunta cPregunta = new CatalogPregunta();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Respuesta r = new Respuesta();
                r.Id_respuesta = result.GetInt32(0);
                r.Pregunta_respuesta = cPregunta.buscarUnaPregunta(result.GetInt32(1));
                r.Nombre_respuesta = result.GetString(2);
                r.Correcta_respuesta = result.GetBoolean(3);
                lRespuestasPregunta.Add(r);
            }
            result.Close();
            bd.Close();
            return lRespuestasPregunta;
        }        

        //Elimina todas las respuestas asociadas a una pregunta acorde a su ID
        public void eliminarRespuestas(int id_pregunta)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarRespuestasDePregunta";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_pregunta", DbType.Int32, id_pregunta);
            bd.execute();
            bd.Close();
        }

        //Actualiza una respuesta existente en la base de datos
        public void actualizarRespuesta(Respuesta r)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarRespuesta";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_respuesta", DbType.Int32, r.Id_respuesta);
            bd.createParameter("@nombre_respuesta", DbType.String, r.Nombre_respuesta);
            bd.createParameter("@correcta_respuesta", DbType.Boolean, r.Correcta_respuesta);
            bd.execute();
            bd.Close();
        }

        //Devuelve una respuesta acorde a su ID
        public Respuesta buscarUnaRespuesta(int id_respuesta)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "buscarRespuestaID";
            bd.CreateCommandSP(sql);
            bd.createParameter("@id_respuesta", DbType.Int32, id_respuesta);

            DbDataReader result = bd.Query();
            result.Read();
            Respuesta r = new Respuesta();
            CatalogPregunta cPregunta = new CatalogPregunta();

            r.Id_respuesta = result.GetInt32(0);
            r.Pregunta_respuesta = cPregunta.buscarUnaPregunta(result.GetInt32(1));
            r.Nombre_respuesta = result.GetString(2);
            r.Correcta_respuesta = result.GetBoolean(3);

            result.Close();
            bd.Close();

            return r;
        }
    }
}