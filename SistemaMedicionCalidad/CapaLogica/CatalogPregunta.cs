using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
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
            bd.createParameter("@id_competencia_pregunta", DbType.Int32, p.Id_competencia_pregunta);
            bd.createParameter("@id_tipo_pregunta_pregunta", DbType.Int32, p.Id_tipo_pregunta_pregunta);
            bd.createParameter("@nombre_pregunta", DbType.String, p.Nombre_pregunta);

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
    }
}
