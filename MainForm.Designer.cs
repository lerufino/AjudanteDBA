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
            dgvResult = new DataGridView();
            dgvResultDetails = new DataGridView();
            btnMoveFiles = new Button();
            pictureBox1 = new PictureBox();
            pnlBlackBox = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvDatabases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            // dgvResult
            // 
            dgvResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResult.Location = new Point(267, 189);
            dgvResult.Name = "dgvResult";
            dgvResult.RowTemplate.Height = 25;
            dgvResult.Size = new Size(304, 350);
            dgvResult.TabIndex = 9;
            dgvResult.CellEnter += dgvResult_CellEnter;
            // 
            // dgvResultDetails
            // 
            dgvResultDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultDetails.Location = new Point(577, 12);
            dgvResultDetails.Name = "dgvResultDetails";
            dgvResultDetails.RowTemplate.Height = 25;
            dgvResultDetails.Size = new Size(491, 527);
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
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1080, 566);
            Controls.Add(pnlBlackBox);
            Controls.Add(pictureBox1);
            Controls.Add(btnMoveFiles);
            Controls.Add(dgvResultDetails);
            Controls.Add(dgvResult);
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
            ((System.ComponentModel.ISupportInitialize)dgvResult).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResultDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private DataGridView dgvResult;
        private DataGridView dgvResultDetails;
        private Button btnMoveFiles;
        private PictureBox pictureBox1;
        private Panel pnlBlackBox;
    }
}