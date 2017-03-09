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
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Respuesta r = new Respuesta();
                r.Id_respuesta = result.GetInt32(0);
                r.Nombre_respuesta = result.GetString(1);
                r.Correcta_respuesta = result.GetBoolean(2);
                lRespuestasPregunta.Add(r);
            }
            return lRespuestasPregunta;
        }

        //Lista todas las respuestas existentes en la base de datos
        public List<Respuesta> listarRespuestas()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarTodasRespuestas";
            bd.CreateCommandSP(sql);

            List<Respuesta> lRespuestas = new List<Respuesta>();
            DbDataReader result = bd.Query();//disponible resultado
            CatalogPregunta cPregunta = new CatalogPregunta();
            Pregunta p = new Pregunta();
            while (result.Read())
            {
                Respuesta r = new Respuesta();
                r.Pregunta_respuesta = p;
                p=cPregunta.buscarUnaPregunta(result.GetInt32(3));

                r.Pregunta_respuesta.Nombre_pregunta = p.Nombre_pregunta;             
                r.Id_respuesta = result.GetInt32(0);
                r.Nombre_respuesta = result.GetString(1);
                r.Correcta_respuesta = result.GetBoolean(2);

                lRespuestas.Add(r);
            }
            return lRespuestas;
        }
        //Elimina una sola respuesta de una pregunta acorde a su ID
        public void eliminarRespuesta(int id_respuesta)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarRespuesta";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_respuesta", DbType.Int32, id_respuesta);
            bd.execute();
            bd.Close();
        }

        //Elimina todas las respuestas asociadas a una pregunta acorde a su ID
        public void eliminarRespuestas(int id_pregunta)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarRespuestas";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_pregunta", DbType.Int32, id_pregunta);
            bd.execute();
            bd.Close();
        }
    }
}