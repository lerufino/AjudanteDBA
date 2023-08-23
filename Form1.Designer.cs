namespace AjudanteDBA
{
    partial class Form1
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
            dgvDatabases.Location = new Point(12, 58);
            dgvDatabases.Name = "dgvDatabases";
            dgvDatabases.RowTemplate.Height = 25;
            dgvDatabases.Size = new Size(212, 438);
            dgvDatabases.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 508);
            Controls.Add(dgvDatabases);
            Controls.Add(btnListDatabases);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvDatabases).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnListDatabases;
        private DataGridView dgvDatabases;
    }
}