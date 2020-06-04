using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AgendaADONET.DAO
{
    public class DAOUtils
    {
        public static DbConnection GetConexao()
        {
            string server = ConfigurationManager.AppSettings["server"].ToString();
            string database = ConfigurationManager.AppSettings["database"].ToString();
            string user = ConfigurationManager.AppSettings["user"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();
            DbConnection conexao = null;
            string connectionString = "";

            if (ConfigurationManager.AppSettings["provider"].ToString() == "MSSQL")
            {
                connectionString = @"Server=" + server + ";Database=" + database + ";User Id=" + user + ";Password=" + password + ";";
                //Conexão com SQL Server
                conexao = new SqlConnection(connectionString);
            }
            else
            {
                connectionString = @"Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd=" + password + ";";
                //Conexão com MySQL
                conexao = new MySqlConnection(connectionString);
            }
            
            conexao.Open();
            return conexao;
        }
        public static DbCommand GetComando(DbConnection conexao)
        {
            DbCommand comando = conexao.CreateCommand();
            return comando;
        }
        public static DbDataReader GetDataReader(DbCommand comando)
        {
            return comando.ExecuteReader();
        }
        public static DbParameter GetParametro(string nome, object valor)
        {
            DbParameter parametro = null;
            if (ConfigurationManager.AppSettings["provider"].ToString() == "MSSQL")
            {
                parametro = new SqlParameter(nome, valor);
            }
            else
            {
                parametro = new MySqlParameter(nome, valor);
            }
            return parametro;
        }
    }
}
