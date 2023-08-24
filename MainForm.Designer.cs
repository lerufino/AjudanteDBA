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
            btnListDatabases = new Button();
            dgvDatabases = new DataGridView();
            btnExportDatabaseList = new Button();
            btnImportDatabaseList = new Button();
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
            dgvDatabases.Size = new Size(466, 423);
            dgvDatabases.TabIndex = 1;
            // 
            // btnExportDatabaseList
            // 
            btnExportDatabaseList.Location = new Point(266, 12);
            btnExportDatabaseList.Name = "btnExportDatabaseList";
            btnExportDatabaseList.Size = new Size(212, 23);
            btnExportDatabaseList.TabIndex = 2;
            btnExportDatabaseList.Text = "Exportar Lista de Bancos de Dados";
            btnExportDatabaseList.UseVisualStyleBackColor = true;
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
            btnImportDatabaseList.Click += btnImportDatabaseList_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 508);
            Controls.Add(btnImportDatabaseList);
            Controls.Add(btnExportDatabaseList);
            Controls.Add(dgvDatabases);
            Controls.Add(btnListDatabases);
            Name = "frmMain";
            Text = "Form1";
            Load += frmMain_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatabases).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnListDatabases;
        private DataGridView dgvDatabases;
        private Button btnExportDatabaseList;
        private Button btnImportDatabaseList;
    }
}