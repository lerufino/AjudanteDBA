using AjudanteDBA.Utilities;
using System.Data;

namespace AjudanteDBA
{
    public partial class frmMain : Form
    {
        private SqlConnectionManager sqlConnectionManager;
        private List<string> selectedDatabases;

        ConfigEnv config;

        public frmMain()
        {
            InitializeComponent();

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
                    MessageBox.Show($"Conectado com as seguintes configurações: \n" + config.ToString());
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
                        // Limpe o TreeView antes de adicionar novos nós
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
                    string query = SqlQueries.QueryBackupAndVerify(db, config.PathToBackup, out string verify);
                    sqlConnectionManager.ExecuteQuery(query);
                    sqlConnectionManager.ExecuteQuery(verify);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro no backup de {db}: " + ex);
                }
            }
        }
        // TODO: Não está funcionando corretamente, revisar!
        private void btnDropDatabase_Click(object sender, EventArgs e)
        {

             if (MessageBox.Show("Essa ação é irreversível e irá afetar todos os bancos de dados selecionados.\nDeseja prosseguir?",
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














        // Vou retomar essa parte do código mais tarde. Por hora, opto por usar o treeview apenas.
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