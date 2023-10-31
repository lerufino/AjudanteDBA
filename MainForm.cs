using AjudanteDBA.Models;
using AjudanteDBA.Utilities;
using System.Data;

namespace AjudanteDBA
{
    public partial class frmMain : Form
    {
        private SqlConnectionManager sqlConnectionManager;
        private List<ActionLogging> ActionLoggings;
        private List<Database> DetachedDatabases = new List<Database>();

        private double _elapsed = 1;
        ConfigEnv config;

        public frmMain()
        {
            InitializeComponent();
            ActionLoggings = new List<ActionLogging>();
            InitializeGrids();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = TimeSpan.FromSeconds(_elapsed);
            lblTimeElapsed.Text = ts.ToString(@"hh\:mm\:ss");

            _elapsed += 1;
        }


        private void InitializeGrids()
        {
            dgvResultBackup.Dock = DockStyle.Fill;
            //dgvResultBackup.DataSource = ActionLoggings.ToList();
            dgvResultDetach.Dock = DockStyle.Fill;
            dgvResultMove.Dock = DockStyle.Fill;

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
            pnlBlackBox.Visible = false;
            PopulateTreeView();
            pnlBlackBox.Visible = true;
        }

        private async void btnBackupAndVerify_Click(object sender, EventArgs e)
        {
            _elapsed = 1;
            timer1.Start();
            await StartBackup();
            timer1.Stop();

        }

        private async Task StartBackup()
        {
            pnlBlackBox.Visible = false;
            ActionLoggings.Clear();
            dgvResultBackup.BringToFront();


            foreach (var db in ListCheckedDatabases())
            {
                //await Task.Run(() => Thread.Sleep(1000));
                Thread.Sleep(1000);

                try
                {
                    //sqlConnectionManager.ActionLogging = new ActionLogging(db);
                    var actionLoggin = new ActionLogging(db);
                    ActionLoggings.Add(actionLoggin);
                    sqlConnectionManager.ActionLogging = actionLoggin;
                    string query = SqlQueries.QueryBackupAndVerify(db, config.PathToBackup, out string verify);
                    await sqlConnectionManager.ExecuteQueryAsync(query);
                    await sqlConnectionManager.ExecuteQueryAsync(verify);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro no backup de {db}: " + ex);
                }

            }
            dgvResultBackup.DataSource = ActionLoggings.ToList();
            dgvResultBackup.Columns["SqlEvents"].Visible = false;
            dgvResultBackup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            pnlBlackBox.Visible = true;

            //timer1.Stop();
        }

        private void btnDropDatabase_Click(object sender, EventArgs e)
        {
            pnlBlackBox.Visible = false;
            Application.DoEvents();

            if (MessageBox.Show("Essa ação é irreversível e irá afetar todos os bancos de dados selecionados.\nDeseja prosseguir?",
                   "Aviso!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DetachedDatabases.Clear();
                foreach (var db in ListCheckedDatabases())
                {
                    try
                    {
                        string query = SqlQueries.QueryDeleteDatabaseAndBackupHistory(db, out string _1deleteHistory, out string _2discardConnections);
                        sqlConnectionManager.ExecuteCommandQuery(_1deleteHistory);
                        sqlConnectionManager.ExecuteCommandQuery(_2discardConnections);
                        sqlConnectionManager.ExecuteCommandQuery(query);

                        DetachedDatabases.Add(PathToDatabaseFiles(db));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir {db}: " + ex);
                        throw;
                    }
                }
                PopulateTreeView();
            }
            pnlBlackBox.Visible = true;
        }
        private void btnDetachDatabase_Click(object sender, EventArgs e)
        {
            pnlBlackBox.Visible = false;

            dgvResultDetach.BringToFront();
            Application.DoEvents();

            DetachedDatabases.Clear();
            foreach (var db in ListCheckedDatabases())
            {
                try
                {
                    string query = SqlQueries.QueryDetach(db);
                    DetachedDatabases.Add(PathToDatabaseFiles(db));
                    sqlConnectionManager.KillConnection(db);
                    sqlConnectionManager.ExecuteCommandQuery(query);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao desanexar o banco {db}: " + ex);
                    throw;
                }
            }
            dgvResultDetach.DataSource = DetachedDatabases;
            dgvResultDetach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            MessageBox.Show("Os bancos de dados selecionados foram desanexados com sucesso.");
            pnlBlackBox.Visible = true;
            Application.DoEvents();
        }

        private void btnMoveFiles_Click(object sender, EventArgs e)
        {
            pnlBlackBox.Visible = false;
            if (DetachedDatabases.Count > 0)
            {
                foreach (var dbModel in DetachedDatabases)
                {
                    try
                    {
                        MoveDatabaseFiles(dbModel);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao mover os arquivos: " + ex);
                        throw;
                    }
                }
            }
            else
            {
                MessageBox.Show("Não há bancos de dados para ser movidos");
            }
            pnlBlackBox.Visible = true;
            MessageBox.Show("Tarefa concluída.");

        }

        // Busca caminho dos arquivos .MDF e .LDF de determinado banco de dados
        public Database PathToDatabaseFiles(string database)
        {
            var query = SqlQueries.QueryDatabaseFilePath(database);
            var queryResult = sqlConnectionManager.ExecuteQuery(query);

            Database dbModel = new()
            {
                TableName = database
            };

            foreach (DataRow row in queryResult.Rows)
            {
                var value = row[0].ToString();
                if (value != null)
                {
                    dbModel.FilePaths.Add(value);
                }
            }

            return dbModel;
        }

        public void MoveDatabaseFiles(Database db)
        {
            string destinationPath = Path.Combine(config.PathToBackup, "MDF e LDF");

            try
            {
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                foreach (var file in db.FilePaths)
                {
                    var destinationFilePath = Path.Combine(destinationPath, Path.GetFileName(file));
                    File.Move(file, destinationFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao mover os arquivos: " + ex);
            }
        }

        private void dgvResult_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            var result = dgvResultBackup.CurrentRow.Cells["SqlEvents"].Value;
            dgvResultDetails.DataSource = result;
            //dgvResultDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultDetails.Columns[0].Width = 55;


        }






        // Vou retomar essa parte do código mais tarde. Por hora, opto por usar o treeview apenas.
        //
        /// 
        /// 
        /// 
        /// 
        /// 
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