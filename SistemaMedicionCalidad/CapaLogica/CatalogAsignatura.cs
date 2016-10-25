using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.CapaDeDatos;
using System.Data;

namespace Project
{
    public class CatalogAsignatura
    {
        public void agregarAsignaturaPA(Asignatura a)
        {
            CapaDeDatos.DataBase bd = new DataBase();
            bd.connect();

            string sql = "insAsignatura";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_asignatura", DbType.Int32, a.Id_asignatura);
            bd.createParameter("@id_escuela_asignatura", DbType.Int32, a.Id_escuela_asignatura);
            bd.createParameter("@rut_docente_asignatura", DbType.String, a.Rut_docente_asignatura);
            bd.createParameter("@nombre_asignatura", DbType.String, a.Nombre_asignatura);
            bd.createParameter("@ano_asignatura", DbType.Int32, a.Ano_asignatura);
            bd.createParameter("@duracion_asignatura", DbType.Boolean, a.Duracion_asignatura);
            bd.execute();
            bd.Close();
        }
    }
}
