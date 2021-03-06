﻿using Project.CapaDeDatos;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Project
{
    public class CatalogAsignaturaDesempeno
    {
        //Asocia un Desempeño con una Asignatura, ambas previamente creadas
        public void insertarAD(Asignatura_Desempeno ad)
        {
            DataBase bd = new DataBase();
            bd.connect();
            string sql = "insAD";
            bd.CreateCommandSP(sql);
            bd.createParameter("@cod_asignatura_ad", DbType.String, ad.Cod_asignatura.Cod_asignatura);
            bd.createParameter("@id_desempeno_ad", DbType.Int32, ad.Id_desempeno.Id_desempeno);
            bd.createParameter("@id_nivel_ad", DbType.Int32, ad.Id_nivel.Id_nivel);
            bd.execute();
            bd.Close();
        }

        //Lista todas las sociedades entre asignaturas y desempeño existentes en la base de datos
        public List<Asignatura_Desempeno> listarAD()
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarAD";

            bd.CreateCommandSP(sql);
            List<Asignatura_Desempeno> lAD = new List<Asignatura_Desempeno>();
            DbDataReader result = bd.Query();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            CatalogNivel cNivel = new CatalogNivel();
            while (result.Read())
            {
                Asignatura_Desempeno ad = new Asignatura_Desempeno();

                ad.Id_ad = result.GetInt32(0);
                ad.Cod_asignatura = cAsignatura.buscarAsignatura(result.GetString(1));
                ad.Id_desempeno = cDesempeno.buscarUnDesempeno(result.GetInt32(2));
                ad.Id_nivel = cNivel.buscarNivel(result.GetInt32(3));

                lAD.Add(ad);
            }
            result.Close();
            bd.Close();

            return lAD;
        }

        //Devuelve la asociacion acorde a su ID
        public Asignatura_Desempeno buscarAD(int id_ad)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "buscarADID";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_ad", DbType.Int32, id_ad);
            DbDataReader result = bd.Query();
            result.Read();

            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            CatalogNivel cNivel = new CatalogNivel();
            Asignatura_Desempeno ad = new Asignatura_Desempeno();

            ad.Id_ad = result.GetInt32(0);
            ad.Cod_asignatura = cAsignatura.buscarAsignatura(result.GetString(1));
            ad.Id_desempeno = cDesempeno.buscarUnDesempeno(result.GetInt32(2));
            ad.Id_nivel = cNivel.buscarNivel(result.GetInt32(3));

            result.Close();
            bd.Close();
            return ad;
        }

        //Actualiza una asociacion existente en la base de datos
        public void actualizarAsociacion(Asignatura_Desempeno ad)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "editarAD";

            bd.CreateCommandSP(sql);

            bd.createParameter("@id_ad", DbType.Int32, ad.Id_ad);
            bd.createParameter("@cod_asignatura_ad", DbType.String, ad.Cod_asignatura.Cod_asignatura);
            bd.createParameter("@id_desempeno_ad", DbType.Int32, ad.Id_desempeno.Id_desempeno);
            bd.createParameter("@id_nivel_ad", DbType.Int32, ad.Id_nivel);
            bd.execute();
            bd.Close();
        }

        //Verifica si ya existe asociacion acorde al id del desempeño
        public int verificarExistenciaADIDD(int id_desempeño)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "verificarExistenciaADIDD";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@id_desempeno", DbType.Int32, id_desempeño);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);

            result.Close();
            bd.Close();
            return existe;
        }

        //Verifica si ya existe asociacion entre desempeño y asignatura previa del desempeño
        public int verificarExistenciaAD(Asignatura_Desempeno ad)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "verificarExistenciaAsociacionAD";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@cod_asignatura", DbType.String, ad.Cod_asignatura.Cod_asignatura);
            bd.createParameter("@id_desempeno", DbType.Int32, ad.Id_desempeno.Id_desempeno);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);

            result.Close();
            bd.Close();
            return existe;
        }

        //Verifica si ya existe una evaluacion para la asignatura
        public int verificarExistenciaEvaluacionAD(string cod_asignatura)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sqlSearch = "verificarExistenciaEvaluacionAD";
            bd.CreateCommandSP(sqlSearch);
            bd.createParameter("@cod_asignatura", DbType.String, cod_asignatura);
            DbDataReader result = bd.Query();
            result.Read();
            int existe = result.GetInt32(0);

            result.Close();
            bd.Close();
            return existe;
        }

        //Elimina un aD existente en la base de datos acorde a su ID
        public void eliminarAD(int id_ad)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "eliminarAD";

            bd.CreateCommandSP(sql);
            bd.createParameter("@id_ad", DbType.Int32, id_ad);
            bd.execute();
            bd.Close();
        }

        //Lista todas las sociedades entre asignatura y desempeño buscadas existentes en la base de datos
        public List<Asignatura_Desempeno> listarADBusqueda(string buscar)
        {
            DataBase bd = new DataBase();
            bd.connect();

            string sql = "mostrarADBusqueda";

            bd.CreateCommandSP(sql);
            bd.createParameter("@buscar", DbType.String, buscar);
            List<Asignatura_Desempeno> lAD = new List<Asignatura_Desempeno>();
            DbDataReader result = bd.Query();
            CatalogAsignatura cAsignatura = new CatalogAsignatura();
            CatalogDesempeno cDesempeno = new CatalogDesempeno();
            CatalogNivel cNivel = new CatalogNivel();
            while (result.Read())
            {
                Asignatura_Desempeno ad = new Asignatura_Desempeno();
                ad.Id_ad = result.GetInt32(0);
                ad.Cod_asignatura = cAsignatura.buscarAsignatura(result.GetString(1));
                ad.Id_desempeno = cDesempeno.buscarUnDesempeno(result.GetInt32(2));
                ad.Id_nivel = cNivel.buscarNivel(result.GetInt32(3));
                lAD.Add(ad);
            }
            result.Close();
            bd.Close();
            return lAD;
        }
    }
}
