using generateTries.Domain;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace generateTries.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = DataGenerator.PopulateSpeedResults(0);
            ExcelFileWriter.ExportToExcel(list);
            Console.WriteLine("check");
        }
    }
}
