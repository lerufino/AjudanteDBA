﻿namespace AjudanteDBA
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
            btnListDatabases = new Button();
            dgvDatabases = new DataGridView();
            btnExportDatabaseList = new Button();
            btnImportDatabaseList = new Button();
            trvDatabases = new TreeView();
            btnBackupAndVerify = new Button();
            btnDropDatabase = new Button();
            lblVersion = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDatabases).BeginInit();
            SuspendLayout();
            // 
            // btnListDatabases
            // 
            btnListDatabases.Location = new Point(12, 12);
            btnListDatabases.Name = "btnListDatabases";
            btnListDatabases.Size = new Size(212, 23);
            btnListDatabases.TabIndex = 0;
            btnListDatabases.Text = "Listar Bancos de Dados";
            btnListDatabases.UseVisualStyleBackColor = true;
            btnListDatabases.Click += btnListDatabases_Click;
            // 
            // dgvDatabases
            // 
            dgvDatabases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatabases.Location = new Point(12, 73);
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
            trvDatabases.Location = new Point(35, 73);
            trvDatabases.Name = "trvDatabases";
            trvDatabases.Size = new Size(226, 395);
            trvDatabases.TabIndex = 4;
            // 
            // btnBackupAndVerify
            // 
            btnBackupAndVerify.Location = new Point(267, 94);
            btnBackupAndVerify.Name = "btnBackupAndVerify";
            btnBackupAndVerify.Size = new Size(211, 23);
            btnBackupAndVerify.TabIndex = 5;
            btnBackupAndVerify.Text = "Fazer Backup";
            btnBackupAndVerify.UseVisualStyleBackColor = true;
            btnBackupAndVerify.Click += btnBackupAndVerify_Click;
            // 
            // btnDropDatabase
            // 
            btnDropDatabase.Location = new Point(267, 134);
            btnDropDatabase.Name = "btnDropDatabase";
            btnDropDatabase.Size = new Size(211, 23);
            btnDropDatabase.TabIndex = 6;
            btnDropDatabase.Text = "Excluir Permanentemente";
            btnDropDatabase.UseVisualStyleBackColor = true;
            btnDropDatabase.Click += btnDropDatabase_Click;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(6, 487);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(47, 15);
            lblVersion.TabIndex = 7;
            lblVersion.Text = "Versão: ";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 508);
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
    }
}