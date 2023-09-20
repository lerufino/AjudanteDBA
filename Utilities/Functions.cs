using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NanoXLSX;

namespace AjudanteDBA.Utilities
{
    public static class Functions
    {
        public static void ExportToExcel()
        {
            string savePath = "Lista_De_Bancos_de_Dados.xlsx";

            Workbook wb = new Workbook(savePath, "Pasta1");
            wb.WS.Value("Nome do Banco");
            wb.WS.Value("Descritivo (Opcional)");

            if (File.Exists(savePath))
                File.Delete(savePath);

            wb.Save();
        }

        public static void ImportExcel()
        {
            string savePath = "Lista_De_Bancos_de_Dados.xlsx";


            var workbook = Workbook.Load(savePath);
            
            var worksheet = workbook.GetWorksheet(0);

            for (int col = 0; col < worksheet.GetLastColumnNumber(); col++)
            {
                for (int row = 0; row < worksheet.GetLastRowNumber(); row++) 
                    
                {
                    if (worksheet.GetCell(row, col)  != null)
                        MessageBox.Show(worksheet.GetCell(row, col)?.Value + "\t");
                }
                MessageBox.Show("Próxima Linha");
            }
            


        }
    }
}
