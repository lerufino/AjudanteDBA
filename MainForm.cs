using AjudanteDBA.Utilities;

namespace AjudanteDBA
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnListDatabases_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Config config = new Config();
            config.ConfigureEnvironment();
        }

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