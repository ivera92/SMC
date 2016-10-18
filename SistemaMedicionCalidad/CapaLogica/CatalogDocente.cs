using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Project
{
    public class CatalogDocente
    {
        public void agregarDocentePA(Docente d)
        {
            CapaDeDatos.DataBase bd = new CapaDeDatos.DataBase();
            bd.connect();

            string sql = "insDocentes";

            bd.CreateCommandSP(sql);
            bd.createParameter("@rut_docente", DbType.String, d.Rut_docente);
            bd.createParameter("@id_profesion", DbType.Int32, d.Id_profesion);
            bd.createParameter("@nombre_docente", DbType.String, d.Nombre_docente);
            bd.createParameter("@fecha_nacimiento_docente", DbType.Date, d.Fecha_nacimiento_docente);
            bd.createParameter("@direccion_docente", DbType.String, d.Direccion_docente);
            bd.createParameter("@telefono_docente", DbType.Int32, d.Telefono_docente);
            bd.createParameter("@nacionalidad_docente", DbType.String, d.Nacionalidad_docente);
            bd.createParameter("@sexo_docente", DbType.Boolean, d.Sexo_docente);
            bd.createParameter("@correo_docente", DbType.String, d.Correo_docente);
            bd.createParameter("@disponibilidad_docente", DbType.Boolean, d.Disponibilidad_docente);
            bd.execute();
            bd.Close();
        } 
    }
}
