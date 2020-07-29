using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPiFindCEP.Models;

namespace WebAPiFindCEP.Services
{
    public class ExcelWrite2
    {
        public async Task<string> WriteExcel(ResponseCorreios respCorreios)
        {
            //Get Directory and File
            var diretory = Directory.GetCurrentDirectory();
            FileInfo excel = new FileInfo(diretory + @"\resultado.xlsx");

            using (ExcelPackage package = new ExcelPackage(excel))
            {
                StringBuilder sb = new StringBuilder();
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int row2 = (worksheet.Dimension.Rows) + 1;
                for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
                {
                    int row = (worksheet.Dimension.Rows) +1;
                }

                sb.AppendLine();

                worksheet.Cells[row2, 1].Value = respCorreios.cep;
                worksheet.Cells[row2, 2].Value = respCorreios.uf;
                worksheet.Cells[row2, 3].Value = respCorreios.cidade;
                worksheet.Cells[row2, 4].Value = respCorreios.bairro;
                worksheet.Cells[row2, 5].Value = respCorreios.complemento;
                worksheet.Cells[row2, 6].Value = respCorreios.logradouro;
                worksheet.Cells[row2, 7].Value = respCorreios.retorno;
                worksheet.Cells[row2, 8].Value = respCorreios.DataHora;
                //Write in Excel
                package.Save();

                return null;
            }
        }
    }
}
