using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjudanteDBA.Utilities
{
    public static class SqlQueries
    {   /// <summary>
        /// Returns a query for backup of a database and another one to verify the integrity of this backup;
        /// </summary>
        /// <param name="database"></param>
        /// <param name="pathToBackup"></param>
        /// <param name="verify"></param>
        /// <returns></returns>
        public static string QueryBackupAndVerify(string database, string pathToBackup, out string verify)
        {
            string date = DateTime.Now.ToString("dd.MM.yy-HH.mm");
            string fileName = database + "_" + date + ".bak";
            //pathToBackup = Path.Combine(Application.StartupPath, pathToBackup);
            var path = Path.Combine(pathToBackup, fileName);

            // Builds the Backup query
            StringBuilder sb = new StringBuilder();
            sb.Append($"BACKUP DATABASE [{database}] TO DISK = N'{path}' ");
            sb.Append($" WITH NOFORMAT, INIT,  NAME = '{fileName}', CHECKSUM");

            //Builds the Verify query
            StringBuilder sb2 = new StringBuilder();
            sb2.Append("DECLARE @backupSetId AS INT ");
            sb2.Append($"SELECT @backupSetId = POSITION FROM msdb..backupset where database_name=N'{database}' ");
            sb2.Append($" AND backup_set_id=(select max(backup_set_id) FROM msdb..backupset WHERE database_name=N'{database}' ) ");
            sb2.Append($" IF @backupSetId IS NULL BEGIN  RAISERROR(N'Falha na verificação do backup. Arquivo não encontrado para ''BancoDeDadosApagavel', 16, 1) END ");
            sb2.Append($" RESTORE VERIFYONLY FROM  DISK = N'{path}' WITH  FILE = @backupSetId");

            verify = sb2.ToString();
            return sb.ToString();
        }

        public static string QueryDeleteDatabaseAndBackupHistory(string database, out string _1deleteHistory, out string _2discardConnections)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'{database}' ");
            _1deleteHistory = sb.ToString();

            StringBuilder sb2 = new StringBuilder();
            sb2.Append($"ALTER DATABASE [{database}] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE ");
            _2discardConnections = sb2.ToString();

            StringBuilder sb3 = new StringBuilder();
            sb3.Append($"DROP DATABASE [{database}]");
            return sb3.ToString();
        }

        public static string QueryDetach(string database)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"ALTER DATABASE [{database}] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE ");
            sb.Append($"EXEC master.dbo.sp_detach_db @dbname = N'{database}' ");
            return sb.ToString();
        }

        public static string QueryDatabaseFilePath(string database)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"SELECT physical_name FROM sys.master_files ");
            sb.Append($"WHERE database_id = DB_ID('{database}') AND type = 0 ");
            return sb.ToString();
        }
    }
}
