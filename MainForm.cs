using AjudanteDBA.Utilities;


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
                    MessageBox.Show("Conectado: " + config.ToString());
                    PopulateTreeView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao instanciar ConfigEnv: " + ex.Message);
            }
        }

        private void PopulateTreeView()
        {
            {
                try
                {
                    // Abra a conexão
                    sqlConnectionManager.OpenConnection();

                    // Consulta SQL para obter os nomes dos bancos de dados
                    string query = "SELECT name FROM sys.databases WHERE database_id > 4"; // Ignorando bancos de sistema
                    var reader = sqlConnectionManager.ExecuteQuery(query);


                    {
                        // Limpe o TreeView antes de adicionar novos nós
                        trvDatabases.Nodes.Clear();
                        trvDatabases.CheckBoxes = true;


                        while (reader.Read())
                        {
                            // Obtém o nome do banco de dados
                            string dbName = reader.GetString(0);

                            // Adicione um nó ao TreeView com o nome do banco de dados
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
            // sqlConnectionManager.ExecuteQuery();
            // MessageBox.Show(SqlQueries.QueryBackupAndVerify(ListCheckedDatabases().First(), config.PathToBackup, out string verify));
            // MessageBox.Show(verify);
        }

        private void btnFazerBackup_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Conectado como: " + config.ToString());
                string query = SqlQueries.QueryBackupAndVerify(ListCheckedDatabases().First(), config.PathToBackup, out string verify);
                MessageBox.Show("Executando a seguinte query: " + query);
                sqlConnectionManager.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro", ex.Message);
                throw;
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