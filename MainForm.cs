using AjudanteDBA.Models;
using AjudanteDBA.Utilities;
using System.Data;

namespace AjudanteDBA
{
    public partial class frmMain : Form
    {
        private SqlConnectionManager sqlConnectionManager;
        private List<ActionLogging> ActionLoggings;

        ConfigEnv config;

        public frmMain()
        {
            InitializeComponent();
            ActionLoggings = new List<ActionLogging>();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //config = new ConfigEnv();
                config = new ConfigEnv();
                config.LoadConfiguration();

                sqlConnectionManager = new SqlConnectionManager(config);
                if (sqlConnectionManager.ConnectionTest())
                {
                    MessageBox.Show($"Conectado com as seguintes configura��es: \n" + config.ToString());
                    PopulateTreeView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao instanciar ConfigEnv: " + ex.Message);
            }
        }
        private void frmMain_Shown(object sender, EventArgs e)
        {
            lblVersion.Text += App.AppVersion.ToString();
        }

        private void PopulateTreeView()
        {
            {
                try
                {
                    // Consulta SQL para obter os nomes dos bancos de dados
                    string query = "SELECT name FROM sys.databases WHERE database_id > 4"; // Ignorando bancos de sistema
                    var queryResult = sqlConnectionManager.ExecuteQuery(query);

                    {
                        // Limpe o TreeView antes de adicionar novos n�s
                        trvDatabases.Nodes.Clear();
                        trvDatabases.CheckBoxes = true;

                        foreach (DataRow row in queryResult.Rows)
                        {
                            string? dbName = row[0].ToString();
                            trvDatabases.Nodes.Add(dbName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro SQL: " + ex.Message);
                }

                finally
                {
                    sqlConnectionManager.CloseConnection();
                }
            }
        }

        private List<string> ListCheckedDatabases() // Revisar nulabilidade da lista
        {
            List<string> selectedDatabases = new List<string>();
            foreach (TreeNode node in trvDatabases.Nodes)
            {
                if (node.Checked)
                {
                    selectedDatabases.Add(node.Text);
                }
            }
            return selectedDatabases;
        }

        private void btnListDatabases_Click(object sender, EventArgs e)
        {
            PopulateTreeView();
        }

        private void btnBackupAndVerify_Click(object sender, EventArgs e)
        {


            foreach (var db in ListCheckedDatabases())
            {
                try
                {
                    //sqlConnectionManager.ActionLogging = new ActionLogging(db);
                    var actionLoggin = new ActionLogging(db);
                    ActionLoggings.Add(actionLoggin);
                    sqlConnectionManager.ActionLogging = actionLoggin;
                    string query = SqlQueries.QueryBackupAndVerify(db, config.PathToBackup, out string verify);
                    sqlConnectionManager.ExecuteQuery(query);
                    sqlConnectionManager.ExecuteQuery(verify);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro no backup de {db}: " + ex);
                }

            }

            dgvResult.DataSource = ActionLoggings.ToList();
            dgvResult.Columns["SqlEvents"].Visible = false;
            dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //foreach (var actionLog in ActionLoggings)
            //{


            //    //MessageBox.Show(actionLog.DatabaseName + " " + actionLog.SqlEvents.Count.ToString() + " " + actionLog.Success);
            //}
        }

        private void btnDropDatabase_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Essa a��o � irrevers�vel e ir� afetar todos os bancos de dados selecionados.\nDeseja prosseguir?",
                   "Aviso!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var db in ListCheckedDatabases())
                {
                    try
                    {
                        string query = SqlQueries.QueryDeleteDatabaseAndBackupHistory(db, out string _1deleteHistory, out string _2discardConnections);
                        sqlConnectionManager.ExecuteCommandQuery(_1deleteHistory);
                        sqlConnectionManager.ExecuteCommandQuery(_2discardConnections);
                        sqlConnectionManager.ExecuteCommandQuery(query);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir {db}: " + ex);
                        throw;
                    }
                }
                PopulateTreeView();
            }
        }
        private void btnDetachDatabase_Click(object sender, EventArgs e)
        {
            foreach (var db in ListCheckedDatabases())
            {
                try
                {
                    string query = SqlQueries.QueryDetach(db);
                    sqlConnectionManager.KillConnection(db);
                    sqlConnectionManager.ExecuteCommandQuery(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao desanexar o banco {db}: " + ex);
                    throw;
                }
            }
            PopulateTreeView();
        }

        private void dgvResult_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var result = dgvResult.CurrentRow.Cells["SqlEvents"].Value;
            dgvResultDetails.DataSource = result;
            //dgvResultDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultDetails.Columns[0].Width = 55;
        }










        // Vou retomar essa parte do c�digo mais tarde. Por hora, opto por usar o treeview apenas.
        private void btnExportDatabaseList_Click(object sender, EventArgs e)
        {
            Functions.ExportToExcel();
        }

        private void btnImportDatabaseList_Click(object sender, EventArgs e)
        {
            Functions.ImportExcel();
        }

       
    }
}