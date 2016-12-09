using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.CapaDeDatos;
using System.Data;
using System.Data.Common;

namespace Project
{
    public class CatalogCompetencia
    {

        public void agregarCompetenciaPA(Competencia c)
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

        public void editarCompetencia(int accion, Competencia c)
        {
            DataBase bd = new DataBase();
            bd.connect();

            accion = 3;

            string sql = "competenciaPA";

            bd.CreateCommandSP(sql);

            bd.createParameter("@accion", DbType.Int32, accion);
            bd.createParameter("@id_competencia", DbType.Int32, c.Id_competencia);
            bd.createParameter("@nombre_competencia", DbType.String, c.Nombre_competencia);
            bd.createParameter("@tipo_competencia", DbType.Boolean, c.Tipo_competencia);
            bd.createParameter("@descripcion_competencia", DbType.String, c.Descripcion_competencia);
            bd.execute();
            bd.Close();
        }

        public List<Competencia> mostrarCompetencias()
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
    }
}
