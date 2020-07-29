using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPiFindCEP.Models;

namespace WebAPiFindCEP.Services
{
    public class ExcelRead
    {
        public async static Task<string> ReadExcel(IFormFile excel)
        {
            //Get Directory and File
            //var diretory = Directory.GetCurrentDirectory();
            //FileInfo excel = new FileInfo(diretory + @"\Lista_de_CEPs.xlsx");
            FileInfo file = new FileInfo(excel.FileName);

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelCEPs ceps = new ExcelCEPs();
                StringBuilder sb = new StringBuilder();
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
                {
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        sb.Append(true);
                        ceps.cepIni = worksheet.Cells[row, 2].Value.ToString();
                        ceps.cepFim = worksheet.Cells[row, 3].Value.ToString();

                        //Declare variables Ini-Fim
                        var vcepIni = Convert.ToInt32(ceps.cepIni.Substring(4));
                        var vcepFim = Convert.ToInt32(ceps.cepFim.Substring(4));
                        var diff = (vcepFim - vcepIni);
                        int vcep = Convert.ToInt32(ceps.cepIni);

                        for (int x = 0; x <= diff; x++)
                        {
                            var respCorreios = await new FindCEP().BuscaCEP(vcep.ToString());

                            //Write in Excel
                            await new ExcelWrite2().WriteExcel(respCorreios);
                            vcep++;
                        }

                    }
                }

            }

            return null;
        }
    }
}
