using AgendaADONET.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaADONET.DAO
{
    public class ContatoDAO
    {
        public DataTable GetContatos()
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM CONTATOS";

           //Populando com DataTable
            DbDataReader reader = DAOUtils.GetDataReader(comando);
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;
        }
        public void Excluir(int id)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM CONTATOS WHERE ID = @id";

            //Passa parametro para SQL Server e MySQl via metodo
            comando.Parameters.Add(DAOUtils.GetParametro("@id", id));
            
            //Executa comando SQL
            comando.ExecuteNonQuery();
        }
        public void Inserir(Contato contato)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO CONTATOS (NOME, EMAIL, TELEFONE) VALUES (@nome, @email, @telefone)";

            //Passa parametro para SQL Server e MySQl via metodo
            comando.Parameters.Add(DAOUtils.GetParametro("@nome", contato.Nome));
            comando.Parameters.Add(DAOUtils.GetParametro("@email", contato.Email));
            comando.Parameters.Add(DAOUtils.GetParametro("@telefone", contato.Telefone));

            //Executa comando SQL
            comando.ExecuteNonQuery();
        }
        public void Atualizar(Contato contato)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE CONTATOS SET NOME = @nome, EMAIL = @email, TELEFONE = @telefone WHERE ID = @id";

            //Passa parametro para SQL Server e MySQl via metodo
            comando.Parameters.Add(DAOUtils.GetParametro("@id", contato.Id));
            comando.Parameters.Add(DAOUtils.GetParametro("@nome", contato.Nome));
            comando.Parameters.Add(DAOUtils.GetParametro("@email", contato.Email));
            comando.Parameters.Add(DAOUtils.GetParametro("@telefone", contato.Telefone));

            //Executa comando SQL
            comando.ExecuteNonQuery();
        }
        public string ContarUsuario()
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT COUNT(*) FROM CONTATOS";
            return comando.ExecuteScalar().ToString();
        }
    }
}
