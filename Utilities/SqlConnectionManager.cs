using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AjudanteDBA.Utilities
{
    public class SqlConnectionManager
    {
        private SqlConnection connection;
        public SqlConnectionManager(ConfigEnv configEnv)
        {
            string conn =
                $"Data Source={configEnv.Datasource};Initial Catalog=master;User ID={configEnv.User};Password={configEnv.Password};TrustServerCertificate=True;Trusted_Connection=True";
            this.connection = new SqlConnection(conn);
        }

        public bool ConnectionTest()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir a conexão com o servidor de bancos de dados.", ex.Message);
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir a conexão: " + ex.Message);
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fechar a conexão: " + ex.Message);
                return false;
            }
        }
        public SqlDataReader ExecuteQuery(string query)
        {
            try
            {
                OpenConnection();
                
                SqlCommand command = new SqlCommand(query, connection);
                connection.InfoMessage += Connection_InfoMessage;
                return command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro SQL: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar a consulta: " + ex.Message);
                return null;
            }
        }
        // Manipula as mensagens de informações do SQL Server
        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            foreach (SqlError error in e.Errors)
            {
                MessageBox.Show("Mensagem do SQL Server: " + error.Message);
                // Pode adicionar lógica adicional para tratamento de mensagens de informações aqui
            }
        }
    }


}
