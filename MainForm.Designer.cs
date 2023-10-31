namespace AjudanteDBA
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            btnListDatabases = new Button();
            dgvDatabases = new DataGridView();
            btnExportDatabaseList = new Button();
            btnImportDatabaseList = new Button();
            trvDatabases = new TreeView();
            btnBackupAndVerify = new Button();
            btnDropDatabase = new Button();
            lblVersion = new Label();
            btnDetachDatabase = new Button();
            dgvResultBackup = new DataGridView();
            dgvResultDetails = new DataGridView();
            btnMoveFiles = new Button();
            pictureBox1 = new PictureBox();
            pnlBlackBox = new Panel();
            label1 = new Label();
            lblTimeElapsed = new Label();
            panel1 = new Panel();
            dgvResultMove = new DataGridView();
            dgvResultDetach = new DataGridView();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgvDatabases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultBackup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultMove).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultDetach).BeginInit();
            SuspendLayout();
            // 
            // btnListDatabases
            // 
            btnListDatabases.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnListDatabases.Location = new Point(12, 12);
            btnListDatabases.Name = "btnListDatabases";
            btnListDatabases.Size = new Size(248, 52);
            btnListDatabases.TabIndex = 0;
            btnListDatabases.Text = "Listar Bancos de Dados";
            btnListDatabases.UseVisualStyleBackColor = true;
            btnListDatabases.Click += btnListDatabases_Click;
            // 
            // dgvDatabases
            // 
            dgvDatabases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatabases.Location = new Point(5, 73);
            dgvDatabases.Name = "dgvDatabases";
            dgvDatabases.RowTemplate.Height = 25;
            dgvDatabases.Size = new Size(153, 395);
            dgvDatabases.TabIndex = 1;
            dgvDatabases.Visible = false;
            // 
            // btnExportDatabaseList
            // 
            btnExportDatabaseList.Location = new Point(266, 12);
            btnExportDatabaseList.Name = "btnExportDatabaseList";
            btnExportDatabaseList.Size = new Size(212, 23);
            btnExportDatabaseList.TabIndex = 2;
            btnExportDatabaseList.Text = "Exportar Lista de Bancos de Dados";
            btnExportDatabaseList.UseVisualStyleBackColor = true;
            btnExportDatabaseList.Visible = false;
            btnExportDatabaseList.Click += btnExportDatabaseList_Click;
            // 
            // btnImportDatabaseList
            // 
            btnImportDatabaseList.Location = new Point(266, 41);
            btnImportDatabaseList.Name = "btnImportDatabaseList";
            btnImportDatabaseList.Size = new Size(212, 23);
            btnImportDatabaseList.TabIndex = 3;
            btnImportDatabaseList.Text = "Importar Lista de Bancos de Dados";
            btnImportDatabaseList.UseVisualStyleBackColor = true;
            btnImportDatabaseList.Visible = false;
            btnImportDatabaseList.Click += btnImportDatabaseList_Click;
            // 
            // trvDatabases
            // 
            trvDatabases.Location = new Point(12, 73);
            trvDatabases.Name = "trvDatabases";
            trvDatabases.Size = new Size(249, 466);
            trvDatabases.TabIndex = 4;
            // 
            // btnBackupAndVerify
            // 
            btnBackupAndVerify.Location = new Point(266, 73);
            btnBackupAndVerify.Name = "btnBackupAndVerify";
            btnBackupAndVerify.Size = new Size(305, 23);
            btnBackupAndVerify.TabIndex = 5;
            btnBackupAndVerify.Text = "Fazer Backup";
            btnBackupAndVerify.UseVisualStyleBackColor = true;
            btnBackupAndVerify.Click += btnBackupAndVerify_Click;
            // 
            // btnDropDatabase
            // 
            btnDropDatabase.Location = new Point(266, 160);
            btnDropDatabase.Name = "btnDropDatabase";
            btnDropDatabase.Size = new Size(305, 23);
            btnDropDatabase.TabIndex = 6;
            btnDropDatabase.Text = "Excluir Permanentemente ⚠️";
            btnDropDatabase.UseVisualStyleBackColor = true;
            btnDropDatabase.Visible = false;
            btnDropDatabase.Click += btnDropDatabase_Click;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(12, 542);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(47, 15);
            lblVersion.TabIndex = 7;
            lblVersion.Text = "Versão: ";
            // 
            // btnDetachDatabase
            // 
            btnDetachDatabase.Location = new Point(266, 102);
            btnDetachDatabase.Name = "btnDetachDatabase";
            btnDetachDatabase.Size = new Size(305, 23);
            btnDetachDatabase.TabIndex = 8;
            btnDetachDatabase.Text = "Desanexar Base";
            btnDetachDatabase.UseVisualStyleBackColor = true;
            btnDetachDatabase.Click += btnDetachDatabase_Click;
            // 
            // dgvResultBackup
            // 
            dgvResultBackup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultBackup.Location = new Point(12, 12);
            dgvResultBackup.Name = "dgvResultBackup";
            dgvResultBackup.RowTemplate.Height = 25;
            dgvResultBackup.Size = new Size(94, 68);
            dgvResultBackup.TabIndex = 9;
            dgvResultBackup.CellEnter += dgvResult_CellEnter;
            // 
            // dgvResultDetails
            // 
            dgvResultDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultDetails.Location = new Point(577, 73);
            dgvResultDetails.Name = "dgvResultDetails";
            dgvResultDetails.RowTemplate.Height = 25;
            dgvResultDetails.Size = new Size(491, 466);
            dgvResultDetails.TabIndex = 10;
            // 
            // btnMoveFiles
            // 
            btnMoveFiles.Location = new Point(266, 131);
            btnMoveFiles.Name = "btnMoveFiles";
            btnMoveFiles.Size = new Size(305, 23);
            btnMoveFiles.TabIndex = 11;
            btnMoveFiles.Text = "Mover Arquivos MDF e LDF";
            btnMoveFiles.UseVisualStyleBackColor = true;
            btnMoveFiles.Click += btnMoveFiles_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(502, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // pnlBlackBox
            // 
            pnlBlackBox.BackColor = SystemColors.Control;
            pnlBlackBox.Location = new Point(502, 12);
            pnlBlackBox.Name = "pnlBlackBox";
            pnlBlackBox.Size = new Size(50, 50);
            pnlBlackBox.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(267, 204);
            label1.Name = "label1";
            label1.Size = new Size(125, 21);
            label1.TabIndex = 14;
            label1.Text = "Bancos afetados:";
            // 
            // lblTimeElapsed
            // 
            lblTimeElapsed.AutoSize = true;
            lblTimeElapsed.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblTimeElapsed.Location = new Point(577, 33);
            lblTimeElapsed.Name = "lblTimeElapsed";
            lblTimeElapsed.Size = new Size(119, 37);
            lblTimeElapsed.TabIndex = 15;
            lblTimeElapsed.Text = "00:00:00";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvResultMove);
            panel1.Controls.Add(dgvResultDetach);
            panel1.Controls.Add(dgvResultBackup);
            panel1.Location = new Point(267, 228);
            panel1.Name = "panel1";
            panel1.Size = new Size(304, 311);
            panel1.TabIndex = 16;
            // 
            // dgvResultMove
            // 
            dgvResultMove.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultMove.Location = new Point(204, 154);
            dgvResultMove.Name = "dgvResultMove";
            dgvResultMove.RowTemplate.Height = 25;
            dgvResultMove.Size = new Size(94, 68);
            dgvResultMove.TabIndex = 11;
            // 
            // dgvResultDetach
            // 
            dgvResultDetach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultDetach.Location = new Point(107, 84);
            dgvResultDetach.Name = "dgvResultDetach";
            dgvResultDetach.RowTemplate.Height = 25;
            dgvResultDetach.Size = new Size(94, 68);
            dgvResultDetach.TabIndex = 10;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1080, 566);
            Controls.Add(panel1);
            Controls.Add(lblTimeElapsed);
            Controls.Add(label1);
            Controls.Add(pnlBlackBox);
            Controls.Add(pictureBox1);
            Controls.Add(btnMoveFiles);
            Controls.Add(dgvResultDetails);
            Controls.Add(btnDetachDatabase);
            Controls.Add(lblVersion);
            Controls.Add(btnDropDatabase);
            Controls.Add(btnBackupAndVerify);
            Controls.Add(trvDatabases);
            Controls.Add(btnImportDatabaseList);
            Controls.Add(btnExportDatabaseList);
            Controls.Add(dgvDatabases);
            Controls.Add(btnListDatabases);
            Name = "frmMain";
            Text = "Ajudante do DBA";
            Load += frmMain_Load;
            Shown += frmMain_Shown;
            ((System.ComponentModel.ISupportInitialize)dgvDatabases).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultBackup).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResultMove).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultDetach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListDatabases;
        private DataGridView dgvDatabases;
        private Button btnExportDatabaseList;
        private Button btnImportDatabaseList;
        private TreeView trvDatabases;
        private Button btnBackupAndVerify;
        private Button btnDropDatabase;
        private Label lblVersion;
        private Button btnDetachDatabase;
        private DataGridView dgvResultBackup;
        private DataGridView dgvResultDetails;
        private Button btnMoveFiles;
        private PictureBox pictureBox1;
        private Panel pnlBlackBox;
        private Label label1;
        private Label lblTimeElapsed;
        private Panel panel1;
        private DataGridView dgvResultDetach;
        private DataGridView dgvResultMove;
        private System.Windows.Forms.Timer timer1;
    }
}