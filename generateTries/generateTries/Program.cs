﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace generateTries
{
    class Program
    {
        public static List<SpeedResults> ResultList { get; set; }
        private const int TOP_SPEED = 29;
        private static readonly List<int> initialSpeeds = new List<int> { 3, 4, 5, };
        private static readonly List<int> slicingSpeeds = new List<int> { 0, 3, 4, 5, 6, };

        static void Main(string[] args)
        {
            var list = PopulateSpeedResults(0);
            ExportToExcel(list);
            Console.WriteLine("check");
        }

        private static void ExportToExcel(List<SpeedResults> list)
        {
            using(ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "Bruellhusten";
                excelPackage.Workbook.Properties.Title = "Mod Speed Chances";
                excelPackage.Workbook.Properties.Subject = "Mod Speed Chances";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                //Create the WorkSheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Chances Per Speed");

                int row = 2;

                worksheet.Cells[1, 1].Value = "Speed";
                worksheet.Cells[1, 2].Value = "Chances";
                worksheet.Cells[1, 3].Value = "PossibileCombinations";

                foreach (SpeedResults speedresult in list)
                {
                    worksheet.Cells[row, 1].Value = speedresult.Speed;
                    worksheet.Cells[row, 2].Value = speedresult.Probability;
                    worksheet.Cells[row, 3].Value = speedresult.PossibleCombinations.Count;
                    row++;
                }

                //Save your file
                FileInfo fi = new FileInfo(@"C:\temp\modChances.xlsx");
                excelPackage.SaveAs(fi);
            }



            //var table = new System.Data.DataTable();

            //table.Columns.Add("Speed", typeof(int));
            //table.Columns.Add("Chance", typeof(decimal));
            //table.Columns.Add("Number of Combinations", typeof(int));

            //var excel = new Microsoft.Office.Interop.Excel.Application();
            //excel.Visible = false;
            //excel.DisplayAlerts = false;
            //var workbook = excel.Workbooks.Add(Type.Missing);
            //var worksheet = (Microsoft.Office.Interop.Excel.Worksheet) workbook.ActiveSheet;
            //worksheet.Name = "mod Chances";
            //worksheet.Cells[1, 1] = "Mod Chances";
            

            ////foreach(SpeedResults speedresult in list)
            ////{
            ////    worksheet.Cells[row, 1] = speedresult.Speed;
            ////    worksheet.Cells[row, 2] = speedresult.Probability;
            ////    worksheet.Cells[row, 3] = speedresult.PossibleCombinations;
            ////    row++;
            ////}

            //workbook.SaveAs("modChances.xls");
            //workbook.Close();
            //excel.Quit();

        }

        private static List<SpeedResults> PopulateSpeedResults(int lowerBorder)
        {
            List<SpeedResults> results = new List<SpeedResults>();

            if (lowerBorder <= TOP_SPEED)
            {
                for (int i = TOP_SPEED; i >= lowerBorder; i-- )
                {
                    var possibleCombinations = GeneratePossibleCombinations(i);
                    results.Add(new SpeedResults
                    {
                        Speed = i,
                        PossibleCombinations = possibleCombinations,
                        Probability = possibleCombinations.Sum(x => x.Probability()),
                    });
                }
            }
            return results;
        }

        private static List<Combination> GeneratePossibleCombinations(int targetSpeed)
        {
            var combinations = new List<Combination>();
            combinations.AddRange(from int greySpeed in initialSpeeds
                                  from int greenIncrease in slicingSpeeds
                                  from int blueIncrease in slicingSpeeds
                                  from int purpleIncrease in slicingSpeeds
                                  from int goldIncreases in slicingSpeeds
                                  where greySpeed + greenIncrease + blueIncrease + purpleIncrease + goldIncreases == targetSpeed
                                  select new Combination
                                  {
                                      Init = new InitialSpeed(greySpeed),
                                      ToGreen = new SlicingIncrease(greenIncrease),
                                      ToBlue = new SlicingIncrease(blueIncrease),
                                      ToPurple = new SlicingIncrease(purpleIncrease),
                                      ToGold = new SlicingIncrease(goldIncreases),
                                  });
            return combinations;
        }
    }
}
