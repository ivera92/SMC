using System.Collections.Generic;
using Project.CapaDeDatos;
using System.Data.Common;
using System.Data;
using Project.CapaDeDatos;

namespace Project
{
    public class CatalogRespuesta
    {
        public void agregarRespuesta(Respuesta r)
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
        public List<Respuesta> mostrarRespuestas(int id_pregunta)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarRespuestasDePregunta";
            bd.CreateCommandSP(sql);

            bd.createParameter("@id_pregunta_respuesta", DbType.Int32, id_pregunta);
            List<Respuesta> lrespuestas = new List<Respuesta>();
            DbDataReader result = bd.Query();//disponible resultado
            while (result.Read())
            {
                Respuesta r = new Respuesta();
                r.Id_respuesta = result.GetInt32(0);
                r.Nombre_respuesta = result.GetString(1);
                r.Correcta_respuesta = result.GetBoolean(2);
                lrespuestas.Add(r);
            }
            return lrespuestas;
        }

        public List<Respuesta> mostrarTodasRespuestas()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarTodasRespuestas";
            bd.CreateCommandSP(sql);

            List<Respuesta> lrespuestas = new List<Respuesta>();
            DbDataReader result = bd.Query();//disponible resultado
            CatalogPregunta cp = new CatalogPregunta();
            Pregunta p = new Pregunta();
            while (result.Read())
            {
                Respuesta r = new Respuesta();
                r.Pregunta_respuesta = p;
                p=cp.buscarUnaPregunta(result.GetInt32(3));

                r.Pregunta_respuesta.Nombre_pregunta = p.Nombre_pregunta;             
                r.Id_respuesta = result.GetInt32(0);
                r.Nombre_respuesta = result.GetString(1);
                r.Correcta_respuesta = result.GetBoolean(2);

                lrespuestas.Add(r);
            }
            return lrespuestas;
        }
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
