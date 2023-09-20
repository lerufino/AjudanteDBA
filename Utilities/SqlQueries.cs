using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjudanteDBA.Utilities
{
    public static class SqlQueries
    {
        public static string QueryBackupAndVerify(string database, string pathToBackup, out string verify)
        {
            string date = DateTime.Now.ToShortDateString().Replace('/','.');
            string fileName = database + "_" + date + ".bak";
            Path.Combine(pathToBackup, fileName);
            

            // Builds the Backup query
            StringBuilder sb = new StringBuilder();
            sb.Append($"BACKUP DATABASE [{database}] TO DISK = N'{pathToBackup}' ");
            sb.Append($" WITH NOFORMAT, INIT,  NAME = '{fileName}', CHECKSUM");


            //Builds the Verify query
            StringBuilder sb2 = new StringBuilder();
            sb2.Append("DECLARE @backupSetId AS INT ");
            sb2.Append($"SELECT @backupSetId = POSITION FROM msdb..backupset where database_name=N'{database}' ");
            sb2.Append($" AND backup_set_id=(select max(backup_set_id) FROM msdb..backupset WHERE database_name=N'{database}' ) ");
            sb2.Append($" IF @backupSetId IS NULL BEGIN  RAISERROR(N'Falha na verificação do backup. Arquivo não encontrado para ''BancoDeDadosApagavel', 16, 1) END ");
            sb2.Append($" RESTORE VERIFYONLY FROM  DISK = N'{pathToBackup}' WITH  FILE = @backupSetId");

            verify = sb2.ToString();
            return sb.ToString();
        }
    }
}
