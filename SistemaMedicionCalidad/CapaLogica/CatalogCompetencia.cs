using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.CapaDeDatos;
using System.Data;

namespace Project
{
    public class CatalogCompetencia
    {
        int accion;

        public void agregarCompetenciaPA(Competencia c)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql="competenciaPA";

            bd.CreateCommandSP(sql);
            accion = 1;
            bd.createParameter("@accion", DbType.Int32, accion);
            bd.createParameter("@id_competencia", DbType.Int32, c.Id_competencia);
            bd.createParameter("@nombre_competencia", DbType.String, c.Nombre_competencia);
            bd.createParameter("@tipo_competencia", DbType.Boolean, c.Tipo_competencia);
            bd.createParameter("descripcion_competencia", DbType.String, c.Descripcion_competencia);
            bd.execute();
            bd.Close();
        }

        public void eliminarCompetencia(Competencia c)
        {
            DataBase bd = new DataBase();
            bd.connect();

            accion=2;

            string sql = "competenciaPA";

            bd.CreateCommandSP(sql);

            bd.createParameter("@accion", DbType.String, accion);
            bd.createParameter("id_competencia", DbType.Int32, c.Id_competencia);
            bd.execute();
            bd.Close();
        }

        public void editarCompetencia(Competencia c)
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
            bd.createParameter("descripcion_competencia", DbType.String, c.Descripcion_competencia);
            bd.execute();
            bd.Close();
        }
    }
}
