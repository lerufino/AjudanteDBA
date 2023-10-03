using AjudanteDBA.Models;
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
        public ActionLogging? ActionLogging { get; set; }

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

        public bool KillConnection(string database)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("USE master ");
                sb.Append("DECLARE @kill varchar(8000); SET @kill = '';");
                sb.Append("SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), spid) + ';' ");
                sb.Append("FROM master..sysprocesses ");
                sb.Append($"WHERE dbid = db_id('{database}')");
                sb.Append("EXEC(@kill); ");

                ExecuteCommandQuery(sb.ToString());

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            try
            {
                DataTable dt = new DataTable();

                OpenConnection();

                SqlCommand command = new SqlCommand(query, connection);
                connection.InfoMessage += Connection_InfoMessage;
                dt.Load(command.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool ExecuteCommandQuery(string query)
        {
            try
            {
                OpenConnection();

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.InfoMessage += Connection_InfoMessage;

                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public object? ExecuteScalarQuery(string query)
        {
            try
            {
                OpenConnection();

                SqlCommand command = new SqlCommand(query, connection);
                
                return command.ExecuteScalar(); 
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        // Manipula as mensagens de informações do SQL Server
        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            if (ActionLogging != null)
                foreach (SqlError error in e.Errors)
                {
                    ActionLogging.SqlEvents.Add(new SqlEvent(error.Number, error.Message));

                    if (error.Number == 3014)
                        ActionLogging.Success = true;
                }
                    
            
        }
    }


}
