using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace Project.CapaDeDatos
{
    public class DataBase
    {
        private DbConnection connection;
        private DbCommand command;
        private string connection_string;
        private static DbProviderFactory factory;
        private DbDataAdapter adapter;

        public DataBase()
        {
            string provider = ConfigurationManager.AppSettings.Get("proveedor");
            this.connection_string = ConfigurationManager.AppSettings.Get("cadena"); //pass nombre base datos nombre servidor
            factory = DbProviderFactories.GetFactory(provider); //instanciarla coneccion con la base de datos
        }

        public void connect()
        {
            this.connection = factory.CreateConnection(); //se crea la conexion
            this.connection.ConnectionString = connection_string; //se configura el string de conexion
            this.connection.Open();
        }
        public void CreateCommand(string sql)
        {
            this.command = factory.CreateCommand();
            this.command.Connection = connection;
            this.command.CommandType = CommandType.Text; //3 opciones para trabajar (consultas)
            this.command.CommandText = sql;
        }
        public void CreateCommandSP(string sql)
        {
            this.command = factory.CreateCommand();
            this.command.Connection = connection;
            this.command.CommandType = CommandType.StoredProcedure; //3 opciones para trabajar (consultas)
            this.command.CommandText = sql;
        }
        public DbDataReader Query()
        {
            return command.ExecuteReader(); //devuelve los valores
        }
        public void Close()
        {
            this.connection.Close();
        }
        public void execute()
        {
            try
            {
                this.command.ExecuteNonQuery();//inserta, update, delete...(no devuelve resultado ni valores)
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message);
            }
        }
        public void createParameter(string name, DbType type, object value)
        {
            DbParameter parameter = factory.CreateParameter();
            parameter.DbType = type;
            parameter.ParameterName = name;
            parameter.Value = value;
            this.command.Parameters.Add(parameter);
        }
        public DataSet dataSet(string sql)
        {
            try
            {
                adapter = factory.CreateDataAdapter();

                this.connect();

                this.CreateCommand(sql);
                adapter.SelectCommand = this.command;

                DbCommandBuilder cb = factory.CreateCommandBuilder();
                cb.DataAdapter = adapter;

                DataSet set = new DataSet();

                //relleno de datos el data set
                adapter.Fill(set);
                return set;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message);
            }
        }
    }
}
