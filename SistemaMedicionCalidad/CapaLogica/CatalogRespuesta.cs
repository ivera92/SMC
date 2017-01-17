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

            bd.createParameter("@id_pregunta_respuesta", DbType.Int32, r.Id_pregunta_respuesta);
            bd.createParameter("@nombre_respuesta", DbType.String, r.Nombre_respuesta);
            bd.createParameter("@correcta_respuesta", DbType.Boolean, r.Correcta_respuesta);
            bd.execute();
            bd.Close();
        }
    }
}
