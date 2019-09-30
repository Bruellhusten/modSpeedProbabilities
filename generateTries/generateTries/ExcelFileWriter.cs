using generateTries.Domain;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace generateTries.Application
{
    public class ExcelFileWriter
    {
        public static void ExportToExcel(List<SpeedResult> list)
        {

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                SetWorkbookProperties(excelPackage);
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Chances Per Speed");
                SetWorksheetHeaders(worksheet);
                FillWorsheetRows(list, worksheet);

                FileInfo fi = new FileInfo(@"C:\temp\modChances.xlsx");
                excelPackage.SaveAs(fi);
            }
        }

        private static void FillWorsheetRows(List<SpeedResult> list, ExcelWorksheet worksheet)
        {
            int row = 2;
            foreach (SpeedResult speedresult in list)
            {
                worksheet.Cells[row, 1].Value = speedresult.Speed;
                worksheet.Cells[row, 2].Value = speedresult.Probability;
                worksheet.Cells[row, 3].Value = speedresult.PossibleCombinations.Count;
                row++;
            }
        }

        private static void SetWorksheetHeaders(ExcelWorksheet worksheet)
        {
            worksheet.Cells[1, 1].Value = "Speed";
            worksheet.Cells[1, 2].Value = "Chances";
            worksheet.Cells[1, 3].Value = "PossibileCombinations";
        }

        private static void SetWorkbookProperties(ExcelPackage excelPackage)
        {
            excelPackage.Workbook.Properties.Author = "Bruellhusten";
            excelPackage.Workbook.Properties.Title = "Mod Speed Chances";
            excelPackage.Workbook.Properties.Subject = "Mod Speed Chances";
            excelPackage.Workbook.Properties.Created = DateTime.Now;
        }
    }
}
